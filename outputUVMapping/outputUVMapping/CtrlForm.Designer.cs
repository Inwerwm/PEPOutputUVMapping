namespace outputUVMapping
{
    partial class CtrlForm
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
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.materialListBox = new System.Windows.Forms.ListBox();
            this.bgGroupBox = new System.Windows.Forms.GroupBox();
            this.radioBgWhite = new System.Windows.Forms.RadioButton();
            this.radioBgTrans = new System.Windows.Forms.RadioButton();
            this.radioBgTex = new System.Windows.Forms.RadioButton();
            this.numOfSelectLabel = new System.Windows.Forms.Label();
            this.reloadButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorDialogButton = new System.Windows.Forms.Button();
            this.selectedColor = new System.Windows.Forms.Panel();
            this.lineWidth = new System.Windows.Forms.NumericUpDown();
            this.lineWidthLabel = new System.Windows.Forms.Label();
            this.bgGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExecuteButton.Location = new System.Drawing.Point(265, 397);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(98, 39);
            this.ExecuteButton.TabIndex = 0;
            this.ExecuteButton.Text = "出力";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // materialListBox
            // 
            this.materialListBox.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.materialListBox.FormattingEnabled = true;
            this.materialListBox.ItemHeight = 21;
            this.materialListBox.Location = new System.Drawing.Point(12, 12);
            this.materialListBox.Name = "materialListBox";
            this.materialListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.materialListBox.Size = new System.Drawing.Size(247, 424);
            this.materialListBox.TabIndex = 1;
            this.materialListBox.SelectedIndexChanged += new System.EventHandler(this.MaterialListBox_SelectedIndexChanged);
            // 
            // bgGroupBox
            // 
            this.bgGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.bgGroupBox.Controls.Add(this.radioBgWhite);
            this.bgGroupBox.Controls.Add(this.radioBgTrans);
            this.bgGroupBox.Controls.Add(this.radioBgTex);
            this.bgGroupBox.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bgGroupBox.Location = new System.Drawing.Point(266, 269);
            this.bgGroupBox.Name = "bgGroupBox";
            this.bgGroupBox.Size = new System.Drawing.Size(98, 122);
            this.bgGroupBox.TabIndex = 2;
            this.bgGroupBox.TabStop = false;
            this.bgGroupBox.Text = "背景";
            // 
            // radioBgWhite
            // 
            this.radioBgWhite.AutoSize = true;
            this.radioBgWhite.Location = new System.Drawing.Point(6, 90);
            this.radioBgWhite.Name = "radioBgWhite";
            this.radioBgWhite.Size = new System.Drawing.Size(44, 25);
            this.radioBgWhite.TabIndex = 2;
            this.radioBgWhite.Text = "白";
            this.radioBgWhite.UseVisualStyleBackColor = true;
            // 
            // radioBgTrans
            // 
            this.radioBgTrans.AutoSize = true;
            this.radioBgTrans.Checked = true;
            this.radioBgTrans.Location = new System.Drawing.Point(6, 59);
            this.radioBgTrans.Name = "radioBgTrans";
            this.radioBgTrans.Size = new System.Drawing.Size(60, 25);
            this.radioBgTrans.TabIndex = 1;
            this.radioBgTrans.TabStop = true;
            this.radioBgTrans.Text = "透過";
            this.radioBgTrans.UseVisualStyleBackColor = true;
            // 
            // radioBgTex
            // 
            this.radioBgTex.AutoSize = true;
            this.radioBgTex.Location = new System.Drawing.Point(6, 28);
            this.radioBgTex.Name = "radioBgTex";
            this.radioBgTex.Size = new System.Drawing.Size(87, 25);
            this.radioBgTex.TabIndex = 0;
            this.radioBgTex.Text = "テクスチャ";
            this.radioBgTex.UseVisualStyleBackColor = true;
            // 
            // numOfSelectLabel
            // 
            this.numOfSelectLabel.AutoSize = true;
            this.numOfSelectLabel.BackColor = System.Drawing.SystemColors.Control;
            this.numOfSelectLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numOfSelectLabel.Location = new System.Drawing.Point(262, 42);
            this.numOfSelectLabel.Name = "numOfSelectLabel";
            this.numOfSelectLabel.Size = new System.Drawing.Size(83, 21);
            this.numOfSelectLabel.TabIndex = 3;
            this.numOfSelectLabel.Text = "選択数：0";
            // 
            // reloadButton
            // 
            this.reloadButton.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reloadButton.Location = new System.Drawing.Point(265, 12);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(98, 27);
            this.reloadButton.TabIndex = 4;
            this.reloadButton.Text = "再読込";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // colorDialogButton
            // 
            this.colorDialogButton.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colorDialogButton.Location = new System.Drawing.Point(265, 201);
            this.colorDialogButton.Name = "colorDialogButton";
            this.colorDialogButton.Size = new System.Drawing.Size(98, 26);
            this.colorDialogButton.TabIndex = 5;
            this.colorDialogButton.Text = "描画色の設定";
            this.colorDialogButton.UseVisualStyleBackColor = true;
            this.colorDialogButton.Click += new System.EventHandler(this.ColorDialogButton_Click);
            // 
            // selectedColor
            // 
            this.selectedColor.BackColor = System.Drawing.Color.Black;
            this.selectedColor.Location = new System.Drawing.Point(265, 233);
            this.selectedColor.Name = "selectedColor";
            this.selectedColor.Size = new System.Drawing.Size(98, 25);
            this.selectedColor.TabIndex = 6;
            // 
            // lineWidth
            // 
            this.lineWidth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lineWidth.Location = new System.Drawing.Point(265, 166);
            this.lineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(98, 29);
            this.lineWidth.TabIndex = 8;
            this.lineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lineWidthLabel
            // 
            this.lineWidthLabel.AutoSize = true;
            this.lineWidthLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lineWidthLabel.Location = new System.Drawing.Point(261, 142);
            this.lineWidthLabel.Name = "lineWidthLabel";
            this.lineWidthLabel.Size = new System.Drawing.Size(82, 21);
            this.lineWidthLabel.TabIndex = 9;
            this.lineWidthLabel.Text = "線の太さ：";
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 450);
            this.Controls.Add(this.lineWidthLabel);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.selectedColor);
            this.Controls.Add(this.colorDialogButton);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.numOfSelectLabel);
            this.Controls.Add(this.bgGroupBox);
            this.Controls.Add(this.materialListBox);
            this.Controls.Add(this.ExecuteButton);
            this.Name = "CtrlForm";
            this.Text = "UVマップ画像出力";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.bgGroupBox.ResumeLayout(false);
            this.bgGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.ListBox materialListBox;
        private System.Windows.Forms.GroupBox bgGroupBox;
        private System.Windows.Forms.RadioButton radioBgWhite;
        private System.Windows.Forms.RadioButton radioBgTrans;
        private System.Windows.Forms.RadioButton radioBgTex;
        private System.Windows.Forms.Label numOfSelectLabel;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button colorDialogButton;
        private System.Windows.Forms.Panel selectedColor;
        private System.Windows.Forms.NumericUpDown lineWidth;
        private System.Windows.Forms.Label lineWidthLabel;
    }
}