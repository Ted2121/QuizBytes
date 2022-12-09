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

namespace ByteManager.WinFormsUI
{
    public partial class Questions : Form
    {
        private IChapterFacadeApiClient ChapterFacadeApiClient;
        private ISubjectFacadeApiClient SubjectFacadeApiClient;

        public Questions()
        {
            InitializeComponent();
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
    }
}
