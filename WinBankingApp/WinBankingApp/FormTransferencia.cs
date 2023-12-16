using WinBankingApp.Classes;

namespace WinBankingApp
{
    // Declaração do namespace WinBankingApp

    // Classe parcial FormTransferencia que herda de Form
    public partial class FormTransferencia : Form
    {
        // Variável para armazenar o CPF do usuário
        private string cpfUsuario;

        // Construtor da classe FormTransferencia que recebe o CPF do usuário logado
        public FormTransferencia(string cpfLogin)
        {
            cpfUsuario = cpfLogin; // Atribui o CPF recebido à variável de classe
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        // Método chamado quando o botão Sair é clicado
        private void Sair_Click(object sender, EventArgs e)
        {
            // Cria e exibe um novo formulário de login
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close(); // Fecha o formulário de transferência
        }

        // Método chamado quando uma tecla é pressionada no campo de destinatário
        private void destinatario_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos numéricos e a tecla de retrocesso
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Ignora a tecla pressionada
            }
        }

        // Método chamado quando o botão de transferir é clicado
        private void transferir_Click(object sender, EventArgs e)
        {
            // Verifica se os campos estão preenchidos corretamente
            if (destinatario_text.Text.Equals("") || Convert.ToDouble(valor_transferencia_text.Text) <= 0)
            {
                MessageBox.Show("Preencha os campos corretamente!");
                return;
            }

            // Chama o método para realizar a transferência
            Transferencia.RealizarTransferencia(cpfUsuario, destinatario_text.Text, Convert.ToDouble(valor_transferencia_text.Text));
        }

        // Método chamado quando uma tecla é pressionada no campo de valor de transferência
        private void valor_transferencia_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtém o texto atual na TextBox
            string text = valor_transferencia_text.Text;

            // Permite apenas dígitos, backspace e ponto decimal
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true; // Ignora a tecla pressionada
            }

            // Permite apenas um ponto decimal
            if (e.KeyChar == ',' && text.Contains(','))
            {
                e.Handled = true; // Ignora a tecla pressionada
            }
        }
    }
}
