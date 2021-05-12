using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AMModInstaller
{
    public partial class Social_Links : Form
    {
        public Social_Links()
        {
            InitializeComponent();
        }

        private void YouTubeButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCaCMegNb4sWCc9rSF2GTpSg");
        }

        private void TwitterButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/TheSingleOneYT");
        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/TheSingleOneYT");
        }
    }
}
