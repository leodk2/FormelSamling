namespace Formelsamling
{
    partial class AddEmailToForm
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
            this.AddEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddEmail
            // 
            this.AddEmail.Location = new System.Drawing.Point(144, 101);
            this.AddEmail.Name = "AddEmail";
            this.AddEmail.Size = new System.Drawing.Size(75, 23);
            this.AddEmail.TabIndex = 5;
            this.AddEmail.Text = "Tilføj";
            this.AddEmail.UseVisualStyleBackColor = true;
            this.AddEmail.Click += new System.EventHandler(this.AddEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tilføj E-mail";
            // 
            // EmailField
            // 
            this.EmailField.Location = new System.Drawing.Point(74, 75);
            this.EmailField.Name = "EmailField";
            this.EmailField.Size = new System.Drawing.Size(221, 20);
            this.EmailField.TabIndex = 3;
            // 
            // AddEmailToForm
            // 
            this.AcceptButton = this.AddEmail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 183);
            this.Controls.Add(this.AddEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmailField);
            this.Name = "AddEmailToForm";
            this.Text = "AddEmailToForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddEmail;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox EmailField;
    }
}