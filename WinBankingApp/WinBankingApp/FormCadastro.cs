using MySql.Data.MySqlClient;
using WinBankingApp.Classes;

namespace WinBankingApp
{
    // Declaração do namespace WinBankingApp

    // Classe parcial FormCadastro que herda de Form
    public partial class FormCadastro : Form
    {
        // Construtor da classe FormCadastro
        public FormCadastro()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        // Método chamado quando o botão de login é clicado
        private void login_Click(object sender, EventArgs e)
        {
            // Cria e exibe um novo formulário de login
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        // Método chamado quando o botão de cadastrar é clicado
        private void cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se o CPF já existe no banco de dados
                if (VerificarExistenciaCPF(cpf_cnpj.Text))
                {
                    MessageBox.Show("CPF já cadastrado. Não é possível cadastrar novamente.");
                    return;
                }

                // Verificar se todos os campos obrigatórios estão preenchidos
                if (!nome_text.Text.Equals("") && !email_text.Text.Equals("") && !cpf_cnpj_text.Text.Equals("") && !senha_text.Text.Equals("") && !saldo_text.Text.Equals("") && Convert.ToDouble(saldo_text.Text) != -1)
                {
                    // Criar uma instância de Usuario e preencher com os dados do formulário
                    Usuario cadUsuario = new Usuario();
                    cadUsuario.nome = nome_text.Text;
                    cadUsuario.email = email_text.Text;
                    cadUsuario.cpf_cnpj = cpf_cnpj.Text;
                    cadUsuario.senha = senha_text.Text;
                    cadUsuario.saldo = Convert.ToDouble(saldo_text.Text);
                    cadUsuario.tipo_usuario = tipoDeUsuario();

                    // Tentar cadastrar o usuário no banco de dados
                    if (cadUsuario.cadastrarUsuario())
                    {
                        MessageBox.Show("Usuário cadastrado!");
                        // Limpar os campos do formulário após o cadastro bem-sucedido
                        nome_text.Clear();
                        email_text.Clear();
                        cpf_cnpj_text.Clear();
                        senha_text.Clear();
                        saldo_text.Clear();
                        tipo_usuario.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar o usuário!");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + exception.Message);
            }
        }

        // Método chamado quando uma tecla é pressionada no campo de saldo
        private void saldo_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtém o texto atual na TextBox
            string text = saldo_text.Text;

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

        // Método chamado quando uma tecla é pressionada no campo de CPF
        private void cpf_cnpj_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e a tecla de retrocesso
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        // Método para obter o tipo de usuário com base na escolha do checkbox
        private string tipoDeUsuario()
        {
            if (tipo_usuario.Checked)
            {
                return "lojista";
            }
            else
            {
                return "comum";
            }
        }

        // Método para verificar se o CPF já existe no banco de dados
        private bool VerificarExistenciaCPF(string cpf)
        {
            try
            {
                // Cria uma conexão com o banco de dados
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                // Preparar a consulta SQL para contar quantos registros têm o CPF fornecido
                string selectQuery = $"SELECT COUNT(*) FROM bankingapp.usuarios WHERE cpf_cnpj = '{cpf}'";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                // Executa a consulta e obtém o resultado
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Fecha a conexão com o banco de dados
                connection.Close();

                return count > 0; // Retorna true se o CPF já existe
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem em caso de erro durante a verificação do CPF
                MessageBox.Show($"Erro ao verificar existência de CPF: {ex.Message}");
                return false; // Em caso de erro, assume que o CPF não existe para evitar cadastro duplicado
            }
        }
    }
}
