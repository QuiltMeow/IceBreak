using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IceBreak
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pbAuthor_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://intro.quilt.idv.tw/");
        }

        private void AboutForm_MouseClick(object sender, MouseEventArgs e)
        {
            wbMedia.Url = new Uri("https://smallquilt.quilt.idv.tw:8923/resource3.php");
            wbMedia.Visible = true;
        }
    }
}