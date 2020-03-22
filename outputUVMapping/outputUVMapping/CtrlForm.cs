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
                Image texture;
                if (string.Compare(Path.GetExtension(texturePath), ".tga", true) == 0)
                    texture = TgaDecoder.TgaDecoder.FromFile(texturePath);
                else if (string.Compare(Path.GetExtension(texturePath), ".dds", true) == 0)
                {
                    MessageBox.Show("ddsファイルは未対応です");
                    continue;
                }
                else
                    texture = Image.FromFile(texturePath);

                //画像の生成
                Bitmap UVMap;
                if (radioBgTex.Checked)
                    UVMap = new Bitmap(texture);
                else
                    UVMap = new Bitmap(texture.Width, texture.Height);

                Graphics gra = Graphics.FromImage(UVMap);
                if (radioBgWhite.Checked)
                    gra.FillRectangle(Brushes.White, gra.VisibleClipBounds);

                //UV情報の描画
                Pen pen = new Pen(Color.Black);
                GraphicsPath gp;
                foreach (var f in pmx.Material[i].Faces)
                {
                    Point[] points = {
                    new Point((int)(f.Vertex1.UV.X * texture.Width), (int)(f.Vertex1.UV.Y * texture.Height)),
                    new Point((int)(f.Vertex2.UV.X * texture.Width), (int)(f.Vertex2.UV.Y * texture.Height)),
                    new Point((int)(f.Vertex3.UV.X * texture.Width), (int)(f.Vertex3.UV.Y * texture.Height))
                    };

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
                        gp = new GraphicsPath();
                        gp.AddPolygon(points);
                        var brush = new PathGradientBrush(gp);
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
                            gra.DrawPolygon(pen, points);
                        }
                    }
                    else
                    {
                        pen.Color = cDialog.Color;
                        pen.Width = (float)lineWidth.Value;
                        gra.DrawPolygon(pen, points);
                    }
                }

                //画像の保存
                string savename = Path.GetDirectoryName(pmx.FilePath) + @"\" + Path.GetDirectoryName(texturePath) + @"\" + Path.GetFileNameWithoutExtension(pmx.FilePath) + "_" + pmx.Material[i].Name + "_UVMap.png";
                UVMap.Save(savename, System.Drawing.Imaging.ImageFormat.Png);

                //後処理
                pen.Dispose();
                gra.Dispose();
                UVMap.Dispose();
                texture.Dispose();
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
