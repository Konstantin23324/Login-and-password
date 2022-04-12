using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Model;
using MaterialSkin.Controls;
using MaterialSkin;

namespace WindowsFormsApp5
{
    public partial class Form3 : MaterialForm
    {
        public Form3()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.FORMA.Show();
        }
    }
}
