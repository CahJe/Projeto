using SistemaHotel.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Endereco
    {
        int id;
        string estado;
        string cidade;
        string logradouro;
        string rua;
        int numero;

        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public string Rua { get => rua; set => rua = value; }
        public int Numero { get => numero; set => numero = value; }

        public Endereco(int id, string estado, string cidade, string logradouro, string rua, int numero)
        {
            this.id = id;
            this.estado = estado;
            this.cidade = cidade;
            this.logradouro = logradouro;
            this.rua = rua;
            this.numero = numero;
        }

        public Endereco() { }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        
        public int inserir(string estado, string cidade, string rua, int numero) 
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO Endereco (estado, cidade, rua, Numero) VALUES (@estado, @Cidade, @Rua, @Numero)  Select @@Identity;";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@Cidade", cidade);
                cmd.Parameters.AddWithValue("@Rua", rua);
                cmd.Parameters.AddWithValue("@Numero", numero);

                id = Convert.ToInt32(cmd.ExecuteScalar()); 
                con.FecharCon();

                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir Endereço na base -> Servidor SQL Erro: " + ex);
            }
                
        }

        public void alterar(int enderecoId, string estado, string cidade, string rua, int numero)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Endereco SET estado = @estado, cidade = @Cidade, rua = @Rua, Numero = @Numero WHERE Id = @EnderecoId";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@EnderecoId", enderecoId);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@Cidade", cidade);
                cmd.Parameters.AddWithValue("@Rua", rua);
                cmd.Parameters.AddWithValue("@Numero", numero);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar endereço na base -> Servidor SQL Erro: " + ex);
            }
        }


    }
}
