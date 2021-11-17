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
    public class TipoFuncionario
    {
        int id;
        string descricao;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public TipoFuncionario(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public TipoFuncionario() { }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;

        public void inserir(string descricao)
        {
            try
            {
                con.AbrirCon();
                sql = "insert into TipoFuncionario (Id, Descricao) Values ((Select isnull(max(Id),0)+1 from TipoFuncionario), @descricao)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@descricao", descricao);

                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir pessoa na base -> Servidor SQL Erro: " + ex);
            }
        }

        public void alterar(int Id, string descricao)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE TipoFuncionario SET Descricao = @descricao WHERE Id = @Id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir pessoa na base -> Servidor SQL Erro: " + ex);
            }
        }

        public int retornaId(string descricao)
        {

            try
            {
                con.AbrirCon();
                sql = "SELECT Id FROM TipoFuncionario WHERE Cpf = @descricao";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@descricao", descricao);

                Id = cmd.ExecuteNonQuery();
                con.FecharCon();

                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir cliente na base -> Servidor SQL Erro: " + ex);
            }

        }


        public DataTable ListaTipo()
        {
            try
            {

                con.AbrirCon();
                sql = "SELECT * FROM TipoFuncionario order by Id";
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

        public void deletar(int Id)
        {
            try
            {
                con.AbrirCon();
                sql = "DELETE FROM TipoFuncionario where id = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir pessoa na base -> Servidor SQL Erro: " + ex);
            }
        }

    }
}
