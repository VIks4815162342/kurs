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

namespace kurs
{
	public partial class Form2 : Form
	{
		public Form2(SqlConnection con)
		{
			InitializeComponent(); this.con = con;
		}
		public SqlConnection con;



		private void button2_Click(object sender, EventArgs e)
		{
			String quertString = @"select * from usluga;";
			string ConnectString = null;
			SqlConnection con = new SqlConnection(ConnectString);
			SqlCommand table = new SqlCommand(quertString, con);
			con.Open();
			SqlDataReader reader = table.ExecuteReader();
			int i = 0;
			dataGridView1.ColumnCount = 3;
			//Установите количество столбцов, которое вернет ваш запрос   
			dataGridView1.Rows.Clear();
			//Удаляет коллекцию строк             
			while (reader.Read())
			//Читает построчно          
			{
				dataGridView1.Rows.Add();
				//Добавляет строку                  
				dataGridView1[0, i].Value = reader[0];
				//Записывает значение первого столбца i-ой строки                    
				dataGridView1[1, i].Value = reader[1];
				//Записывает значение второго столбца i-ой строки  
				dataGridView1[2, i].Value = reader[2];
				//Записывает значение второго столбца i-ой строки
		
				i++;

			}
			reader.Close();
			//Чтение останавливается            
			con.Close();
			//Соединение закрывается

		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}
	}
}
