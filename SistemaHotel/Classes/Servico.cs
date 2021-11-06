using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;

        public void inserir(string tipo, string descricao, decimal valor, bool ativo = true)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO Servico (Tipo, Descricao, Valor, Ativo) VALUES (@tipo, @descricao, @valor, @ativo)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@ativo", ativo);

                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir serviço na base -> Servidor SQL Erro: " + ex);
            }
        }

        public void alterar(int id, string descricao, decimal valor, bool ativo)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Servico SET Descricao = @descricao, Valor = @valor, Ativo = @ativo WHERE Id = @Id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@ativo", ativo);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar serviço na base -> Servidor SQL Erro: " + ex);
            }
        }


        public bool verificaExistencia(int Numero)
        {
            SqlCommand cmdVerificar;

            cmdVerificar = new SqlCommand("SELECT * FROM Quarto WHERE Numero = @Numero", con.con);
            cmdVerificar.Parameters.AddWithValue("@Numero", Numero);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public DataTable ListaServico()
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT * FROM servicos order by Tipo asc";
                cmd = new SqlCommand(sql, con.con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.FecharCon();

                return dt;

            }
            catch (Exception ex)
            {

                throw new Exception("Servidor SQL Erro: " + ex);
            }
        }

        public void deletar(int id)
        {
            try
            {
                con.AbrirCon();
                sql = "DELETE FROM Servico WHERE Id = @Id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar serviço na base -> Servidor SQL Erro: " + ex);
            }
        }
    }
}
