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
    public partial class FormAddPlayers : Form
    {
        FormEditPlayer formEditPlayer = new FormEditPlayer();

        public FormAddPlayers()
        {
            InitializeComponent();
        }

        private void buttonEditPlayerAdd_Click(object sender, EventArgs e)
        {
            formEditPlayer = new FormEditPlayer();
            formEditPlayer.ShowDialog();
        }
    }
}
