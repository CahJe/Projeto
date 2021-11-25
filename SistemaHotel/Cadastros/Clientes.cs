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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Cadastros
{
    public partial class FrmHospedes : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        
        Pessoa pessoa = new Pessoa();
        Cliente cliente = new Cliente();
        Endereco endereco = new Endereco();

        string cpfAntigo;

        public FrmHospedes()
        {
            InitializeComponent();
        }


       
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "Id";
            grid.Columns[1].HeaderText = "DataCriacao";
            grid.Columns[2].HeaderText = "Nome";
            grid.Columns[3].HeaderText = "CPF";
            grid.Columns[4].HeaderText = "Sexo"; 
            grid.Columns[5].HeaderText = "Telefone";
            grid.Columns[6].HeaderText = "DDD";
            grid.Columns[7].HeaderText = "Email";
            grid.Columns[8].HeaderText = "Estado";
            grid.Columns[9].HeaderText = "Cidade";
            grid.Columns[10].HeaderText = "Rua";
            //grid.Columns[11].HeaderText = "Numero";

            grid.Columns[0].Visible = false;
            //grid.Columns[5].Visible = false;

            grid.Columns[1].Width = 200;
        }

        private void Listar()
        {
            var dt = cliente.ListaCliente(); 
            grid.DataSource = dt;
            
            FormatarDG();
        }


        private void BuscarNome()
        {
            var dt = cliente.buscaNome(txtBuscarNome.Text);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        private void BuscarCPF()
        {
            string cpf = txtBuscarCPF.Text.Replace("-", "").Replace(".", "");
            var dt = cliente.buscaCPF(cpf);         
            grid.DataSource = dt;           
            FormatarDG();
        }


        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
            txtEmail.Enabled = true;
            cbSexo.Enabled = true;
            txtTelefone.Enabled = true;
            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;
            cbSexo.Enabled = false;
            cbEstado.Enabled = false;
            txtEmail.Enabled = false;
            txtNumero.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            cbEstado.Text = "";
            cbSexo.Text = "";
            txtEmail.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
        }




        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            Listar();
            rbNome.Checked = true;
            desabilitarCampos();
        }

        private void RbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            txtBuscarCPF.Visible = false;

            txtBuscarNome.Text = "";
            txtBuscarCPF.Text = "";
        }

        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            txtBuscarCPF.Visible = true;

            txtBuscarNome.Text = "";
            txtBuscarCPF.Text = "";
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
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                txtNome.Focus();
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtEmail.Text.ToString().Trim() == "")
            {
                txtEmail.Text = "";
                MessageBox.Show("Preencha o Email", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }

            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            var cpf = txtCPF.Text.Replace(".", "").Replace("-", "");

            if (cliente.retornaId(cpf) > 0)
            {
                MessageBox.Show("CPF já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Text = "";
                txtCPF.Focus();
                return;
            }
            
            //CÓDIGO DO BOTÃO PARA SALVAR    

            var enderecoId = endereco.inserir(cbEstado.Text, txtCidade.Text, txtEndereco.Text, int.Parse(txtNumero.Text));
            var pessoaId = pessoa.inserir(cpf, txtNome.Text, cbSexo.Text, pessoa.retornaTelefone(txtTelefone.Text), pessoa.retornaDDD(txtTelefone.Text), txtEmail.Text, enderecoId);
            cliente.inserir(pessoaId);
        
            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            if (txtEmail.Text.ToString().Trim() == "")
            {
                txtEmail.Text = "";
                MessageBox.Show("Preencha o Email", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA EDITAR

            pessoa.retornaPessoa(txtCPF.Text);
            endereco.alterar(pessoa.EnderecoId, cbEstado.Text, txtCidade.Text, txtEndereco.Text, int.Parse(txtNumero.Text));
            pessoa.alterar(pessoa.Id, txtCPF.Text, txtNome.Text, cbSexo.Text, pessoa.retornaTelefone(txtTelefone.Text), pessoa.retornaDDD(txtTelefone.Text), txtEmail.Text);
                                                                   
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
                sql = "DELETE FROM hospedes where id = @id";
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
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = grid.CurrentRow.Cells[4].Value.ToString();
            

            cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void TxtBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCPF.Text == "   .   .   -")
            {
                Listar();
            }
            else
            {
                BuscarCPF();
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaHospedes == "hospedes")
            {
                Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();
               
                Close();
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
