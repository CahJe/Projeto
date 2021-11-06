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

namespace SistemaHotel.Cadastros
{
    public partial class FrmServicos : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        Servico servico = new Servico();

        public FrmServicos()
        {
            InitializeComponent();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "Id";
            grid.Columns[1].HeaderText = "Tipo";
            grid.Columns[2].HeaderText = "Descricao";
            grid.Columns[3].HeaderText = "Valor";
            grid.Columns[4].HeaderText = "Ativo";

            grid.Columns[3].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;
            grid.Columns[4].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {
            var dt = servico.ListaServico();
            grid.DataSource = dt;

            FormatarDG();
        }


        private void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
            cbAtivo.Enabled = true;
            cbTipo.Enabled = true;

            cbTipo.Focus();
        }


        private void desabilitarCampos()
        {
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
            cbTipo.Enabled = false;
            cbAtivo.Enabled = false;
        }


        private void limparCampos()
        {
            txtDescricao.Text = "";
            txtValor.Text = "";
            cbAtivo.Checked = false;
            cbTipo.Text = "";
        }


        private void FrmServicos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            limparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA SALVAR
            var valor = txtValor.Text.Replace(".","").Replace(",", ".");

            servico.inserir(cbTipo.Text, txtDescricao.Text, Convert.ToDecimal(valor), cbAtivo.Checked);                
           
            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            habilitarCampos();
            cbTipo.Enabled = false;

            id = grid.CurrentRow.Cells[0].Value.ToString();
            cbTipo.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[3].Value.ToString();
            cbAtivo.Checked = Convert.ToBoolean(grid.CurrentRow.Cells[4].Value.ToString());
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }


            //CÓDIGO DO BOTÃO PARA EDITAR

            servico.alterar(int.Parse(id), txtDescricao.Text, Convert.ToDecimal(txtValor.Text), cbAtivo.Checked);

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO PARA EXCLUIR
                servico.deletar(int.Parse(id));
                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;

                limparCampos();
                desabilitarCampos();
                Listar();
            }
        }
    }
}
