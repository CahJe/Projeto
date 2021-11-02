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
    }
}
