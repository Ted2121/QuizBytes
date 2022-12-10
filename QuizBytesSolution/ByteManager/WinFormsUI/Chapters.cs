using ByteManager.Client_Singletons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private IEnumerable<SubjectDto> Subjects { get; set; }
        private int ChapterId { get; set; }
        public Chapters()
        {
            InitializeComponent();
        }

        private void singleAnswerDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task GetChapters()
        {
            ChapterFacadeApi = ChapterFacadeSingleton.Instance;
            var chaptersEnum = await ChapterFacadeApi.GetAllChaptersAsync();
            var chapterList = chaptersEnum.ToList();
            ChapterDataGrid_Resize();
            chapterBindingSource.DataSource = chapterList;
            ChapterDataGrid.DataSource = chapterBindingSource;
        }

        private async Task GetSubjects()
        {
            SubjectFacadeApi = SubjectFacadeSingleton.Instance;
            Subjects = await SubjectFacadeApi.GetAllSubjectsAsync();
            var subjectsList = Subjects.ToList();
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
            await GetChaptersAndSubjects();
        }

        private async Task GetChaptersAndSubjects()
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

        private void chaptersEditButton_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to update this chapter?";
            CreatePopUpForm(message, async () => {await EditChapters();});
        }

        private async void CreatePopUpForm(string message, Func<Task> method)
        {
            string title = "Confirm";
            DialogResult dialog = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                await method.Invoke();
            }
        }
        private async Task EditChapters()
        {
            ChapterDto updatedChapter = new()
            {
                Id = ChapterId,
                FKSubjectId = GetSubjectIdFromCombobox(),
                Description = descriptionTextBox.Text,
                Name = chapterNameTextBox.Text
            };
            await UpdateChapter(updatedChapter);
            await GetChapters();
        }

        private int GetSubjectIdFromCombobox()
        {
            var subjectName = subjectComboBox.SelectedValue.ToString();

            var subjectId = Subjects.Where(subject => subject.Name == subjectName).Select(subject => subject.Id).FirstOrDefault();

            return subjectId;
        }

        private async Task UpdateChapter(ChapterDto chapter)
        {
            await ChapterFacadeApi.UpdateChapterAsync(chapter);
        }

        private void questionsNavigationButton_Click(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            this.Hide();
            Questions questions = new Questions();
            questions.Show();
        }

        private void webusersNavigationButton_Click(object sender, EventArgs e)
        {
            ShowWebUsers();
        }

        private void ShowWebUsers()
        {
            this.Hide();
            WebUsers webUsers = new WebUsers();
            webUsers.Show();
        }

        private void dashboardNavigationButton_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void ShowDashboard()
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

        private async void ChaptersConfirmButton_Click(object sender, EventArgs e)
        {
            await CreateChapter(NewChapterCreationAsync());
            await GetChapters();
        }
        private ChapterDto NewChapterCreationAsync()
        {
            int subjectId = GetSubjectIdFromCombobox();
            ChapterDto chapter = new()
            {
                Description = descriptionTextBox.Text,
                Name = chapterNameTextBox.Text,
                FKSubjectId = subjectId,
            };
            return chapter;
        }
        private async Task CreateChapter(ChapterDto chapter)
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
