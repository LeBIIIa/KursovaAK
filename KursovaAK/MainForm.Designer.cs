﻿namespace KursovaSP
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
            this.TokensTab = new System.Windows.Forms.TabPage();
            this.TokensGrid = new System.Windows.Forms.DataGridView();
            this.ErrorTab = new System.Windows.Forms.TabPage();
            this.ErrorText = new System.Windows.Forms.TextBox();
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
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ReportTab.SuspendLayout();
            this.TokensTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TokensGrid)).BeginInit();
            this.ErrorTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 660);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1200, 32);
            this.statusStrip.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(1177, 25);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "toolStripStatusLabel1";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Code, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
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
            this.Code.Size = new System.Drawing.Size(1192, 428);
            this.Code.TabIndex = 0;
            this.Code.Text = "";
            this.Code.TextChanged += new System.EventHandler(this.Code_TextChanged);
            this.Code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
            this.Code.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseDown);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ReportTab);
            this.tabControl.Controls.Add(this.TokensTab);
            this.tabControl.Controls.Add(this.ErrorTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(4, 443);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1192, 179);
            this.tabControl.TabIndex = 1;
            // 
            // ReportTab
            // 
            this.ReportTab.Controls.Add(this.ReportText);
            this.ReportTab.Location = new System.Drawing.Point(4, 29);
            this.ReportTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReportTab.Name = "ReportTab";
            this.ReportTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReportTab.Size = new System.Drawing.Size(1184, 146);
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
            this.ReportText.Size = new System.Drawing.Size(1176, 136);
            this.ReportText.TabIndex = 0;
            // 
            // TokensTab
            // 
            this.TokensTab.Controls.Add(this.TokensGrid);
            this.TokensTab.Location = new System.Drawing.Point(4, 29);
            this.TokensTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TokensTab.Name = "TokensTab";
            this.TokensTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TokensTab.Size = new System.Drawing.Size(1184, 146);
            this.TokensTab.TabIndex = 1;
            this.TokensTab.Text = "Список лексем";
            this.TokensTab.UseVisualStyleBackColor = true;
            // 
            // TokensGrid
            // 
            this.TokensGrid.AllowUserToAddRows = false;
            this.TokensGrid.AllowUserToDeleteRows = false;
            this.TokensGrid.AllowUserToResizeColumns = false;
            this.TokensGrid.AllowUserToResizeRows = false;
            this.TokensGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TokensGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TokensGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TokensGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TokensGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TokensGrid.Location = new System.Drawing.Point(4, 5);
            this.TokensGrid.MultiSelect = false;
            this.TokensGrid.Name = "TokensGrid";
            this.TokensGrid.ReadOnly = true;
            this.TokensGrid.RowHeadersWidth = 62;
            this.TokensGrid.RowTemplate.Height = 28;
            this.TokensGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TokensGrid.Size = new System.Drawing.Size(1176, 136);
            this.TokensGrid.TabIndex = 1;
            this.TokensGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TokensGrid_DataBindingComplete);
            // 
            // ErrorTab
            // 
            this.ErrorTab.Controls.Add(this.ErrorText);
            this.ErrorTab.Location = new System.Drawing.Point(4, 29);
            this.ErrorTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ErrorTab.Name = "ErrorTab";
            this.ErrorTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ErrorTab.Size = new System.Drawing.Size(1184, 146);
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
            this.ErrorText.Size = new System.Drawing.Size(1176, 136);
            this.ErrorText.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CreatePrompt = true;
            this.saveFileDialog.DefaultExt = "s77";
            this.saveFileDialog.FileName = "new";
            this.saveFileDialog.Filter = "Compilator s77|*.s77";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Зберегти файл програми";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "s77";
            this.openFileDialog.Filter = "Compilator s77|*.s77";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Відкрити файл програми";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.проектToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
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
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(382, 34);
            this.openFileToolStripMenuItem.Text = "Відкрити файл програми";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
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
            this.проектToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
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
            this.Text = "Compilator s77";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ReportTab.ResumeLayout(false);
            this.ReportTab.PerformLayout();
            this.TokensTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TokensGrid)).EndInit();
            this.ErrorTab.ResumeLayout(false);
            this.ErrorTab.PerformLayout();
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
        private System.Windows.Forms.TabPage TokensTab;
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
        private System.Windows.Forms.DataGridView TokensGrid;
    }
}
