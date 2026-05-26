namespace MentCarePresentationLayer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnDoctors = new Guna.UI2.WinForms.Guna2Button();
            this.btnConsultations = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPatients
            // 
            this.btnPatients.AutoRoundedCorners = true;
            this.btnPatients.BackColor = System.Drawing.Color.Transparent;
            this.btnPatients.BorderColor = System.Drawing.Color.Transparent;
            this.btnPatients.BorderRadius = 29;
            this.btnPatients.CheckedState.Parent = this.btnPatients;
            this.btnPatients.CustomImages.Parent = this.btnPatients;
            this.btnPatients.FillColor = System.Drawing.Color.Transparent;
            this.btnPatients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatients.ForeColor = System.Drawing.Color.White;
            this.btnPatients.HoverState.Parent = this.btnPatients;
            this.btnPatients.Image = ((System.Drawing.Image)(resources.GetObject("btnPatients.Image")));
            this.btnPatients.ImageOffset = new System.Drawing.Point(-20, 0);
            this.btnPatients.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPatients.Location = new System.Drawing.Point(3, 99);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.ShadowDecoration.Parent = this.btnPatients;
            this.btnPatients.Size = new System.Drawing.Size(286, 61);
            this.btnPatients.TabIndex = 0;
            this.btnPatients.Text = "Patients";
            this.btnPatients.TextOffset = new System.Drawing.Point(-15, 0);
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnDoctors
            // 
            this.btnDoctors.AutoRoundedCorners = true;
            this.btnDoctors.BackColor = System.Drawing.Color.Transparent;
            this.btnDoctors.BorderColor = System.Drawing.Color.Transparent;
            this.btnDoctors.BorderRadius = 29;
            this.btnDoctors.CheckedState.Parent = this.btnDoctors;
            this.btnDoctors.CustomImages.Parent = this.btnDoctors;
            this.btnDoctors.FillColor = System.Drawing.Color.Transparent;
            this.btnDoctors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctors.ForeColor = System.Drawing.Color.White;
            this.btnDoctors.HoverState.Parent = this.btnDoctors;
            this.btnDoctors.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctors.Image")));
            this.btnDoctors.ImageOffset = new System.Drawing.Point(-20, 0);
            this.btnDoctors.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDoctors.Location = new System.Drawing.Point(3, 166);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.ShadowDecoration.Parent = this.btnDoctors;
            this.btnDoctors.Size = new System.Drawing.Size(286, 61);
            this.btnDoctors.TabIndex = 0;
            this.btnDoctors.Text = "Doctors";
            this.btnDoctors.TextOffset = new System.Drawing.Point(-15, 0);
            // 
            // btnConsultations
            // 
            this.btnConsultations.AutoRoundedCorners = true;
            this.btnConsultations.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultations.BorderColor = System.Drawing.Color.Transparent;
            this.btnConsultations.BorderRadius = 29;
            this.btnConsultations.CheckedState.Parent = this.btnConsultations;
            this.btnConsultations.CustomImages.Parent = this.btnConsultations;
            this.btnConsultations.FillColor = System.Drawing.Color.Transparent;
            this.btnConsultations.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultations.ForeColor = System.Drawing.Color.White;
            this.btnConsultations.HoverState.Parent = this.btnConsultations;
            this.btnConsultations.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultations.Image")));
            this.btnConsultations.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnConsultations.ImageSize = new System.Drawing.Size(40, 40);
            this.btnConsultations.Location = new System.Drawing.Point(3, 233);
            this.btnConsultations.Name = "btnConsultations";
            this.btnConsultations.ShadowDecoration.Parent = this.btnConsultations;
            this.btnConsultations.Size = new System.Drawing.Size(286, 61);
            this.btnConsultations.TabIndex = 0;
            this.btnConsultations.Text = "Consultations";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnConsultations);
            this.guna2Panel1.Controls.Add(this.btnDoctors);
            this.guna2Panel1.Controls.Add(this.btnPatients);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(35)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(295, 583);
            this.guna2Panel1.TabIndex = 5;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(295, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.ShadowDecoration.Parent = this.pnlContainer;
            this.pnlContainer.Size = new System.Drawing.Size(879, 583);
            this.pnlContainer.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1174, 583);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.guna2Panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnPatients;
        private Guna.UI2.WinForms.Guna2Button btnDoctors;
        private Guna.UI2.WinForms.Guna2Button btnConsultations;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
    }
}

