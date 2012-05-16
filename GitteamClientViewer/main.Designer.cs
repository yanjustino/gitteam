namespace GitteamClientViewer
{
    partial class main
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
            this.btnVerificarCommitsPendentes = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnVerificarCommitsPendentes
            // 
            this.btnVerificarCommitsPendentes.Location = new System.Drawing.Point(121, 14);
            this.btnVerificarCommitsPendentes.Name = "btnVerificarCommitsPendentes";
            this.btnVerificarCommitsPendentes.Size = new System.Drawing.Size(247, 23);
            this.btnVerificarCommitsPendentes.TabIndex = 1;
            this.btnVerificarCommitsPendentes.Text = "Verificar Commits Pendentes";
            this.btnVerificarCommitsPendentes.UseVisualStyleBackColor = true;
            this.btnVerificarCommitsPendentes.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(15, 16);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(720, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 262);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnVerificarCommitsPendentes);
            this.Name = "main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerificarCommitsPendentes;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

