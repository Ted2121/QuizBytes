namespace ByteManager.WinFormsUI
{
    partial class Questions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Questions));
            this.lineSeparator = new System.Windows.Forms.Label();
            this.webusersNavigationButton = new System.Windows.Forms.Button();
            this.questionsNavigationButton = new System.Windows.Forms.Button();
            this.chaptersNavigationButton = new System.Windows.Forms.Button();
            this.dashboardNavigationButton = new System.Windows.Forms.Button();
            this.singleAnswerDataGrid = new System.Windows.Forms.DataGridView();
            this.questionsIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapterNameLabel = new System.Windows.Forms.Label();
            this.questionTypeLabel = new System.Windows.Forms.Label();
            this.questionTextLabel = new System.Windows.Forms.Label();
            this.correctAnswerLabel = new System.Windows.Forms.Label();
            this.wrongAnswerOneLabel = new System.Windows.Forms.Label();
            this.wrongAnswerTwoLabel = new System.Windows.Forms.Label();
            this.wrongAnswerThreeLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.wrongAnswerThreeTextBox = new System.Windows.Forms.TextBox();
            this.wonrgAnswerTwoTextBox = new System.Windows.Forms.TextBox();
            this.wrongAnswerOneTextBox = new System.Windows.Forms.TextBox();
            this.correctAnswerTextBox = new System.Windows.Forms.TextBox();
            this.questionTextTextBox = new System.Windows.Forms.TextBox();
            this.questionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.chapterNameCombobox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.questionEditButton = new System.Windows.Forms.PictureBox();
            this.questionConfirmButton = new System.Windows.Forms.PictureBox();
            this.questionCancelButton = new System.Windows.Forms.PictureBox();
            this.questionDeleteButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.singleAnswerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionEditButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionConfirmButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionDeleteButton)).BeginInit();
            this.SuspendLayout();
            // 
            // lineSeparator
            // 
            this.lineSeparator.BackColor = System.Drawing.Color.White;
            this.lineSeparator.Location = new System.Drawing.Point(315, 40);
            this.lineSeparator.Name = "lineSeparator";
            this.lineSeparator.Size = new System.Drawing.Size(1, 960);
            this.lineSeparator.TabIndex = 9;
            // 
            // webusersNavigationButton
            // 
            this.webusersNavigationButton.AccessibleName = "";
            this.webusersNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.webusersNavigationButton.AutoSize = true;
            this.webusersNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webusersNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.webusersNavigationButton.ForeColor = System.Drawing.Color.White;
            this.webusersNavigationButton.Location = new System.Drawing.Point(40, 317);
            this.webusersNavigationButton.Name = "webusersNavigationButton";
            this.webusersNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.webusersNavigationButton.TabIndex = 8;
            this.webusersNavigationButton.Text = "Web Users";
            this.webusersNavigationButton.UseVisualStyleBackColor = true;
            // 
            // questionsNavigationButton
            // 
            this.questionsNavigationButton.AccessibleName = "";
            this.questionsNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.questionsNavigationButton.AutoSize = true;
            this.questionsNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionsNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionsNavigationButton.ForeColor = System.Drawing.Color.White;
            this.questionsNavigationButton.Location = new System.Drawing.Point(40, 238);
            this.questionsNavigationButton.Name = "questionsNavigationButton";
            this.questionsNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.questionsNavigationButton.TabIndex = 7;
            this.questionsNavigationButton.Text = "> Questions";
            this.questionsNavigationButton.UseVisualStyleBackColor = true;
            // 
            // chaptersNavigationButton
            // 
            this.chaptersNavigationButton.AccessibleName = "";
            this.chaptersNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chaptersNavigationButton.AutoSize = true;
            this.chaptersNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chaptersNavigationButton.ForeColor = System.Drawing.Color.White;
            this.chaptersNavigationButton.Location = new System.Drawing.Point(40, 159);
            this.chaptersNavigationButton.Name = "chaptersNavigationButton";
            this.chaptersNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.chaptersNavigationButton.TabIndex = 6;
            this.chaptersNavigationButton.Text = "Chapters";
            this.chaptersNavigationButton.UseVisualStyleBackColor = true;
            // 
            // dashboardNavigationButton
            // 
            this.dashboardNavigationButton.AccessibleName = "";
            this.dashboardNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dashboardNavigationButton.AutoSize = true;
            this.dashboardNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardNavigationButton.ForeColor = System.Drawing.Color.White;
            this.dashboardNavigationButton.Location = new System.Drawing.Point(40, 80);
            this.dashboardNavigationButton.Name = "dashboardNavigationButton";
            this.dashboardNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.dashboardNavigationButton.TabIndex = 5;
            this.dashboardNavigationButton.Text = "Dashboard";
            this.dashboardNavigationButton.UseVisualStyleBackColor = true;
            // 
            // singleAnswerDataGrid
            // 
            this.singleAnswerDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.singleAnswerDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.singleAnswerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.singleAnswerDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.questionsIndex,
            this.chapterName,
            this.questionText});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.singleAnswerDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.singleAnswerDataGrid.EnableHeadersVisualStyles = false;
            this.singleAnswerDataGrid.GridColor = System.Drawing.Color.White;
            this.singleAnswerDataGrid.Location = new System.Drawing.Point(375, 80);
            this.singleAnswerDataGrid.Name = "singleAnswerDataGrid";
            this.singleAnswerDataGrid.RowHeadersVisible = false;
            this.singleAnswerDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.singleAnswerDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.singleAnswerDataGrid.RowTemplate.Height = 25;
            this.singleAnswerDataGrid.Size = new System.Drawing.Size(1450, 400);
            this.singleAnswerDataGrid.TabIndex = 10;
            // 
            // questionsIndex
            // 
            this.questionsIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.questionsIndex.HeaderText = "No.";
            this.questionsIndex.MinimumWidth = 81;
            this.questionsIndex.Name = "questionsIndex";
            this.questionsIndex.Width = 90;
            // 
            // chapterName
            // 
            this.chapterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chapterName.HeaderText = "Chapter Name";
            this.chapterName.MinimumWidth = 200;
            this.chapterName.Name = "chapterName";
            this.chapterName.Width = 300;
            // 
            // questionText
            // 
            this.questionText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.questionText.HeaderText = "Question Text";
            this.questionText.MinimumWidth = 694;
            this.questionText.Name = "questionText";
            // 
            // chapterNameLabel
            // 
            this.chapterNameLabel.AutoSize = true;
            this.chapterNameLabel.Location = new System.Drawing.Point(10, 10);
            this.chapterNameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.chapterNameLabel.Name = "chapterNameLabel";
            this.chapterNameLabel.Size = new System.Drawing.Size(194, 37);
            this.chapterNameLabel.TabIndex = 11;
            this.chapterNameLabel.Text = "Chapter Name";
            this.chapterNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // questionTypeLabel
            // 
            this.questionTypeLabel.AutoSize = true;
            this.questionTypeLabel.Location = new System.Drawing.Point(10, 50);
            this.questionTypeLabel.Margin = new System.Windows.Forms.Padding(5);
            this.questionTypeLabel.Name = "questionTypeLabel";
            this.questionTypeLabel.Size = new System.Drawing.Size(193, 37);
            this.questionTypeLabel.TabIndex = 12;
            this.questionTypeLabel.Text = "Question Type";
            this.questionTypeLabel.Click += new System.EventHandler(this.questionTypeLabel_Click);
            // 
            // questionTextLabel
            // 
            this.questionTextLabel.AutoSize = true;
            this.questionTextLabel.Location = new System.Drawing.Point(10, 90);
            this.questionTextLabel.Margin = new System.Windows.Forms.Padding(5);
            this.questionTextLabel.Name = "questionTextLabel";
            this.questionTextLabel.Size = new System.Drawing.Size(185, 37);
            this.questionTextLabel.TabIndex = 13;
            this.questionTextLabel.Text = "Question Text";
            // 
            // correctAnswerLabel
            // 
            this.correctAnswerLabel.AutoSize = true;
            this.correctAnswerLabel.Location = new System.Drawing.Point(10, 130);
            this.correctAnswerLabel.Margin = new System.Windows.Forms.Padding(5);
            this.correctAnswerLabel.Name = "correctAnswerLabel";
            this.correctAnswerLabel.Size = new System.Drawing.Size(204, 37);
            this.correctAnswerLabel.TabIndex = 14;
            this.correctAnswerLabel.Text = "Correct Answer";
            // 
            // wrongAnswerOneLabel
            // 
            this.wrongAnswerOneLabel.AutoSize = true;
            this.wrongAnswerOneLabel.Location = new System.Drawing.Point(10, 170);
            this.wrongAnswerOneLabel.Margin = new System.Windows.Forms.Padding(5);
            this.wrongAnswerOneLabel.Name = "wrongAnswerOneLabel";
            this.wrongAnswerOneLabel.Size = new System.Drawing.Size(216, 37);
            this.wrongAnswerOneLabel.TabIndex = 15;
            this.wrongAnswerOneLabel.Text = "Wrong Answer 1";
            // 
            // wrongAnswerTwoLabel
            // 
            this.wrongAnswerTwoLabel.AutoSize = true;
            this.wrongAnswerTwoLabel.Location = new System.Drawing.Point(10, 210);
            this.wrongAnswerTwoLabel.Margin = new System.Windows.Forms.Padding(5);
            this.wrongAnswerTwoLabel.Name = "wrongAnswerTwoLabel";
            this.wrongAnswerTwoLabel.Size = new System.Drawing.Size(220, 37);
            this.wrongAnswerTwoLabel.TabIndex = 16;
            this.wrongAnswerTwoLabel.Text = "Wrong Answer 2";
            // 
            // wrongAnswerThreeLabel
            // 
            this.wrongAnswerThreeLabel.AutoSize = true;
            this.wrongAnswerThreeLabel.Location = new System.Drawing.Point(10, 250);
            this.wrongAnswerThreeLabel.Margin = new System.Windows.Forms.Padding(5);
            this.wrongAnswerThreeLabel.Name = "wrongAnswerThreeLabel";
            this.wrongAnswerThreeLabel.Size = new System.Drawing.Size(220, 37);
            this.wrongAnswerThreeLabel.TabIndex = 17;
            this.wrongAnswerThreeLabel.Text = "Wrong Answer 3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(375, 538);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.wrongAnswerTwoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.chapterNameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.wrongAnswerThreeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.questionTypeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.questionTextLabel);
            this.splitContainer1.Panel1.Controls.Add(this.wrongAnswerOneLabel);
            this.splitContainer1.Panel1.Controls.Add(this.correctAnswerLabel);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(20);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wrongAnswerThreeTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.wonrgAnswerTwoTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.wrongAnswerOneTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.correctAnswerTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.questionTextTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.questionTypeComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.chapterNameCombobox);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1334, 292);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 18;
            // 
            // wrongAnswerThreeTextBox
            // 
            this.wrongAnswerThreeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wrongAnswerThreeTextBox.Location = new System.Drawing.Point(12, 247);
            this.wrongAnswerThreeTextBox.Name = "wrongAnswerThreeTextBox";
            this.wrongAnswerThreeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wrongAnswerThreeTextBox.Size = new System.Drawing.Size(1000, 39);
            this.wrongAnswerThreeTextBox.TabIndex = 6;
            // 
            // wonrgAnswerTwoTextBox
            // 
            this.wonrgAnswerTwoTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wonrgAnswerTwoTextBox.Location = new System.Drawing.Point(12, 207);
            this.wonrgAnswerTwoTextBox.Name = "wonrgAnswerTwoTextBox";
            this.wonrgAnswerTwoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wonrgAnswerTwoTextBox.Size = new System.Drawing.Size(1000, 39);
            this.wonrgAnswerTwoTextBox.TabIndex = 5;
            // 
            // wrongAnswerOneTextBox
            // 
            this.wrongAnswerOneTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wrongAnswerOneTextBox.Location = new System.Drawing.Point(12, 168);
            this.wrongAnswerOneTextBox.Name = "wrongAnswerOneTextBox";
            this.wrongAnswerOneTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wrongAnswerOneTextBox.Size = new System.Drawing.Size(1000, 39);
            this.wrongAnswerOneTextBox.TabIndex = 4;
            // 
            // correctAnswerTextBox
            // 
            this.correctAnswerTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.correctAnswerTextBox.Location = new System.Drawing.Point(12, 129);
            this.correctAnswerTextBox.Name = "correctAnswerTextBox";
            this.correctAnswerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.correctAnswerTextBox.Size = new System.Drawing.Size(1000, 39);
            this.correctAnswerTextBox.TabIndex = 3;
            // 
            // questionTextTextBox
            // 
            this.questionTextTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.questionTextTextBox.Location = new System.Drawing.Point(12, 90);
            this.questionTextTextBox.Name = "questionTextTextBox";
            this.questionTextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.questionTextTextBox.Size = new System.Drawing.Size(1000, 39);
            this.questionTextTextBox.TabIndex = 2;
            // 
            // questionTypeComboBox
            // 
            this.questionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionTypeComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.questionTypeComboBox.ForeColor = System.Drawing.Color.Black;
            this.questionTypeComboBox.FormattingEnabled = true;
            this.questionTypeComboBox.Location = new System.Drawing.Point(12, 51);
            this.questionTypeComboBox.MaxDropDownItems = 10;
            this.questionTypeComboBox.Name = "questionTypeComboBox";
            this.questionTypeComboBox.Size = new System.Drawing.Size(250, 40);
            this.questionTypeComboBox.TabIndex = 1;
            // 
            // chapterNameCombobox
            // 
            this.chapterNameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chapterNameCombobox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chapterNameCombobox.ForeColor = System.Drawing.Color.Black;
            this.chapterNameCombobox.FormattingEnabled = true;
            this.chapterNameCombobox.Location = new System.Drawing.Point(12, 11);
            this.chapterNameCombobox.MaxDropDownItems = 10;
            this.chapterNameCombobox.Name = "chapterNameCombobox";
            this.chapterNameCombobox.Size = new System.Drawing.Size(250, 40);
            this.chapterNameCombobox.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.questionEditButton);
            this.flowLayoutPanel1.Controls.Add(this.questionConfirmButton);
            this.flowLayoutPanel1.Controls.Add(this.questionCancelButton);
            this.flowLayoutPanel1.Controls.Add(this.questionDeleteButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1737, 538);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(88, 292);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // questionEditButton
            // 
            this.questionEditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionEditButton.Location = new System.Drawing.Point(13, 23);
            this.questionEditButton.Name = "questionEditButton";
            this.questionEditButton.Size = new System.Drawing.Size(60, 60);
            this.questionEditButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionEditButton.TabIndex = 20;
            this.questionEditButton.TabStop = false;
            // 
            // questionConfirmButton
            // 
            this.questionConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionConfirmButton.Location = new System.Drawing.Point(13, 89);
            this.questionConfirmButton.Name = "questionConfirmButton";
            this.questionConfirmButton.Size = new System.Drawing.Size(60, 60);
            this.questionConfirmButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionConfirmButton.TabIndex = 21;
            this.questionConfirmButton.TabStop = false;
            // 
            // questionCancelButton
            // 
            this.questionCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionCancelButton.Location = new System.Drawing.Point(13, 155);
            this.questionCancelButton.Name = "questionCancelButton";
            this.questionCancelButton.Size = new System.Drawing.Size(60, 60);
            this.questionCancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionCancelButton.TabIndex = 22;
            this.questionCancelButton.TabStop = false;
            // 
            // questionDeleteButton
            // 
            this.questionDeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionDeleteButton.Location = new System.Drawing.Point(13, 221);
            this.questionDeleteButton.Name = "questionDeleteButton";
            this.questionDeleteButton.Size = new System.Drawing.Size(60, 60);
            this.questionDeleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionDeleteButton.TabIndex = 23;
            this.questionDeleteButton.TabStop = false;
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.singleAnswerDataGrid);
            this.Controls.Add(this.lineSeparator);
            this.Controls.Add(this.webusersNavigationButton);
            this.Controls.Add(this.questionsNavigationButton);
            this.Controls.Add(this.chaptersNavigationButton);
            this.Controls.Add(this.dashboardNavigationButton);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Questions";
            this.Text = "ByteManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.singleAnswerDataGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionEditButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionConfirmButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionDeleteButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lineSeparator;
        private Button webusersNavigationButton;
        private Button questionsNavigationButton;
        private Button chaptersNavigationButton;
        private Button dashboardNavigationButton;
        private DataGridView singleAnswerDataGrid;
        private Label chapterNameLabel;
        private Label questionTypeLabel;
        private Label questionTextLabel;
        private Label correctAnswerLabel;
        private Label wrongAnswerOneLabel;
        private Label wrongAnswerTwoLabel;
        private DataGridViewTextBoxColumn questionsIndex;
        private DataGridViewTextBoxColumn chapterName;
        private DataGridViewTextBoxColumn questionText;
        private Label wrongAnswerThreeLabel;
        private SplitContainer splitContainer1;
        private ComboBox chapterNameCombobox;
        private TextBox wrongAnswerThreeTextBox;
        private TextBox wonrgAnswerTwoTextBox;
        private TextBox wrongAnswerOneTextBox;
        private TextBox correctAnswerTextBox;
        private TextBox questionTextTextBox;
        private ComboBox questionTypeComboBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox questionEditButton;
        private PictureBox questionConfirmButton;
        private PictureBox questionCancelButton;
        private PictureBox questionDeleteButton;
    }
}