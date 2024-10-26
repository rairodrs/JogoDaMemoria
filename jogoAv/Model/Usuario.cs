using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jogoAv.BO;
using jogoAv.DAO;

namespace jogoAv.Model
{
    class Usuario
    {
        private string nome;
        private int tempo;

        public string Nome { get => nome; set => nome = value; }
        public int Tempo { get => tempo; set => tempo = value; }


    }
}
