using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApiClient;
using WindowsApiClient.DTOs;

namespace ByteManager.WinFormsUI
{
    public partial class Chapters : Form
    {

        private BindingSource chapterBindingSource = new();
        private IChapterFacadeApiClient ChapterFacadeApi { get; set; }
        public Chapters(IChapterFacadeApiClient chapterFacadeApi)
        {
            InitializeComponent();
            ChapterFacadeApi = chapterFacadeApi;
            GetData(ChapterFacadeApi);
        }

        private void singleAnswerDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void GetData(IChapterFacadeApiClient ChapterFacadeApi)
        {
            var chaptersEnum = await ChapterFacadeApi.GetAllChaptersAsync();
            var chapterList = chaptersEnum.ToList();
            //ChapterDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            ChapterDataGrid_Resize();
            chapterBindingSource.DataSource = chapterList;
            ChapterDataGrid.DataSource = chapterBindingSource;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Chapters_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chapterNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void questionTextTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void questionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chaptersEditButton_Click(object sender, EventArgs e)
        {
            chapterNameTextBox.ReadOnly = false;
            //topicComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            //subTopicComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void questionsNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Questions questions = new Questions();
            questions.Show();
        }

        private void webusersNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            WebUsers webUsers = new WebUsers();
            webUsers.Show();
        }

        private void dashboardNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ChapterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChapterDataGrid_Resize()
        {
            ChapterDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            ChapterDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ChapterDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ChapterDataGrid.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ChapterDataGrid.ForeColor = Color.Black;
        }

        private void ChapterDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
