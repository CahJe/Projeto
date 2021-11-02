using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHotel.Classes
{
    public class Cliente
    {
        int id;
        int pessoaId;

        public int PessoaId { get => pessoaId; set => pessoaId = value; }
        public int Id { get => id; set => id = value; }

        public Cliente(int id, int pessoaId)
        {
            this.Id = id;
            this.PessoaId = pessoaId;            
        }

        public Cliente() { }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;

        public void inserir(int pessoaId)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO cliente (PessoaId) VALUES (@PessoaId)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Cpf", pessoaId);

                id = cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao inserir cliente na base: {0}", ex);
                throw;
            }
        }     

        public bool verificaExistencia(string Cpf)
        {
            SqlCommand cmdVerificar;

            cmdVerificar = new SqlCommand("SELECT * FROM Pessoa p JOIN Cliente c on c.PessoaId = p.Id WHERE p.cpf = @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", Cpf);
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
                Console.WriteLine("Falha de conexão com a base: {0}", ex);
                throw;

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
                Console.WriteLine("Falha de conexão com a base: {0}", ex);
                throw;

            }
        }


        public DataTable ListaCliente()
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT convert(varchar, p.DataCriacao, 103) DataCriacao, p.CPF, p.Nome,p.Sexo, p.Telefone,p.DDD,p.Email, ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Cliente c (nolock) on c.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id Order by nome desc";
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
                Console.WriteLine("Falha de conexão com a base: {0}", ex);
                throw;

            }
        }
    }
}
