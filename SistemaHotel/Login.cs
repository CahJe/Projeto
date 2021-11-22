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
    public partial class FrmLogin : Form
    {
        Conexao con = new Conexao();
        public FrmLogin()
        {
            
            InitializeComponent();
            pnlLogin.Visible = false;
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
            pnlLogin.Visible = true;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 114, 160);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 72, 103);

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }
        }


        private void ChamarLogin()
        {
            if (txtCPF.Text.ToString().Trim() == "   .   .   -")
            {
                MessageBox.Show("Preencha o Usuário", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Text = "";
                txtCPF.Focus();
                return;
            }

            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha a Senha", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            string cpf = txtCPF.Text.Replace(".","").Replace("-","");

            //AQUI VAI O CÓDIGO PARA O LOGIN
            SqlCommand cmdVerificar;
            SqlDataReader reader;

            con.AbrirCon();
            cmdVerificar = new SqlCommand("SELECT * FROM Pessoa p JOIN Funcionario f on f.PessoaId = p.Id JOIN TipoFuncionario tf on tf.Id = f.TipoFuncionarioId where p.CPF = @CPF and p.senha = @senha", con.con);
            cmdVerificar.Parameters.AddWithValue("@CPF", cpf);
            cmdVerificar.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmdVerificar.ExecuteReader();
            
            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    Program.nomeUsuario = Convert.ToString(reader["nome"]);
                    Program.cargoUsuario = Convert.ToString(reader["descricao"]);                   
                }

                MessageBox.Show("Bem Vindo! " + Program.nomeUsuario, "Login Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmMenu form = new FrmMenu();
                //this.Hide();
                Limpar();
                form.Show();
            }
            else
            {
                MessageBox.Show("Erro ao Logar!", "Dados Incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Text = "";
                txtCPF.Focus();
                txtSenha.Text = "";
            }

            con.FecharCon();  
        }


        private void Limpar()
        {
            txtCPF.Text = "";
            txtSenha.Text = "";
            txtCPF.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
        }
    }
}
