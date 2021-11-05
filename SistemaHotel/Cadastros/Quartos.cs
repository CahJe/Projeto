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
        string id;
        Quarto quarto = new Quarto();

        string quartoAntigo;

        public FrmQuartos()
        {
            InitializeComponent();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Quarto";
            grid.Columns[2].HeaderText = "Valor";
            grid.Columns[3].HeaderText = "Pessoas";
            

            grid.Columns[0].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        

        private void habilitarCampos()
        {
            txtQuarto.Enabled = true;
            txtAndar.Enabled = true;
            txtOcupacao.Enabled = true;
           
        }


        private void desabilitarCampos()
        {
            txtQuarto.Enabled = false;
            txtAndar.Enabled = false;
            txtOcupacao.Enabled = false;
            
        }


        private void limparCampos()
        {
            txtQuarto.Text = "";
            txtAndar.Text = "";
            txtOcupacao.Text = "";
            
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
            con.AbrirCon();
            sql = "UPDATE quartos SET quarto = @quarto, valor = @valor, pessoas = @pessoas where id = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", txtQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", txtAndar.Text);
            cmd.Parameters.AddWithValue("@pessoas", txtOcupacao.Text);

            cmd.Parameters.AddWithValue("@id", id);


            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            if (txtQuarto.Text != quartoAntigo)
            {
                SqlCommand cmdVerificar;

                cmdVerificar = new SqlCommand("SELECT * FROM quartos where quarto = @quarto", con.con);
                cmdVerificar.Parameters.AddWithValue("@quarto", txtQuarto.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Quarto já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuarto.Text = "";
                    txtQuarto.Focus();
                    return;
                }

            }


            cmd.ExecuteNonQuery();
            con.FecharCon();

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
                con.AbrirCon();
                sql = "DELETE FROM quartos where id = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();

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

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtQuarto.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtAndar.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtOcupacao.Text = grid.CurrentRow.Cells[3].Value.ToString();
           
            quartoAntigo = grid.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
