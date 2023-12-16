using MySql.Data.MySqlClient;

// Declaração do namespace WinBankingApp.Classes
namespace WinBankingApp.Classes
{
    // Definição da classe ConexaoDb
    class ConexaoDb
    {
        // Declaração de variáveis para informações de conexão com o banco de dados
        private const string server = "localhost";
        private const string database = "bankingapp";
        private const string user = "root";
        private const string password = "sample";

        // Construção da string de conexão com o banco de dados
        static public string dbConnection = $"server={server}; user id={user}; database={database}; password={password}";

        // Método estático para obter um usuário pelo CPF
        public static Usuario ObterUsuarioPorCPF(string cpf)
        {
            try
            {
                // Criação de uma conexão com o banco de dados
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                // Construção da consulta SQL para selecionar um usuário pelo CPF
                string selectQuery = $"SELECT * FROM bankingapp.usuarios WHERE cpf_cnpj = '{cpf}'";

                // Criação de um comando SQL com a consulta e associação à conexão
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                // Execução da consulta e obtenção de um leitor de dados
                MySqlDataReader reader = command.ExecuteReader();

                // Inicialização de uma instância de Usuario
                Usuario usuario = null;

                // Verificação se há linhas no resultado da consulta
                if (reader.Read())
                {
                    // Preenchimento dos dados do usuário a partir do resultado da consulta
                    usuario = new Usuario
                    {
                        id = Convert.ToInt16(reader["id"]),
                        nome = reader["nome_completo"].ToString(),
                        cpf_cnpj = reader["cpf_cnpj"].ToString(),
                        email = reader["email"].ToString(),
                        senha = reader["senha"].ToString(),
                        tipo_usuario = reader["tipo_usuario"].ToString(),
                        saldo = Convert.ToDouble(reader["saldo"])
                    };
                }

                // Fechamento do leitor de dados e da conexão
                reader.Close();
                connection.Close();

                // Verificação se um usuário foi encontrado
                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    // Mensagem indicando que o usuário com o CPF fornecido não foi encontrado
                    Console.WriteLine($"Usuário com CPF {cpf} não encontrado.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Exibição de uma mensagem em caso de erro durante o processo
                Console.WriteLine($"Erro ao obter usuário por CPF: {ex.Message}");
                return null;
            }
        }
    }
}
