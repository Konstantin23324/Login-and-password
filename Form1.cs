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
    public partial class Form1 : MaterialForm
    {
        public static Form1 FORMA { get; set; }
        public static User USER { get; set; }
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme (Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
            User usr = db.User.Find(textBox1.Text);
            if ((usr != null) && (usr.Psw == textBox2.Text))
            {
                USER = usr;
                FORMA = this;
                if (usr.Role == "Директор")
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else if (usr.Role == "Менеджер")
                {
                    Form3 frm = new Form3();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином и паролем нет");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            FORMA=this;
            this.Hide();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
