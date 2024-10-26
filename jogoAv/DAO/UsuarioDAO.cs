using jogoAv.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoAv.DAO
{
    class UsuarioDAO
    {
        public void Insert(Usuario usuario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into usuario(nome,tempo) values(@nome,@tempo);";

                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@tempo", usuario.Tempo);

                Connection.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel se conectar" + ex.Message);
            }
        }

      

        public IList<Usuario> Ranking (string tempo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * from usuario order by tempo;";

                comando.Parameters.AddWithValue("@tempo", tempo);  

                MySqlDataReader dr = Connection.Selecionar(comando);

                IList<Usuario> usuarios = new List<Usuario>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Nome = (string)dr["nome"];
                        usuario.Tempo = (int)dr["tempo"];
                        

                        usuarios.Add(usuario);

                    }
                }
                else
                {
                    usuarios = null;
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel se conectar" + ex.Message);
            }
        }
    }
}

