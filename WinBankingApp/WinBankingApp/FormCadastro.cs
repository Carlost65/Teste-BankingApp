using WinBankingApp.Classes;

namespace WinBankingApp
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!nome_text.Text.Equals("") && !email_text.Text.Equals("") && !cpf_cnpj_text.Text.Equals("") && !senha_text.Text.Equals("") && !saldo_text.Text.Equals("") && saldo_val() != -1)
                {
                    Usuario cadUsuario = new Usuario();
                    cadUsuario.nome = nome_text.Text;
                    cadUsuario.email = email_text.Text;
                    cadUsuario.cpf_cnpj = cpf_cnpj.Text;
                    cadUsuario.senha = senha_text.Text;
                    cadUsuario.saldo = saldo_val();
                    cadUsuario.tipo_usuario = tipoDeUsuario();

                    if (cadUsuario.cadastrarUsuario())
                    {
                        MessageBox.Show("usuario cadastrado!");
                        nome_text.Clear();
                        email_text.Clear();
                        cpf_cnpj_text.Clear();
                        senha_text.Clear();
                        saldo_text.Clear();
                        tipo_usuario.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel cadastrar o usuario!");
                    }
                }
                else
                {
                    MessageBox.Show("Preecha todos os campos!");

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao cadastrar usuario: " + exception.Message);
            }
        }

        private void saldo_text_KeyPress(object sender, KeyPressEventArgs args)
        {
            // Obtém o texto atual na TextBox
            string text = saldo_text.Text;

            // Permite apenas dígitos, backspace e ponto decimal
            if (!Char.IsDigit(args.KeyChar) && args.KeyChar != (char)8 && args.KeyChar != '.')
            {
                args.Handled = true;
            }

            // Permite apenas um ponto decimal
            if (args.KeyChar == '.' && text.Contains('.'))
            {
                args.Handled = true;
            }
        }

        private void cpf_cnpj_text_KeyPress(object sender, KeyPressEventArgs args)
        {
            //permite apenas digitos
            if (!Char.IsDigit(args.KeyChar) && args.KeyChar != (char)8)
            {
                args.Handled = true;
            }
        }

        //conversão do campo de texto de saldo para double
        private double saldo_val()
        {
            if (double.TryParse(saldo_text.Text, out double saldoConvetido))
            {
                // A conversão foi bem-sucedida
                return saldoConvetido;
            }
            else
            {
                // A conversao falhou
                MessageBox.Show("Valor inválido. Insira um número válido.");
                return -1;
            }
        }
        private string tipoDeUsuario()
        {
            if (tipo_usuario.Checked)
            {
                return "lojista";
            }
            else
                return "comum";
        }
    }
}