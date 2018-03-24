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
    public partial class FormPlayers : Form
    {

        FormAddPlayers formAddPlayers = new FormAddPlayers();
        FormEditPlayer formEditPlayer = new FormEditPlayer();

        public FormPlayers()
        {
            InitializeComponent();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            formAddPlayers = new FormAddPlayers();
            formAddPlayers.ShowDialog();
        }

        private void buttonEditPlayerPlayers_Click(object sender, EventArgs e)
        {
            formEditPlayer = new FormEditPlayer();
            formEditPlayer.ShowDialog();
        }
    }
}
