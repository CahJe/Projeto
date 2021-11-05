namespace SistemaHotel
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóspedesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quartosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReservas = new System.Windows.Forms.ToolStripMenuItem();
            this.novaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadroDeReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChekInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.novoServiçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeMovimentaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeMovimentaçõesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblQuartosDisponiveis = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalReservas = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblQuartosOcupados = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastro,
            this.MenuReservas,
            this.MenuChekInOut,
            this.MenuRelatorios,
            this.MenuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionáriosToolStripMenuItem,
            this.hóspedesToolStripMenuItem,
            this.quartosToolStripMenuItem,
            this.serviçosToolStripMenuItem,
            this.cargoToolStripMenuItem});
            this.MenuCadastro.Image = ((System.Drawing.Image)(resources.GetObject("MenuCadastro.Image")));
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(87, 20);
            this.MenuCadastro.Text = "Cadastros";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.FuncionáriosToolStripMenuItem_Click);
            // 
            // hóspedesToolStripMenuItem
            // 
            this.hóspedesToolStripMenuItem.Name = "hóspedesToolStripMenuItem";
            this.hóspedesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hóspedesToolStripMenuItem.Text = "Clientes";
            this.hóspedesToolStripMenuItem.Click += new System.EventHandler(this.HóspedesToolStripMenuItem_Click);
            // 
            // quartosToolStripMenuItem
            // 
            this.quartosToolStripMenuItem.Name = "quartosToolStripMenuItem";
            this.quartosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quartosToolStripMenuItem.Text = "Quartos";
            this.quartosToolStripMenuItem.Click += new System.EventHandler(this.QuartosToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.ServiçosToolStripMenuItem_Click);
            // 
            // cargoToolStripMenuItem
            // 
            this.cargoToolStripMenuItem.Name = "cargoToolStripMenuItem";
            this.cargoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargoToolStripMenuItem.Text = "Cargo";
            this.cargoToolStripMenuItem.Click += new System.EventHandler(this.CargoToolStripMenuItem_Click);
            // 
            // MenuReservas
            // 
            this.MenuReservas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaReservaToolStripMenuItem,
            this.quadroDeReservasToolStripMenuItem});
            this.MenuReservas.Image = ((System.Drawing.Image)(resources.GetObject("MenuReservas.Image")));
            this.MenuReservas.Name = "MenuReservas";
            this.MenuReservas.Size = new System.Drawing.Size(80, 20);
            this.MenuReservas.Text = "Reservas";
            // 
            // novaReservaToolStripMenuItem
            // 
            this.novaReservaToolStripMenuItem.Name = "novaReservaToolStripMenuItem";
            this.novaReservaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.novaReservaToolStripMenuItem.Text = "Nova Reserva";
            this.novaReservaToolStripMenuItem.Click += new System.EventHandler(this.NovaReservaToolStripMenuItem_Click);
            // 
            // quadroDeReservasToolStripMenuItem
            // 
            this.quadroDeReservasToolStripMenuItem.Name = "quadroDeReservasToolStripMenuItem";
            this.quadroDeReservasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quadroDeReservasToolStripMenuItem.Text = "Consultar Reservas";
            this.quadroDeReservasToolStripMenuItem.Click += new System.EventHandler(this.QuadroDeReservasToolStripMenuItem_Click);
            // 
            // MenuChekInOut
            // 
            this.MenuChekInOut.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoServiçoToolStripMenuItem,
            this.checkOutToolStripMenuItem});
            this.MenuChekInOut.Image = ((System.Drawing.Image)(resources.GetObject("MenuChekInOut.Image")));
            this.MenuChekInOut.Name = "MenuChekInOut";
            this.MenuChekInOut.Size = new System.Drawing.Size(106, 20);
            this.MenuChekInOut.Text = "Check In/Out";
            // 
            // novoServiçoToolStripMenuItem
            // 
            this.novoServiçoToolStripMenuItem.Name = "novoServiçoToolStripMenuItem";
            this.novoServiçoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.novoServiçoToolStripMenuItem.Text = "Check In";
            this.novoServiçoToolStripMenuItem.Click += new System.EventHandler(this.NovoServiçoToolStripMenuItem_Click);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.checkOutToolStripMenuItem.Text = "Check Out";
            this.checkOutToolStripMenuItem.Click += new System.EventHandler(this.CheckOutToolStripMenuItem_Click);
            // 
            // MenuRelatorios
            // 
            this.MenuRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioDeProdutosToolStripMenuItem,
            this.relatórioDeVendasToolStripMenuItem,
            this.relatórioDeServiçosToolStripMenuItem,
            this.relatórioDeMovimentaçõesToolStripMenuItem,
            this.relatórioDeMovimentaçõesToolStripMenuItem1});
            this.MenuRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("MenuRelatorios.Image")));
            this.MenuRelatorios.Name = "MenuRelatorios";
            this.MenuRelatorios.Size = new System.Drawing.Size(87, 20);
            this.MenuRelatorios.Text = "Relatórios";
            // 
            // relatórioDeProdutosToolStripMenuItem
            // 
            this.relatórioDeProdutosToolStripMenuItem.Name = "relatórioDeProdutosToolStripMenuItem";
            this.relatórioDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.relatórioDeProdutosToolStripMenuItem.Text = "Relatório de Produtos";
            this.relatórioDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.RelatórioDeProdutosToolStripMenuItem_Click);
            // 
            // relatórioDeVendasToolStripMenuItem
            // 
            this.relatórioDeVendasToolStripMenuItem.Name = "relatórioDeVendasToolStripMenuItem";
            this.relatórioDeVendasToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.relatórioDeVendasToolStripMenuItem.Text = "Relatório de Vendas";
            this.relatórioDeVendasToolStripMenuItem.Click += new System.EventHandler(this.RelatórioDeVendasToolStripMenuItem_Click);
            // 
            // relatórioDeServiçosToolStripMenuItem
            // 
            this.relatórioDeServiçosToolStripMenuItem.Name = "relatórioDeServiçosToolStripMenuItem";
            this.relatórioDeServiçosToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.relatórioDeServiçosToolStripMenuItem.Text = "Relatório de Serviços";
            this.relatórioDeServiçosToolStripMenuItem.Click += new System.EventHandler(this.RelatórioDeServiçosToolStripMenuItem_Click);
            // 
            // relatórioDeMovimentaçõesToolStripMenuItem
            // 
            this.relatórioDeMovimentaçõesToolStripMenuItem.Name = "relatórioDeMovimentaçõesToolStripMenuItem";
            this.relatórioDeMovimentaçõesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.relatórioDeMovimentaçõesToolStripMenuItem.Text = "Relatório de Entrada / Saída";
            this.relatórioDeMovimentaçõesToolStripMenuItem.Click += new System.EventHandler(this.RelatórioDeMovimentaçõesToolStripMenuItem_Click);
            // 
            // relatórioDeMovimentaçõesToolStripMenuItem1
            // 
            this.relatórioDeMovimentaçõesToolStripMenuItem1.Name = "relatórioDeMovimentaçõesToolStripMenuItem1";
            this.relatórioDeMovimentaçõesToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.relatórioDeMovimentaçõesToolStripMenuItem1.Text = "Relatório de Movimentações";
            this.relatórioDeMovimentaçõesToolStripMenuItem1.Click += new System.EventHandler(this.RelatórioDeMovimentaçõesToolStripMenuItem1_Click);
            // 
            // MenuSair
            // 
            this.MenuSair.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.MenuSair.Image = ((System.Drawing.Image)(resources.GetObject("MenuSair.Image")));
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(54, 20);
            this.MenuSair.Text = "Sair";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // pnlTopo
            // 
            this.pnlTopo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTopo.Controls.Add(this.label18);
            this.pnlTopo.Controls.Add(this.label17);
            this.pnlTopo.Controls.Add(this.button8);
            this.pnlTopo.Controls.Add(this.button4);
            this.pnlTopo.Controls.Add(this.button3);
            this.pnlTopo.Location = new System.Drawing.Point(0, 27);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(527, 104);
            this.pnlTopo.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(258, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 18);
            this.label18.TabIndex = 141;
            this.label18.Text = "Consulta reserva";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(404, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 18);
            this.label17.TabIndex = 31;
            this.label17.Text = "Reserva";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(498, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(25, 25);
            this.button8.TabIndex = 140;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(283, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 65);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(397, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 65);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(4, 137);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(260, 160);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(283, 303);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(240, 160);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(283, 137);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(240, 160);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(4, 303);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(260, 160);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHora.Location = new System.Drawing.Point(73, 32);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(103, 29);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "13:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "DATA:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblData.Location = new System.Drawing.Point(88, 79);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 22);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "07/05/2019";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(-52, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(370, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "____________________________________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(17, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Cargo:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCargo.Location = new System.Drawing.Point(75, 225);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(80, 18);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "13/04/2019";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(19, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(-42, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "____________________________________";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUsuario.Location = new System.Drawing.Point(75, 195);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(114, 18);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Carlos fernando";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(16, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Nome:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(18, 370);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 18);
            this.label14.TabIndex = 11;
            this.label14.Text = "Quartos Disponíveis:";
            // 
            // lblQuartosDisponiveis
            // 
            this.lblQuartosDisponiveis.AutoSize = true;
            this.lblQuartosDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuartosDisponiveis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblQuartosDisponiveis.Location = new System.Drawing.Point(167, 370);
            this.lblQuartosDisponiveis.Name = "lblQuartosDisponiveis";
            this.lblQuartosDisponiveis.Size = new System.Drawing.Size(24, 18);
            this.lblQuartosDisponiveis.TabIndex = 12;
            this.lblQuartosDisponiveis.Text = "10";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(20, 280);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(-42, 417);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(370, 22);
            this.label12.TabIndex = 14;
            this.label12.Text = "____________________________________";
            // 
            // lblTotalReservas
            // 
            this.lblTotalReservas.AutoSize = true;
            this.lblTotalReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReservas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalReservas.Location = new System.Drawing.Point(98, 340);
            this.lblTotalReservas.Name = "lblTotalReservas";
            this.lblTotalReservas.Size = new System.Drawing.Size(16, 18);
            this.lblTotalReservas.TabIndex = 15;
            this.lblTotalReservas.Text = "5";
            this.lblTotalReservas.Click += new System.EventHandler(this.lblTotalReservas_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(17, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "Reservas:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(19, 400);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(139, 18);
            this.label16.TabIndex = 17;
            this.label16.Text = "Quartos Ocupados:";
            // 
            // lblQuartosOcupados
            // 
            this.lblQuartosOcupados.AutoSize = true;
            this.lblQuartosOcupados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuartosOcupados.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblQuartosOcupados.Location = new System.Drawing.Point(168, 400);
            this.lblQuartosOcupados.Name = "lblQuartosOcupados";
            this.lblQuartosOcupados.Size = new System.Drawing.Size(16, 18);
            this.lblQuartosOcupados.TabIndex = 18;
            this.lblQuartosOcupados.Text = "5";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlRight.Controls.Add(this.lblQuartosOcupados);
            this.pnlRight.Controls.Add(this.label16);
            this.pnlRight.Controls.Add(this.label10);
            this.pnlRight.Controls.Add(this.lblTotalReservas);
            this.pnlRight.Controls.Add(this.label12);
            this.pnlRight.Controls.Add(this.pictureBox3);
            this.pnlRight.Controls.Add(this.lblQuartosDisponiveis);
            this.pnlRight.Controls.Add(this.label14);
            this.pnlRight.Controls.Add(this.label9);
            this.pnlRight.Controls.Add(this.lblUsuario);
            this.pnlRight.Controls.Add(this.label5);
            this.pnlRight.Controls.Add(this.pictureBox2);
            this.pnlRight.Controls.Add(this.lblCargo);
            this.pnlRight.Controls.Add(this.label7);
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Controls.Add(this.pictureBox1);
            this.pnlRight.Controls.Add(this.lblData);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.lblHora);
            this.pnlRight.Location = new System.Drawing.Point(529, 27);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(217, 437);
            this.pnlRight.TabIndex = 2;
            this.pnlRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRight_Paint);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 471);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Hotelaria ";
            this.Activated += new System.EventHandler(this.FrmMenu_Activated);
            this.Deactivate += new System.EventHandler(this.FrmMenu_Deactivate);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.Resize += new System.EventHandler(this.FrmMenu_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóspedesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quartosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuReservas;
        private System.Windows.Forms.ToolStripMenuItem novaReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadroDeReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuChekInOut;
        private System.Windows.Forms.ToolStripMenuItem novoServiçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem cargoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeVendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeServiçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeMovimentaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeMovimentaçõesToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblQuartosDisponiveis;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalReservas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblQuartosOcupados;
        private System.Windows.Forms.Panel pnlRight;
    }
}