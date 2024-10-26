using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jogoAv.Model;
using jogoAv.DAO;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace jogoAv.BO
{
    class UsuarioBO
    {
        public void Gravar(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            if ((usuario.Nome !="")&&(usuario.Tempo!=0))
            {
                usuarioDAO.Insert(usuario);
           
            }
        }

        public IList<Usuario> Selecionar(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();


            IList<Usuario> usuarioTemp = usuarioDAO.Ranking(Convert.ToString(usuario.Tempo));
            return usuarioTemp;


        }

    }
}
