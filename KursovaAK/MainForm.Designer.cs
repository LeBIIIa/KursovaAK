namespace KursovaAK
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Code = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ReportTab = new System.Windows.Forms.TabPage();
            this.ReportText = new System.Windows.Forms.TextBox();
            this.ErrorTab = new System.Windows.Forms.TabPage();
            this.ErrorText = new System.Windows.Forms.TextBox();
            this.OutputTab = new System.Windows.Forms.TabPage();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ReportTab.SuspendLayout();
            this.ErrorTab.SuspendLayout();
            this.OutputTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 663);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1200, 29);
            this.statusStrip.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(1177, 22);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "toolStripStatusLabel1";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Code, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 627);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Code
            // 
            this.Code.AcceptsTab = true;
            this.Code.AutoWordSelection = true;
            this.Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Code.BulletIndent = 4;
            this.Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Code.Location = new System.Drawing.Point(4, 5);
            this.Code.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(592, 617);
            this.Code.TabIndex = 0;
            this.Code.Text = "";
            this.Code.TextChanged += new System.EventHandler(this.Code_TextChanged);
            this.Code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichTextBox_KeyUp);
            this.Code.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RichTextBox_MouseDown);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ReportTab);
            this.tabControl.Controls.Add(this.ErrorTab);
            this.tabControl.Controls.Add(this.OutputTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(604, 5);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(592, 617);
            this.tabControl.TabIndex = 1;
            // 
            // ReportTab
            // 
            this.ReportTab.Controls.Add(this.ReportText);
            this.ReportTab.Location = new System.Drawing.Point(4, 29);
            this.ReportTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReportTab.Name = "ReportTab";
            this.ReportTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReportTab.Size = new System.Drawing.Size(584, 584);
            this.ReportTab.TabIndex = 0;
            this.ReportTab.Text = "Звіт по проекту";
            this.ReportTab.UseVisualStyleBackColor = true;
            // 
            // ReportText
            // 
            this.ReportText.AcceptsReturn = true;
            this.ReportText.AcceptsTab = true;
            this.ReportText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportText.Location = new System.Drawing.Point(4, 5);
            this.ReportText.Multiline = true;
            this.ReportText.Name = "ReportText";
            this.ReportText.ReadOnly = true;
            this.ReportText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReportText.Size = new System.Drawing.Size(576, 574);
            this.ReportText.TabIndex = 0;
            // 
            // ErrorTab
            // 
            this.ErrorTab.Controls.Add(this.ErrorText);
            this.ErrorTab.Location = new System.Drawing.Point(4, 29);
            this.ErrorTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ErrorTab.Name = "ErrorTab";
            this.ErrorTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ErrorTab.Size = new System.Drawing.Size(584, 584);
            this.ErrorTab.TabIndex = 2;
            this.ErrorTab.Text = "Список помилок";
            this.ErrorTab.UseVisualStyleBackColor = true;
            // 
            // ErrorText
            // 
            this.ErrorText.AcceptsReturn = true;
            this.ErrorText.AcceptsTab = true;
            this.ErrorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorText.Location = new System.Drawing.Point(4, 5);
            this.ErrorText.Multiline = true;
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.ReadOnly = true;
            this.ErrorText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorText.Size = new System.Drawing.Size(576, 574);
            this.ErrorText.TabIndex = 0;
            // 
            // OutputTab
            // 
            this.OutputTab.Controls.Add(this.OutputText);
            this.OutputTab.Location = new System.Drawing.Point(4, 29);
            this.OutputTab.Name = "OutputTab";
            this.OutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.OutputTab.Size = new System.Drawing.Size(584, 584);
            this.OutputTab.TabIndex = 3;
            this.OutputTab.Text = "Вивід";
            this.OutputTab.UseVisualStyleBackColor = true;
            // 
            // OutputText
            // 
            this.OutputText.AcceptsReturn = true;
            this.OutputText.AcceptsTab = true;
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Location = new System.Drawing.Point(3, 3);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputText.Size = new System.Drawing.Size(578, 578);
            this.OutputText.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CreatePrompt = true;
            this.saveFileDialog.DefaultExt = "as";
            this.saveFileDialog.FileName = "new";
            this.saveFileDialog.Filter = "Program|*.as";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Зберегти файл програми";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "as";
            this.openFileDialog.Filter = "Program|*.as";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Відкрити файл програми";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.проектToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 36);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 30);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(382, 34);
            this.openFileToolStripMenuItem.Text = "Відкрити файл програми";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(382, 34);
            this.SaveToolStripMenuItem.Text = "Зберегти файл програми";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(382, 34);
            this.SaveAsToolStripMenuItem.Text = "Зберегти файл програми ...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // проектToolStripMenuItem
            // 
            this.проектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompileToolStripMenuItem,
            this.RunToolStripMenuItem});
            this.проектToolStripMenuItem.Name = "проектToolStripMenuItem";
            this.проектToolStripMenuItem.Size = new System.Drawing.Size(88, 30);
            this.проектToolStripMenuItem.Text = "Проект";
            // 
            // CompileToolStripMenuItem
            // 
            this.CompileToolStripMenuItem.Name = "CompileToolStripMenuItem";
            this.CompileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.CompileToolStripMenuItem.Size = new System.Drawing.Size(321, 34);
            this.CompileToolStripMenuItem.Text = "Скомпілювати";
            this.CompileToolStripMenuItem.Click += new System.EventHandler(this.CompileToolStripMenuItem_Click);
            // 
            // RunToolStripMenuItem
            // 
            this.RunToolStripMenuItem.Name = "RunToolStripMenuItem";
            this.RunToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.RunToolStripMenuItem.Size = new System.Drawing.Size(321, 34);
            this.RunToolStripMenuItem.Text = "Запустити програму";
            this.RunToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 30);
            this.aboutToolStripMenuItem.Text = "Про автора";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Kursova AK";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ReportTab.ResumeLayout(false);
            this.ReportTab.PerformLayout();
            this.ErrorTab.ResumeLayout(false);
            this.ErrorTab.PerformLayout();
            this.OutputTab.ResumeLayout(false);
            this.OutputTab.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox Code;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ReportTab;
        private System.Windows.Forms.TabPage ErrorTab;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox ReportText;
        private System.Windows.Forms.TextBox ErrorText;
        private System.Windows.Forms.TabPage OutputTab;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

