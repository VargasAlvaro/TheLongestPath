namespace WFALongestSkiRun
{
    partial class FormLongestSkiRun
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.buttonProcces = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLoadInput = new System.Windows.Forms.Button();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.labelResults = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelImputMatriz = new System.Windows.Forms.Label();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.buttonProcces);
            this.panelPrincipal.Controls.Add(this.buttonCancel);
            this.panelPrincipal.Controls.Add(this.buttonLoadInput);
            this.panelPrincipal.Controls.Add(this.textBoxResults);
            this.panelPrincipal.Controls.Add(this.labelResults);
            this.panelPrincipal.Controls.Add(this.textBoxInput);
            this.panelPrincipal.Controls.Add(this.labelImputMatriz);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(494, 256);
            this.panelPrincipal.TabIndex = 0;
            // 
            // buttonProcces
            // 
            this.buttonProcces.Location = new System.Drawing.Point(89, 216);
            this.buttonProcces.Name = "buttonProcces";
            this.buttonProcces.Size = new System.Drawing.Size(75, 23);
            this.buttonProcces.TabIndex = 6;
            this.buttonProcces.Text = "Procces";
            this.buttonProcces.UseVisualStyleBackColor = true;
            this.buttonProcces.Click += new System.EventHandler(this.ButtonProcces_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(338, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonLoadInput
            // 
            this.buttonLoadInput.Location = new System.Drawing.Point(30, 80);
            this.buttonLoadInput.Name = "buttonLoadInput";
            this.buttonLoadInput.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadInput.TabIndex = 4;
            this.buttonLoadInput.Text = "Load";
            this.buttonLoadInput.UseVisualStyleBackColor = true;
            this.buttonLoadInput.Click += new System.EventHandler(this.ButtonLoadInput_Click);
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(30, 147);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(451, 63);
            this.textBoxResults.TabIndex = 3;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(27, 131);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(42, 13);
            this.labelResults.TabIndex = 2;
            this.labelResults.Text = "Results";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(30, 54);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(451, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // labelImputMatriz
            // 
            this.labelImputMatriz.AutoSize = true;
            this.labelImputMatriz.Location = new System.Drawing.Point(27, 38);
            this.labelImputMatriz.Name = "labelImputMatriz";
            this.labelImputMatriz.Size = new System.Drawing.Size(64, 13);
            this.labelImputMatriz.TabIndex = 0;
            this.labelImputMatriz.Text = "Imput Matriz";
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.FileName = "openFileDialogInput";
            // 
            // FormLongestSkiRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 256);
            this.Controls.Add(this.panelPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 295);
            this.MinimumSize = new System.Drawing.Size(510, 295);
            this.Name = "FormLongestSkiRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Longest Ski Run";
            this.Load += new System.EventHandler(this.FormLongestSkiRun_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLoadInput;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelImputMatriz;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.Button buttonProcces;
    }
}

