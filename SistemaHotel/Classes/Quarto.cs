using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Quarto
    {
        int numero;
        int andar;
        string descricao;
        bool ocupado;
        int ocupacao_maxima;

        public int Numero { get => numero; set => numero = value; }
        public int Andar { get => andar; set => andar = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public bool Ocupado { get => ocupado; set => ocupado = value; }
        public int Ocupacao_maxima { get => ocupacao_maxima; set => ocupacao_maxima = value; }

        public Quarto(int numero, int andar, string descricao, bool ocupado, int ocupacao_maxima)
        {
            this.Numero = numero;
            this.Andar = andar;
            this.Descricao = descricao;
            this.Ocupado = ocupado;
            this.Ocupacao_maxima = ocupacao_maxima;
        }

        public Quarto() { }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;

        public void inserir(int numero, int andar, string descricao, int ocupacao_maxima, bool ocupado = false)
        {
            try
            {
                con.AbrirCon();
                sql = "INSERT INTO Quarto (Numero, Andar, Descricao, Ocupado, Ocupacao_Maxima) VALUES (@Numero, @Andar, @Descricao, @Ocupado, @Ocupacao_Maxima)";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Numero", numero);
                cmd.Parameters.AddWithValue("@Andar", andar);
                cmd.Parameters.AddWithValue("@Descricao", descricao);
                cmd.Parameters.AddWithValue("@Ocupacao_Maxima", ocupacao_maxima);
                cmd.Parameters.AddWithValue("@Ocupado", ocupado);

                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir quarto na base -> Servidor SQL Erro: " + ex);
            }
        }

        public void alterar(int numero, int ocupacao_maxima, string descricao)
        {
            try
            {
                con.AbrirCon();
                sql = "UPDATE Quarto SET Ocupacao_Maxima = @Ocupacao_Maxima, Descricao = @descricao WHERE Numero = @numero";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@Ocupacao_Maxima", ocupacao_maxima);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar quarto na base -> Servidor SQL Erro: " + ex);
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

        public DataTable ListaQuarto()
        {
            try
            {
                con.AbrirCon();
                sql = "Select * from Quarto Order by numero asc";
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

        public void deletar(int numero)
        {
            try
            {
                con.AbrirCon();
                sql = "DELETE FROM Quarto WHERE Numero = @Numero";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Numero", numero);

                cmd.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar quarto na base -> Servidor SQL Erro: " + ex);
            }
        }


    }
}
