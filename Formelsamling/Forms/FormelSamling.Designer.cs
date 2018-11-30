namespace Formelsamling
{
    partial class FormelSamling
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
            this.FormelTree = new System.Windows.Forms.TreeView();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.FormulaSearch = new System.Windows.Forms.TextBox();
            this.fVariables = new System.Windows.Forms.CheckedListBox();
            this.ResultTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FormelTree
            // 
            this.FormelTree.Location = new System.Drawing.Point(12, 38);
            this.FormelTree.Name = "FormelTree";
            this.FormelTree.Size = new System.Drawing.Size(150, 400);
            this.FormelTree.TabIndex = 0;
            this.FormelTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FormelTree_AfterSelect);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(385, 415);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 1;
            this.CalculateButton.Text = "Udregn";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // FormulaSearch
            // 
            this.FormulaSearch.Location = new System.Drawing.Point(12, 12);
            this.FormulaSearch.Name = "FormulaSearch";
            this.FormulaSearch.Size = new System.Drawing.Size(150, 20);
            this.FormulaSearch.TabIndex = 3;
            // 
            // fVariables
            // 
            this.fVariables.CheckOnClick = true;
            this.fVariables.FormattingEnabled = true;
            this.fVariables.Location = new System.Drawing.Point(680, 299);
            this.fVariables.Name = "fVariables";
            this.fVariables.Size = new System.Drawing.Size(108, 139);
            this.fVariables.TabIndex = 4;
            this.fVariables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fVariables_ItemCheck);
            // 
            // ResultTextbox
            // 
            this.ResultTextbox.Location = new System.Drawing.Point(348, 389);
            this.ResultTextbox.Name = "ResultTextbox";
            this.ResultTextbox.ReadOnly = true;
            this.ResultTextbox.Size = new System.Drawing.Size(150, 20);
            this.ResultTextbox.TabIndex = 5;
            this.ResultTextbox.Text = "Resultat her";
            // 
            // FormelSamling
            // 
            this.AcceptButton = this.CalculateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultTextbox);
            this.Controls.Add(this.fVariables);
            this.Controls.Add(this.FormulaSearch);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.FormelTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormelSamling";
            this.Text = "Formelsamling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FormelTree;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox FormulaSearch;
        private System.Windows.Forms.CheckedListBox fVariables;
        private System.Windows.Forms.TextBox ResultTextbox;
    }
}

