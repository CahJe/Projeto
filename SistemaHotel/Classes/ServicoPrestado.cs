using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class ServicoPrestado
    {
        int servicoId;
        int estadiaId;
        bool ativo;
        
        public int ServicoId { get => servicoId; set => servicoId = value; }
        public int EstadiaId { get => estadiaId; set => estadiaId = value; }
        public bool Ativo { get => ativo; set => ativo = value; }

        public ServicoPrestado(int servicoId, int estadiaId, bool ativo)
        {
            this.ServicoId = servicoId;
            this.EstadiaId = estadiaId;
            this.Ativo = ativo;
        }

        public ServicoPrestado() { }

    }
}
