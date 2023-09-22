namespace CZJB.UI
{
    partial class Form1
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
            cmbPacientes = new ComboBox();
            label1 = new Label();
            txtLog = new TextBox();
            btnFullExam = new Button();
            btnMedicalAppointment = new Button();
            SuspendLayout();
            // 
            // cmbPacientes
            // 
            cmbPacientes.FormattingEnabled = true;
            cmbPacientes.Location = new Point(69, 12);
            cmbPacientes.Name = "cmbPacientes";
            cmbPacientes.Size = new Size(312, 23);
            cmbPacientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Paciente";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(11, 100);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(370, 370);
            txtLog.TabIndex = 3;
            // 
            // btnFullExam
            // 
            btnFullExam.Location = new Point(11, 41);
            btnFullExam.Name = "btnFullExam";
            btnFullExam.Size = new Size(370, 24);
            btnFullExam.TabIndex = 4;
            btnFullExam.Text = "Realizar examen completo";
            btnFullExam.UseVisualStyleBackColor = true;
            btnFullExam.Click += btnFullExam_Click;
            // 
            // btnMedicalAppointment
            // 
            btnMedicalAppointment.Location = new Point(11, 71);
            btnMedicalAppointment.Name = "btnMedicalAppointment";
            btnMedicalAppointment.Size = new Size(370, 23);
            btnMedicalAppointment.TabIndex = 5;
            btnMedicalAppointment.Text = "Turno con medico";
            btnMedicalAppointment.UseVisualStyleBackColor = true;
            btnMedicalAppointment.Click += btnMedicalAppointment_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 483);
            Controls.Add(btnMedicalAppointment);
            Controls.Add(btnFullExam);
            Controls.Add(txtLog);
            Controls.Add(label1);
            Controls.Add(cmbPacientes);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPacientes;
        private Label label1;
        private TextBox txtLog;
        private Button btnFullExam;
        private Button btnMedicalAppointment;
    }
}