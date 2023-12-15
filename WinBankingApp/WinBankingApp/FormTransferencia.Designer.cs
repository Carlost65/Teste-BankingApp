namespace WinBankingApp
{
    partial class FormTransferencia
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
            Sair = new Button();
            titulo = new Label();
            saldo = new Label();
            destinatario = new Label();
            valor_transferencia = new Label();
            valor_saldo_text = new Label();
            destinatario_text = new TextBox();
            valor_transferencia_text = new TextBox();
            transferir = new Button();
            SuspendLayout();
            // 
            // Sair
            // 
            Sair.Location = new Point(447, 5);
            Sair.Name = "Sair";
            Sair.Size = new Size(75, 23);
            Sair.TabIndex = 0;
            Sair.Text = "Sair";
            Sair.UseVisualStyleBackColor = true;
            Sair.Click += Sair_Click;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Location = new Point(251, 9);
            titulo.Name = "titulo";
            titulo.Size = new Size(76, 15);
            titulo.TabIndex = 1;
            titulo.Text = "Transferencia";
            // 
            // saldo
            // 
            saldo.AutoSize = true;
            saldo.Location = new Point(85, 54);
            saldo.Name = "saldo";
            saldo.Size = new Size(39, 15);
            saldo.TabIndex = 2;
            saldo.Text = "Saldo:";
            // 
            // destinatario
            // 
            destinatario.AutoSize = true;
            destinatario.Location = new Point(85, 93);
            destinatario.Name = "destinatario";
            destinatario.Size = new Size(73, 15);
            destinatario.TabIndex = 3;
            destinatario.Text = "Destinatario:";
            // 
            // valor_transferencia
            // 
            valor_transferencia.AutoSize = true;
            valor_transferencia.Location = new Point(85, 132);
            valor_transferencia.Name = "valor_transferencia";
            valor_transferencia.Size = new Size(123, 15);
            valor_transferencia.TabIndex = 4;
            valor_transferencia.Text = "Valor da transferencia:";
            // 
            // valor_saldo_text
            // 
            valor_saldo_text.AutoSize = true;
            valor_saldo_text.Location = new Point(209, 54);
            valor_saldo_text.Name = "valor_saldo_text";
            valor_saldo_text.Size = new Size(0, 15);
            valor_saldo_text.TabIndex = 5;
            // 
            // destinatario_text
            // 
            destinatario_text.Location = new Point(209, 85);
            destinatario_text.MaxLength = 14;
            destinatario_text.Name = "destinatario_text";
            destinatario_text.Size = new Size(204, 23);
            destinatario_text.TabIndex = 6;
            destinatario_text.KeyPress += destinatario_text_KeyPress;
            // 
            // valor_transferencia_text
            // 
            valor_transferencia_text.Location = new Point(209, 124);
            valor_transferencia_text.Name = "valor_transferencia_text";
            valor_transferencia_text.Size = new Size(204, 23);
            valor_transferencia_text.TabIndex = 7;
            valor_transferencia_text.KeyPress += valor_transferencia_text_KeyPress;
            // 
            // transferir
            // 
            transferir.Location = new Point(253, 166);
            transferir.Name = "transferir";
            transferir.Size = new Size(75, 23);
            transferir.TabIndex = 8;
            transferir.Text = "Transferir";
            transferir.UseVisualStyleBackColor = true;
            transferir.Click += transferir_Click;
            // 
            // FormTransferencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 319);
            Controls.Add(transferir);
            Controls.Add(valor_transferencia_text);
            Controls.Add(destinatario_text);
            Controls.Add(valor_saldo_text);
            Controls.Add(valor_transferencia);
            Controls.Add(destinatario);
            Controls.Add(saldo);
            Controls.Add(titulo);
            Controls.Add(Sair);
            Name = "FormTransferencia";
            Text = "FormTransferencia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Sair;
        private Label titulo;
        private Label saldo;
        private Label destinatario;
        private Label valor_transferencia;
        private Label valor_saldo_text;
        private TextBox destinatario_text;
        private TextBox valor_transferencia_text;
        private Button transferir;
    }
}