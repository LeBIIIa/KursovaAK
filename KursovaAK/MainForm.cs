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
using Assembler;

namespace KursovaAK
{
    public partial class MainForm : Form
    {
        private bool ifSave;
        private string currFile;
        private string currWay;
        private string currName;
        private ISol sol;
        public MainForm()
        {
            InitializeComponent();
            GetPosition();
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
            try
            {
                File.WriteAllText(ConfigurationManager.AppSettings.Get("ErrorsFile"), string.Empty);
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
                var inFileName = currFile;
                var outFileName = currWay + "\\" + currName + ".mc";
                ReportText.AppendText("Compiling the project begins...\r\n");
                ReportText.AppendText("Input file of the project " + currName + ".as.\r\n");
                ReportText.AppendText("Begins search for errors...\r\n");
                bool isError = false;
                try
                {
                    sol = new ASol();
                    sol.Run(inFileName, outFileName);
                }
                catch (MessageException ex)
                {
                    isError = true;
                    File.WriteAllText(ConfigurationManager.AppSettings.Get("ErrorsFile"), ex.Message);
                }
                ErrorText.AppendText(File.ReadAllText(ConfigurationManager.AppSettings.Get("ErrorsFile")));
                if (!isError)
                {
                    ReportText.AppendText("No errors found.\r\n");
                    ReportText.AppendText("Compiling the project completed.\r\n");
                    ReportText.AppendText("Now you can start the program to perform.\r\n");
                    RunToolStripMenuItem.Enabled = true;
                }
                else
                {
                    tabControl.SelectedIndex = tabControl.TabPages.IndexOfKey("ErrorTab");
                    ReportText.AppendText("See error tab.\r\n");
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
                tabControl.SelectedIndex = tabControl.TabPages.IndexOfKey("ErrorTab");
                ErrorText.AppendText("See Error.log");
                MessageBox.Show("Ой...щось пішло не так, глянь Error.log", "НЛО", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportText.Clear();
            ErrorText.Clear();
            OutputText.Clear();
            try
            {
                File.WriteAllText(ConfigurationManager.AppSettings.Get("ErrorsFile"), string.Empty);
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
                var inFileName = Path.ChangeExtension(currFile, ".mc");
                var outFileName = currWay + "\\" + currName + ".mc_report";
                ReportText.AppendText("Running the project begins...\r\n");
                ReportText.AppendText("Input file of the project " + currName + ".mc.\r\n");
                ReportText.AppendText("Begins search for errors...\r\n");
                bool isError = false;
                try
                {
                    sol = new SSol();
                    sol.Run(inFileName, outFileName);
                }
                catch (MessageException ex)
                {
                    isError = true;
                    File.WriteAllText(ConfigurationManager.AppSettings.Get("ErrorsFile"), ex.Message);
                }
                ErrorText.AppendText(File.ReadAllText(ConfigurationManager.AppSettings.Get("ErrorsFile")));
                if (!isError)
                {
                    tabControl.SelectedIndex = tabControl.TabPages.IndexOfKey("OutputTab");
                    OutputText.AppendText(File.ReadAllText(outFileName));
                    ReportText.AppendText("No errors found.\r\n");
                    ReportText.AppendText("Finish running.");
                }
                else
                {
                    tabControl.SelectedIndex = tabControl.TabPages.IndexOfKey("ErrorTab");
                    ReportText.AppendText("See error tab.\r\n");
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message + " " + ex.StackTrace);
                MessageBox.Show("Ой...щось пішло не так, глянь Error.log", "НЛО", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Code_TextChanged(object sender, EventArgs e)
        {
            RunToolStripMenuItem.Enabled = false;
            ifSave = false;
        }

    }
}
