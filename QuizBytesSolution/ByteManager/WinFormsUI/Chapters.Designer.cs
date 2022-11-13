﻿namespace ByteManager.WinFormsUI
{
    partial class Chapters
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

        private Button dashboardNavigationButton;
        private Button chaptersNavigationButton;
        private Button questionsNavigationButton;
        private Button webusersNavigationButton;
        private Label lineSeparator;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chapters));
            this.dashboardNavigationButton = new System.Windows.Forms.Button();
            this.chaptersNavigationButton = new System.Windows.Forms.Button();
            this.questionsNavigationButton = new System.Windows.Forms.Button();
            this.webusersNavigationButton = new System.Windows.Forms.Button();
            this.lineSeparator = new System.Windows.Forms.Label();
            this.topicChaptersDataGrid = new System.Windows.Forms.DataGridView();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horizontalLineSeparator = new System.Windows.Forms.Label();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.chapterNameTextBox = new System.Windows.Forms.TextBox();
            this.chapterNameLabel = new System.Windows.Forms.Label();
            this.courseLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chaptersEditButton = new System.Windows.Forms.PictureBox();
            this.chaptersConfirmButton = new System.Windows.Forms.PictureBox();
            this.chaptersCancelButton = new System.Windows.Forms.PictureBox();
            this.chaptersDeleteButton = new System.Windows.Forms.PictureBox();
            this.chapterDescription = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.topicChaptersDataGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersEditButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersConfirmButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersDeleteButton)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardNavigationButton
            // 
            this.dashboardNavigationButton.AccessibleName = "";
            this.dashboardNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dashboardNavigationButton.AutoSize = true;
            this.dashboardNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardNavigationButton.ForeColor = System.Drawing.Color.White;
            this.dashboardNavigationButton.Location = new System.Drawing.Point(40, 174);
            this.dashboardNavigationButton.Name = "dashboardNavigationButton";
            this.dashboardNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.dashboardNavigationButton.TabIndex = 6;
            this.dashboardNavigationButton.Text = "Dashboard";
            this.dashboardNavigationButton.UseVisualStyleBackColor = true;
            this.dashboardNavigationButton.Click += new System.EventHandler(this.dashboardNavigationButton_Click);
            // 
            // chaptersNavigationButton
            // 
            this.chaptersNavigationButton.AccessibleName = "";
            this.chaptersNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chaptersNavigationButton.AutoSize = true;
            this.chaptersNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chaptersNavigationButton.ForeColor = System.Drawing.Color.White;
            this.chaptersNavigationButton.Location = new System.Drawing.Point(40, 253);
            this.chaptersNavigationButton.Name = "chaptersNavigationButton";
            this.chaptersNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.chaptersNavigationButton.TabIndex = 7;
            this.chaptersNavigationButton.Text = "> Chapters";
            this.chaptersNavigationButton.UseVisualStyleBackColor = true;
            // 
            // questionsNavigationButton
            // 
            this.questionsNavigationButton.AccessibleName = "";
            this.questionsNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.questionsNavigationButton.AutoSize = true;
            this.questionsNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionsNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionsNavigationButton.ForeColor = System.Drawing.Color.White;
            this.questionsNavigationButton.Location = new System.Drawing.Point(40, 332);
            this.questionsNavigationButton.Name = "questionsNavigationButton";
            this.questionsNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.questionsNavigationButton.TabIndex = 8;
            this.questionsNavigationButton.Text = "Questions";
            this.questionsNavigationButton.UseVisualStyleBackColor = true;
            this.questionsNavigationButton.Click += new System.EventHandler(this.questionsNavigationButton_Click);
            // 
            // webusersNavigationButton
            // 
            this.webusersNavigationButton.AccessibleName = "";
            this.webusersNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.webusersNavigationButton.AutoSize = true;
            this.webusersNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webusersNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.webusersNavigationButton.ForeColor = System.Drawing.Color.White;
            this.webusersNavigationButton.Location = new System.Drawing.Point(40, 411);
            this.webusersNavigationButton.Name = "webusersNavigationButton";
            this.webusersNavigationButton.Size = new System.Drawing.Size(235, 73);
            this.webusersNavigationButton.TabIndex = 9;
            this.webusersNavigationButton.Text = "Web Users";
            this.webusersNavigationButton.UseVisualStyleBackColor = true;
            this.webusersNavigationButton.Click += new System.EventHandler(this.webusersNavigationButton_Click);
            // 
            // lineSeparator
            // 
            this.lineSeparator.BackColor = System.Drawing.Color.White;
            this.lineSeparator.Location = new System.Drawing.Point(315, 40);
            this.lineSeparator.Name = "lineSeparator";
            this.lineSeparator.Size = new System.Drawing.Size(1, 960);
            this.lineSeparator.TabIndex = 10;
            // 
            // topicChaptersDataGrid
            // 
            this.topicChaptersDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.topicChaptersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.topicChaptersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.topicChaptersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.course,
            this.subject,
            this.chapterName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.topicChaptersDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.topicChaptersDataGrid.EnableHeadersVisualStyles = false;
            this.topicChaptersDataGrid.GridColor = System.Drawing.Color.White;
            this.topicChaptersDataGrid.Location = new System.Drawing.Point(375, 80);
            this.topicChaptersDataGrid.Name = "topicChaptersDataGrid";
            this.topicChaptersDataGrid.RowHeadersVisible = false;
            this.topicChaptersDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.topicChaptersDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.topicChaptersDataGrid.RowTemplate.Height = 25;
            this.topicChaptersDataGrid.Size = new System.Drawing.Size(1450, 400);
            this.topicChaptersDataGrid.TabIndex = 11;
            this.topicChaptersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.singleAnswerDataGrid_CellContentClick);
            // 
            // course
            // 
            this.course.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.course.HeaderText = "Course";
            this.course.MinimumWidth = 483;
            this.course.Name = "course";
            this.course.Width = 483;
            // 
            // subject
            // 
            this.subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.subject.HeaderText = "Subject";
            this.subject.MinimumWidth = 483;
            this.subject.Name = "subject";
            this.subject.Width = 483;
            // 
            // chapterName
            // 
            this.chapterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chapterName.HeaderText = "Chapter Name";
            this.chapterName.MinimumWidth = 483;
            this.chapterName.Name = "chapterName";
            // 
            // horizontalLineSeparator
            // 
            this.horizontalLineSeparator.BackColor = System.Drawing.Color.White;
            this.horizontalLineSeparator.Location = new System.Drawing.Point(365, 545);
            this.horizontalLineSeparator.Name = "horizontalLineSeparator";
            this.horizontalLineSeparator.Size = new System.Drawing.Size(1480, 1);
            this.horizontalLineSeparator.TabIndex = 21;
            // 
            // courseComboBox
            // 
            this.courseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.courseComboBox.ForeColor = System.Drawing.Color.Black;
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(690, 679);
            this.courseComboBox.MaxDropDownItems = 10;
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(561, 33);
            this.courseComboBox.TabIndex = 22;
            this.courseComboBox.SelectedIndexChanged += new System.EventHandler(this.questionTypeComboBox_SelectedIndexChanged);
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subjectComboBox.ForeColor = System.Drawing.Color.Black;
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(690, 739);
            this.subjectComboBox.MaxDropDownItems = 10;
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(561, 33);
            this.subjectComboBox.TabIndex = 23;
            this.subjectComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chapterNameTextBox
            // 
            this.chapterNameTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chapterNameTextBox.Location = new System.Drawing.Point(690, 619);
            this.chapterNameTextBox.Name = "chapterNameTextBox";
            this.chapterNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chapterNameTextBox.Size = new System.Drawing.Size(561, 33);
            this.chapterNameTextBox.TabIndex = 24;
            this.chapterNameTextBox.TextChanged += new System.EventHandler(this.questionTextTextBox_TextChanged);
            // 
            // chapterNameLabel
            // 
            this.chapterNameLabel.AutoSize = true;
            this.chapterNameLabel.Location = new System.Drawing.Point(480, 618);
            this.chapterNameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.chapterNameLabel.Name = "chapterNameLabel";
            this.chapterNameLabel.Size = new System.Drawing.Size(157, 30);
            this.chapterNameLabel.TabIndex = 25;
            this.chapterNameLabel.Text = "Chapter Name";
            this.chapterNameLabel.Click += new System.EventHandler(this.chapterNameLabel_Click);
            // 
            // courseLabel
            // 
            this.courseLabel.AutoSize = true;
            this.courseLabel.Location = new System.Drawing.Point(480, 678);
            this.courseLabel.Margin = new System.Windows.Forms.Padding(5);
            this.courseLabel.Name = "courseLabel";
            this.courseLabel.Size = new System.Drawing.Size(82, 30);
            this.courseLabel.TabIndex = 26;
            this.courseLabel.Text = "Course";
            this.courseLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(480, 738);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(5);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(87, 30);
            this.subjectLabel.TabIndex = 27;
            this.subjectLabel.Text = "Subject";
            this.subjectLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chaptersEditButton);
            this.flowLayoutPanel1.Controls.Add(this.chaptersConfirmButton);
            this.flowLayoutPanel1.Controls.Add(this.chaptersCancelButton);
            this.flowLayoutPanel1.Controls.Add(this.chaptersDeleteButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1737, 596);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 11);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(88, 303);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // chaptersEditButton
            // 
            this.chaptersEditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersEditButton.Image = ((System.Drawing.Image)(resources.GetObject("chaptersEditButton.Image")));
            this.chaptersEditButton.Location = new System.Drawing.Point(13, 23);
            this.chaptersEditButton.Name = "chaptersEditButton";
            this.chaptersEditButton.Size = new System.Drawing.Size(59, 60);
            this.chaptersEditButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chaptersEditButton.TabIndex = 20;
            this.chaptersEditButton.TabStop = false;
            this.chaptersEditButton.Click += new System.EventHandler(this.chaptersEditButton_Click);
            // 
            // chaptersConfirmButton
            // 
            this.chaptersConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersConfirmButton.Image = global::ByteManager.Properties.Resources.AffirmativeButton;
            this.chaptersConfirmButton.Location = new System.Drawing.Point(13, 89);
            this.chaptersConfirmButton.Name = "chaptersConfirmButton";
            this.chaptersConfirmButton.Size = new System.Drawing.Size(59, 60);
            this.chaptersConfirmButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chaptersConfirmButton.TabIndex = 21;
            this.chaptersConfirmButton.TabStop = false;
            // 
            // chaptersCancelButton
            // 
            this.chaptersCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersCancelButton.Image = global::ByteManager.Properties.Resources.NegativeButton;
            this.chaptersCancelButton.Location = new System.Drawing.Point(13, 155);
            this.chaptersCancelButton.Name = "chaptersCancelButton";
            this.chaptersCancelButton.Size = new System.Drawing.Size(59, 60);
            this.chaptersCancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chaptersCancelButton.TabIndex = 22;
            this.chaptersCancelButton.TabStop = false;
            // 
            // chaptersDeleteButton
            // 
            this.chaptersDeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chaptersDeleteButton.Image = global::ByteManager.Properties.Resources.TrashBinButton;
            this.chaptersDeleteButton.Location = new System.Drawing.Point(13, 221);
            this.chaptersDeleteButton.Name = "chaptersDeleteButton";
            this.chaptersDeleteButton.Size = new System.Drawing.Size(59, 60);
            this.chaptersDeleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chaptersDeleteButton.TabIndex = 23;
            this.chaptersDeleteButton.TabStop = false;
            // 
            // chapterDescription
            // 
            this.chapterDescription.AutoSize = true;
            this.chapterDescription.Location = new System.Drawing.Point(480, 793);
            this.chapterDescription.Margin = new System.Windows.Forms.Padding(5);
            this.chapterDescription.Name = "chapterDescription";
            this.chapterDescription.Size = new System.Drawing.Size(127, 30);
            this.chapterDescription.TabIndex = 38;
            this.chapterDescription.Text = "Description";
            this.chapterDescription.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(690, 800);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(561, 140);
            this.descriptionTextBox.TabIndex = 39;
            // 
            // Chapters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.chapterDescription);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.courseLabel);
            this.Controls.Add(this.chapterNameLabel);
            this.Controls.Add(this.chapterNameTextBox);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.horizontalLineSeparator);
            this.Controls.Add(this.topicChaptersDataGrid);
            this.Controls.Add(this.lineSeparator);
            this.Controls.Add(this.webusersNavigationButton);
            this.Controls.Add(this.questionsNavigationButton);
            this.Controls.Add(this.chaptersNavigationButton);
            this.Controls.Add(this.dashboardNavigationButton);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Chapters";
            this.Text = "ByteManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Chapters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.topicChaptersDataGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaptersEditButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersConfirmButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaptersDeleteButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView topicChaptersDataGrid;
        private Label horizontalLineSeparator;
        private ComboBox courseComboBox;
        private ComboBox subjectComboBox;
        private TextBox chapterNameTextBox;
        private Label chapterNameLabel;
        private Label courseLabel;
        private Label subjectLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox chaptersEditButton;
        private PictureBox chaptersConfirmButton;
        private PictureBox chaptersCancelButton;
        private PictureBox chaptersDeleteButton;
        private DataGridViewTextBoxColumn course;
        private DataGridViewTextBoxColumn subject;
        private DataGridViewTextBoxColumn chapterName;
        private Label chapterDescription;
        private TextBox descriptionTextBox;
    }
}