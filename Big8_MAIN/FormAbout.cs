using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big8_MAIN
{
    public partial class FormAbout : Form
    {

        System.Media.SoundPlayer startMusic = new System.Media.SoundPlayer(Properties.Resources.Dance);

        public FormAbout()
        {
            InitializeComponent();

            this.Activated += this.FormAbout_Activated;
            this.FormClosing += this.FormAbout_Closing;
        }

        private void FormAbout_Activated(object sender, EventArgs e)
        {
            startMusic.Play();
        }

        private void FormAbout_Closing(object sender, EventArgs e)
        {
            startMusic.Stop();
        }
    }
}
