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

namespace SistemaHotel.Cadastros
{
    public partial class FrmFuncionarios : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        TipoFuncionario tipoFuncionario = new TipoFuncionario();
        Funcionario funcionario = new Funcionario();
        Pessoa pessoa = new Pessoa();
        Endereco endereco = new Endereco();

        string cpfAntigo;

        public FrmFuncionarios()
        {
            InitializeComponent();
        }


        private void CarregarCombobox()
        {

            var dt = tipoFuncionario.ListaTipo();
            cbCargo.DataSource = dt;
            cbCargo.ValueMember = "id";
            cbCargo.DisplayMember = "descricao";
            cbCargo.SelectedValue.ToString();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "Id";
            grid.Columns[1].HeaderText = "DataCriacao";
            grid.Columns[2].HeaderText = "CPF";
            grid.Columns[3].HeaderText = "Nome";
            grid.Columns[4].HeaderText = "Cargo";
            grid.Columns[5].HeaderText = "sexo";
            grid.Columns[6].HeaderText = "Telefone";
            grid.Columns[7].HeaderText = "DDD";
            grid.Columns[8].HeaderText = "Email";
            grid.Columns[9].HeaderText = "Estado";
            grid.Columns[10].HeaderText = "Cidade";
            grid.Columns[11].HeaderText = "Rua";
            grid.Columns[12].HeaderText = "Numero";
            //grid.Columns[13].HeaderText = "Senha";

            grid.Columns[0].Visible = false;
            //grid.Columns[13].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {

            var dt = funcionario.ListaFuncionario();
            grid.DataSource = dt;
            FormatarDG();
        }


        private void BuscarNome()
        {
            var dt = funcionario.buscaNome(txtBuscarNome.Text);
            grid.DataSource = dt;
            
            FormatarDG();
        }


        private void BuscarCPF()
        {
            var dt = funcionario.buscaCPF(txtBuscarCPF.Text);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco.Enabled = true;
            cbCargo.Enabled = true;
            cbEstado.Enabled = true;
            cbSexo.Enabled = true;
            txtCidade.Enabled = true;
            txtEmail.Enabled = true;
            txtNumero.Enabled = true;
            txtSenha.Enabled = true;
            txtConfirmaSenha.Enabled = true;
            txtTelefone.Enabled = true;
            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;
            cbCargo.Enabled = false;
            txtTelefone.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtNumero.Text = "";
            txtSenha.Text = "";
            txtConfirmaSenha.Text = "";

        }


        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            Listar();
            rbNome.Checked = true;
            CarregarCombobox();
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

            if (cbCargo.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Cargo!");
                Close();
            }

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
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }

            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                MessageBox.Show("Preencha a senha", "As senhas não conferem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmaSenha.Text = "";
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            string cpf = txtCPF.Text.Replace(".","").Replace("-","");

            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            if (funcionario.verificaExistencia(cpf))
            {
                MessageBox.Show("CPF já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Text = "";
                txtCPF.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA SALVAR
            var enderecoId = endereco.inserir(cbEstado.Text, txtCidade.Text, txtEndereco.Text, int.Parse(txtNumero.Text));
            var pessoaId = pessoa.inserir(cpf, txtNome.Text, cbSexo.Text, pessoa.retornaTelefone(txtTelefone.Text), pessoa.retornaDDD(txtTelefone.Text), txtEmail.Text, enderecoId, txtConfirmaSenha.Text);
            funcionario.inserir(int.Parse(cbCargo.SelectedValue.ToString()), pessoaId);


            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void Grid_Click(object sender, EventArgs e)
        {
           
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

            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }


            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            if (txtCPF.Text != cpfAntigo)
            {
                if (funcionario.verificaExistencia(txtCPF.Text))
                {
                    MessageBox.Show("CPF já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCPF.Text = "";
                    txtCPF.Focus();
                    return;
                }

            }

            //CÓDIGO DO BOTÃO PARA EDITAR

            pessoa.retornaPessoa(txtCPF.Text);
            endereco.alterar(pessoa.EnderecoId, cbEstado.Text, txtCidade.Text, txtEndereco.Text, int.Parse(txtNumero.Text));
            pessoa.alterar(pessoa.Id, txtCPF.Text, txtNome.Text, cbSexo.Text, pessoa.retornaTelefone(txtTelefone.Text), pessoa.retornaDDD(txtTelefone.Text), txtEmail.Text, txtConfirmaSenha.Text);
            funcionario.alterar(int.Parse(cbCargo.ValueMember), pessoa.Id);
                     
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

                funcionario.deletar(int.Parse(id));
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

            txtCPF.Enabled = false;
            txtConfirmaSenha.Enabled = false;
            txtSenha.Enabled = false;

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtCPF.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[3].Value.ToString();
            cbCargo.Text = grid.CurrentRow.Cells[4].Value.ToString();
            cbSexo.Text = grid.CurrentRow.Cells[5].Value.ToString();
            txtTelefone.Text = String.Concat(grid.CurrentRow.Cells[7].Value.ToString(), grid.CurrentRow.Cells[6].Value.ToString());
            txtEmail.Text = grid.CurrentRow.Cells[8].Value.ToString();
            cbEstado.Text = grid.CurrentRow.Cells[9].Value.ToString();
            txtCidade.Text = grid.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = grid.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = grid.CurrentRow.Cells[12].Value.ToString();
            txtSenha.Text = grid.CurrentRow.Cells[13].Value.ToString();
            txtConfirmaSenha.Text = grid.CurrentRow.Cells[13].Value.ToString();

            //cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
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

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
