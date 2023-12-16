using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WinBankingApp.Classes
{
    internal class Transferencia
    {
        public static bool RealizarTransferencia(string cpfRemetente, string cpfDestinatario, double valor)
        {
            try
            {
                Usuario remetente = ConexaoDb.ObterUsuarioPorCPF(cpfRemetente);
                Usuario destinatario = ConexaoDb.ObterUsuarioPorCPF(cpfDestinatario);

                if (remetente == null || destinatario == null)
                {
                    MessageBox.Show("Usuário inválido.");
                    return false;
                }

                if (remetente.saldo < valor)
                {
                    MessageBox.Show("Saldo insuficiente para realizar a transferência.");
                    return false;
                }

                if (remetente.tipo_usuario.Equals("lojista"))
                {
                    MessageBox.Show("Lojistas só podem receber transferências.");
                    return false;
                }

                if (valor <= 0)
                {
                    MessageBox.Show("O valor da transferência deve ser maior que zero.");
                    return false;
                }

                // Realiza a transferência
                remetente.saldo -= valor;
                destinatario.saldo += valor;

                // Atualiza os saldos no banco de dados
                AtualizarSaldoNoBanco(remetente);
                AtualizarSaldoNoBanco(destinatario);

                RegistroTranferencia.RegistrarTransacaoNoBanco(cpfRemetente, cpfDestinatario, valor);

                MessageBox.Show($"Transferência de {valor:C} realizada com sucesso de {remetente.nome} para {destinatario.nome}./n Seu saldo atual é de {remetente.saldo}.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar a transferência: {ex.Message}");
                return false;
            }
        }

        private static void AtualizarSaldoNoBanco(Usuario usuario)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                string updateQuery = $"UPDATE bankingapp.usuarios SET saldo = {usuario.saldo} WHERE cpf_cnpj = '{usuario.cpf_cnpj}'";
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar saldo no banco de dados: {ex.Message}");
            }
        }
    }
}
