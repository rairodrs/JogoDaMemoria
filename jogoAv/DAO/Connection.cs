using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using jogoAv.BO;
using jogoAv.Model;
namespace jogoAv.DAO
{
    class Connection
    {
        public static MySqlConnection Conectar()
        {
            string stringConexao = "SERVER=localhost;DATABASE=jogoAv;UID=root;PASSWORD='';";
            MySqlConnection conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }

        public static void CRUD(MySqlCommand comando)
        {
            MySqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();
        }

        public static MySqlDataReader Selecionar(MySqlCommand comando)
        {
            MySqlConnection con = Conectar();
            comando.Connection = con;
            MySqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}
