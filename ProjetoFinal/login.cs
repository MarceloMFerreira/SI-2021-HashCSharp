using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            if (con.consultaUsuario(txtUser.Text, txtSenha.Text) == true)
            {
                Form1 formPrincipal = new Form1();
                formPrincipal.Show();
                

            }
            else
            {
                MessageBox.Show("Usuario ou senha incorreta");
                limpa();
            }
        }

        private void btnCadUser_Click(object sender, EventArgs e)
        {
            cadUsuario formCadUser = new cadUsuario();
            formCadUser.Show();
        }
        void limpa(){
            txtSenha.Clear();
            txtUser.Clear();
            txtUser.Focus();
            }
    }
}
