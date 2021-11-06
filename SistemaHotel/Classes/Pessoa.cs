using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Pessoa
    {
        int id;
        DateTime dataCriacao;
        string cpf;
        string nome;
        string sexo;
        string telefone;
        string ddd;
        string email;
        string senha;
        int enderecoId;

        public int Id { get => id; set => id = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Ddd { get => ddd; set => ddd = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public int EnderecoId { get => enderecoId; set => enderecoId = value; }

        public Pessoa(int id, DateTime dataCriacao, string cpf, string nome, string sexo, string telefone, string ddd, string email, string senha, int enderecoId)
        {
            this.Id = id;
            this.DataCriacao = dataCriacao;
            this.Cpf = cpf;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Telefone = telefone;
            this.Ddd = ddd;
            this.Email = email;
            this.Senha = senha;
            this.EnderecoId = enderecoId;
        }

        public Pessoa() { }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;

        public int inserir(string cpf, string nome, string sexo, string telefone, string ddd, string email, int enderecoId, string senha = null)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO Pessoa (DataCriacao, CPF, Nome, Sexo, Telefone, DDD, Email, Senha, EnderecoId) VALUES ( getdate(), @Cpf, @Nome, @Sexo, @Telefone, @DDD, @Email, @Senha, @EnderecoId)  Select @@Identity;";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Cpf", cpf);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Sexo", sexo);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                cmd.Parameters.AddWithValue("@DDD", ddd);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);
                cmd.Parameters.AddWithValue("@EnderecoId", enderecoId);

                id = cmd.ExecuteNonQuery();
                con.FecharCon();

                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir pessoa na base -> Servidor SQL Erro: " + ex);
            }
        }


        public void alterar(int pessoaId, string cpf, string nome, string sexo, string telefone, string ddd, string email, string senha = null)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Pessoa SET Nome = @Nome, Sexo = @Sexo, Telefone = @Telefone, DDD = @DDD, Email = @Email, Senha = @Senha WHERE Id = @PessoaId";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Sexo", sexo);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                cmd.Parameters.AddWithValue("@DDD", ddd);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar pessoa na base -> Servidor SQL Erro: " + ex);
            }
        }

        public string retornaDDD(string telefone)
        {
            // Remove qualquer caracter que não seja numérico
            var numero = Regex.Replace(telefone, "[^0-9]+$", "");
            // Pega os 2 primeiros caracteres
            var ddd = numero.Substring(0, 2);

            return ddd;
        }

        public string retornaTelefone(string telefone)
        {
            // Remove qualquer caracter que não seja numérico
            var numero = Regex.Replace(telefone, "[^0-9]+$", "");
            // Pega os 2 primeiros caracteres
            var tel = numero.Substring(3, 9);

            return tel;
        }

        public void retornaPessoa(string cpf)
        {
            try
            {
                con.AbrirCon();
                sql = "SELECT Id, Cpf, Nome, sexo, Telefone, DDD, Email, Senha, EnderecoId FROM Pessoa WHERE Cpf = @cpf";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Cpf", cpf);

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.id = dr.GetInt32(0);
                    this.Cpf = dr.GetString(1);
                    this.Nome = dr.GetString(2);
                    this.Sexo = dr.GetString(3);
                    this.Telefone = dr.GetString(4);
                    this.Ddd = dr.GetString(5);
                    this.Email = dr.GetString(6);
                    this.Senha = dr.GetString(7);
                    this.EnderecoId = dr.GetInt32(8);
                }

                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir cliente na base -> Servidor SQL Erro: " + ex);
            }

        }
    }
}