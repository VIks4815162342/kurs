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
	public partial class Form3 : Form
	{
		public Form3(SqlConnection con)
		{
			InitializeComponent(); this.con = con;
		}
		public SqlConnection con;


		private void Form3_Load(object sender, EventArgs e)
		{
			String quertString = @"select * from Employers;"; 
			SqlCommand table = new SqlCommand(quertString, con);
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
				dataGridView1[5, i].Value = reader[5];
				dataGridView1[6, i].Value = reader[6];
				dataGridView1[7, i].Value = reader[7];
				dataGridView1[8, i].Value = reader[8];
				dataGridView1[9, i].Value = reader[9];
				dataGridView1[10, i].Value = reader[10];
				dataGridView1[11, i].Value = reader[11];
				dataGridView1[12, i].Value = reader[12];
				dataGridView1[13, i].Value = reader[13];
				dataGridView1[14, i].Value = reader[14];
				dataGridView1[15, i].Value = reader[15];

				i++;
			}
			reader.Close(); con.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((checkBox2.Checked == false) && (checkBox3.Checked == false))
				{
					if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && 
					(textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "")&& 
					(textBox8.Text != "") &&
					(textBox9.Text != "") &&
					(textBox10.Text != "") &&
					(textBox11.Text != "") &&
					(textBox12.Text != "") &&
					(textBox14.Text != "") &&
					(textBox15.Text != "") &&
					(textBox16.Text != ""))

				{
				dataGridView1[1, dataGridView1.RowCount - 1].Value = textBox2.Text;
				dataGridView1[2, dataGridView1.RowCount - 1].Value = textBox3.Text;
				dataGridView1[3, dataGridView1.RowCount - 1].Value = textBox4.Text;
				dataGridView1[4, dataGridView1.RowCount - 1].Value = textBox5.Text;
				dataGridView1[5, dataGridView1.RowCount - 1].Value = textBox6.Text;
				dataGridView1[6, dataGridView1.RowCount - 1].Value = textBox7.Text;
				dataGridView1[7, dataGridView1.RowCount - 1].Value = textBox8.Text;
					dataGridView1[8, dataGridView1.RowCount - 1].Value = textBox9.Text;
					dataGridView1[9, dataGridView1.RowCount - 1].Value = textBox10.Text;
					dataGridView1[10, dataGridView1.RowCount - 1].Value = textBox11.Text;
					dataGridView1[12, dataGridView1.RowCount - 1].Value = textBox12.Text;
					dataGridView1[13, dataGridView1.RowCount - 1].Value = textBox13.Text;
					dataGridView1[14, dataGridView1.RowCount - 1].Value = textBox14.Text;
					dataGridView1[15, dataGridView1.RowCount - 1].Value = textBox15.Text;
					


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
						if (textBox6.Text != "")
						{ dataGridView1[5, cel.Y].Value = textBox6.Text; }
						if (textBox7.Text != "")
						{ dataGridView1[6, cel.Y].Value = textBox7.Text; }
						if (textBox8.Text != "")
						{ dataGridView1[7, cel.Y].Value = textBox8.Text; }
						
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
						String quertString = @"select Employers.ID_employee from Employers where Employers.ID_employee='" + dataGridView1.CurrentCell.Value + "';";
						SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						if (reader.Read())
						{ flag = true; }
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
					(textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") &&
					(textBox8.Text != "") &&
					(textBox9.Text != "") &&
					(textBox10.Text != "") &&
					(textBox11.Text != "") &&
					(textBox12.Text != "") &&
					(textBox14.Text != "") &&
					(textBox15.Text != "") &&
					(textBox16.Text != ""))
				{

						DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{

							String quertString = @"insert into Employers (First_name, Middle_name, Last_name, Mobile_number,
                            Date_BD, Login, Password,ID_position, City, Street, Home, Number_apartment,  ID_role, Serier_passport, Number_passport) values('"
							+ textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" +
							Convert.ToDateTime(textBox6.Text) + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "'" +
							",'" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "');";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
							quertString = @"select * from Employers;"; con.Open();
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
							dataGridView1[5, i].Value = reader[5];
							dataGridView1[6, i].Value = reader[6];
							dataGridView1[7, i].Value = reader[7];
							dataGridView1[8, i].Value = reader[8];
							dataGridView1[9, i].Value = reader[9];
							dataGridView1[10, i].Value = reader[10];
							dataGridView1[11, i].Value = reader[11];
							dataGridView1[12, i].Value = reader[12];
							dataGridView1[13, i].Value = reader[13];
							dataGridView1[14, i].Value = reader[14];
							dataGridView1[15, i].Value = reader[15];
					

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
							String quertString = @"update Employers set First_name='" + textBox2.Text + "' where ID_employee='" + textBox1.Text + "'";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
							textBox2.Text = "";
						}

						if (textBox3.Text != "")
						{
							String quertString = @"update Employers set Middle_name='" + textBox3.Text + "' where ID_employee='" + textBox1.Text + "'";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
						    textBox3.Text = "";
						}

						if (textBox4.Text != "")
						{
							String quertString = @"update Employers set Last_name='" + textBox4.Text + "' where ID_employee='" + textBox1.Text + "'";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
						    textBox4.Text = "";
						}

					    if (textBox5.Text != "")
						{
							String quertString = @"update Employers set Mobile_number='" + textBox5.Text + "' where ID_employee='" + textBox1.Text + "'";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
							textBox5.Text = "";
						}
					   
                        if (textBox6.Text != "")
						{
							String quertString = @"update Employers set Date_BD='" + Convert.ToDateTime(textBox6.Text) + "' where ID_employee='" + textBox1.Text + "'";
							SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
						    textBox6.Text = "";
						}

						if (textBox7.Text != "")
						{
						    String quertString = @"update Employers set Login='" + textBox7.Text + "' where ID_employee='" + textBox1.Text + "'";
						    SqlCommand insert = new SqlCommand(quertString, con); con.Open();
							insert.ExecuteNonQuery(); con.Close();
						    textBox7.Text = "";
						}

					    if (textBox8.Text != "")
					{
				 		String quertString = @"update Employers set Password='" + textBox8.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox8.Text = "";
					}
					if (textBox9.Text != "")
					{
						String quertString = @"update Employers set ID_position='" + textBox9.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox9.Text = "";
					}
					if (textBox10.Text != "")
					{
						String quertString = @"update Employers set City='" + textBox10.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox10.Text = "";
					}
					if (textBox11.Text != "")
					{
						String quertString = @"update Employers set Street='" + textBox11.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox11.Text = "";
					}
					if (textBox12.Text != "")
					{
						String quertString = @"update Employers set Home='" + textBox12.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox12.Text = "";
					}
					if (textBox13.Text != "")
					{
						String quertString = @"update Employers set Number_apartment='" + textBox13.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox13.Text = "";
					}
					if (textBox14.Text != "")
					{
						String quertString = @"update Employers set ID_role='" + textBox14.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox14.Text = "";
					}
					if (textBox15.Text != "")
					{
						String quertString = @"update Employers set Serier_passport='" + textBox15.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox15.Text = "";
					}
					if (textBox16.Text != "")
					{
						String quertString = @"update Employers set Number_passport='" + textBox16.Text + "' where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox16.Text = "";
					}


					dataGridView1.Rows.Clear(); con.Open();
						String quertString1 = @"select * from Employers;";
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
						dataGridView1[5, i].Value = reader[5];
						dataGridView1[6, i].Value = reader[6];
						dataGridView1[7, i].Value = reader[7];
						dataGridView1[8, i].Value = reader[8];
						dataGridView1[9, i].Value = reader[9];
						dataGridView1[10, i].Value = reader[10];
						dataGridView1[11, i].Value = reader[11];
						dataGridView1[12, i].Value = reader[12];
						dataGridView1[13, i].Value = reader[13];
						dataGridView1[14, i].Value = reader[14];
						dataGridView1[15, i].Value = reader[15];
						

						i++;
					}
						reader.Close(); con.Close(); textBox1.Text = "";
					}
					else { MessageBox.Show("Не введено значение сотрудника!"); }
					checkBox2.Checked = false;
					textBox1.Text = "";
				}

				if (checkBox3.Checked == true)
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						String quertString = @"delete from Employers where ID_employee='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
						quertString = @"select * from Employers;"; con.Open();
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
						dataGridView1[5, i].Value = reader[5];
						dataGridView1[6, i].Value = reader[6];
						dataGridView1[7, i].Value = reader[7];
						dataGridView1[8, i].Value = reader[8];
						dataGridView1[9, i].Value = reader[9];
						dataGridView1[10, i].Value = reader[10];
						dataGridView1[11, i].Value = reader[11];
						dataGridView1[12, i].Value = reader[12];
						dataGridView1[13, i].Value = reader[13];
						dataGridView1[14, i].Value = reader[14];
						dataGridView1[15, i].Value = reader[15];
						

						i++;
					}

						reader.Close(); con.Close(); textBox1.Text = "";
					}
					if (result == DialogResult.No)
					{
						dataGridView1.Rows.Clear(); con.Open();
						String quertString = @"select * from Employers;"; SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4];
						dataGridView1[5, i].Value = reader[5];
						dataGridView1[6, i].Value = reader[6];
						dataGridView1[7, i].Value = reader[7];
						dataGridView1[8, i].Value = reader[8];
						dataGridView1[9, i].Value = reader[9];
						dataGridView1[10, i].Value = reader[10];
						dataGridView1[11, i].Value = reader[11];
						dataGridView1[12, i].Value = reader[12];
						dataGridView1[13, i].Value = reader[13];
						dataGridView1[14, i].Value = reader[14];
						dataGridView1[15, i].Value = reader[15];
						

						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
					}
					checkBox3.Checked = false;
				}
			


		}

 
		}
    }
	
