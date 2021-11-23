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

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;


        public void inserir(int tipoFuncionarioId, int pessoaId)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO Funcionario (TipoFuncionarioId, PessoaId) VALUES (@TipoFuncionarioId, @PessoaId)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmd.Parameters.AddWithValue("@TipoFuncionarioId", tipoFuncionarioId);

                id = cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir funcionário na base -> Servidor SQL Erro: " + ex);
            }
        }

        public void alterar(int tipoFuncionarioId, int pessoaId)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Funcionario SET TipoFuncionarioId = @tipoFuncionarioId WHERE Id = @PessoaId";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@tipoFuncionarioId", tipoFuncionarioId);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar funcionario na base -> Servidor SQL Erro: " + ex);
            }
        }

        public void deletar(int pessoaId)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Funcionario SET DataInativação = getdate() WHERE Id = @PessoaId";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar funcionário na base -> Servidor SQL Erro: " + ex);
            }
        }

        public bool verificaExistencia(string Cpf)
        {
            SqlCommand cmdVerificar;

            cmdVerificar = new SqlCommand("SELECT * FROM Pessoa p JOIN Funcionario f on f.PessoaId = p.Id WHERE p.cpf = @cpf", con.con);
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


        public DataTable ListaFuncionario()
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT p.id, convert(varchar, p.DataCriacao, 103) as DataCriacao, p.CPF, p.Nome, tf.Descricao as Cargo,p.Sexo, p.Telefone,p.DDD,p.Email,ed.Estado, ed.Cidade, ed.Rua, ed.Numero, p.Senha FROM Pessoa p (nolock) JOIN Funcionario f (nolock) on f.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id JOIN TipoFuncionario tf (nolock) on tf.Id = f.TipoFuncionarioId Where f.DataInativacao is null Order by nome desc";
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

        public DataTable buscaCPF(string cpf)
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT p.id, convert(varchar, p.DataCriacao, 103) as DataCriacao, p.CPF, p.Nome, tf.Descricao as Cargo,p.Sexo, p.Telefone,p.DDD,p.Email,ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Funcionario f (nolock) on f.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id JOIN TipoFuncionario tf (nolock) on tf.Id = f.TipoFuncionarioId WHERE p.CPF = @cpf And f.DataInativacao is null";
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
                sql = "SELECT p.id, convert(varchar, p.DataCriacao, 103) as DataCriacao, p.CPF, p.Nome, tf.Descricao as Cargo,p.Sexo, p.Telefone,p.DDD,p.Email,ed.Estado, ed.Cidade, ed.Rua, ed.Numero FROM Pessoa p (nolock) JOIN Funcionario f (nolock) on f.PessoaId = p.Id JOIN Endereco ed (nolock)on p.EnderecoId = ed.Id JOIN TipoFuncionario tf (nolock) on tf.Id = f.TipoFuncionarioId WHERE p.nome LIKE @nome And f.DataInativacao is null";
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


    }
}
