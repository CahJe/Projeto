using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Servico
    {
        int id;
        string tipo;
        string descricao;
        decimal valor;
        bool ativo;        

        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public bool Ativo { get => ativo; set => ativo = value; }

        public Servico(int id, string tipo, string descricao, decimal valor, bool ativo)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Valor = valor;
            this.Ativo = ativo;
        }

        public Servico() { }
    }
}
