using SistemaHotel.Classes;
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
    public partial class FormReservas : Form
    {
        ServicoPrestado servicoPrestado = new ServicoPrestado();
        Estadia estadia = new Estadia();
        Servico servico = new Servico();
        Quarto quarto = new Quarto();
        string numero;
        string ocupacao_maxima;
        Cliente cliente = new Cliente();

        public FormReservas()
        {
            InitializeComponent();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            Desabilitar();
            //ListarQuartos();
            CarregaComboLista();
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text.Replace("", "").Replace("", "");
            var qtdcpf = cpf.Length;

            if (qtdcpf >= 11)
            {
                if (!cliente.verificaExistencia(cpf))
                {
                    MessageBox.Show("Cliente não possui cadastro na base", "CPF Não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpf.Text = "";
                    txtCpf.Focus();
                    return;
                }
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaComboLista()
        {
            // SERVIÇOS CADASTRADOS

            var dt = servico.listaServico();
            //clServicos.Items.AddRange();

            cbServico.Items.Clear();
            cbServico.DataSource = dt;
            cbServico.ValueMember = "id";
            cbServico.DisplayMember = "Tipo";
            cbServico.SelectedValue.ToString();
        }

        private void ListarQuartos() 
        {
            var dt = quarto.ListaQuartoDisponivel(dtEntrada.Value, dtSaida.Value);
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
            grid.Enabled = true;
            //grid.Columns[1].Width = 200;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtCpf.Enabled = true;
            //cbOcupantes.Enabled = true;
            dtEntrada.Enabled = true;
            dtSaida.Enabled = true;
            btnLista.Enabled = true;
            //cbServico.Enabled = true;            
        }

        private void Desabilitar()
        {
            btnLista.Enabled = false;
            btnSalvar.Enabled = false;
            txtCpf.Enabled = false;
            cbOcupantes.Enabled = false;
            dtEntrada.Enabled = false;
            dtSaida.Enabled = false;
            cbServico.Enabled = false;
            grid.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Focus();
                return;
            }

            if (cbOcupantes.Text == "")
            {
                MessageBox.Show("Preencha o numero de ocupantes", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbOcupantes.Text = "";
                cbOcupantes.Text = "";
                cbOcupantes.Focus();
                return;
            }
 
            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "");

            var IdEstadia = estadia.inserir(int.Parse(cbOcupantes.Text), dtEntrada.Value, dtSaida.Value, cliente.retornaclienteId(cpf), int.Parse(numero));

            if (cbServico.Text != "")
            {
                servicoPrestado.inserir(int.Parse(cbServico.SelectedValue.ToString()), IdEstadia);
            }

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            Desabilitar();
            CarregaComboLista();
            //desabilitarCampos();

        }

        private void limparCampos() 
        {
            cbServico.Text = "";
            cbOcupantes.Text = "";
            txtCpf.Text = "";

        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            ListarQuartos();
        }

        private void ocupacao() 
        {
            cbOcupantes.DataSource = Enumerable.Range(1, int.Parse(ocupacao_maxima)).ToList();
            cbOcupantes.Enabled = true;
        }


        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnSalvar.Enabled = false;
            numero = grid.CurrentRow.Cells[0].Value.ToString();
            ocupacao_maxima = grid.CurrentRow.Cells[4].Value.ToString();

            ocupacao();
            cbServico.Enabled = true;
        }

        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
