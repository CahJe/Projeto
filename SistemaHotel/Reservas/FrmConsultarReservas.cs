using SistemaHotel.Classes;
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

namespace SistemaHotel.Reservas
{
    public partial class FrmConsultarReservas : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        Estadia estadia = new Estadia();
        string id;
        string valor;

        public FrmConsultarReservas()
        {
            InitializeComponent();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "Id";
            grid.Columns[1].HeaderText = "QuartoNumero";
            grid.Columns[2].HeaderText = "Andar";
            grid.Columns[3].HeaderText = "Descricao";
            grid.Columns[4].HeaderText = "DataEntrada";
            grid.Columns[5].HeaderText = "DataSaida";
            grid.Columns[6].HeaderText = "DataCancelamento";
            grid.Columns[7].HeaderText = "Status";
            grid.Columns[8].HeaderText = "Cliete";
                        
            grid.Columns[0].Visible = false;

            grid.Columns[1].Width = 60;
            grid.Columns[4].Width = 60;
            grid.Columns[11].Width = 60;
            grid.Columns[12].Width = 60;
            grid.Columns[13].Width = 60;
        }

        private void ListarData()
        {
            bool ativo = true;

            var dt = estadia.Lista(dtBuscarReserva.Value, ativo);
            grid.DataSource = dt;

            FormatarDG();
        }


        private void ListarDataInicio()
        {


            FormatarDG();
        }


        private void ListarNome()
        {


            FormatarDG();
        }


        private void HabilitarBotoes()
        {
            btnRemove.Enabled = true;
        }

        private void DesabilitarBotoes()
        {
            grid.Enabled = false;
            btnRemove.Enabled = false;
            BtnListar.Enabled = true;
        }


        private void FrmConsultarReservas_Load(object sender, EventArgs e)
        {
            //dtBuscarReserva.Value = DateTime.Today;
            //ListarData();
            DesabilitarBotoes();
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            ListarNome();
        }

        private void DtBuscarInicioReserva_ValueChanged(object sender, EventArgs e)
        {
            //ListarDataInicio();
        }

        private void DtBuscarReserva_ValueChanged(object sender, EventArgs e)
        {
            //ListarData();
        }

        private void CbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListarData();
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarBotoes();
            id = grid.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            bool ativo = false;

            var resultado = MessageBox.Show("Deseja Realmente Cancelar a reserva?", "Cancelar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.AbrirCon();
                sql = "UPDATE Estadia SET Ativo = @ativo, DataCancelamento = @data where id = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@status", ativo);
                cmd.Parameters.AddWithValue("@data", DateTime.Today);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();

                MessageBox.Show("Reserva cancelada com Sucesso!", "Reserva cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ListarData();
            DesabilitarBotoes();            
        }

        private void BtnRel_Click(object sender, EventArgs e)
        {


        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            var dt = estadia.Lista(dtBuscarReserva.Value, cbAtivo.Checked);
            grid.DataSource = dt;
            grid.Enabled = true;

            FormatarDG();
        }
    }
}
