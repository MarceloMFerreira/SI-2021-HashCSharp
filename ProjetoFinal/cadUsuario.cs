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
    public partial class cadUsuario : Form
    {
        public cadUsuario()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCadUser_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereUser(txtNewUser.Text,txtNewSenha.Text);
            if (r == true) { 
                MessageBox.Show("Inserido com sucesso :)");
                 Close();
            }
            else
                MessageBox.Show("Erro: " + con.msg);
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
