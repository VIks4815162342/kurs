﻿using System;
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
	public partial class Form8 : Form
	{
		public Form8(SqlConnection con)
		{
			InitializeComponent(); this.con = con;
		}
		public SqlConnection con;

		private void Form8_Load(object sender, EventArgs e)
		{

			String quertString = @"select * from prodazha;"; SqlCommand table = new SqlCommand(quertString, con);
			con.Open();
			SqlDataReader reader = table.ExecuteReader(); int i = 0;
			while (reader.Read())
			{
				dataGridView1.Rows.Add();
				dataGridView1[0, i].Value = reader[0];
				dataGridView1[1, i].Value = reader[1];
				dataGridView1[2, i].Value = reader[2];
				dataGridView1[3, i].Value = reader[3];
				dataGridView1[4, i].Value = reader[4];
				i++;
			}
			reader.Close(); con.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((checkBox2.Checked == false) && (checkBox3.Checked == false))
			{
				if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
				(textBox5.Text != ""))
				{
					dataGridView1[1, dataGridView1.RowCount - 1].Value = textBox2.Text;
					dataGridView1[2, dataGridView1.RowCount - 1].Value = textBox3.Text;
					dataGridView1[3, dataGridView1.RowCount - 1].Value = textBox4.Text;
					dataGridView1[4, dataGridView1.RowCount - 1].Value = textBox5.Text;
					checkBox1.Checked = true;
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения или заполните все поля"); }
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if ((checkBox1.Checked == false) && (checkBox3.Checked == false))
			{
				checkBox2.Checked = true; Point cel;
				cel = dataGridView1.CurrentCellAddress; if (cel.X == 0)
				{ MessageBox.Show("ID менять нельзя!", "Error!!!"); }
				else
				{
					textBox1.Text = Convert.ToString(dataGridView1[0, cel.Y].Value);
					//Хранится id именяемой записи
					//Если текстовое поле не пустое, то изменяем соответствующую ячейку 
					if (textBox2.Text != "")
					{ dataGridView1[1, cel.Y].Value = textBox2.Text; }
					if (textBox3.Text != "")
					{ dataGridView1[2, cel.Y].Value = textBox3.Text; }
					if (textBox4.Text != "")
					{ dataGridView1[3, cel.Y].Value = textBox4.Text; }
					if (textBox5.Text != "")
					{ dataGridView1[4, cel.Y].Value = textBox5.Text; }
					
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if ((checkBox1.Checked == false) && (checkBox2.Checked == false))

			{
				Point cel;
				cel = dataGridView1.CurrentCellAddress; if (cel.X != 0)
				{ MessageBox.Show("Удаление только по ID!", "Error!!!"); }
				else
				{
					bool flag = true; con.Open();
					String quertString = @"select prodazha.Id_prodazhi from prodazha where prodazha.Id_prodazhi='" + dataGridView1.CurrentCell.Value + "';";
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					if (reader.Read())
					{ flag = false; }
					con.Close();
					if (flag)
					{
						checkBox3.Checked = true; textBox1.Text =
						Convert.ToString(dataGridView1.CurrentCell.Value);
						dataGridView1.Rows.RemoveAt(cel.Y);
					}
					else { MessageBox.Show("Значение используется в другой таблице", "Удаление невозможно!"); }
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
				(textBox5.Text != ""))
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						String quertString = @"insert into prodazha (id_klienta, id_uslugi, 
                            data_prod, vremya_prod) values('"
						+ textBox2.Text + "','" + textBox3.Text + "','" +
						Convert.ToDateTime(textBox4.Text) + "','" + Convert.ToDateTime(textBox5.Text) + "');";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
						quertString = @"select * from prodazha;"; con.Open();
						SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add();
							dataGridView1[0, i].Value = reader[0];
							dataGridView1[1, i].Value = reader[1];
							dataGridView1[2, i].Value = reader[2];
							dataGridView1[3, i].Value = reader[3];
							dataGridView1[4, i].Value = reader[4];
							
							i++;
						}
						reader.Close(); con.Close();
					}
					else
					{
						dataGridView1[1, dataGridView1.RowCount - 1].Value = ""; textBox1.Text = "";
					}
				}
				else { MessageBox.Show("Не введено какое-то значение!"); }
				checkBox1.Checked = false;
			}
			if (checkBox2.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{ //Если поле не пустое, то отправляется запрос на изменение 
					if (textBox2.Text != "")
					{
						String quertString = @"update prodazha set id_klienta='" + textBox2.Text + "' where Id_prodazhi='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox2.Text = "";
					}

					if (textBox3.Text != "")
					{
						String quertString = @"update prodazha set id_uslugi='" + textBox3.Text + "' where Id_prodazhi='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox3.Text = "";
					}

				

					if (textBox4.Text != "")
					{
						String quertString = @"update prodazga set data_prod='" + Convert.ToDateTime(textBox4.Text) + "' where Id_prodazhi='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox4.Text = "";
					}

					if (textBox5.Text != "")
					{
						String quertString = @"update prodazha set vremya_prod='" + Convert.ToDateTime(textBox5.Text) + "' where Id_prodazhi='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox5.Text = "";
					}



					dataGridView1.Rows.Clear(); con.Open();
					String quertString1 = @"select * from prodazha;";
					SqlCommand table = new SqlCommand(quertString1, con);
					SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4];
						
						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				else { MessageBox.Show("Не введено значение продажи!"); }
				checkBox2.Checked = false;
				textBox1.Text = "";
			}

			if (checkBox3.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					String quertString = @"delete from prodazha where Id_prodazhi='" + textBox1.Text + "'";
					SqlCommand insert = new SqlCommand(quertString, con); con.Open();
					insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
					quertString = @"select * from prodazha;"; con.Open();
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4];
						
						i++;
					}

					reader.Close(); con.Close(); textBox1.Text = "";
				}
				if (result == DialogResult.No)
				{
					dataGridView1.Rows.Clear(); con.Open();
					String quertString = @"select * from prodazha;"; SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4];
						
						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				checkBox3.Checked = false;
			}
		}
	}
}
