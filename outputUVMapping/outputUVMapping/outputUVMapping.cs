using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace outputUVMapping
{
    public class outputUVMapping : PEPluginClass
    {
        public outputUVMapping() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "UVマップ画像出力";
            }
        }

        public override string Version
        {
            get
            {
                return "2.2";
            }
        }

        public override string Description
        {
            get
            {
                return "UVマップの画像を出力する";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "UVマップ画像出力");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                if (this.c_form == null)
                {
                    this.c_form = new CtrlForm(args);
                    this.c_form.Visible = true;
                }
                else
                {
                    this.c_form.Visible = !this.c_form.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override void Dispose()
        {
            if (this.c_form != null)
            {
                this.c_form.Close();
                this.c_form = null;
            }
        }


        CtrlForm c_form;
    }

}
