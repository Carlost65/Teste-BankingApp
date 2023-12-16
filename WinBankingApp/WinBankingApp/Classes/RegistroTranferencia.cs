using MySql.Data.MySqlClient;

// Declaração do namespace WinBankingApp.Classes
namespace WinBankingApp.Classes
{
    // Definição da classe interna RegistroTranferencia
    internal class RegistroTranferencia
    {
        // Método para registrar uma transação no banco de dados
        public static void RegistrarTransacaoNoBanco(string cpfRemetente, string cpfDestinatario, double valor)
        {
            try
            {
                // Obtenção do ID do remetente e destinatário a partir de seus CPFs
                int remetenteId = ConexaoDb.ObterUsuarioPorCPF(cpfRemetente).id;
                int destinatarioId = ConexaoDb.ObterUsuarioPorCPF(cpfDestinatario).id;

                // Criação de uma conexão com o banco de dados
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                // Início de uma transação no banco de dados
                MySqlTransaction transaction = connection.BeginTransaction();

                // Preparação da consulta SQL para inserir uma nova transação
                string insertQuery = "INSERT INTO bankingapp.transacoes(remetente_id, destinatario_id, valor) VALUES(@remetente_id, @destinatario_id, @valor)";

                // Criação de um comando SQL com a consulta e associação à conexão e à transação
                MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction);

                // Adição de parâmetros à consulta para evitar injeção de SQL
                command.Parameters.AddWithValue("@remetente_id", remetenteId);
                command.Parameters.AddWithValue("@destinatario_id", destinatarioId);
                command.Parameters.AddWithValue("@valor", valor);

                // Execução da consulta para inserir a transação no banco de dados
                command.ExecuteNonQuery();

                // Confirmação da transação
                transaction.Commit();

                // Fechamento da conexão com o banco de dados
                connection.Close();
            }
            catch (Exception ex)
            {
                // Exibição de uma mensagem em caso de erro durante o processo
                MessageBox.Show($"Erro ao registrar transação no banco de dados: {ex.Message}");
            }
        }
    }
}

