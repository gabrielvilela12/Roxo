using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fear
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pbox_Olho_MouseHover(object sender, EventArgs e)
        {
            pbox_Olho.Image = Properties.Resources.olho_on;
            tbox_PW_Usuario.PasswordChar = '\u0000';
        }

        private void pbox_Olho_MouseLeave(object sender, EventArgs e)
        {
            pbox_Olho.Image = Properties.Resources.olho_off;
            tbox_PW_Usuario.PasswordChar = '*';
        }

        private void pbox_Olho_Click(object sender, EventArgs e)
        {

        }
    }
}
