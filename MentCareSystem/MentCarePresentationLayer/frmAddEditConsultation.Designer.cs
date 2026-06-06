namespace MentCarePresentationLayer
{
    partial class frmAddEditConsultation
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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.dtConsultationDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblConsultationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddEditConsultation = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbPatients = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTreatmentPlan = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbDoctors = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Location = new System.Drawing.Point(408, 614);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(98, 50);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(147, 614);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(98, 50);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtConsultationDate
            // 
            this.dtConsultationDate.BorderRadius = 15;
            this.dtConsultationDate.CheckedState.Parent = this.dtConsultationDate;
            this.dtConsultationDate.CustomFormat = "";
            this.dtConsultationDate.FillColor = System.Drawing.Color.White;
            this.dtConsultationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtConsultationDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtConsultationDate.HoverState.Parent = this.dtConsultationDate;
            this.dtConsultationDate.Location = new System.Drawing.Point(382, 133);
            this.dtConsultationDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtConsultationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtConsultationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtConsultationDate.Name = "dtConsultationDate";
            this.dtConsultationDate.ShadowDecoration.Parent = this.dtConsultationDate;
            this.dtConsultationDate.Size = new System.Drawing.Size(241, 36);
            this.dtConsultationDate.TabIndex = 23;
            this.dtConsultationDate.Value = new System.DateTime(2026, 6, 5, 1, 5, 34, 28);
            // 
            // lblConsultationID
            // 
            this.lblConsultationID.AutoSize = true;
            this.lblConsultationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultationID.Location = new System.Drawing.Point(165, 132);
            this.lblConsultationID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsultationID.Name = "lblConsultationID";
            this.lblConsultationID.Size = new System.Drawing.Size(27, 20);
            this.lblConsultationID.TabIndex = 18;
            this.lblConsultationID.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Patient";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Consultation ID";
            // 
            // lblAddEditConsultation
            // 
            this.lblAddEditConsultation.BackColor = System.Drawing.Color.Transparent;
            this.lblAddEditConsultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditConsultation.Location = new System.Drawing.Point(239, 31);
            this.lblAddEditConsultation.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddEditConsultation.Name = "lblAddEditConsultation";
            this.lblAddEditConsultation.Size = new System.Drawing.Size(190, 26);
            this.lblAddEditConsultation.TabIndex = 13;
            this.lblAddEditConsultation.Text = "Add New Consultation";
            // 
            // cbPatients
            // 
            this.cbPatients.BackColor = System.Drawing.Color.Transparent;
            this.cbPatients.BorderRadius = 15;
            this.cbPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPatients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatients.FocusedColor = System.Drawing.Color.Empty;
            this.cbPatients.FocusedState.Parent = this.cbPatients;
            this.cbPatients.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.HoverState.Parent = this.cbPatients;
            this.cbPatients.IntegralHeight = false;
            this.cbPatients.ItemHeight = 30;
            this.cbPatients.ItemsAppearance.Parent = this.cbPatients;
            this.cbPatients.Location = new System.Drawing.Point(43, 213);
            this.cbPatients.MaxDropDownItems = 5;
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.ShadowDecoration.Parent = this.cbPatients;
            this.cbPatients.Size = new System.Drawing.Size(140, 36);
            this.cbPatients.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(209, 190);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Doctor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Consultation Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(378, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Diagnosis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Treatment Plan";
            // 
            // txtTreatmentPlan
            // 
            this.txtTreatmentPlan.AutoScroll = true;
            this.txtTreatmentPlan.AutoScrollMinSize = new System.Drawing.Size(2, 5);
            this.txtTreatmentPlan.BorderRadius = 15;
            this.txtTreatmentPlan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTreatmentPlan.DefaultText = "";
            this.txtTreatmentPlan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTreatmentPlan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTreatmentPlan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTreatmentPlan.DisabledState.Parent = this.txtTreatmentPlan;
            this.txtTreatmentPlan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTreatmentPlan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTreatmentPlan.FocusedState.Parent = this.txtTreatmentPlan;
            this.txtTreatmentPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTreatmentPlan.ForeColor = System.Drawing.Color.Black;
            this.txtTreatmentPlan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTreatmentPlan.HoverState.Parent = this.txtTreatmentPlan;
            this.txtTreatmentPlan.Location = new System.Drawing.Point(52, 310);
            this.txtTreatmentPlan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTreatmentPlan.Multiline = true;
            this.txtTreatmentPlan.Name = "txtTreatmentPlan";
            this.txtTreatmentPlan.PasswordChar = '\0';
            this.txtTreatmentPlan.PlaceholderText = "";
            this.txtTreatmentPlan.SelectedText = "";
            this.txtTreatmentPlan.ShadowDecoration.Parent = this.txtTreatmentPlan;
            this.txtTreatmentPlan.Size = new System.Drawing.Size(580, 156);
            this.txtTreatmentPlan.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 471);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.AutoScroll = true;
            this.txtNotes.AutoScrollMinSize = new System.Drawing.Size(2, 5);
            this.txtNotes.BorderRadius = 15;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.Parent = this.txtNotes;
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.FocusedState.Parent = this.txtNotes;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.HoverState.Parent = this.txtNotes;
            this.txtNotes.Location = new System.Drawing.Point(52, 496);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.ShadowDecoration.Parent = this.txtNotes;
            this.txtNotes.Size = new System.Drawing.Size(580, 77);
            this.txtNotes.TabIndex = 37;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BorderRadius = 15;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiagnosis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiagnosis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.DisabledState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiagnosis.FocusedState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.txtDiagnosis.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiagnosis.HoverState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Location = new System.Drawing.Point(382, 213);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PasswordChar = '\0';
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.ShadowDecoration.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Size = new System.Drawing.Size(241, 36);
            this.txtDiagnosis.TabIndex = 38;
            // 
            // cbDoctors
            // 
            this.cbDoctors.BackColor = System.Drawing.Color.Transparent;
            this.cbDoctors.BorderRadius = 15;
            this.cbDoctors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDoctors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctors.FocusedColor = System.Drawing.Color.Empty;
            this.cbDoctors.FocusedState.Parent = this.cbDoctors;
            this.cbDoctors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.HoverState.Parent = this.cbDoctors;
            this.cbDoctors.IntegralHeight = false;
            this.cbDoctors.ItemHeight = 30;
            this.cbDoctors.ItemsAppearance.Parent = this.cbDoctors;
            this.cbDoctors.Location = new System.Drawing.Point(204, 213);
            this.cbDoctors.MaxDropDownItems = 5;
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.ShadowDecoration.Parent = this.cbDoctors;
            this.cbDoctors.Size = new System.Drawing.Size(140, 36);
            this.cbDoctors.TabIndex = 28;
            // 
            // frmAddEditConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 706);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtTreatmentPlan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDoctors);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtConsultationDate);
            this.Controls.Add(this.lblConsultationID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddEditConsultation);
            this.Name = "frmAddEditConsultation";
            this.Text = "frmAddEditConsultation";
            this.Load += new System.EventHandler(this.frmAddEditConsultation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtConsultationDate;
        private System.Windows.Forms.Label lblConsultationID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAddEditConsultation;
        private Guna.UI2.WinForms.Guna2ComboBox cbPatients;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtTreatmentPlan;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private Guna.UI2.WinForms.Guna2ComboBox cbDoctors;
    }
}