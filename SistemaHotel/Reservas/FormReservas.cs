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
            Desabilitar();
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

        private void Desabilitar()
        {
            btnSalvar.Enabled = false;
            txtCpf.Enabled = false;
            cbOcupantes.Enabled = false;
            dtEntrada.Enabled = false;
            dtSaida.Enabled = false;
            clServicos.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

         // obs. PARA MELHORIAS, QUERY SQL PARA VALIDAR QUARTOS DISPONIVEIS 
         
            //declare @datainicial date = '2021-11-26'
            //declare @datafinal date = '2021-11-27'
            
            //; WITH Quartos_indisponiveis as (
            //    SELECT q.*
            //    FROM #Estadia e 
            //	LEFT JOIN #Quarto q on e.QuartoNumero = q.Numero 
            //	WHERE
            //        (cast(e.DataEntrada as date) between @datainicial and @datafinal or
            
            //         cast(e.DataSaida as date) between @datainicial and @datafinal)
            
            //    AND e.Ativo = 1
            //)
            
            //Select* from #Quarto where Numero not in (Select numero from Quartos_indisponiveis)
        }
    }
}
