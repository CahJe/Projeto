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




        private void FormatarDGCheckIn()
        {
            //grid.Columns[0].HeaderText = "ID";
            //grid.Columns[1].HeaderText = "Quarto";
            //grid.Columns[2].HeaderText = "Data Entrada";
            //grid.Columns[3].HeaderText = "Data Saída";
            //grid.Columns[4].HeaderText = "Dias";
            //grid.Columns[5].HeaderText = "Valor";
            //grid.Columns[6].HeaderText = "Nome";
            //grid.Columns[7].HeaderText = "Telefone";
            //grid.Columns[8].HeaderText = "Data";
            //grid.Columns[9].HeaderText = "Funcionario";
            //grid.Columns[10].HeaderText = "Status";
            //grid.Columns[11].HeaderText = "Check-In";

            //grid.Columns[12].HeaderText = "Check-Out";
            //grid.Columns[13].HeaderText = "Pago";

            //grid.Columns[0].Visible = false;

            
            //grid.Columns[5].Visible = false;
            //grid.Columns[8].Visible = false;
            //grid.Columns[9].Visible = false;
            //grid.Columns[10].Visible = false;
            //grid.Columns[12].Visible = false;
            

            //grid.Columns[1].Width = 60;
            //grid.Columns[4].Width = 60;
            //grid.Columns[11].Width = 60;
            //grid.Columns[12].Width = 60;
            //grid.Columns[13].Width = 60;
        }

        private void ListarCheckIn()
        {

            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where entrada = curDate() and status = @status and checkin = @checkin order by quarto asc";
            //cmd = new SqlCommand(sql, con.con);
           
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //cmd.Parameters.AddWithValue("@checkin", "Não");

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //grid.DataSource = dt;
            //con.FecharCon();

            //FormatarDGCheckIn();
        }




        private void FormatarDGCheckOut()
        {
            //grid2.Columns[0].HeaderText = "ID";
            //grid2.Columns[1].HeaderText = "Quarto";
            //grid2.Columns[2].HeaderText = "Data Entrada";
            //grid2.Columns[3].HeaderText = "Data Saída";
            //grid2.Columns[4].HeaderText = "Dias";
            //grid2.Columns[5].HeaderText = "Valor";
            //grid2.Columns[6].HeaderText = "Nome";
            //grid2.Columns[7].HeaderText = "Telefone";
            //grid2.Columns[8].HeaderText = "Data";
            //grid2.Columns[9].HeaderText = "Funcionario";
            //grid2.Columns[10].HeaderText = "Status";
            //grid2.Columns[11].HeaderText = "Check-In";

            //grid2.Columns[12].HeaderText = "Check-Out";
            //grid2.Columns[13].HeaderText = "Pago";

            //grid2.Columns[0].Visible = false;


            //grid2.Columns[5].Visible = false;
            //grid2.Columns[8].Visible = false;
            //grid2.Columns[9].Visible = false;
            //grid2.Columns[10].Visible = false;
            //grid2.Columns[11].Visible = false;
           

            //grid2.Columns[1].Width = 60;
            //grid2.Columns[4].Width = 60;
            //grid2.Columns[11].Width = 60;
            //grid2.Columns[12].Width = 60;
            //grid2.Columns[13].Width = 60;
        }

        private void ListarCheckOut()
        {

            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where saida = curDate() and status = @status and checkout = @checkout order by quarto asc";
            //cmd = new SqlCommand(sql, con.con);

            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //cmd.Parameters.AddWithValue("@checkout", "Não");

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //grid2.DataSource = dt;
            //con.FecharCon();

            //FormatarDGCheckOut();
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
            con.AbrirCon();
            //sql = "SELECT * FROM reservas where data = @data and status = @status";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalReservasDia = dt.Rows.Count;
            //lblTotalReservas.Text = totalReservasDia.ToString();
            //con.FecharCon();
        }


        private void BuscarQuartosDisponiveis()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM ocupacoes where data = @data";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalQuartosDisponiveis = dt.Rows.Count;


            //BUSCAR TOTAL DE QUARTOS
            //sql = "SELECT * FROM quartos";
            //cmd = new SqlCommand(sql, con.con);
            
            //SqlDataAdapter da2 = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt2 = new DataTable();
            //da.Fill(dt2);
            //totalQuartos = dt2.Rows.Count;
            //double total;
            //total = totalQuartos - totalQuartosDisponiveis;
            //lblQuartosDisponiveis.Text = total.ToString();
            //con.FecharCon();
        }


        private void BuscarQuartosOcupados()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM ocupacoes where data = @data";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalQuartosOcupados = dt.Rows.Count;
            //lblQuartosOcupados.Text = totalQuartosOcupados.ToString();
            //con.FecharCon();
        }


        private void BuscarTotalCheckIn()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where entrada = @data and status = @status";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalCheckIn = dt.Rows.Count;
            //lblTotalCheckIn.Text = totalCheckIn.ToString();
            //con.FecharCon();
        }


        private void BuscarTotalCheckOut()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where saida = @data and status = @status";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalCheckOut = dt.Rows.Count;
            //lblTotalCheckOut.Text = totalCheckOut.ToString();
            //con.FecharCon();
        }


        private void BuscarTotalCheckInConfirmados()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where entrada = @data and status = @status and checkin = @checkin";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //cmd.Parameters.AddWithValue("@checkin", "Sim");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalCheckInConfirmados = dt.Rows.Count;
            //lblCheckIn.Text = totalCheckInConfirmados.ToString();
            //con.FecharCon();
        }

        private void BuscarTotalCheckOutConfirmados()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM reservas where saida = @data and status = @status and checkout = @checkout";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@data", DateTime.Today);
            //cmd.Parameters.AddWithValue("@status", "Confirmada");
            //cmd.Parameters.AddWithValue("@checkout", "Sim");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //totalCheckOutConfirmados = dt.Rows.Count;
            //lblCheckOut.Text = totalCheckOutConfirmados.ToString();
            //con.FecharCon();
        }


        private void VerificarEstoque()
        {
            //con.AbrirCon();
            //sql = "SELECT * FROM produtos where estoque < @estoque";
            //cmd = new SqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@estoque", 15);
            
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    lblEstoque.Text = "Estoque Baixo!";
            //    imgEstoque.Image = Properties.Resources.baixo;
            //}
            //else
            //{
            //    lblEstoque.Text = "Estoque Bom!";
            //    imgEstoque.Image = Properties.Resources.bom;
            //}
            //con.FecharCon();
        }



        private void FrmMenu_Activated(object sender, EventArgs e)
        {
                       
         
        }

        private void chamarMetodos()
        {
            BuscarReservasDia();
            BuscarQuartosDisponiveis();
            BuscarQuartosOcupados();
            BuscarTotalCheckIn();
            BuscarTotalCheckOut();
            BuscarTotalCheckInConfirmados();
            BuscarTotalCheckOutConfirmados();
            VerificarEstoque();

            ListarCheckOut();
            ListarCheckIn();
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
            Reservas.FrmConsultarReservas form = new Reservas.FrmConsultarReservas();
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Reservas.FormReservas form = new Reservas.FormReservas();
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

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (pago == "Sim")
            {
                con.AbrirCon();
                sql = "UPDATE reservas SET checkin = @checkin where id = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@checkin", "Sim");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();
                ListarCheckIn();
                //btnConfirmar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Você precisa antes confirmar o pagamento!");
                //btnConfirmar.Enabled = false;
            }
        }

        private void Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnConfirmar2.Enabled = true;
            //id = grid2.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnConfirmar2_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            sql = "UPDATE reservas SET checkout = @checkout where id = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@checkout", "Sim");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.FecharCon();
            ListarCheckOut();
            //btnConfirmar2.Enabled = false;


            con.AbrirCon();
            sql = "DELETE from ocupacoes where id_reserva = @id";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            sql = "UPDATE reservas SET pago = @pago where id = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@pago", "Sim");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.FecharCon();

            //SALVAR VALOR DA RESERVA NA TABELA DE MOVIMENTAÇÕES
            con.AbrirCon();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Reserva");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(valor));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", id);


            cmd.ExecuteNonQuery();
            con.FecharCon();


            MessageBox.Show("Lançamento de Valor Efetuado!", "Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListarCheckIn();
            //btnPago.Enabled = false;
        }

        private void LimparDadosMovimentaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (backupFeito == "Sim")
            {
                var resultado = MessageBox.Show("Deseja limpar todas as movimentações de " + ano + " ?", "Limpar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA EXCLUIR
                    con.AbrirCon();
                    sql = "DELETE FROM movimentacoes where data >= @dataInicial and data <= @dataFinal";
                    cmd = new SqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                    cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));
                    cmd.ExecuteNonQuery();
                    con.FecharCon();

                    MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faça antes o Backup!", "Registro não Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            backupFeito = "";
        }

        private void BackupDoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup();
            backupFeito = "Sim";
        }

        private void backup()
        {
            string constring = con.conec;

            // Important Additional Connection Options
            constring += "charset=utf8;convertzerodatetime=true;";
            string data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
            string file = "backup/backup-" + data + ".sql";
            
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                        cmd.Connection = conn;
                        conn.Open();
                        //mb.ExportToFile(file);x
                        conn.Close();
                    
                }
            }

            MessageBox.Show("Backup Efetuado Data: " + data, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if(backupFeito == "Sim")
            {
                var resultado = MessageBox.Show("Deseja limpar todas as reservas de " + ano + " ?", "Limpar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA EXCLUIR
                    con.AbrirCon();
                    sql = "DELETE FROM reservas where entrada >= @entrada and saida <= @saida";
                    cmd = new SqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@entrada", Convert.ToDateTime(dataInicial));
                    cmd.Parameters.AddWithValue("@saida", Convert.ToDateTime(dataFinal));
                    cmd.ExecuteNonQuery();
                    con.FecharCon();

                    MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faça antes o Backup!", "Registro não Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            backupFeito = "";

        }
    }
}
