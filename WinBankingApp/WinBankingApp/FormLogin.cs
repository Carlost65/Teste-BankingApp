using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBankingApp.Classes;

namespace WinBankingApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void cadastro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                FormTransferencia formTransferencia = new FormTransferencia();
                formTransferencia.Show();
                this.Close();
            }
        }

        private bool Login()
        {
            Usuario usuario = ConexaoDb.ObterUsuarioPorCPF(usuario_text.Text);

            if (usuario == null)
            {
                MessageBox.Show("Usuario não encontrado!");
                return false;
            }
            if (usuario.senha != senha_text.Text)
            {
                MessageBox.Show("senha incorreta!");
                return false;
            }
            return true;
        }

        private void usuario_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
