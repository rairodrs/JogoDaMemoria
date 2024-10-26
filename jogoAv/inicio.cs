using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jogoAv.BO;
using jogoAv.DAO;
using jogoAv.Model;

namespace jogoAv
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
           

            inicio frm = new inicio();
            frm.Close();

            Form1 abrir = new Form1();
            abrir.ShowDialog();
            UsuarioBO usuarioBO = new UsuarioBO();
            Usuario usuario = new Usuario();
        
        }
       

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
