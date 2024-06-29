namespace Fear
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.pnl_Detail = new System.Windows.Forms.Panel();
            this.pbox_Olho = new System.Windows.Forms.PictureBox();
            this.tbox_PW_Usuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbox_UNm_Usuario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_Button = new System.Windows.Forms.Panel();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Olho)).BeginInit();
            this.pnl_Button.SuspendLayout();
            this.pnl_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detail
            // 
            this.pnl_Detail.BackColor = System.Drawing.Color.GhostWhite;
            this.pnl_Detail.Controls.Add(this.panel1);
            this.pnl_Detail.Controls.Add(this.pbox_Olho);
            this.pnl_Detail.Controls.Add(this.tbox_PW_Usuario);
            this.pnl_Detail.Controls.Add(this.label11);
            this.pnl_Detail.Controls.Add(this.tbox_UNm_Usuario);
            this.pnl_Detail.Controls.Add(this.label8);
            this.pnl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detail.Location = new System.Drawing.Point(0, 44);
            this.pnl_Detail.Name = "pnl_Detail";
            this.pnl_Detail.Size = new System.Drawing.Size(402, 128);
            this.pnl_Detail.TabIndex = 13;
            // 
            // pbox_Olho
            // 
            this.pbox_Olho.Image = ((System.Drawing.Image)(resources.GetObject("pbox_Olho.Image")));
            this.pbox_Olho.Location = new System.Drawing.Point(198, 81);
            this.pbox_Olho.Name = "pbox_Olho";
            this.pbox_Olho.Size = new System.Drawing.Size(23, 22);
            this.pbox_Olho.TabIndex = 8;
            this.pbox_Olho.TabStop = false;
            this.pbox_Olho.Click += new System.EventHandler(this.pbox_Olho_Click);
            // 
            // tbox_PW_Usuario
            // 
            this.tbox_PW_Usuario.Location = new System.Drawing.Point(66, 82);
            this.tbox_PW_Usuario.Name = "tbox_PW_Usuario";
            this.tbox_PW_Usuario.PasswordChar = '*';
            this.tbox_PW_Usuario.Size = new System.Drawing.Size(132, 20);
            this.tbox_PW_Usuario.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "PassWord";
            // 
            // tbox_UNm_Usuario
            // 
            this.tbox_UNm_Usuario.Location = new System.Drawing.Point(66, 41);
            this.tbox_UNm_Usuario.Name = "tbox_UNm_Usuario";
            this.tbox_UNm_Usuario.Size = new System.Drawing.Size(132, 20);
            this.tbox_UNm_Usuario.TabIndex = 1;
            this.tbox_UNm_Usuario.Tag = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "UserName";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // pnl_Button
            // 
            this.pnl_Button.BackColor = System.Drawing.Color.Indigo;
            this.pnl_Button.Controls.Add(this.btn_Confirmar);
            this.pnl_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Button.Location = new System.Drawing.Point(0, 172);
            this.pnl_Button.Name = "pnl_Button";
            this.pnl_Button.Size = new System.Drawing.Size(402, 35);
            this.pnl_Button.TabIndex = 12;
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.BackColor = System.Drawing.Color.Lavender;
            this.btn_Confirmar.FlatAppearance.BorderSize = 0;
            this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirmar.Location = new System.Drawing.Point(166, 6);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirmar.TabIndex = 4;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = false;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // pnl_Title
            // 
            this.pnl_Title.BackColor = System.Drawing.Color.Indigo;
            this.pnl_Title.Controls.Add(this.label5);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(402, 44);
            this.pnl_Title.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Login";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 10);
            this.panel1.TabIndex = 12;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 207);
            this.Controls.Add(this.pnl_Detail);
            this.Controls.Add(this.pnl_Button);
            this.Controls.Add(this.pnl_Title);
            this.Name = "frm_Login";
            this.Text = "frm_Login";
            this.pnl_Detail.ResumeLayout(false);
            this.pnl_Detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Olho)).EndInit();
            this.pnl_Button.ResumeLayout(false);
            this.pnl_Title.ResumeLayout(false);
            this.pnl_Title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detail;
        private System.Windows.Forms.PictureBox pbox_Olho;
        private System.Windows.Forms.TextBox tbox_PW_Usuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbox_UNm_Usuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnl_Button;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Panel pnl_Title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}