﻿
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
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeSizeOK
            // 
            this.ChangeSizeOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChangeSizeOK.Location = new System.Drawing.Point(57, 145);
            this.ChangeSizeOK.Name = "ChangeSizeOK";
            this.ChangeSizeOK.Size = new System.Drawing.Size(75, 23);
            this.ChangeSizeOK.TabIndex = 0;
            this.ChangeSizeOK.Text = "Apply";
            this.ChangeSizeOK.UseVisualStyleBackColor = true;
            // 
            // ChangeSizeCancel
            // 
            this.ChangeSizeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ChangeSizeCancel.Location = new System.Drawing.Point(170, 145);
            this.ChangeSizeCancel.Name = "ChangeSizeCancel";
            this.ChangeSizeCancel.Size = new System.Drawing.Size(75, 23);
            this.ChangeSizeCancel.TabIndex = 1;
            this.ChangeSizeCancel.Text = "Cancel";
            this.ChangeSizeCancel.UseVisualStyleBackColor = true;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(86, 38);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 2;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(86, 87);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 3;
            this.labelWidth.Text = "Width";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(145, 36);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownHeight.TabIndex = 4;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(145, 85);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownWidth.TabIndex = 6;
            // 
            // ChangeSize_Modal_Dialog
            // 
            this.AcceptButton = this.ChangeSizeOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ChangeSizeCancel;
            this.ClientSize = new System.Drawing.Size(338, 212);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.ChangeSizeCancel);
            this.Controls.Add(this.ChangeSizeOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSize_Modal_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Universe Size";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeSizeOK;
        private System.Windows.Forms.Button ChangeSizeCancel;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
    }
}