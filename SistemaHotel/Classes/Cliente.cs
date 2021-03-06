using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SistemaHotel.DAL;

namespace SistemaHotel.Classes
{
    public class Cliente : Pessoa
    {
        int id;
        int pessoaId;
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;


        public int PessoaId { get => pessoaId; set => pessoaId = value; }
        public int Id { get => id; set => id = value; }

        public Cliente(int id, int pessoaId)
        {
            this.Id = id;
            this.PessoaId = pessoaId;            
        }

        public Cliente() { }

        
        public void inserir(int pessoaId)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO cliente (PessoaId) VALUES (@PessoaId)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

                id = cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir cliente na base -> Servidor SQL Erro: " + ex);
            }
        }     

        public bool verificaExistencia(string Cpf)
        {
            //SqlCommand cmdVerificar;

            //cmdVerificar = new SqlCommand("SELECT * FROM Pessoa p JOIN Cliente c on c.PessoaId = p.Id WHERE p.cpf = @cpf", con.con);
            //cmdVerificar.Parameters.AddWithValue("@cpf", Cpf);
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmdVerificar;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}

            //return false;
            con.AbrirCon();
            sql = "SELECT * FROM Pessoa p JOIN Cliente c on c.PessoaId = p.Id WHERE p.cpf = @cpf";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", Cpf);
            //SqlDataReader reader = cmd.ExecuteReader();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return true;
            }

            return false;
        }

        public DataTable buscaCPF(string cpf) 
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT convert(varchar, p.DataCriacao, 103) DataCriacao, p.CPF, p.Nome,p.Sexo, p.Telefone,p.DDD,p.Email, ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Cliente c (nolock) on c.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id WHERE p.CPF = @cpf";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@cpf", cpf);
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


        public DataTable buscaNome(string nome)
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT convert(varchar, p.DataCriacao, 103) DataCriacao, p.CPF, p.Nome,p.Sexo, p.Telefone,p.DDD,p.Email, ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Cliente c (nolock) on c.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id where p.nome LIKE @nome";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@nome", nome + "%");
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


        public DataTable ListaCliente()
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT p.id, convert(varchar, p.DataCriacao, 103) DataCriacao, p.CPF, p.Nome,p.Sexo, p.Telefone,p.DDD,p.Email, ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Cliente c (nolock) on c.PessoaId = p.Id JOIN Endereco ed (nolock) on p.EnderecoId = ed.Id Order by nome desc";
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

        public int retornaId(string cpf)
        {

            try
            {
                con.AbrirCon();
                sql = "SELECT Id FROM Pessoa WHERE Cpf = @cpf";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Cpf", cpf);

                PessoaId = cmd.ExecuteNonQuery();
                con.FecharCon();

                return PessoaId;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir cliente na base -> Servidor SQL Erro: " + ex);
            }


        }

        public int retornaclienteId(string cpf)
        {

            try
            {
                int IdCliente;
                con.AbrirCon();
                sql = "Select c.Id from Pessoa p join Cliente c on c.PessoaId = p.Id Where p.Cpf = @cpf";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Cpf", cpf);

                IdCliente = Convert.ToInt32(cmd.ExecuteScalar());
                con.FecharCon();

                return IdCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir cliente na base -> Servidor SQL Erro: " + ex);
            }


        }

    }
}
