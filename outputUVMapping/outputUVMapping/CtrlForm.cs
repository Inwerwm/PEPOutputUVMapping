using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            cDialog = new ColorDialog();
            cDialog.Color = Color.Black;
            selectedColor.BackColor = cDialog.Color;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            foreach (int i in materialListBox.SelectedIndices)
            {
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

                Bitmap UVMap;
                if (radioBgTex.Checked)
                    UVMap = new Bitmap(texture);
                else
                    UVMap = new Bitmap(texture.Width, texture.Height);

                Graphics gra = Graphics.FromImage(UVMap);
                if (radioBgWhite.Checked)
                    gra.FillRectangle(Brushes.White, gra.VisibleClipBounds);

                Pen pen = new Pen(cDialog.Color, (float)lineWidth.Value);
                foreach (var f in pmx.Material[i].Faces)
                {
                    Point[] points = {
                    new Point((int)(f.Vertex1.UV.X * texture.Width), (int)(f.Vertex1.UV.Y * texture.Height)),
                    new Point((int)(f.Vertex2.UV.X * texture.Width), (int)(f.Vertex2.UV.Y * texture.Height)),
                    new Point((int)(f.Vertex3.UV.X * texture.Width), (int)(f.Vertex3.UV.Y * texture.Height))
                    };

                    gra.DrawPolygon(pen, points);
                }

                string savename = Path.GetDirectoryName(pmx.FilePath) + @"\" + Path.GetDirectoryName(texturePath) + @"\" + Path.GetFileNameWithoutExtension(pmx.FilePath) + "_" + pmx.Material[i].Name + "_UVMap.png";
                UVMap.Save(savename, System.Drawing.Imaging.ImageFormat.Png);

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
            pmx = this.args.Host.Connector.Pmx.GetCurrentState();
            materialListBox.Items.Clear();
            materialListBox.Items.AddRange(pmx.Material.Select(m => m.Name).ToArray());
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
    }
}
