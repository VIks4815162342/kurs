using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace kurs
{
    public partial class Form12 : Form
    {

        public Form12()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
        {
			//Создание строки подключения             
			String ConnectString = @"Data Source=DESKTOP-DO2D450;Initial Catalog=BeautifulDay;User Id=mishks;Password=111;";

			//Объявление новой переменной типа SqlConection            
			SqlConnection con = new SqlConnection(ConnectString);
			//Переменная, представляющая ошибки, появляющиеся во время выполнения приложения     
			try
			{
				con.Open();
				//Открытие подключения            
			}
			catch (Exception ex)
			//При возникновении неполадок при подключении появится сообщение с информацией об ошибке           
			{
				MessageBox.Show("Error: Ошибка подключения к БД!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			con.Close();
			//Соединение закрывается
			if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
                    (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != ""))
            {
				try
				{
					String quertString1 = @"insert into Clients (First_name,Last_name, Middle_name,Date_BD, " +
					@"Mobile_number, Login, Password, ID_role, File_photo)" +
					@"values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToDateTime(textBox4.Text)
					+ "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "', 3, '" + textBox8.Text + "'); ";
					SqlCommand insert = new SqlCommand(quertString1, con);
					con.Open();
					insert.ExecuteNonQuery();
					con.Close();
					String quertString2 = @"create login " + textBox6.Text + " with password = '" + textBox7.Text + @"'; " +
					"create user " + textBox6.Text + " for login " + textBox6.Text + ";" +
					"alter role db_datareader add member " + textBox6.Text + ";";
					insert = new SqlCommand(quertString2, con);
					con.Open();
					insert.ExecuteNonQuery();
					con.Close();
					this.Close();
					Form1 registration = new Form1();
					registration.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Ошибка: поля не заполнены!\nЗаполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string imgFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\UserPhoto";

		private string copyFileAndGetRelativePath(string sourcePath, string file)
		{
			string filenameString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 6);
			string[] incorrectSymb = { "=", "+", "/" };
			for (int i = 0; i < incorrectSymb.Length; i++)
				filenameString = filenameString.Replace(incorrectSymb[i], "");
			string fname = $"{filenameString}({Path.GetFileNameWithoutExtension(file)}){Path.GetExtension(file)}";
			string fullPath = $"{imgFolder}\\{fname}";
			File.Copy(sourcePath, fullPath);
			return fname;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			label1.Select();
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string fullname = copyFileAndGetRelativePath(openFileDialog1.FileName, openFileDialog1.SafeFileName);
				textBox8.Text = fullname;
				try
				{
					pictureBox1.Image = Image.FromFile($"UserPhoto\\{textBox8.Text}");
				}
				catch
				{
					pictureBox1.Image = Image.FromFile("UserPhoto\\nophoto.png");
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			label1.Select();
			textBox8.Clear();
			pictureBox1.Image = Image.FromFile("UserPhoto\\nophoto.png");
		}

		private void Form12_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}

