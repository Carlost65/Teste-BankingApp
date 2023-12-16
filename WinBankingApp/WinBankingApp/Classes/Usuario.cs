using MySql.Data.MySqlClient;

// Declaração do namespace WinBankingApp.Classes
namespace WinBankingApp.Classes
{
    // Definição da classe interna Usuario
    internal class Usuario
    {
        // Propriedades da classe representando os dados do usuário
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf_cnpj { get; set; }
        public string senha { get; set; }
        public string tipo_usuario { get; set; }
        public double saldo { get; set; }

        // Método para cadastrar usuários no banco de dados
        public bool cadastrarUsuario()
        {
            try
            {
                // Criação de uma conexão com o banco de dados
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                // Início de uma transação no banco de dados
                MySqlTransaction transaction = connection.BeginTransaction();

                // Preparação da consulta SQL para inserir um novo usuário
                string insert = "INSERT INTO bankingapp.usuarios(nome_completo, cpf_cnpj, email, senha, tipo_usuario, saldo) VALUES(@nome, @cpf_cnpj, @email, @senha, @tipo_usuario, @saldo);";
                MySqlCommand command = new MySqlCommand(insert, connection, transaction);

                // Adição de parâmetros à consulta para evitar injeção de SQL
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@cpf_cnpj", cpf_cnpj);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@tipo_usuario", tipo_usuario);
                command.Parameters.AddWithValue("@saldo", saldo);

                // Execução da consulta para inserir o novo usuário no banco de dados
                command.ExecuteNonQuery();

                // Confirmação da transação
                transaction.Commit();

                // Fechamento da conexão com o banco de dados
                connection.Close();

                // Indica que o cadastro foi bem-sucedido
                return true;
            }
            catch (Exception exception)
            {
                // Exibe uma mensagem em caso de erro durante o cadastro do usuário
                MessageBox.Show("Erro no cadastro - método cadastrarUsuarios: " + exception.Message);
                return false;
            }
        }
    }
}

