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
            this.checkBoxWeightMode = new System.Windows.Forms.CheckBox();
            this.comboBoxWeightBone = new System.Windows.Forms.ComboBox();
            this.groupBoxWeightMode = new System.Windows.Forms.GroupBox();
            this.checkBoxWPoint = new System.Windows.Forms.CheckBox();
            this.numericScale = new System.Windows.Forms.NumericUpDown();
            this.labelScale = new System.Windows.Forms.Label();
            this.checkBoxWLine = new System.Windows.Forms.CheckBox();
            this.checkBoxWFace = new System.Windows.Forms.CheckBox();
            this.bgGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
            this.groupBoxWeightMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScale)).BeginInit();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExecuteButton.Location = new System.Drawing.Point(258, 706);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(147, 68);
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
            this.materialListBox.Location = new System.Drawing.Point(13, 14);
            this.materialListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.materialListBox.Name = "materialListBox";
            this.materialListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.materialListBox.Size = new System.Drawing.Size(237, 760);
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
            this.bgGroupBox.Location = new System.Drawing.Point(258, 556);
            this.bgGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bgGroupBox.Name = "bgGroupBox";
            this.bgGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bgGroupBox.Size = new System.Drawing.Size(147, 140);
            this.bgGroupBox.TabIndex = 2;
            this.bgGroupBox.TabStop = false;
            this.bgGroupBox.Text = "背景";
            // 
            // radioBgWhite
            // 
            this.radioBgWhite.AutoSize = true;
            this.radioBgWhite.Location = new System.Drawing.Point(8, 102);
            this.radioBgWhite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.radioBgTrans.Location = new System.Drawing.Point(8, 67);
            this.radioBgTrans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.radioBgTex.Location = new System.Drawing.Point(8, 32);
            this.radioBgTex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numOfSelectLabel.Location = new System.Drawing.Point(254, 67);
            this.numOfSelectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numOfSelectLabel.Name = "numOfSelectLabel";
            this.numOfSelectLabel.Size = new System.Drawing.Size(83, 21);
            this.numOfSelectLabel.TabIndex = 3;
            this.numOfSelectLabel.Text = "選択数：0";
            // 
            // reloadButton
            // 
            this.reloadButton.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reloadButton.Location = new System.Drawing.Point(258, 14);
            this.reloadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(147, 47);
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
            this.colorDialogButton.Location = new System.Drawing.Point(258, 446);
            this.colorDialogButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.colorDialogButton.Name = "colorDialogButton";
            this.colorDialogButton.Size = new System.Drawing.Size(147, 46);
            this.colorDialogButton.TabIndex = 5;
            this.colorDialogButton.Text = "描画色の設定";
            this.colorDialogButton.UseVisualStyleBackColor = true;
            this.colorDialogButton.Click += new System.EventHandler(this.ColorDialogButton_Click);
            // 
            // selectedColor
            // 
            this.selectedColor.BackColor = System.Drawing.Color.Black;
            this.selectedColor.Location = new System.Drawing.Point(258, 502);
            this.selectedColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectedColor.Name = "selectedColor";
            this.selectedColor.Size = new System.Drawing.Size(147, 44);
            this.selectedColor.TabIndex = 6;
            // 
            // lineWidth
            // 
            this.lineWidth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lineWidth.Location = new System.Drawing.Point(258, 407);
            this.lineWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(147, 29);
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
            this.lineWidthLabel.Location = new System.Drawing.Point(255, 381);
            this.lineWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lineWidthLabel.Name = "lineWidthLabel";
            this.lineWidthLabel.Size = new System.Drawing.Size(82, 21);
            this.lineWidthLabel.TabIndex = 9;
            this.lineWidthLabel.Text = "線の太さ：";
            // 
            // checkBoxWeightMode
            // 
            this.checkBoxWeightMode.AutoSize = true;
            this.checkBoxWeightMode.Location = new System.Drawing.Point(258, 93);
            this.checkBoxWeightMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxWeightMode.Name = "checkBoxWeightMode";
            this.checkBoxWeightMode.Size = new System.Drawing.Size(149, 25);
            this.checkBoxWeightMode.TabIndex = 10;
            this.checkBoxWeightMode.Text = "ウェイト色塗りモード";
            this.checkBoxWeightMode.UseVisualStyleBackColor = true;
            this.checkBoxWeightMode.CheckedChanged += new System.EventHandler(this.checkBoxWeightMode_CheckedChanged);
            // 
            // comboBoxWeightBone
            // 
            this.comboBoxWeightBone.FormattingEnabled = true;
            this.comboBoxWeightBone.Location = new System.Drawing.Point(6, 19);
            this.comboBoxWeightBone.Name = "comboBoxWeightBone";
            this.comboBoxWeightBone.Size = new System.Drawing.Size(135, 29);
            this.comboBoxWeightBone.TabIndex = 11;
            // 
            // groupBoxWeightMode
            // 
            this.groupBoxWeightMode.Controls.Add(this.checkBoxWFace);
            this.groupBoxWeightMode.Controls.Add(this.checkBoxWLine);
            this.groupBoxWeightMode.Controls.Add(this.checkBoxWPoint);
            this.groupBoxWeightMode.Controls.Add(this.comboBoxWeightBone);
            this.groupBoxWeightMode.Location = new System.Drawing.Point(258, 113);
            this.groupBoxWeightMode.Name = "groupBoxWeightMode";
            this.groupBoxWeightMode.Size = new System.Drawing.Size(147, 150);
            this.groupBoxWeightMode.TabIndex = 12;
            this.groupBoxWeightMode.TabStop = false;
            this.groupBoxWeightMode.Visible = false;
            // 
            // checkBoxWPoint
            // 
            this.checkBoxWPoint.AutoSize = true;
            this.checkBoxWPoint.Checked = true;
            this.checkBoxWPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWPoint.Location = new System.Drawing.Point(6, 54);
            this.checkBoxWPoint.Name = "checkBoxWPoint";
            this.checkBoxWPoint.Size = new System.Drawing.Size(89, 25);
            this.checkBoxWPoint.TabIndex = 13;
            this.checkBoxWPoint.Text = "点を描画";
            this.checkBoxWPoint.UseVisualStyleBackColor = true;
            // 
            // numericScale
            // 
            this.numericScale.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericScale.Location = new System.Drawing.Point(258, 347);
            this.numericScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScale.Name = "numericScale";
            this.numericScale.Size = new System.Drawing.Size(147, 29);
            this.numericScale.TabIndex = 8;
            this.numericScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelScale.Location = new System.Drawing.Point(255, 321);
            this.labelScale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(127, 21);
            this.labelScale.TabIndex = 9;
            this.labelScale.Text = "出力サイズ倍率：";
            // 
            // checkBoxWLine
            // 
            this.checkBoxWLine.AutoSize = true;
            this.checkBoxWLine.Checked = true;
            this.checkBoxWLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWLine.Location = new System.Drawing.Point(6, 85);
            this.checkBoxWLine.Name = "checkBoxWLine";
            this.checkBoxWLine.Size = new System.Drawing.Size(89, 25);
            this.checkBoxWLine.TabIndex = 13;
            this.checkBoxWLine.Text = "線を描画";
            this.checkBoxWLine.UseVisualStyleBackColor = true;
            // 
            // checkBoxWFace
            // 
            this.checkBoxWFace.AutoSize = true;
            this.checkBoxWFace.Location = new System.Drawing.Point(6, 116);
            this.checkBoxWFace.Name = "checkBoxWFace";
            this.checkBoxWFace.Size = new System.Drawing.Size(89, 25);
            this.checkBoxWFace.TabIndex = 13;
            this.checkBoxWFace.Text = "面を描画";
            this.checkBoxWFace.UseVisualStyleBackColor = true;
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 789);
            this.Controls.Add(this.groupBoxWeightMode);
            this.Controls.Add(this.checkBoxWeightMode);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.numericScale);
            this.Controls.Add(this.lineWidthLabel);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.selectedColor);
            this.Controls.Add(this.colorDialogButton);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.numOfSelectLabel);
            this.Controls.Add(this.bgGroupBox);
            this.Controls.Add(this.materialListBox);
            this.Controls.Add(this.ExecuteButton);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "CtrlForm";
            this.Text = "UVマップ画像出力";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.bgGroupBox.ResumeLayout(false);
            this.bgGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).EndInit();
            this.groupBoxWeightMode.ResumeLayout(false);
            this.groupBoxWeightMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScale)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxWeightMode;
        private System.Windows.Forms.ComboBox comboBoxWeightBone;
        private System.Windows.Forms.GroupBox groupBoxWeightMode;
        private System.Windows.Forms.NumericUpDown numericScale;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.CheckBox checkBoxWPoint;
        private System.Windows.Forms.CheckBox checkBoxWFace;
        private System.Windows.Forms.CheckBox checkBoxWLine;
    }
}