using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteManager.WinFormsUI
{
    public partial class WebUsers : Form
    {
        public WebUsers()
        {
            InitializeComponent();
        }

        private void webusersNavigationButton_Click(object sender, EventArgs e)
        {

        }

        private void chapterNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chaptersNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chapters chapters = new Chapters();
            chapters.Show();
        }

        private void questionsNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Questions questions = new Questions();
            questions.Show();
        }

        private void dashboardNavigationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
