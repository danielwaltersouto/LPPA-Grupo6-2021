namespace WindowsFormsApp1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.TbpassV = new System.Windows.Forms.TextBox();
            this.TbPassHash = new System.Windows.Forms.TextBox();
            this.TbPassHashV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pass";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Encriptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Validar Pass";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pass";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(79, 30);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(100, 20);
            this.TbPass.TabIndex = 4;
            this.TbPass.TextChanged += new System.EventHandler(this.TbPass_TextChanged);
            // 
            // TbpassV
            // 
            this.TbpassV.Location = new System.Drawing.Point(79, 82);
            this.TbpassV.Name = "TbpassV";
            this.TbpassV.Size = new System.Drawing.Size(100, 20);
            this.TbpassV.TabIndex = 5;
            // 
            // TbPassHash
            // 
            this.TbPassHash.Location = new System.Drawing.Point(266, 30);
            this.TbPassHash.Name = "TbPassHash";
            this.TbPassHash.Size = new System.Drawing.Size(199, 20);
            this.TbPassHash.TabIndex = 6;
            // 
            // TbPassHashV
            // 
            this.TbPassHashV.Location = new System.Drawing.Point(266, 82);
            this.TbPassHashV.Name = "TbPassHashV";
            this.TbPassHashV.Size = new System.Drawing.Size(199, 20);
            this.TbPassHashV.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 126);
            this.Controls.Add(this.TbPassHashV);
            this.Controls.Add(this.TbPassHash);
            this.Controls.Add(this.TbpassV);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.TextBox TbpassV;
        private System.Windows.Forms.TextBox TbPassHash;
        private System.Windows.Forms.TextBox TbPassHashV;
    }
}

