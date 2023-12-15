namespace WinBankingApp
{
    partial class FormCadastro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cadastrar = new Button();
            nome = new Label();
            email = new Label();
            senha = new Label();
            cpf_cnpj = new Label();
            Titulo = new Label();
            nome_text = new TextBox();
            email_text = new TextBox();
            cpf_cnpj_text = new TextBox();
            senha_text = new TextBox();
            tipo_usuario = new CheckBox();
            saldo_text = new TextBox();
            saldo = new Label();
            login = new Button();
            SuspendLayout();
            // 
            // cadastrar
            // 
            cadastrar.Location = new Point(245, 253);
            cadastrar.Name = "cadastrar";
            cadastrar.Size = new Size(75, 23);
            cadastrar.TabIndex = 0;
            cadastrar.Text = "Cadastrar";
            cadastrar.UseVisualStyleBackColor = true;
            cadastrar.Click += cadastrar_Click;
            // 
            // nome
            // 
            nome.AutoSize = true;
            nome.Location = new Point(36, 43);
            nome.Name = "nome";
            nome.Size = new Size(99, 15);
            nome.TabIndex = 1;
            nome.Text = "Nome Completo:";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(36, 80);
            email.Name = "email";
            email.Size = new Size(39, 15);
            email.TabIndex = 2;
            email.Text = "Email:";
            // 
            // senha
            // 
            senha.AutoSize = true;
            senha.Location = new Point(36, 151);
            senha.Name = "senha";
            senha.Size = new Size(42, 15);
            senha.TabIndex = 3;
            senha.Text = "Senha:";
            // 
            // cpf_cnpj
            // 
            cpf_cnpj.AutoSize = true;
            cpf_cnpj.Location = new Point(36, 116);
            cpf_cnpj.Name = "cpf_cnpj";
            cpf_cnpj.Size = new Size(63, 15);
            cpf_cnpj.TabIndex = 5;
            cpf_cnpj.Text = "CPF/CNPJ:";
            // 
            // Titulo
            // 
            Titulo.AutoSize = true;
            Titulo.Location = new Point(255, 9);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(54, 15);
            Titulo.TabIndex = 7;
            Titulo.Text = "Cadastro";
            // 
            // nome_text
            // 
            nome_text.Location = new Point(138, 40);
            nome_text.MaxLength = 255;
            nome_text.Name = "nome_text";
            nome_text.Size = new Size(388, 23);
            nome_text.TabIndex = 1;
            // 
            // email_text
            // 
            email_text.Location = new Point(138, 77);
            email_text.MaxLength = 255;
            email_text.Name = "email_text";
            email_text.Size = new Size(388, 23);
            email_text.TabIndex = 2;
            // 
            // cpf_cnpj_text
            // 
            cpf_cnpj_text.Location = new Point(138, 113);
            cpf_cnpj_text.MaxLength = 14;
            cpf_cnpj_text.Name = "cpf_cnpj_text";
            cpf_cnpj_text.Size = new Size(388, 23);
            cpf_cnpj_text.TabIndex = 3;
            cpf_cnpj_text.KeyPress += cpf_cnpj_text_KeyPress;
            // 
            // senha_text
            // 
            senha_text.Location = new Point(138, 148);
            senha_text.MaxLength = 255;
            senha_text.Name = "senha_text";
            senha_text.Size = new Size(388, 23);
            senha_text.TabIndex = 4;
            // 
            // tipo_usuario
            // 
            tipo_usuario.AutoSize = true;
            tipo_usuario.Location = new Point(466, 224);
            tipo_usuario.Name = "tipo_usuario";
            tipo_usuario.Size = new Size(60, 19);
            tipo_usuario.TabIndex = 12;
            tipo_usuario.Text = "Lojista";
            tipo_usuario.UseVisualStyleBackColor = true;
            // 
            // saldo_text
            // 
            saldo_text.Location = new Point(138, 183);
            saldo_text.Name = "saldo_text";
            saldo_text.Size = new Size(388, 23);
            saldo_text.TabIndex = 5;
            saldo_text.KeyPress += saldo_text_KeyPress;
            // 
            // saldo
            // 
            saldo.AutoSize = true;
            saldo.Location = new Point(36, 186);
            saldo.Name = "saldo";
            saldo.Size = new Size(70, 15);
            saldo.TabIndex = 14;
            saldo.Text = "Saldo inicial";
            // 
            // login
            // 
            login.Location = new Point(451, 5);
            login.Name = "login";
            login.Size = new Size(75, 23);
            login.TabIndex = 15;
            login.Text = "Login";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 320);
            Controls.Add(login);
            Controls.Add(saldo);
            Controls.Add(saldo_text);
            Controls.Add(tipo_usuario);
            Controls.Add(senha_text);
            Controls.Add(cpf_cnpj_text);
            Controls.Add(email_text);
            Controls.Add(nome_text);
            Controls.Add(Titulo);
            Controls.Add(cpf_cnpj);
            Controls.Add(senha);
            Controls.Add(email);
            Controls.Add(nome);
            Controls.Add(cadastrar);
            Name = "FormCadastro";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cadastrar;
        private Label nome;
        private Label email;
        private Label senha;
        private Label cpf_cnpj;
        private Label Titulo;
        private TextBox nome_text;
        private TextBox email_text;
        private TextBox cpf_cnpj_text;
        private TextBox senha_text;
        private CheckBox tipo_usuario;
        private TextBox saldo_text;
        private Label saldo;
        private Button login;
    }
}