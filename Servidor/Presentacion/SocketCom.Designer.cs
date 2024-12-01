namespace Servidor
{
    partial class SocketCom
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_Mensajes = new System.Windows.Forms.TextBox();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            this.Txt_Clientes = new System.Windows.Forms.TextBox();
            this.BTN_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Mensajes
            // 
            this.Txt_Mensajes.Location = new System.Drawing.Point(9, 86);
            this.Txt_Mensajes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Mensajes.Multiline = true;
            this.Txt_Mensajes.Name = "Txt_Mensajes";
            this.Txt_Mensajes.Size = new System.Drawing.Size(567, 240);
            this.Txt_Mensajes.TabIndex = 0;
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Clientes.Location = new System.Drawing.Point(128, 38);
            this.Lbl_Clientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(183, 24);
            this.Lbl_Clientes.TabIndex = 1;
            this.Lbl_Clientes.Text = "Clientes Conectados";
            // 
            // Txt_Clientes
            // 
            this.Txt_Clientes.Enabled = false;
            this.Txt_Clientes.Location = new System.Drawing.Point(320, 43);
            this.Txt_Clientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Clientes.Name = "Txt_Clientes";
            this.Txt_Clientes.Size = new System.Drawing.Size(140, 20);
            this.Txt_Clientes.TabIndex = 2;
            // 
            // BTN_Salir
            // 
            this.BTN_Salir.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Salir.Location = new System.Drawing.Point(490, 332);
            this.BTN_Salir.Name = "BTN_Salir";
            this.BTN_Salir.Size = new System.Drawing.Size(82, 32);
            this.BTN_Salir.TabIndex = 13;
            this.BTN_Salir.Text = "Salir";
            this.BTN_Salir.UseVisualStyleBackColor = true;
            this.BTN_Salir.Click += new System.EventHandler(this.BTN_Salir_Click);
            // 
            // SocketCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 376);
            this.Controls.Add(this.BTN_Salir);
            this.Controls.Add(this.Txt_Clientes);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.Txt_Mensajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SocketCom";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Mensajes;
        private System.Windows.Forms.Label Lbl_Clientes;
        private System.Windows.Forms.TextBox Txt_Clientes;
        private System.Windows.Forms.Button BTN_Salir;
    }
}

