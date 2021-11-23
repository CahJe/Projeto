using SistemaHotel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel
{
    public partial class FrmMenu : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;

        Int32 totalReservasDia;
        Int32 totalQuartosDisponiveis;
        Int32 totalQuartosOcupados;
        Int32 totalCheckIn;
        Int32 totalCheckOut;
        Int32 totalCheckInConfirmados;
        Int32 totalCheckOutConfirmados;

        Int32 totalQuartos;

        string pago;
        string valor;

        string backupFeito;

        

        //variaveis para buscar o ultimo ano
        Int32 ano;
        DateTime data = DateTime.Now;
        string dataInicial, dataFinal;
       

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Hide();
            FrmLogin form = new FrmLogin();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            pnlTopo.BackColor = Color.FromArgb(230, 230, 230);
            pnlRight.BackColor = Color.FromArgb(130, 130, 130);

           
            lblUsuario.Text = Program.nomeUsuario;
            lblCargo.Text = Program.cargoUsuario;

            lblData.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");

            VerificarNivelUsuario();

            ano = data.Year - 1;

            dataInicial = "01/01/" + ano;
            dataFinal = "31/12/" + ano;

            chamarMetodos();

        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmFuncionarios form = new Cadastros.FrmFuncionarios();
            form.Show();
        }

        private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmCargo form = new Cadastros.FrmCargo();
            form.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void NovoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void ServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmServicos form = new Cadastros.FrmServicos();
            form.Show();
        }

        private void RelatórioDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void NovaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {


        }

        private void RelatórioDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EntradasESaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HóspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmHospedes form = new Cadastros.FrmHospedes();
            form.Show();
        }

        private void QuartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmQuartos form = new Cadastros.FrmQuartos();
            form.Show();
        }

        private void NovoServiçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void RelatórioDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RelatórioDeMovimentaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RelatórioDeMovimentaçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void NovaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FormReservas form = new Reservas.FormReservas();
            form.Show();
        }

        private void QuadroDeReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FrmConsultarReservas form = new Reservas.FrmConsultarReservas();
            form.Show();
        }

        private void NovoServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CheckOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void BuscarReservasDia()
        {
            bool ativo = true;

            con.AbrirCon();
            sql = "SELECT * FROM Estadia where DataEntrada = @data and Ativo = @status";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            cmd.Parameters.AddWithValue("@status", ativo);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalReservasDia = dt.Rows.Count;
            lblTotalReservas.Text = totalReservasDia.ToString();
            con.FecharCon();
        }


        private void BuscarQuartosDisponiveis()
        {
            con.AbrirCon();
            sql = "SELECT * FROM Estadia e JOIN Quarto q on e.QuartoNumero = q.Numero WHERE cast(e.DataEntrada as date) = @data";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalQuartosDisponiveis = dt.Rows.Count;


            //BUSCAR TOTAL DE QUARTOS
            sql = "SELECT * FROM Quarto";
            cmd = new SqlCommand(sql, con.con);

            SqlDataAdapter da2 = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            totalQuartos = dt2.Rows.Count;
            double total;
            total = totalQuartos - totalQuartosDisponiveis;
            lblQuartosDisponiveis.Text = total.ToString();
            con.FecharCon();
        }


        private void BuscarQuartosOcupados()
        {
            con.AbrirCon();
            sql = "SELECT * FROM Estadia e JOIN Quarto q on e.QuartoNumero = q.Numero WHERE cast(e.DataEntrada as date) = @data";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalQuartosOcupados = dt.Rows.Count;
            lblQuartosOcupados.Text = totalQuartosOcupados.ToString();
            con.FecharCon();
        }


        private void BuscarTotalCheckIn()
        {
            
        }


        private void BuscarTotalCheckOut()
        {
            
        }


        private void BuscarTotalCheckInConfirmados()
        {
            
        }

        private void BuscarTotalCheckOutConfirmados()
        {
            
        }


       



        private void FrmMenu_Activated(object sender, EventArgs e)
        {
                       
         
        }

        private void chamarMetodos()
        {
            BuscarReservasDia();
            BuscarQuartosDisponiveis();
            BuscarQuartosOcupados();
        }

        private void EstoqueBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LblEstoque_Click(object sender, EventArgs e)
        {

        }

        private void ImgEstoque_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Reservas.FormReservas form = new Reservas.FormReservas();
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Reservas.FrmConsultarReservas form = new Reservas.FrmConsultarReservas();
            form.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
        }

        private void Button6_Click(object sender, EventArgs e)
        {
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }


        private void VerificarNivelUsuario()
        {
            if (lblCargo.Text == "Gerente")
            {
                funcionáriosToolStripMenuItem.Enabled = true;
                quartosToolStripMenuItem.Enabled = true;
                serviçosToolStripMenuItem.Enabled = true;
                cargoToolStripMenuItem.Enabled = true;
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnConfirmar.Enabled = true;
            //btnPago.Enabled = true;
            //id = grid.CurrentRow.Cells[0].Value.ToString();
            //pago = grid.CurrentRow.Cells[13].Value.ToString();
            //valor = grid.CurrentRow.Cells[5].Value.ToString();
        }

        
        private void Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnConfirmar2.Enabled = true;
            //id = grid2.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnConfirmar2_Click(object sender, EventArgs e)
        {
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
 
        }

        private void LimparDadosMovimentaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BackupDoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void backup()
        {
            //    string constring = con.conec;

            //    // Important Additional Connection Options
            //    constring += "charset=utf8;convertzerodatetime=true;";
            //    string data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
            //    string file = "backup/backup-" + data + ".sql";
                
            //    using (SqlConnection conn = new SqlConnection(constring))
            //    {
            //        using (SqlCommand cmd = new SqlCommand())
            //        {
                        
            //                cmd.Connection = conn;
            //                conn.Open();
            //                //mb.ExportToFile(file);x
            //                conn.Close();
                        
            //        }
            //    }

            //    MessageBox.Show("Backup Efetuado Data: " + data, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
        }

        private void FrmMenu_Deactivate(object sender, EventArgs e)
        {
            
             
            
        }

        private void Button8_Click(object sender, EventArgs e)
        {
                      
            chamarMetodos();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblTotalReservas_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LimparDadosReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
