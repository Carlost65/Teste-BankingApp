using WinBankingApp.Classes;

// Declaração do namespace WinBankingApp
namespace WinBankingApp
{
    // Classe parcial FormLogin que herda de Form
    public partial class FormLogin : Form
    {
        // Construtor da classe FormLogin
        public FormLogin()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        // Método chamado quando o botão de cadastro é clicado
        private void cadastro_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário de login
        }

        // Método chamado quando o botão de entrar é clicado
        private void entrar_Click(object sender, EventArgs e)
        {
            // Verifica se o login foi bem-sucedido
            if (Login())
            {
                // Se o login foi bem-sucedido, abre o formulário de transferência
                FormTransferencia formTransferencia = new FormTransferencia(usuario_text.Text);
                formTransferencia.Show();
                this.Close(); // Fecha o formulário de login
            }
        }

        // Método para realizar a autenticação do usuário
        private bool Login()
        {
            // Obtém informações do usuário com base no CPF digitado
            Usuario usuario = ConexaoDb.ObterUsuarioPorCPF(usuario_text.Text);

            // Verifica se o usuário foi encontrado
            if (usuario == null)
            {
                MessageBox.Show("Usuário não encontrado!");
                return false;
            }

            // Verifica se a senha digitada é correta
            if (usuario.senha != senha_text.Text)
            {
                MessageBox.Show("Senha incorreta!");
                return false;
            }

            // Retorna verdadeiro se o login for bem-sucedido
            return true;
        }

        // Método chamado quando uma tecla é pressionada no campo de usuário
        private void usuario_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas a entrada de dígitos numéricos e a tecla de retrocesso
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Ignora a tecla pressionada
            }
        }
    }
}

