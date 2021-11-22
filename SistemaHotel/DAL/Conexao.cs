using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.DAL
{
    public class Conexao
    {

        //CONEXAO COM O BANCO DE DADOS LOCAL
        public string conec = @"Data Source = DESKTOP-LFU4RFH\SQLEXPRESS;Initial Catalog = Hotel;Integrated Security = True";
        // "Data Source = DESKTOP - LFU4RFH\SQLEXPRESS;Initial Catalog = Projeto login;Integrated Security = True"


        public SqlConnection con = null;

        public void AbrirCon()
        {
            try
            {
                con = new SqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na conexão com o Banco! " + ex.Message);
            }

            
        }


        public void FecharCon()
        {
            try
            {
                con = new SqlConnection(conec);
                con.Close();
                con.Dispose();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na conexão com o Banco! " + ex.Message);
            }
        }              

    }


}
