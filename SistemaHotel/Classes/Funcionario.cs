using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Funcionario : Pessoa
    {
        int id;
        int tipoFuncionarioId;
        int pessoaId;
        DateTime dataInativacao;
        
        public int Id { get => id; set => id = value; }
        public int TipoFuncionarioId { get => tipoFuncionarioId; set => tipoFuncionarioId = value; }
        public int PessoaId { get => pessoaId; set => pessoaId = value; }
        public DateTime DataInativacao { get => dataInativacao; set => dataInativacao = value; }

        public Funcionario(int id, int tipoFuncionarioId, int pessoaId, DateTime dataInativacao)
        {
            this.Id = id;
            this.TipoFuncionarioId = tipoFuncionarioId;
            this.PessoaId = pessoaId;
            this.DataInativacao = dataInativacao;
        }

        public Funcionario() { }

    }
}
