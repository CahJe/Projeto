using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Estadia
    {
        int id;
        int n_ocupantes;
        DateTime dataEntrada;
        DateTime dataSaida;
        int clienteId;
        int quartoNumero;
        bool ativo;
        DateTime dataCancelamento;

        public int Id { get => id; set => id = value; }
        public int N_ocupantes { get => n_ocupantes; set => n_ocupantes = value; }
        public DateTime DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public DateTime DataSaida { get => dataSaida; set => dataSaida = value; }
        public int ClienteId { get => clienteId; set => clienteId = value; }
        public int QuartoNumero { get => quartoNumero; set => quartoNumero = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
        public DateTime DataCancelamento { get => dataCancelamento; set => dataCancelamento = value; }

        public Estadia(int id, int n_ocupantes, DateTime dataEntrada, DateTime dataSaida, int clienteId, int quartoNumero, bool ativo, DateTime dataCancelamento)
        {
            this.Id = id;
            this.N_ocupantes = n_ocupantes;
            this.DataEntrada = dataEntrada;
            this.DataSaida = dataSaida;
            this.ClienteId = clienteId;
            this.QuartoNumero = quartoNumero;
            this.Ativo = ativo;
            this.DataCancelamento = dataCancelamento;
        }

        public Estadia() { }

    }
}
