using SistemaHotel.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;


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


        public void inserir(int ServicoId, int EstadiaId, bool Ativo = true)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO ServicoPrestado (ServicoId, EstadiaId, Ativo) VALUES (@ServicoId, @EstadiaId, @Ativo)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@ServicoId", ServicoId);
                cmd.Parameters.AddWithValue("@EstadiaId", EstadiaId);
                cmd.Parameters.AddWithValue("@Ativo", Ativo);

                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir estadia na base -> Servidor SQL Erro: " + ex);
            }


        }
    }
}
