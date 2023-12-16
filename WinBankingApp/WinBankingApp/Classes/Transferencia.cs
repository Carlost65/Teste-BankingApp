using MySql.Data.MySqlClient;

// Declaração do namespace WinBankingApp.Classes
namespace WinBankingApp.Classes
{
    // Definição da classe interna Transferencia
    internal class Transferencia
    {
        // Método estático para realizar uma transferência entre usuários
        public static bool RealizarTransferencia(string cpfRemetente, string cpfDestinatario, double valor)
        {
            try
            {
                // Obtém informações do remetente e do destinatário a partir de seus CPFs
                Usuario remetente = ConexaoDb.ObterUsuarioPorCPF(cpfRemetente);
                Usuario destinatario = ConexaoDb.ObterUsuarioPorCPF(cpfDestinatario);

                // Verifica se os usuários são válidos
                if (remetente == null || destinatario == null)
                {
                    MessageBox.Show("Usuário inválido.");
                    return false;
                }

                // Verifica se o saldo do remetente é suficiente para a transferência
                if (remetente.saldo < valor)
                {
                    MessageBox.Show("Saldo insuficiente para realizar a transferência.");
                    return false;
                }

                // Verifica se o remetente é um lojista, pois lojistas só podem receber transferências
                if (remetente.tipo_usuario.Equals("lojista"))
                {
                    MessageBox.Show("Lojistas só podem receber transferências.");
                    return false;
                }

                // Verifica se o valor da transferência é maior que zero
                if (valor <= 0)
                {
                    MessageBox.Show("O valor da transferência deve ser maior que zero.");
                    return false;
                }

                // Realiza a transferência subtraindo o valor do remetente e adicionando ao destinatário
                remetente.saldo -= valor;
                destinatario.saldo += valor;

                // Atualiza os saldos no banco de dados
                AtualizarSaldoNoBanco(remetente);
                AtualizarSaldoNoBanco(destinatario);

                // Registra a transação no banco de dados
                RegistroTranferencia.RegistrarTransacaoNoBanco(cpfRemetente, cpfDestinatario, valor);

                // Exibe uma mensagem de sucesso com informações sobre a transferência
                MessageBox.Show($"Transferência de {valor:C} realizada com sucesso de {remetente.nome} para {destinatario.nome}.\nSeu saldo atual é de {remetente.saldo}.");
                return true;
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem em caso de erro durante o processo de transferência
                MessageBox.Show($"Erro ao realizar a transferência: {ex.Message}");
                return false;
            }
        }

        // Método privado para atualizar o saldo de um usuário no banco de dados
        private static void AtualizarSaldoNoBanco(Usuario usuario)
        {
            try
            {
                // Cria uma conexão com o banco de dados
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();

                // Constrói a consulta SQL para atualizar o saldo do usuário
                string updateQuery = $"UPDATE bankingapp.usuarios SET saldo = {usuario.saldo} WHERE cpf_cnpj = '{usuario.cpf_cnpj}'";

                // Cria um comando SQL com a consulta e o associa à conexão
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                // Executa a consulta para atualizar o saldo no banco de dados
                command.ExecuteNonQuery();

                // Fecha a conexão com o banco de dados
                connection.Close();
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem em caso de erro durante a atualização do saldo no banco de dados
                MessageBox.Show($"Erro ao atualizar saldo no banco de dados: {ex.Message}");
            }
        }
    }
}

