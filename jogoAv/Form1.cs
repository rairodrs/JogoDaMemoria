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
    public partial class Form1 : Form
    {
       
        int movimentos, cliques, cartasEncontradas, tagIndex;
        Image[] img = new Image[9];
        List<String> lista = new List<string>();

        int[] tags = new int[2];

        int quantidade = 0;

        Usuario usuario = new Usuario();
        UsuarioBO usuarioBO = new UsuarioBO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        

        public Form1()
        {

            InitializeComponent();
            inicio();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
        private void inicio()
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                int tagIndex = int.Parse(String.Format("{0}", item.Tag));
                img[tagIndex] = item.Image;
                item.Image = Properties.Resources.back;
                item.Enabled = true;

            }
            Posicoes();
        }

        private void Posicoes()
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                Random rdn = new Random();

                int[] xP = { 100, 198, 298, 394, 501, 612 };
                int[] yP = { 3, 116, 224 };

            Repete:

                var x = xP[rdn.Next(0, xP.Length)];

                var y = yP[rdn.Next(0, yP.Length)];



                string verificacao = x.ToString() + y.ToString();

                if (lista.Contains(verificacao))
                {
                    goto Repete;
                }
                else
                {
                    item.Location = new Point(x, y);
                    lista.Add(verificacao);
                }

            }

        }
        private void ImagensClick_click(object sender, EventArgs e)
        {
            bool parEncontrado = false;

            PictureBox pic = (PictureBox)sender;
            cliques++;
            tagIndex = int.Parse(String.Format("{0}", pic.Tag));
            pic.Image = img[tagIndex];
            pic.Refresh();

            if (cliques == 1)
            {
                tags[0] = int.Parse(String.Format("{0}", pic.Tag));
            }
            else if (cliques == 2)
            {
                movimentos++;
                label1.Text = "Movimentos: "+movimentos.ToString();
                tags[1] = int.Parse(String.Format("{0}", pic.Tag));
                parEncontrado = ChecagemPares();
                Desvirar(parEncontrado);
            }
        }

    

        private void Timer1_Tick(object sender, EventArgs e)
        {
            quantidade++;
            label2.Text = quantidade.ToString(); 
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            quantidade++;
            labelt2.Text = quantidade.ToString();
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool ChecagemPares()
        {
            cliques = 0;
            if (tags[0] == tags[1]) { return true; } else { return false; }
        }
        private void Desvirar(bool check)
        {
            Thread.Sleep(500);
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                if (int.Parse(String.Format("{0}", item.Tag)) == tags[0] ||
                    int.Parse(String.Format("{0}", item.Tag)) == tags[1])
                {
                    if (check == true)
                    {
                        item.Enabled = false;
                        cartasEncontradas++;
                    }
                    else
                    {
                        item.Image = Properties.Resources.back;
                        item.Refresh();

                    }
                }
            }
            FinalJogo();
        }

       

        private void FinalJogo()
        {
            if (cartasEncontradas == (img.Length * 2))
            {
               

                Usuario usuario = new Usuario();
                UsuarioBO usuarioBO = new UsuarioBO();

              

                timer1.Enabled = false;
                MessageBox.Show("Parabéns, "+txtNome.Text+" você terminou o jogo com " + movimentos.ToString() + " movimentos "+"e "+quantidade+"s");
                DialogResult msg=MessageBox.Show("Deseja recomeçar?", "", MessageBoxButtons.YesNo);

                    inicio frm = new inicio();
                usuario.Tempo = quantidade;
                usuario.Nome = txtNome.Text;

                usuarioBO.Gravar(usuario);
         

                if (msg == DialogResult.No)
                {
                   
                    MessageBox.Show("Obrigada por jogar "+txtNome.Text+"\n Até mais >.<");
                    Form1 frm1 = new Form1();
                    frm1.Close();

                    Ranking abrir = new Ranking();
                    abrir.ShowDialog();

                    Application.Exit();
                }
                else if (msg == DialogResult.Yes)
                {
                    movimentos = 0;
                    quantidade = 0;
                    cliques = 0;
                    cartasEncontradas = 0; 
                    lista.Clear();
                    inicio();
                    timer1.Stop();
                    timer1.Start();


                }
                
            }
        }
    }
}

