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
    public partial class Form4 : MaterialForm
    {
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    return false;
            }

            return true;
        }
        Model1 db = new Model1();
        public Form4()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a = IsDigitsOnly(textBox5.Text);
            if (!a)
            {
                MessageBox.Show("В имени не должно быть чисел");
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Нужно заполнить все данные");
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Пароли не соответствуют" + textBox2.Text +textBox3.Text);
                return;
            }
            if ((textBox2.Text != "Директор") && (textBox2.Text != "Менеджер"))
            {
                MessageBox.Show("Такой роли нет!!!");
                return;
            }
            User usr = db.User.Find(textBox1.Text);
            if (usr != null)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!");
                return;
            }
            usr = new User();
            usr.Login=textBox1.Text;
            usr.Psw= textBox4.Text;
            usr.Role=textBox2.Text;
            usr.Name=textBox5.Text;
            db.User.Add(usr);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Пользователь " + usr.Login + " зарегистрирован!");
            Form1.FORMA.Show();
            this.Close();
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.FORMA.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
