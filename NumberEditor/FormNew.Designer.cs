namespace NumberEditor
{
    partial class FormNew
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
            this.groupBoxImage = new DarkUI.Controls.DarkGroupBox();
            this.upDownImageHeight = new DarkUI.Controls.DarkNumericUpDown();
            this.upDownImageWidth = new DarkUI.Controls.DarkNumericUpDown();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.label4 = new DarkUI.Controls.DarkLabel();
            this.label3 = new DarkUI.Controls.DarkLabel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.groupBoxGrid = new DarkUI.Controls.DarkGroupBox();
            this.upDownGridHeight = new DarkUI.Controls.DarkNumericUpDown();
            this.upDownGridWidth = new DarkUI.Controls.DarkNumericUpDown();
            this.label5 = new DarkUI.Controls.DarkLabel();
            this.label6 = new DarkUI.Controls.DarkLabel();
            this.label7 = new DarkUI.Controls.DarkLabel();
            this.label8 = new DarkUI.Controls.DarkLabel();
            this.btnOK = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownImageWidth)).BeginInit();
            this.groupBoxGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownGridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownGridWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.upDownImageHeight);
            this.groupBoxImage.Controls.Add(this.upDownImageWidth);
            this.groupBoxImage.Controls.Add(this.label2);
            this.groupBoxImage.Controls.Add(this.label4);
            this.groupBoxImage.Controls.Add(this.label3);
            this.groupBoxImage.Controls.Add(this.label1);
            this.groupBoxImage.Location = new System.Drawing.Point(22, 27);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(389, 89);
            this.groupBoxImage.TabIndex = 0;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Image Size";
            // 
            // upDownImageHeight
            // 
            this.upDownImageHeight.Location = new System.Drawing.Point(206, 47);
            this.upDownImageHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upDownImageHeight.Name = "upDownImageHeight";
            this.upDownImageHeight.Size = new System.Drawing.Size(120, 20);
            this.upDownImageHeight.TabIndex = 2;
            this.upDownImageHeight.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // upDownImageWidth
            // 
            this.upDownImageWidth.Location = new System.Drawing.Point(18, 49);
            this.upDownImageWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upDownImageWidth.Name = "upDownImageWidth";
            this.upDownImageWidth.Size = new System.Drawing.Size(120, 20);
            this.upDownImageWidth.TabIndex = 1;
            this.upDownImageWidth.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "pixel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "pixel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.upDownGridHeight);
            this.groupBoxGrid.Controls.Add(this.upDownGridWidth);
            this.groupBoxGrid.Controls.Add(this.label5);
            this.groupBoxGrid.Controls.Add(this.label6);
            this.groupBoxGrid.Controls.Add(this.label7);
            this.groupBoxGrid.Controls.Add(this.label8);
            this.groupBoxGrid.Location = new System.Drawing.Point(22, 141);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(389, 89);
            this.groupBoxGrid.TabIndex = 0;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "Grid Size";
            // 
            // upDownGridHeight
            // 
            this.upDownGridHeight.Location = new System.Drawing.Point(206, 48);
            this.upDownGridHeight.Name = "upDownGridHeight";
            this.upDownGridHeight.Size = new System.Drawing.Size(120, 20);
            this.upDownGridHeight.TabIndex = 2;
            this.upDownGridHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // upDownGridWidth
            // 
            this.upDownGridWidth.Location = new System.Drawing.Point(18, 49);
            this.upDownGridWidth.Name = "upDownGridWidth";
            this.upDownGridWidth.Size = new System.Drawing.Size(120, 20);
            this.upDownGridWidth.TabIndex = 1;
            this.upDownGridWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "pixel";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "pixel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Width";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(249, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(336, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            
            // 
            // FormNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 329);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBoxGrid);
            this.Controls.Add(this.groupBoxImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNew";
            this.Text = "New";
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownImageWidth)).EndInit();
            this.groupBoxGrid.ResumeLayout(false);
            this.groupBoxGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownGridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownGridWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox groupBoxImage;
        private DarkUI.Controls.DarkNumericUpDown upDownImageHeight;
        private DarkUI.Controls.DarkNumericUpDown upDownImageWidth;
        private DarkUI.Controls.DarkLabel label2;
        private DarkUI.Controls.DarkLabel label4;
        private DarkUI.Controls.DarkLabel label3;
        private DarkUI.Controls.DarkLabel label1;
        private DarkUI.Controls.DarkGroupBox groupBoxGrid;
        private DarkUI.Controls.DarkNumericUpDown upDownGridHeight;
        private DarkUI.Controls.DarkNumericUpDown upDownGridWidth;
        private DarkUI.Controls.DarkLabel label5;
        private DarkUI.Controls.DarkLabel label6;
        private DarkUI.Controls.DarkLabel label7;
        private DarkUI.Controls.DarkLabel label8;
        private DarkUI.Controls.DarkButton btnOK;
        private DarkUI.Controls.DarkButton btnCancel;
    }
}