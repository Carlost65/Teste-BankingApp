using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WinBankingApp.Classes
{
    internal class Usuario
    {
        private int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf_cnpj { get; set; }
        public string senha { get; set; }
        public string tipo_usuario {  get; set; }
        public double saldo {  get; set; }

        //metodo para cadastrar usuarios no banco
        public bool cadastrarUsuario()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConexaoDb.dbConnection);
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                string insert = "INSERT INTO bankingapp.usuarios(nome_completo, cpf_cnpj, email, senha, tipo_usuario, saldo) VALUES(@nome, @cpf_cnpj, @email, @senha, @tipo_usuario, @saldo);";
                MySqlCommand command = new MySqlCommand(insert, connection, transaction);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@cpf_cnpj", cpf_cnpj);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@tipo_usuario", tipo_usuario);
                command.Parameters.AddWithValue("@saldo", saldo);
                command.ExecuteNonQuery();  // Executa a consulta
                transaction.Commit();
                connection.Close();
                return true;

            }catch(Exception exception)
            {
                MessageBox.Show("erro no cadastro - metodo cadastrarUsuarios" + exception.Message);
                return false;
            }
        }
    }
}
