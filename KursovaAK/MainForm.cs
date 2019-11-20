using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;

namespace KursovaSP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            GetPosition();
            //RichEdit1->Paragraph->FirstIndent = 5;
            //RichEdit1->Paragraph->RightIndent = 4;
            openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            ifSave = false;
            currFile = string.Empty;
            Logger.InitLogger();
            RunToolStripMenuItem.Enabled = false;
        }

        private void GetPosition()
        {
            // Get the line.
            int index = Code.SelectionStart;
            int line = Code.GetLineFromCharIndex(index);

            // Get the column.
            int firstChar = Code.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            statusStrip.Items[0].Text = $"Ряд: { line + 1 } Сто: {column + 1}";
        }

        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            GetPosition();
        }

        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            GetPosition();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currFile = openFileDialog.FileName;
                    Code.Text = File.ReadAllText(currFile);
                    currWay = Path.GetDirectoryName(currFile);
                    currName = Path.GetFileNameWithoutExtension(currFile);
                    ifSave = true;
                    RunToolStripMenuItem.Enabled = false;
                };
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                if (string.IsNullOrEmpty(currFile))
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currFile = saveFileDialog.FileName;
                        Save();
                        currWay = Path.GetDirectoryName(currFile);
                        currName = Path.GetFileNameWithoutExtension(currFile);
                    }
                }
                else
                {
                    Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currFile = saveFileDialog.FileName;
                    Save();
                    currWay = Path.GetDirectoryName(currFile);
                    currName = Path.GetFileNameWithoutExtension(currFile);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Save()
        {
            ifSave = true;
            File.WriteAllText(currFile, Code.Text);
        }

        private void CompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportText.Clear();
            ErrorText.Clear();
            Datas.Clear();
            try
            {
                way = Application.StartupPath;
                if (string.IsNullOrEmpty(currFile))
                {
                    MessageBox.Show("Save file before compiling");
                    return;
                }
                if (!ifSave)
                {
                    Save();
                }
                tabControl.SelectedIndex = tabControl.TabPages.IndexOfKey("ReportTab");
                // Отримання і формування мен ввхідних та вихідних файлів
                inFileName = currFile;
                outFileName = currWay + "\\" + currName + ".asm";
                ReportText.AppendText("Compiling the project begins...\r\n");
                ReportText.AppendText("Input file of the project " + currName + ".l69.\r\n");
                using (fin = new StreamReader(inFileName))
                {
                    // Розбиття на лексеми і друк у файл
                    AnalisisTokens(fin);
                }
                ReportText.AppendText("Begins search for tokens...\r\n");
                ReportText.AppendText("Find " + TokensTable.Count + " tokens.\r\n");
                PrintTokensInFile();
                TokensGrid.DataSource = Datas;
                nNumberErrors = ErrorChecking();
                ReportText.AppendText("Begins search for errors...\r\n");
                ErrorText.AppendText(File.ReadAllText(ConfigurationManager.AppSettings.Get("ErrorsFile")));
                // Якшо немає помилок, перейти до трансляції коду
                if (nNumberErrors != 0)
                {
                    ReportText.AppendText("Find " + nNumberErrors + " errors.\r\n");
                }
                else
                {
                    ReportText.AppendText("No errors found.\r\n");
                    using (fout = new StreamWriter(outFileName))
                    {
                        ReportText.AppendText("ASM file " + currName + ".asm successfully created.\r\n");
                        Generator.GenerateCode(fout);
                    }
                    string obj, exe, asmf, cop, tmp;
                    obj = currName + ".obj";
                    exe = currName + ".exe";
                    asmf = currName + ".asm";
                    cop = way + "\\" + asmf;
                    ReportText.AppendText("Compiling the " + asmf + " with tasm32.exe ...\r\n");
                    if (File.Exists(cop))
                    {
                        File.Delete(cop);
                    }
                    File.Copy(outFileName, cop);
                    ReportText.AppendText("Linking the " + obj + " with tlink32.exe ...\r\n");
                    if (RunCmd(asmf) == 0)
                    {
                        tmp = currWay + "\\" + currName + ".map";
                        cop = way + "\\" + currName + ".map";
                        File.Copy(cop, tmp, false);
                        tmp = currWay + "\\" + obj;
                        cop = way + "\\" + obj;
                        File.Copy(cop, tmp, false);
                        tmp = currWay + "\\" + exe;
                        cop = way + "\\" + exe;
                        Thread.Sleep(200);
                        File.Copy(cop, tmp, false);
                        ReportText.AppendText("Compiling the project completed.\r\n");
                        ReportText.AppendText("Now you can start the program to perform.\r\n");
                    }
                    else
                    {
                        ReportText.AppendText("Something happened! See error tab.\r\n");
                    }
                    RunToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
            }
        }

        private int RunCmd(string asmf)
        {
            FileStream f = null;
            try
            {
                f = File.Create("run.cmd");
                using (var batFile = new StreamWriter(f))
                {
                    f = null;
                    batFile.Write("@echo off\n");
                    batFile.Write($"@ml /c /coff {asmf}\n");
                    batFile.Write($"@link /subsystem:console {asmf}\n");
                }
            }
            finally
            {
                f?.Dispose();
            }
            var processInfo = new ProcessStartInfo("run.cmd")
            {
                StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            var process = Process.Start(processInfo);

            var output = new Action<string>(s =>
            {
                ReportText.AppendText(s);
            });
            var errorOut = new Action<string>(s =>
            {
                ErrorText.AppendText(s);
            });

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                ReportText.BeginInvoke(output, e.Data + "\r\n");
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                ErrorText.BeginInvoke(errorOut, e.Data + "\r\n");
            process.BeginErrorReadLine();

            process.WaitForExit();

            int ret = process.ExitCode;
            process.Close();
            return ret;
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var exe = currWay + "\\" + currName + ".exe";
                Process.Start(exe);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Code_TextChanged(object sender, EventArgs e)
        {
            ifSave = false;
        }

        private void TokensGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }
    }
}
