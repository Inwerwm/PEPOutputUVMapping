using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace outputUVMapping
{
    public partial class CtrlForm : Form
    {
        IPERunArgs args;
        IPXPmx pmx;
        ColorDialog cDialog;

        public CtrlForm(IPERunArgs args)
        {
            InitializeComponent();
            this.args = args;
            pmx = this.args.Host.Connector.Pmx.GetCurrentState();

            materialListBox.Items.AddRange(pmx.Material.Select(m => m.Name).ToArray());
            comboBoxWeightBone.Items.AddRange(pmx.Bone.Select(b => b.Name).ToArray());
            comboBoxWeightBone.SelectedIndex = 0;
            cDialog = new ColorDialog();
            cDialog.Color = Color.Black;
            selectedColor.BackColor = cDialog.Color;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            foreach (int i in materialListBox.SelectedIndices)
            {
                //テクスチャの読込
                string texturePath = pmx.Material[i].Tex;
                if (string.Compare(Path.GetExtension(texturePath), ".dds", true) == 0)
                {
                    MessageBox.Show("ddsファイルは未対応です");
                    continue;
                }

                int width;
                int height;
                string errorMessage = "";
                bool hasOccurError = false;
                Bitmap UVMap;
                Graphics gra;
                Pen pen;

                using (Image texture = (string.Compare(Path.GetExtension(texturePath), ".tga", true) == 0) ? TgaDecoder.TgaDecoder.FromFile(texturePath) : Image.FromFile(texturePath))
                {
                    //画像の生成
                    UVMap = new Bitmap(texture.Width * (int)numericScale.Value, texture.Height * (int)numericScale.Value);
                    gra = Graphics.FromImage(UVMap);
                    if (radioBgTex.Checked)
                    {
                        gra.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        gra.DrawImage(texture, 0, 0, UVMap.Width, UVMap.Height);
                    }
                    if (radioBgWhite.Checked)
                        gra.FillRectangle(Brushes.White, gra.VisibleClipBounds);
                }

                //UV情報の描画
                pen = new Pen(Color.Black);
                width = UVMap.Width;
                height = UVMap.Height;
                foreach (var f in pmx.Material[i].Faces)
                {
                    var pointfs = f.ToPointF(width, height);
                    var points = f.ToPoint(width, height);

                    if (checkBoxWeightMode.Checked)
                    {

                        //ウェイト値の取得
                        (IPXBone bone, float weight)? weight1 = Utility.GetWeights(f.Vertex1).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);
                        (IPXBone bone, float weight)? weight2 = Utility.GetWeights(f.Vertex2).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);
                        (IPXBone bone, float weight)? weight3 = Utility.GetWeights(f.Vertex3).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);

                        var weight = new float[]
                        {
                            (weight1?.weight) ?? 0,
                            (weight2?.weight) ?? 0,
                            (weight3?.weight) ?? 0
                        };

                        //描画

                        using (GraphicsPath gp = new GraphicsPath())
                        {
                            gp.AddPolygon(points);
                            try
                            {
                                using (PathGradientBrush brush = new PathGradientBrush(gp))
                                {
                                    brush.SurroundColors = new Color[] {
                                        Color.FromArgb((int)Math.Round(weight[0] * 255,MidpointRounding.AwayFromZero), 0, 0),
                                        Color.FromArgb((int)Math.Round(weight[1] * 255,MidpointRounding.AwayFromZero), 0, 0),
                                        Color.FromArgb((int)Math.Round(weight[2] * 255,MidpointRounding.AwayFromZero), 0, 0)
                                    };
                                    brush.CenterColor = Color.FromArgb((int)Math.Round(weight.Average() * 255, MidpointRounding.AwayFromZero), 0, 0);

                                    if (radioButtonWeightFace.Checked)
                                        gra.FillPolygon(brush, points);
                                    else if (radioButtonWeightLine.Checked)
                                    {
                                        pen.Brush = brush;
                                        pen.Width = (float)lineWidth.Value;
                                        gra.DrawPolygon(pen, points);
                                    }
                                }
                            }
                            catch (OutOfMemoryException)
                            {
                                try
                                {
                                    using (GraphicsPath fgp = new GraphicsPath())
                                    {
                                        fgp.AddPolygon(pointfs);
                                        using (PathGradientBrush brush = new PathGradientBrush(fgp))
                                        {
                                            brush.SurroundColors = new Color[] {
                                                Color.FromArgb((int)Math.Round(weight[0] * 255,MidpointRounding.AwayFromZero), 0, 0),
                                                Color.FromArgb((int)Math.Round(weight[1] * 255,MidpointRounding.AwayFromZero), 0, 0),
                                                Color.FromArgb((int)Math.Round(weight[2] * 255,MidpointRounding.AwayFromZero), 0, 0)
                                            };
                                            brush.CenterColor = Color.FromArgb((int)Math.Round(weight.Average() * 255, MidpointRounding.AwayFromZero), 0, 0);

                                            if (radioButtonWeightFace.Checked)
                                                gra.FillPolygon(brush, pointfs);
                                            else if (radioButtonWeightLine.Checked)
                                            {
                                                pen.Brush = brush;
                                                gra.DrawPolygon(pen, pointfs);
                                            }
                                        }
                                    }
                                }
                                catch (OutOfMemoryException)
                                {
                                    hasOccurError = true;
                                    errorMessage += "(" + pointfs[0].X + ", " + pointfs[0].Y + "), ";
                                    errorMessage += "(" + pointfs[1].X + ", " + pointfs[1].Y + "), ";
                                    errorMessage += "(" + pointfs[2].X + ", " + pointfs[2].Y + ")" + Environment.NewLine;
                                }

                            }
                        }
                    }
                    else
                    {
                        pen.Color = cDialog.Color;
                        pen.Width = (float)lineWidth.Value;
                        gra.DrawPolygon(pen, points);
                    }
                }
                if (hasOccurError)
                    MessageBox.Show("以下の面の描画に失敗しました：" + Environment.NewLine + errorMessage);

                //画像の保存
                string savename = Path.GetDirectoryName(pmx.FilePath) + @"\" + Path.GetDirectoryName(texturePath) + @"\" + Path.GetFileNameWithoutExtension(pmx.FilePath) + "_" + pmx.Material[i].Name + "_UVMap.png";
                UVMap.Save(savename, System.Drawing.Imaging.ImageFormat.Png);

                //後処理
                pen.Dispose();
                gra.Dispose();
                UVMap.Dispose();
            }

            MessageBox.Show("完了しました");
        }

        private void MaterialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            numOfSelectLabel.Text = $"選択数：{materialListBox.SelectedItems.Count}";
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            materialListBox.Items.Clear();
            materialListBox.Items.AddRange(pmx.Material.Select(m => m.Name).ToArray());
            comboBoxWeightBone.Items.Clear();
            comboBoxWeightBone.Items.AddRange(pmx.Bone.Select(b => b.Name).ToArray());
        }

        private void ColorDialogButton_Click(object sender, EventArgs e)
        {
            if (cDialog.ShowDialog() == DialogResult.OK)
                selectedColor.BackColor = cDialog.Color;
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                // フォームを非表示設定
                this.Visible = false;
            }
        }

        private void checkBoxWeightMode_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxWeightMode.Visible = checkBoxWeightMode.Checked;
        }
    }
}
