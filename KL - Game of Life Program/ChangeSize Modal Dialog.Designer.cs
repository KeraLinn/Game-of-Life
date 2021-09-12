
namespace KL___Game_of_Life_Program
{
    partial class ChangeSize_Modal_Dialog
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
            this.ChangeSizeOK = new System.Windows.Forms.Button();
            this.ChangeSizeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeSizeOK
            // 
            this.ChangeSizeOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChangeSizeOK.Location = new System.Drawing.Point(110, 289);
            this.ChangeSizeOK.Name = "ChangeSizeOK";
            this.ChangeSizeOK.Size = new System.Drawing.Size(75, 23);
            this.ChangeSizeOK.TabIndex = 0;
            this.ChangeSizeOK.Text = "Apply";
            this.ChangeSizeOK.UseVisualStyleBackColor = true;
            // 
            // ChangeSizeCancel
            // 
            this.ChangeSizeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ChangeSizeCancel.Location = new System.Drawing.Point(253, 289);
            this.ChangeSizeCancel.Name = "ChangeSizeCancel";
            this.ChangeSizeCancel.Size = new System.Drawing.Size(75, 23);
            this.ChangeSizeCancel.TabIndex = 1;
            this.ChangeSizeCancel.Text = "Cancel";
            this.ChangeSizeCancel.UseVisualStyleBackColor = true;
            // 
            // ChangeSize_Modal_Dialog
            // 
            this.AcceptButton = this.ChangeSizeOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ChangeSizeCancel;
            this.ClientSize = new System.Drawing.Size(460, 361);
            this.Controls.Add(this.ChangeSizeCancel);
            this.Controls.Add(this.ChangeSizeOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSize_Modal_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeSize_Modal_Dialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChangeSizeOK;
        private System.Windows.Forms.Button ChangeSizeCancel;
    }
}