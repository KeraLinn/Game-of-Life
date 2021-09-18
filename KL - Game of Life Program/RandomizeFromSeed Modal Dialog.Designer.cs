
namespace KL___Game_of_Life_Program
{
    partial class RandomizeFromSeed_Modal_Dialog
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
            this.SeedNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LabelSeed = new System.Windows.Forms.Label();
            this.SeedButtonOK = new System.Windows.Forms.Button();
            this.SeedButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // SeedNumericUpDown1
            // 
            this.SeedNumericUpDown1.Location = new System.Drawing.Point(136, 39);
            this.SeedNumericUpDown1.Name = "SeedNumericUpDown1";
            this.SeedNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.SeedNumericUpDown1.TabIndex = 0;
            // 
            // LabelSeed
            // 
            this.LabelSeed.AutoSize = true;
            this.LabelSeed.Location = new System.Drawing.Point(83, 41);
            this.LabelSeed.Name = "LabelSeed";
            this.LabelSeed.Size = new System.Drawing.Size(32, 13);
            this.LabelSeed.TabIndex = 1;
            this.LabelSeed.Text = "Seed";
            // 
            // SeedButtonOK
            // 
            this.SeedButtonOK.Location = new System.Drawing.Point(86, 106);
            this.SeedButtonOK.Name = "SeedButtonOK";
            this.SeedButtonOK.Size = new System.Drawing.Size(75, 23);
            this.SeedButtonOK.TabIndex = 2;
            this.SeedButtonOK.Text = "OK";
            this.SeedButtonOK.UseVisualStyleBackColor = true;
            // 
            // SeedButtonCancel
            // 
            this.SeedButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SeedButtonCancel.Location = new System.Drawing.Point(216, 106);
            this.SeedButtonCancel.Name = "SeedButtonCancel";
            this.SeedButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.SeedButtonCancel.TabIndex = 3;
            this.SeedButtonCancel.Text = "Cancel";
            this.SeedButtonCancel.UseVisualStyleBackColor = true;
            // 
            // RandomizeFromSeed_Modal_Dialog
            // 
            this.AcceptButton = this.SeedButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SeedButtonCancel;
            this.ClientSize = new System.Drawing.Size(376, 173);
            this.Controls.Add(this.SeedButtonCancel);
            this.Controls.Add(this.SeedButtonOK);
            this.Controls.Add(this.LabelSeed);
            this.Controls.Add(this.SeedNumericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomizeFromSeed_Modal_Dialog";
            this.Text = "Randomize from Seed";
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SeedNumericUpDown1;
        private System.Windows.Forms.Label LabelSeed;
        private System.Windows.Forms.Button SeedButtonOK;
        private System.Windows.Forms.Button SeedButtonCancel;
    }
}