using SistemaHotel.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;


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


        public int inserir(int n_ocupantes, DateTime DataEntrada, DateTime DataSaida, int ClienteId, int QuartoNumero, bool Ativo = true)
        {
            try
            {
                int Estadia;
                con.AbrirCon();
                sql = "INSERT INTO Estadia (n_ocupantes, DataEntrada, DataSaida, ClienteId, QuartoNumero, Ativo) VALUES (@n_ocupantes, @DataEntrada, @DataSaida, @ClienteId, @QuartoNumero, @Ativo) Select @@identity";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@n_ocupantes", n_ocupantes);
                cmd.Parameters.AddWithValue("@DataEntrada", DataEntrada);
                cmd.Parameters.AddWithValue("@DataSaida", DataSaida);
                cmd.Parameters.AddWithValue("@ClienteId", ClienteId);
                cmd.Parameters.AddWithValue("@QuartoNumero", QuartoNumero);
                cmd.Parameters.AddWithValue("@Ativo", Ativo);

                Estadia = Convert.ToInt32(cmd.ExecuteScalar());
                con.FecharCon();

                return Estadia;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir estadia na base -> Servidor SQL Erro: " + ex);
            }


        }

        public DataTable Lista(DateTime dataReserva, bool ativo) 
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT e.Id, e.QuartoNumero, q.Andar, q.Descricao, e.DataEntrada, e.DataSaida, e.DataCancelamento, case when e.Ativo = 1 then 'Ativo' else 'Inativo' end Status, p.Nome Cliente FROM Estadia e join Cliente c on c.Id = e.ClienteId join Pessoa p on p.Id = c.PessoaId join Quarto q on q.Numero = e.QuartoNumero where Cast(e.DataEntrada as date) = @data and e.Ativo = @ativo order by e.DataEntrada asc";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@data", dataReserva.Date);
                cmd.Parameters.AddWithValue("@ativo", ativo);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);                
                con.FecharCon();

                return dt;

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao consultar estadias na base -> Servidor SQL Erro: " + ex);
            }
            
        }


    }
}