using SistemaHotel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Reservas
{
    public partial class FormReservas : Form
    {
        Servico servico = new Servico();
        Quarto quarto = new Quarto();

        public FormReservas()
        {
            InitializeComponent();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            ListarQuartos();
            CarregaComboLista();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaComboLista()
        {
            // SERVIÇOS CADASTRADOS

            clServicos.Items.Clear();
            var listaServico = servico.Lista();
            clServicos.Items.AddRange(listaServico.ToArray());

            
        }

        private void ListarQuartos() 
        {
            var dt = quarto.ListaQuarto();
            grid.DataSource = dt;

            FormatarDG();

        }

        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "Numero";
            grid.Columns[1].HeaderText = "Andar";
            grid.Columns[2].HeaderText = "Descricao";
            grid.Columns[3].HeaderText = "Ocupado";
            grid.Columns[4].HeaderText = "Ocupacao_Maxima";

            grid.Columns[3].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            txtCpf.Enabled = true;
            cbOcupantes.Enabled = true;
            dtEntrada.Enabled = true;
            dtSaida.Enabled = true;
            clServicos.Enabled = true;            
        }

    }
}
