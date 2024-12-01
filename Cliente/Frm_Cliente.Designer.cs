namespace Cliente
{
    partial class Frm_Cliente
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
            Txt_Mensaje = new TextBox();
            Bnt_Enviar = new Button();
            Btn_Conectar = new Button();
            Txt_Servidor = new TextBox();
            Btn_Desconectar = new Button();
            SuspendLayout();
            // 
            // Txt_Mensaje
            // 
            Txt_Mensaje.Location = new Point(4, 54);
            Txt_Mensaje.Margin = new Padding(3, 2, 3, 2);
            Txt_Mensaje.Multiline = true;
            Txt_Mensaje.Name = "Txt_Mensaje";
            Txt_Mensaje.Size = new Size(686, 197);
            Txt_Mensaje.TabIndex = 0;
            // 
            // Bnt_Enviar
            // 
            Bnt_Enviar.Location = new Point(580, 264);
            Bnt_Enviar.Margin = new Padding(3, 2, 3, 2);
            Bnt_Enviar.Name = "Bnt_Enviar";
            Bnt_Enviar.Size = new Size(110, 28);
            Bnt_Enviar.TabIndex = 1;
            Bnt_Enviar.Text = "&Enviar";
            Bnt_Enviar.UseVisualStyleBackColor = true;
            Bnt_Enviar.Click += Bnt_Enviar_Click;
            // 
            // Btn_Conectar
            // 
            Btn_Conectar.Location = new Point(512, 11);
            Btn_Conectar.Margin = new Padding(3, 2, 3, 2);
            Btn_Conectar.Name = "Btn_Conectar";
            Btn_Conectar.Size = new Size(82, 31);
            Btn_Conectar.TabIndex = 2;
            Btn_Conectar.Text = "&Conectar";
            Btn_Conectar.UseVisualStyleBackColor = true;
            Btn_Conectar.Click += Btn_Conectar_Click;
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Location = new Point(4, 14);
            Txt_Servidor.Margin = new Padding(3, 2, 3, 2);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(502, 23);
            Txt_Servidor.TabIndex = 3;
            // 
            // Btn_Desconectar
            // 
            Btn_Desconectar.Location = new Point(599, 11);
            Btn_Desconectar.Margin = new Padding(3, 2, 3, 2);
            Btn_Desconectar.Name = "Btn_Desconectar";
            Btn_Desconectar.Size = new Size(91, 31);
            Btn_Desconectar.TabIndex = 4;
            Btn_Desconectar.Text = "&Desconectar";
            Btn_Desconectar.UseVisualStyleBackColor = true;
            Btn_Desconectar.Click += Btn_Desconectar_Click;
            // 
            // Frm_Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 314);
            Controls.Add(Btn_Desconectar);
            Controls.Add(Txt_Servidor);
            Controls.Add(Btn_Conectar);
            Controls.Add(Bnt_Enviar);
            Controls.Add(Txt_Mensaje);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Frm_Cliente";
            Text = "Peticiones de Cliente";
            Load += Frm_Cliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Mensaje;
        private Button Bnt_Enviar;
        private Button Btn_Conectar;
        private TextBox Txt_Servidor;
        private Button Btn_Desconectar;
    }
}