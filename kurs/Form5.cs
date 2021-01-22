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
	public partial class Form5 : Form
	{
		public Form5(SqlConnection con)
		{
			InitializeComponent(); this.con = con;
		}
		public SqlConnection con;


		private void Form5_Load(object sender, EventArgs e)
		{
			String quertString = @"select * from Services;"; 
			SqlCommand table = new SqlCommand(quertString, con);

			con.Open();
			SqlDataReader reader = table.ExecuteReader(); int i = 0;
			while (reader.Read())
			{
				dataGridView2.Rows.Add();
				dataGridView2[0, i].Value = reader[0];
				dataGridView2[1, i].Value = reader[1];
				dataGridView2[2, i].Value = reader[2];
				i++;
			}
			reader.Close(); con.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			if ((checkBox2.Checked == false) && (checkBox3.Checked == false))//Если остальные checkBox не активны
			{
				if ((textBox3.Text != "") && (textBox4.Text != ""))//Если текстовое поле не пустое
				{
					dataGridView2[1, dataGridView2.RowCount - 1].Value = textBox3.Text;
					dataGridView2[2, dataGridView2.RowCount - 1].Value = textBox4.Text;
					checkBox1.Checked = true;//Первый checkBox становится активным
				}

			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }//Если checkBox 2 или 3 активны, то программа выдаст сообщение о необходимости сохранить предыдущие изменения
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if ((checkBox1.Checked == false) && (checkBox3.Checked == false))
			{
				checkBox2.Checked = true; Point cel;
				cel = dataGridView2.CurrentCellAddress; if (cel.X == 0)
				{ MessageBox.Show("ID менять нельзя!", "Error!!!"); }
				else
				{
					textBox1.Text = Convert.ToString(dataGridView2[0, cel.Y].Value);
					//Хранится id именяемой записи
					//Если текстовое поле не пустое, то изменяем соответствующую ячейку 
					if (textBox3.Text != "")
					{ dataGridView2[1, cel.Y].Value = textBox3.Text; }
					if (textBox4.Text != "")
					{ dataGridView2[2, cel.Y].Value = textBox4.Text; }
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }

		}

		private void button3_Click(object sender, EventArgs e)
		{

			if ((checkBox1.Checked == false) && (checkBox2.Checked == false))//Проверка, нет ли несохраненных изменений
			{
				Point cel;//Класс, содержащий два параметра X и Y-в нашем случае столбец и строку ячейки 
				cel = dataGridView2.CurrentCellAddress;//Запоминаем адрес выбранной строки
				bool flag = true;//Логическая переменная, означающая можно ли удалить

				if (cel.X != 0)
				{ MessageBox.Show("Удаление только по ID!", "Error!!!"); }//Удаление производится только по ID
				else
				{
					con.Open();//Открытие соединения
					String quertString = @"select Services.ID_service from Services where Services.ID_service='" + dataGridView2.CurrentCell.Value + "';";//Проверка, есть ли у какой либо книги такая категория
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					if (reader.Read())//Если запрос вернул хоть одно значение
					{ flag = true; }
					con.Close();
					if (flag)//Если нет ни одной книги с данной категорией
					{
						checkBox3.Checked = true;//Устанавливаем флаг textBox3.Text =
						Convert.ToString(dataGridView2.CurrentCell.Value);//Запоминает ID удаляемой записи dataGridView2.Rows.RemoveAt(cel.Y);//Удаляем строку
					}//Иначе выводим сообщения об ошибках
					else { MessageBox.Show("Значение используется в другой таблице", "Удаление невозможно!"); }
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				if ((textBox3.Text != "") && (textBox4.Text != ""))
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);//Диалоговое окно вопроса, содержащее кнопки Да и Нет
					if (result == DialogResult.Yes)//Если пользователь согласился на изменения
					{
						String quertString = @"insert into Services (Name_service, cost)
 
                            values('" + textBox3.Text + "','" + textBox4.Text + "');";//Строка запроса
						dataGridView2.Rows.Clear();
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						
						//Выполнение запроса con.Close();
						quertString = @"select * from Services;"; con.Open();
						SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
						{
							dataGridView2.Rows.Add();
							dataGridView2[0, i].Value = reader[0];
							dataGridView2[1, i].Value = reader[1];
							dataGridView2[2, i].Value = reader[2];
							i++;
						}
						reader.Close(); con.Close();
					}

					else
					{//Если пользователь не согласился на изменения, запись в последней

						dataGridView2[1, dataGridView2.RowCount - 1].Value = ""; textBox1.Text = "";

					}
				}



				else { MessageBox.Show("Не введено значение услуги!"); }
				checkBox1.Checked = false;//После выполнения действия checkBox перестает

			}
			if (checkBox2.Checked == true)

			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (textBox3.Text != "")
					{
						String quertString = @"update Services set Name_service='" + textBox3.Text + "' where ID_service='" + textBox1.Text + "'";
						SqlCommand update = new SqlCommand(quertString, con); con.Open();
						update.ExecuteNonQuery(); con.Close();
						textBox3.Text = "";
					}
					if (textBox4.Text != "")
					{
						String quertString = @"update Services set Cost='" + textBox4.Text + "' where ID_service='" + textBox1.Text + "'";
						SqlCommand update = new SqlCommand(quertString, con); con.Open();
						update.ExecuteNonQuery(); con.Close();
						textBox4.Text = "";
					}

					dataGridView2.Rows.Clear(); con.Open();
					String quertString1 = @"select * from Services;";
					SqlCommand table = new SqlCommand(quertString1, con);
					SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView2.Rows.Add();
						dataGridView2[0, i].Value = reader[0];
						dataGridView2[1, i].Value = reader[1];
						dataGridView2[2, i].Value = reader[2]; i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
			
			
					else { MessageBox.Show("Не введено значение услуги!"); }
			        checkBox2.Checked = false;
			        textBox1.Text = "";
		            } 

				if (checkBox3.Checked == true)
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						String quertString = @"delete from Services where ID_service='" + textBox1.Text + "'";
		                SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close(); dataGridView2.Rows.Clear();
						quertString = @"select * from Services;"; con.Open();
						SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
						{
							dataGridView2.Rows.Add();
							dataGridView2[0, i].Value = reader[0];
							dataGridView2[1, i].Value = reader[1];
							dataGridView2[2, i].Value = reader[2]; i++;
						}

						reader.Close(); con.Close(); textBox1.Text = "";
					}
					if (result == DialogResult.No)
					{
						dataGridView2.Rows.Clear(); con.Open();
						String quertString = @"select * from Services;"; SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
						{
							dataGridView2.Rows.Add();
							dataGridView2[0, i].Value = reader[0];
							dataGridView2[1, i].Value = reader[1];
							dataGridView2[2, i].Value = reader[2]; i++;
						}
						reader.Close(); con.Close(); textBox1.Text = "";
					}
					checkBox3.Checked = false;
				}
			}

		}
	}
	


