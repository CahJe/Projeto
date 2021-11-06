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
    public partial class FrmQuartos : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string numero;
        Quarto quarto = new Quarto();

        string quartoAntigo;

        public FrmQuartos()
        {
            InitializeComponent();
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

        private void Listar()
        {
            var dt = quarto.ListaQuarto();
            grid.DataSource = dt;
            FormatarDG();
        }


        

        private void habilitarCampos()
        {
            txtQuarto.Enabled = true;
            txtAndar.Enabled = true;
            txtOcupacao.Enabled = true;
            txtDescricao.Enabled = true;
           
        }


        private void desabilitarCampos()
        {
            txtQuarto.Enabled = false;
            txtAndar.Enabled = false;
            txtOcupacao.Enabled = false;
            txtDescricao.Enabled = false;
        }


        private void limparCampos()
        {
            txtQuarto.Text = "";
            txtAndar.Text = "";
            txtOcupacao.Text = "";
            txtDescricao.Text = "";           
        }


        private void FrmQuartos_Load(object sender, EventArgs e)
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
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.ToString().Trim() == "")
            {
                txtQuarto.Text = "";
                MessageBox.Show("Preencha o Quarto", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuarto.Focus();
                return;
            }

            if (txtAndar.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAndar.Focus();
                return;
            }
            
            if (txtOcupacao.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAndar.Focus();
                return;
            }

            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAndar.Focus();
                return;
            }


            //VERIFICAR SE O QUARTO JÁ EXISTE NO BANCO

            if (quarto.verificaExistencia(int.Parse(txtQuarto.Text)))
            {
                MessageBox.Show("Quarto já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuarto.Text = "";
                txtQuarto.Focus();
                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR

            quarto.inserir(int.Parse(txtQuarto.Text), int.Parse(txtAndar.Text), txtDescricao.Text, int.Parse(txtOcupacao.Text));
          
            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.ToString().Trim() == "")
            {
                txtQuarto.Text = "";
                MessageBox.Show("Preencha o Quarto", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuarto.Focus();
                return;
            }

            if (txtAndar.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAndar.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA EDITAR

            quarto.alterar(int.Parse(numero), int.Parse(txtOcupacao.Text), txtDescricao.Text);
           
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

                quarto.deletar(int.Parse(numero));                
                
                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();

                Listar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            habilitarCampos();
            txtQuarto.Enabled = false;

            numero = grid.CurrentRow.Cells[0].Value.ToString();
            txtQuarto.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtAndar.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtOcupacao.Text = grid.CurrentRow.Cells[4].Value.ToString();
           
            quartoAntigo = grid.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
