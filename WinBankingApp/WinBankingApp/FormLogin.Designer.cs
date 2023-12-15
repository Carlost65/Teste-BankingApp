namespace WinBankingApp
{
    partial class FormLogin
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
            cadastro = new Button();
            titulo = new Label();
            cpf_cnpj = new Label();
            usuario_text = new TextBox();
            senha = new Label();
            senha_text = new TextBox();
            entrar = new Button();
            SuspendLayout();
            // 
            // cadastro
            // 
            cadastro.Location = new Point(448, 8);
            cadastro.Name = "cadastro";
            cadastro.Size = new Size(75, 23);
            cadastro.TabIndex = 18;
            cadastro.Text = "Cadastro";
            cadastro.UseVisualStyleBackColor = true;
            cadastro.Click += cadastro_Click;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Location = new Point(237, 12);
            titulo.Name = "titulo";
            titulo.Size = new Size(37, 15);
            titulo.TabIndex = 19;
            titulo.Text = "Login";
            // 
            // cpf_cnpj
            // 
            cpf_cnpj.AutoSize = true;
            cpf_cnpj.Location = new Point(225, 46);
            cpf_cnpj.Name = "cpf_cnpj";
            cpf_cnpj.Size = new Size(63, 15);
            cpf_cnpj.TabIndex = 20;
            cpf_cnpj.Text = "CPF/CNPJ:";
            // 
            // usuario_text
            // 
            usuario_text.Location = new Point(160, 64);
            usuario_text.MaxLength = 14;
            usuario_text.Name = "usuario_text";
            usuario_text.Size = new Size(191, 23);
            usuario_text.TabIndex = 21;
            usuario_text.KeyPress += usuario_text_KeyPress;
            // 
            // senha
            // 
            senha.AutoSize = true;
            senha.Location = new Point(232, 101);
            senha.Name = "senha";
            senha.Size = new Size(42, 15);
            senha.TabIndex = 22;
            senha.Text = "Senha:";
            // 
            // senha_text
            // 
            senha_text.Location = new Point(160, 119);
            senha_text.Name = "senha_text";
            senha_text.Size = new Size(191, 23);
            senha_text.TabIndex = 23;
            // 
            // entrar
            // 
            entrar.Location = new Point(215, 157);
            entrar.Name = "entrar";
            entrar.Size = new Size(75, 23);
            entrar.TabIndex = 24;
            entrar.Text = "Entrar";
            entrar.UseVisualStyleBackColor = true;
            entrar.Click += entrar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 320);
            Controls.Add(entrar);
            Controls.Add(senha_text);
            Controls.Add(senha);
            Controls.Add(usuario_text);
            Controls.Add(cpf_cnpj);
            Controls.Add(titulo);
            Controls.Add(cadastro);
            Name = "FormLogin";
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cadastro;
        private Button login;
        private Label titulo;
        private Label cpf_cnpj;
        private TextBox usuario_text;
        private Label senha;
        private TextBox senha_text;
        private Button entrar;
    }
}