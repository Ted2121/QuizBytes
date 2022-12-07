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
        private BindingSource subjectsBindingSource = new();
        private IChapterFacadeApiClient ChapterFacadeApi { get; set; }
        private ISubjectFacadeApiClient SubjectFacadeApi { get; set; }
        //private ICourseFacadeApiClient CourseFacadeApi { get; set; }
        private int ChapterId { get; set; }
        public Chapters(IChapterFacadeApiClient chapterFacadeApi, ISubjectFacadeApiClient subjectFacadeApi)
        {
            InitializeComponent();
            ChapterFacadeApi = chapterFacadeApi;
            //CourseFacadeApi = courseFacadeApi;
            SubjectFacadeApi = subjectFacadeApi;
        }

        private void singleAnswerDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task GetChapters()
        {
            var chaptersEnum = await ChapterFacadeApi.GetAllChaptersAsync();
            var chapterList = chaptersEnum.ToList();
            ChapterDataGrid_Resize();
            chapterBindingSource.DataSource = chapterList;
            ChapterDataGrid.DataSource = chapterBindingSource;
        }

        private async Task GetSubjects()
        {
            var subjectsEnum = await SubjectFacadeApi.GetAllSubjectsAsync();
            var subjectsList = subjectsEnum.ToList();
            for(int i = 0; i < subjectsList.Count; i++)
            {
                subjectsBindingSource.Insert(i, subjectsList[i].Name);
            }
            subjectComboBox.DataSource = subjectsBindingSource;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Chapters_Load(object sender, EventArgs e)
        {
            await GetChapters();
            await GetSubjects();
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

        private async void chaptersEditButton_Click(object sender, EventArgs e)
        {
            ChapterDto updatedChapter = new()
            {
                Id = ChapterId,
                FKSubjectId = 20,
                Description = descriptionTextBox.Text,
                Name = chapterNameTextBox.Text
            };
            await updateChapter(updatedChapter);
            await GetChapters();
        }

        private async Task updateChapter(ChapterDto chapter)
        {
            await ChapterFacadeApi.UpdateChapterAsync(chapter);
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
            ParseDatagridRows(e);
        }

        private void ParseDatagridRows(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ChapterDataGrid.Rows[e.RowIndex];
                ChapterId = int.Parse(row.Cells[0].Value.ToString());
                chapterNameTextBox.Text = row.Cells[1].Value.ToString();
                descriptionTextBox.Text = row.Cells[2].Value.ToString();
            }
        }

        private async void chaptersConfirmButton_Click(object sender, EventArgs e)
        {
            var subjectName = subjectComboBox.Text;
            int subjectId = await getSubjectIdFromName(subjectName);
            ChapterDto chapter = new()
            {
                Description = descriptionTextBox.Text,
                Name = chapterNameTextBox.Text,
                FKSubjectId = subjectId,
            };
            await createChapter(chapter);
            await GetChapters();
        }

        private async Task<int> getSubjectIdFromName(string subjectName)
        {
            var subjects = await SubjectFacadeApi.GetAllSubjectsAsync();
            var subjectList = subjects.ToList();
            for (var i = 0; i < subjectList.Count; i++)
            {
                if(subjectName == subjectList[i].Name)
                {
                    return subjectList[i].Id;
                }
            }
            return -1;
        }
        private async Task createChapter(ChapterDto chapter)
        {
            var id = await ChapterFacadeApi.InsertChapterAsync(chapter);
        }

        private async void chaptersDeleteButton_Click(object sender, EventArgs e)
        {
            await ChapterFacadeApi.DeleteChapterAsync(ChapterId);
            await GetChapters();
        }
    }
}
