using WindowsApiClient;

namespace ByteManager.WinFormsUI
{
    public partial class Dashboard : Form
    {
        private IChapterFacadeApiClient ChapterFacadeApiClient;
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
            this.Hide();
            Questions questions = new Questions();
            questions.Show();
        }

        private void chaptersNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chapters chapters = new Chapters(ChapterFacadeApiClient);
            chapters.Show();
        }

        private void webusersNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            WebUsers webUsers = new WebUsers();
            webUsers.Show();
        }
    }
}
