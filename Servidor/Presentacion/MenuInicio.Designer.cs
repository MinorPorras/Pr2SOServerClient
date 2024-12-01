namespace Servidor.Presentacion
{
    partial class MenuInicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Mantenimiento = new System.Windows.Forms.Button();
            this.BTN_SocketCom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú Principal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BTN_Mantenimiento
            // 
            this.BTN_Mantenimiento.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Mantenimiento.Location = new System.Drawing.Point(57, 83);
            this.BTN_Mantenimiento.Name = "BTN_Mantenimiento";
            this.BTN_Mantenimiento.Size = new System.Drawing.Size(170, 60);
            this.BTN_Mantenimiento.TabIndex = 1;
            this.BTN_Mantenimiento.Text = "1. Mantenimiento del padrón";
            this.BTN_Mantenimiento.UseVisualStyleBackColor = true;
            this.BTN_Mantenimiento.Click += new System.EventHandler(this.BTN_Mantenimiento_Click);
            // 
            // BTN_SocketCom
            // 
            this.BTN_SocketCom.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SocketCom.Location = new System.Drawing.Point(57, 178);
            this.BTN_SocketCom.Name = "BTN_SocketCom";
            this.BTN_SocketCom.Size = new System.Drawing.Size(170, 60);
            this.BTN_SocketCom.TabIndex = 2;
            this.BTN_SocketCom.Text = "2. Socket de comunicación";
            this.BTN_SocketCom.UseVisualStyleBackColor = true;
            this.BTN_SocketCom.Click += new System.EventHandler(this.BTN_SocketCom_Click);
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 291);
            this.Controls.Add(this.BTN_SocketCom);
            this.Controls.Add(this.BTN_Mantenimiento);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "MenuInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuInicio";
            this.Load += new System.EventHandler(this.MenuInicio_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MenuInicio_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Mantenimiento;
        private System.Windows.Forms.Button BTN_SocketCom;
    }
}