using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBankingApp.Classes
{
    internal class RegistroTranferencia
    {
        public static void RegistrarTransacaoNoBanco(string cpfRemetente, string cpfDestinatario, double valor)
        {
            try
            {
                int remetenteId = ConexaoDb.ObterUsuarioPorCPF(cpfRemetente).id;
                int destinatarioId = ConexaoDb.ObterUsuarioPorCPF(cpfDestinatario).id;

                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                // Preparar a consulta SQL para inserir uma nova transação
                string insertQuery = "INSERT INTO bankingapp.transacoes(remetente_id, destinatario_id, valor) VALUES(@remetente_id, @destinatario_id, @valor)";

                // Criar um comando SQL com a consulta e associá-lo à conexão e à transação
                MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction);

                // Adicionar parâmetros à consulta para evitar injeção de SQL
                command.Parameters.AddWithValue("@remetente_id", remetenteId);
                command.Parameters.AddWithValue("@destinatario_id", destinatarioId);
                command.Parameters.AddWithValue("@valor", valor);

                // Executar a consulta para inserir a transação no banco de dados
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar transação no banco de dados: {ex.Message}");
            }
        }
    }
}
