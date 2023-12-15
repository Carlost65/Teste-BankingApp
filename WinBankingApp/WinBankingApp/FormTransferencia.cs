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
    public partial class FormTransferencia : Form
    {
        string cpfUsuario;
        public FormTransferencia(string cpfLogin)
        {
            cpfUsuario = cpfLogin;
            valor_saldo_text.Text = ConexaoDb.ObterUsuarioPorCPF(cpfUsuario).saldo.ToString();
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void destinatario_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void transferir_Click(object sender, EventArgs e)
        {
            Transferencia.RealizarTransferencia(cpfUsuario, destinatario_text.Text, Convert.ToDouble(valor_transferencia_text.Text));
        }

        private void valor_transferencia_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtém o texto atual na TextBox
            string text = valor_transferencia_text.Text;

            // Permite apenas dígitos, backspace e ponto decimal
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Permite apenas um ponto decimal
            if (e.KeyChar == ',' && text.Contains(','))
            {
                e.Handled = true;
            }
        }
    }
}
