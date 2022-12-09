using WindowsApiClient;

namespace ByteManager.WinFormsUI
{
    public partial class Dashboard : Form
    {
        private IChapterFacadeApiClient ChapterFacadeApiClient;
        private ISubjectFacadeApiClient SubjectFacadeApiClient;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            this.Hide();
            Questions questions = new Questions();
            questions.Show();
        }

        private void chaptersNavigationButton_Click(object sender, EventArgs e)
        {
            ShowChapters();
        }

        private void ShowChapters()
        {
            this.Hide();
            Chapters chapters = new Chapters();
            chapters.Show();
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
    }
}
