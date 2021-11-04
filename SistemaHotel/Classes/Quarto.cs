using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Quarto
    {
        int numero;
        int andar;
        string descricao;
        bool ocupado;
        int ocupacao_maxima;

        public int Numero { get => numero; set => numero = value; }
        public int Andar { get => andar; set => andar = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public bool Ocupado { get => ocupado; set => ocupado = value; }
        public int Ocupacao_maxima { get => ocupacao_maxima; set => ocupacao_maxima = value; }

        public Quarto(int numero, int andar, string descricao, bool ocupado, int ocupacao_maxima)
        {
            this.Numero = numero;
            this.Andar = andar;
            this.Descricao = descricao;
            this.Ocupado = ocupado;
            this.Ocupacao_maxima = ocupacao_maxima;
        }

        public Quarto() { }





    }
}
