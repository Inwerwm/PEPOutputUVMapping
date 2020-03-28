using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
			List<IPXFace> errorFaces = new List<IPXFace>();
			string savename, savePath = "";

			foreach (object obj in this.materialListBox.SelectedIndices)
			{
				int i = (int)obj;
				string texturePath = this.pmx.Material[i].Tex;
				if (string.Compare(Path.GetExtension(texturePath), ".dds", true) == 0)
				{
					if (radioBgTex.Checked)
						MessageBox.Show("ddsファイルは未対応です" + Environment.NewLine + "背景テクスチャは透明で出力します。");
					texturePath = "";
				}

				int width;
				int height;
				Bitmap UVMap;
				Graphics gra;
				if (texturePath == "")
				{
					width = 1024 * (int)this.numericScale.Value;
					height = 1024 * (int)this.numericScale.Value;
					UVMap = new Bitmap(width + (this.checkBoxWeightMode.Checked ? 1 : 0), height + (this.checkBoxWeightMode.Checked ? 1 : 0));
					gra = Graphics.FromImage(UVMap);
				}
				else
				{
					using (Image texture = (string.Compare(Path.GetExtension(texturePath), ".tga", true) == 0) ? TgaDecoder.TgaDecoder.FromFile(texturePath) : Image.FromFile(texturePath))
					{
						width = texture.Width * (int)this.numericScale.Value;
						height = texture.Width * (int)this.numericScale.Value;
						UVMap = new Bitmap(width + (this.checkBoxWeightMode.Checked ? 1 : 0), height + (this.checkBoxWeightMode.Checked ? 1 : 0));
						gra = Graphics.FromImage(UVMap);
						if (this.radioBgTex.Checked)
						{
							gra.InterpolationMode = InterpolationMode.HighQualityBicubic;
							gra.DrawImage(texture, 0, 0, width, height);
						}
					}
				}

				if (this.radioBgWhite.Checked)
				{
					gra.FillRectangle(Brushes.White, gra.VisibleClipBounds);
				}


				if (this.checkBoxWeightMode.Checked && (this.checkBoxWPoint.Checked || this.checkBoxWFace.Checked || this.checkBoxWLine.Checked))
				{
					bool pointOnly = this.checkBoxWPoint.Checked && !this.checkBoxWFace.Checked && !this.checkBoxWLine.Checked;
					var drawer = new PixelDrawer.PixelDrawer(width, height);
					List<Color[]> weightColors = new List<Color[]>();
					List<V2[]> UVs = new List<V2[]>();
					foreach (IPXFace f in this.pmx.Material[i].Faces)
					{
						(IPXBone bone, float weight)? weight1 = Utility.GetWeights(f.Vertex1).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);
						(IPXBone bone, float weight)? weight2 = Utility.GetWeights(f.Vertex2).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);
						(IPXBone bone, float weight)? weight3 = Utility.GetWeights(f.Vertex3).Find(w => w.bone == pmx.Bone[comboBoxWeightBone.SelectedIndex]);

						var weight = new float[] { (weight1?.weight) ?? 0, (weight2?.weight) ?? 0, (weight3?.weight) ?? 0 };
						weightColors.Add((from w in weight select Color.FromArgb((w * 255f).Round(), 0, 0)).ToArray());
						UVs.Add(f.ExtructUV());
						try
						{
							if (pointOnly)
							{
								drawer.Plot(weightColors.Last(), UVs.Last(), (int)this.lineWidth.Value);
							}
							else
							{
								if (this.checkBoxWFace.Checked)
								{
									drawer.FillPolygon(weightColors.Last(), UVs.Last());
								}
								if (this.checkBoxWLine.Checked)
								{
									drawer.DrawPolygon(weightColors.Last(), UVs.Last(), (float)lineWidth.Value);
								}
							}
						}
						catch (OutOfMemoryException)
						{
							errorFaces.Add(f);
						}
					}
					if (this.checkBoxWPoint.Checked && !pointOnly)
					{
						for (int j = 0; j < this.pmx.Material[i].Faces.Count; j++)
						{
							drawer.Plot(weightColors[j], UVs[j], (int)this.lineWidth.Value);
						}
					}

					drawer.Write();
					gra.DrawImage(drawer.Canvas, 0, 0);
				}
				else
				{
					foreach (PXSide side in new PXMesh(this.pmx.Material[i]).Sides)
					{
						using (Pen pen = new Pen(this.cDialog.Color))
						{
							pen.Width = (float)this.lineWidth.Value;
							gra.DrawLine(pen, side.VertexPair[0].UV.ToPoint(width, height), side.VertexPair[1].UV.ToPoint(width, height));
						}
					}
				}
				savePath = texturePath == ""
						 ? $"{Path.GetDirectoryName(pmx.FilePath)}\\{Path.GetFileNameWithoutExtension(pmx.FilePath)}_{pmx.Material[i].Name}"
						 : $"{Path.GetDirectoryName(pmx.FilePath)}\\{Path.GetDirectoryName(texturePath)}\\{Path.GetFileNameWithoutExtension(pmx.FilePath)}_{pmx.Material[i].Name}";
				savename = savePath + (checkBoxWeightMode.Checked ? "_WeightMap.png" : "_UVMap.png");
				UVMap.Save(savename, ImageFormat.Png);
				gra.Dispose();
				UVMap.Dispose();
			}
			string message = "完了しました。";
			if (errorFaces.Count>0)
			{
				savename = savePath + "_ErrorLog.txt";
				using(StreamWriter writer=new StreamWriter(savename))
				{
					foreach (var f in errorFaces)
					{
						writer.WriteLine(f.PrintUV());
					}
				}
				message += $"{Environment.NewLine}{errorFaces.Count}枚の面の描画に失敗しました。{Environment.NewLine}エラーログを{Path.GetDirectoryName(savename)}に出力しました。";
			}
			MessageBox.Show(message);

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
