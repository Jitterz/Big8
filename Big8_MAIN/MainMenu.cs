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
    public partial class FormMainMenu : Form
    {
        // Instance of Players Form
        FormPlayers formPlayers = new FormPlayers();

        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void buttonPlayersMain_Click(object sender, EventArgs e)
        {
            // So I cant open multiple of the same form
            formPlayers = new FormPlayers();
            formPlayers.ShowDialog();
        }
    }
}
