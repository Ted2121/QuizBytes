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
            this.questionTabControl = new System.Windows.Forms.TabControl();
            this.singleAnswerTabPage = new System.Windows.Forms.TabPage();
            this.singleAnswerDataGrid = new System.Windows.Forms.DataGridView();
            this.trueFalseTabPage = new System.Windows.Forms.TabPage();
            this.chapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correctAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wrongAnswer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wrongAnswer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wrongAnswer3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionTabControl.SuspendLayout();
            this.singleAnswerTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleAnswerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lineSeparator
            // 
            this.lineSeparator.BackColor = System.Drawing.Color.White;
            this.lineSeparator.Location = new System.Drawing.Point(315, 40);
            this.lineSeparator.Name = "lineSeparator";
            this.lineSeparator.Size = new System.Drawing.Size(1, 980);
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
            // questionTabControl
            // 
            this.questionTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.questionTabControl.Controls.Add(this.singleAnswerTabPage);
            this.questionTabControl.Controls.Add(this.trueFalseTabPage);
            this.questionTabControl.Location = new System.Drawing.Point(400, 80);
            this.questionTabControl.Name = "questionTabControl";
            this.questionTabControl.SelectedIndex = 0;
            this.questionTabControl.Size = new System.Drawing.Size(1415, 318);
            this.questionTabControl.TabIndex = 10;
            // 
            // singleAnswerTabPage
            // 
            this.singleAnswerTabPage.Controls.Add(this.singleAnswerDataGrid);
            this.singleAnswerTabPage.Location = new System.Drawing.Point(4, 39);
            this.singleAnswerTabPage.Name = "singleAnswerTabPage";
            this.singleAnswerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.singleAnswerTabPage.Size = new System.Drawing.Size(1407, 275);
            this.singleAnswerTabPage.TabIndex = 0;
            this.singleAnswerTabPage.Text = "Single Answer";
            this.singleAnswerTabPage.UseVisualStyleBackColor = true;
            this.singleAnswerTabPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // singleAnswerDataGrid
            // 
            this.singleAnswerDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.singleAnswerDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.singleAnswerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.singleAnswerDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chapterName,
            this.questionText,
            this.hint,
            this.correctAnswer,
            this.wrongAnswer1,
            this.wrongAnswer2,
            this.wrongAnswer3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.singleAnswerDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.singleAnswerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleAnswerDataGrid.EnableHeadersVisualStyles = false;
            this.singleAnswerDataGrid.GridColor = System.Drawing.Color.White;
            this.singleAnswerDataGrid.Location = new System.Drawing.Point(3, 3);
            this.singleAnswerDataGrid.Name = "singleAnswerDataGrid";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.singleAnswerDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.singleAnswerDataGrid.RowTemplate.Height = 25;
            this.singleAnswerDataGrid.Size = new System.Drawing.Size(1401, 269);
            this.singleAnswerDataGrid.TabIndex = 0;
            this.singleAnswerDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // trueFalseTabPage
            // 
            this.trueFalseTabPage.Location = new System.Drawing.Point(4, 24);
            this.trueFalseTabPage.Name = "trueFalseTabPage";
            this.trueFalseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.trueFalseTabPage.Size = new System.Drawing.Size(1407, 290);
            this.trueFalseTabPage.TabIndex = 1;
            this.trueFalseTabPage.Text = "True/False Answer";
            this.trueFalseTabPage.UseVisualStyleBackColor = true;
            // 
            // chapterName
            // 
            this.chapterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.chapterName.HeaderText = "Chapter Name";
            this.chapterName.Name = "chapterName";
            this.chapterName.Width = 162;
            // 
            // questionText
            // 
            this.questionText.HeaderText = "Question Text";
            this.questionText.MinimumWidth = 500;
            this.questionText.Name = "questionText";
            this.questionText.Width = 500;
            // 
            // hint
            // 
            this.hint.HeaderText = "Hint";
            this.hint.Name = "hint";
            // 
            // correctAnswer
            // 
            this.correctAnswer.HeaderText = "Correct Answer";
            this.correctAnswer.Name = "correctAnswer";
            // 
            // wrongAnswer1
            // 
            this.wrongAnswer1.HeaderText = "Wrong Answer 1";
            this.wrongAnswer1.Name = "wrongAnswer1";
            // 
            // wrongAnswer2
            // 
            this.wrongAnswer2.HeaderText = "Wrong Answer 2";
            this.wrongAnswer2.Name = "wrongAnswer2";
            // 
            // wrongAnswer3
            // 
            this.wrongAnswer3.HeaderText = "Wrong Answer 3";
            this.wrongAnswer3.Name = "wrongAnswer3";
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.questionTabControl);
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
            this.questionTabControl.ResumeLayout(false);
            this.singleAnswerTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.singleAnswerDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lineSeparator;
        private Button webusersNavigationButton;
        private Button questionsNavigationButton;
        private Button chaptersNavigationButton;
        private Button dashboardNavigationButton;
        private TabControl questionTabControl;
        private TabPage singleAnswerTabPage;
        private TabPage trueFalseTabPage;
        private DataGridView singleAnswerDataGrid;
        private DataGridViewTextBoxColumn chapterName;
        private DataGridViewTextBoxColumn questionText;
        private DataGridViewTextBoxColumn hint;
        private DataGridViewTextBoxColumn correctAnswer;
        private DataGridViewTextBoxColumn wrongAnswer1;
        private DataGridViewTextBoxColumn wrongAnswer2;
        private DataGridViewTextBoxColumn wrongAnswer3;
    }
}