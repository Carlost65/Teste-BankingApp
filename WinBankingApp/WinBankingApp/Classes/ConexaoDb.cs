using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBankingApp.Classes
{
     class ConexaoDb
    {
        //declaração das variaves de informações do banco de dados 
        private const string server = "localhost";
        private const string database = "bankingapp";
        private const string user = "root";
        private const string password = "sample";

        //contrução da string de conexção com o banco de dados
        static public string dbConnection = $"server={server}; user id={user}; database={database}; password={password}";

        public static Usuario ObterUsuarioPorCPF(string cpf)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                string selectQuery = $"SELECT * FROM bankingapp.usuarios WHERE cpf_cnpj = '{cpf}'";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                Usuario usuario = null;

                if (reader.Read())
                {
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

                reader.Close();
                connection.Close();

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    // O usuário com o CPF fornecido não foi encontrado
                    Console.WriteLine($"Usuário com CPF {cpf} não encontrado.");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter usuário por CPF: {ex.Message}");
                return null;
            }
        }
    }
}
