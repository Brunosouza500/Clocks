namespace Alarma
{
    partial class frmSetAlarm
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
            this.txbHora = new System.Windows.Forms.TextBox();
            this.txbMinuto = new System.Windows.Forms.TextBox();
            this.txbSegundo = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbxMelodia = new System.Windows.Forms.ComboBox();
            this.btnSetAlarm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbHora
            // 
            this.txbHora.Location = new System.Drawing.Point(28, 56);
            this.txbHora.Multiline = true;
            this.txbHora.Name = "txbHora";
            this.txbHora.Size = new System.Drawing.Size(69, 67);
            this.txbHora.TabIndex = 0;
            // 
            // txbMinuto
            // 
            this.txbMinuto.Location = new System.Drawing.Point(131, 56);
            this.txbMinuto.Multiline = true;
            this.txbMinuto.Name = "txbMinuto";
            this.txbMinuto.Size = new System.Drawing.Size(69, 67);
            this.txbMinuto.TabIndex = 1;
            // 
            // txbSegundo
            // 
            this.txbSegundo.Location = new System.Drawing.Point(248, 56);
            this.txbSegundo.Multiline = true;
            this.txbSegundo.Name = "txbSegundo";
            this.txbSegundo.Size = new System.Drawing.Size(69, 67);
            this.txbSegundo.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(28, 191);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(225, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // cbxMelodia
            // 
            this.cbxMelodia.FormattingEnabled = true;
            this.cbxMelodia.Location = new System.Drawing.Point(28, 258);
            this.cbxMelodia.Name = "cbxMelodia";
            this.cbxMelodia.Size = new System.Drawing.Size(121, 21);
            this.cbxMelodia.TabIndex = 4;
            // 
            // btnSetAlarm
            // 
            this.btnSetAlarm.Location = new System.Drawing.Point(92, 311);
            this.btnSetAlarm.Name = "btnSetAlarm";
            this.btnSetAlarm.Size = new System.Drawing.Size(75, 35);
            this.btnSetAlarm.TabIndex = 5;
            this.btnSetAlarm.Text = "Set Alarm";
            this.btnSetAlarm.UseVisualStyleBackColor = true;
            this.btnSetAlarm.Click += new System.EventHandler(this.btnSetAlarm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(290, 311);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSetAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 385);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetAlarm);
            this.Controls.Add(this.cbxMelodia);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txbSegundo);
            this.Controls.Add(this.txbMinuto);
            this.Controls.Add(this.txbHora);
            this.Name = "frmSetAlarm";
            this.Text = "Alarma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbHora;
        private System.Windows.Forms.TextBox txbMinuto;
        private System.Windows.Forms.TextBox txbSegundo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbxMelodia;
        private System.Windows.Forms.Button btnSetAlarm;
        private System.Windows.Forms.Button btnExit;
    }
}