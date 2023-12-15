using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBankingApp.Classes
{
    static class ConexaoDb
    {
        //declaração das variaves de informações do banco de dados 
        private const string server = "localhost";
        private const string database = "bankingapp";
        private const string user = "root";
        private const string password = "sample";

        //contrução da string de conexção com o banco de dados
        static public string dbConnection = $"server={server}; user id={user}; database={database}; password={password}";
    }
}
