using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using jogoAv.BO;
using jogoAv.Model;
using jogoAv.DAO;
using System.Media;

namespace jogoAv
{
    public partial class Ranking : Form
    {
        public Ranking()
        {

            InitializeComponent();
            UsuarioBO usuarioBO = new UsuarioBO();
            Usuario usuario = new Usuario();

           



        }
  

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
          

        
        }
       
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Usuario usuario = new Usuario();
            UsuarioBO usuarioBO = new UsuarioBO();


            DataGridViewRow linhaSelecionada;
            linhaSelecionada = dataGridView1.CurrentRow;
           
                usuario.Nome= linhaSelecionada.Cells[0].Value.ToString();
                string tempo = Convert.ToString(usuario.Tempo);
                tempo= linhaSelecionada.Cells[1].Value.ToString();


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBO usuarioBO = new UsuarioBO();
            dataGridView1.DataSource = usuarioBO.Selecionar(usuario);
        }
    }
}
