using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kurs
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Создание строки подключения             
			String ConnectString = @"Data Source=DESKTOP-DO2D450; Initial Catalog=BeautifulDay; User Id=" + tbox_Login.Text + ";Password=" + tbox_Password.Text + ";";
			/*Initial Catalog=BeautifulDay*/

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
				MessageBox.Show(string.Format("Error:1 {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				con.Close();
				//Соединение закрывается
				return;
			}
			con.Close();
			//Соединение закрывается  
			this.Hide();
			var parent = new MDIParent1(con);
			try
			{
				SqlCommand login = new SqlCommand($@"SELECT ID_role from Clients WHERE Login = '{tbox_Login.Text}' and Password = '{tbox_Password.Text}'", con);
				con.Open();
				SqlDataReader loginRead = login.ExecuteReader();
				loginRead.Read();
				loginRead["ID_role"].ToString();
				parent.r= int.Parse(loginRead["ID_role"].ToString());
				loginRead.Close();
				con.Close();
			}
			catch
			{
				try { con.Close(); } catch {; }
				try
				{
					SqlCommand login = new SqlCommand($@"SELECT ID_role from Employers WHERE Login = '{tbox_Login.Text}' and Password = '{tbox_Password.Text}'", con);
					con.Open();
					SqlDataReader loginRead = login.ExecuteReader();
					loginRead.Read();
					loginRead["ID_role"].ToString();
					parent.r = int.Parse(loginRead["ID_role"].ToString());
					loginRead.Close();
					con.Close();
				}
				catch {; }
			}
			//Создается новая родительская форма, содержащая параметр SqlConnection con                     
			parent.Show();
			//Открывается новая родительская форма 
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			tbox_Login.Text = "mishks";
			tbox_Password.Text = "111";
		}

		private void label3_Click(object sender, EventArgs e)
		{
			button2.PerformClick();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form12 registration = new Form12();
			registration.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			String ConnectString = @"Data Source=DESKTOP-DO2D450;Initial Catalog=BeautifulDay;User Id=guestSK;Password=111;";
			SqlConnection con = new SqlConnection(ConnectString);
			con.Open();
			this.Hide();
			var parent = new MDIParent1(con);
			parent.Show();

		}
	}
}
