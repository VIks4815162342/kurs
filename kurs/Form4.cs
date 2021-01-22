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
	public partial class Form4 : Form
	{
		public Form4(SqlConnection con)
		{
			InitializeComponent(); this.con = con;

			//pictureBox.Image = Image.FromFile(@"D:\Мамин теефон\Camera\IMG_20191013_105307.jpg");
		}
		public SqlConnection con;


		private void Form4_Load(object sender, EventArgs e)
		{
			String quertString = @"select ID_client, First_name, Middle_name, Last_name, Series_passport, 
			Number_passport, Date_BD, Login, CONVERT(NVARCHAR(10),HashBytes('MD5', Password),2) as 'Password_MD5', Mobile_number
			from Clients;"; 
			SqlCommand table = new SqlCommand(quertString, con);
			con.Open();
			SqlDataReader reader = table.ExecuteReader(); int i = 0;
			while (reader.Read())
			{
				this.table.Rows.Add();
				this.table[0, i].Value = reader[0];
				this.table[1, i].Value = reader[1];
				this.table[2, i].Value = reader[2];
				this.table[3, i].Value = reader[3];
				this.table[4, i].Value = reader[4];
				this.table[5, i].Value = reader[5];
				this.table[6, i].Value = reader[6];
				this.table[7, i].Value = reader[7];
				this.table[8, i].Value = reader[8];
				this.table[9, i].Value = reader[9];

				i++;
			}
			reader.Close(); con.Close();
		}
	

		private void button1_Click(object sender, EventArgs e)
		{
			if ((checkBox2.Checked == false) && (checkBox3.Checked == false))
			{
				if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
				(textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") &&
				(textBox8.Text != "") && (textBox9.Text != ""))
				{
					table[1, table.RowCount - 1].Value = textBox2.Text;
					table[2, table.RowCount - 1].Value = textBox3.Text;
					table[3, table.RowCount - 1].Value = textBox4.Text;
					table[4, table.RowCount - 1].Value = textBox5.Text;
					table[5, table.RowCount - 1].Value = textBox6.Text;
					table[6, table.RowCount - 1].Value = textBox7.Text;
					table[7, table.RowCount - 1].Value = textBox8.Text;
					table[8, table.RowCount - 1].Value = textBox9.Text;
					table[9, table.RowCount - 1].Value = textBox10.Text;

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
				cel = table.CurrentCellAddress; if (cel.X == 0)
				{ MessageBox.Show("ID менять нельзя!", "Error!!!"); }
				else
				{
					textBox1.Text = Convert.ToString(table[0, cel.Y].Value);
					//Хранится id именяемой записи
					//Если текстовое поле не пустое, то изменяем соответствующую ячейку 
					if (textBox2.Text != "")
					{ table[1, cel.Y].Value = textBox2.Text; }
					if (textBox3.Text != "")
					{ table[2, cel.Y].Value = textBox3.Text; }
					if (textBox4.Text != "")
					{ table[3, cel.Y].Value = textBox4.Text; }
					if (textBox5.Text != "")
					{ table[4, cel.Y].Value = textBox5.Text; }
					if (textBox6.Text != "")
					{ table[5, cel.Y].Value = textBox6.Text; }
					if (textBox7.Text != "")
					{ table[6, cel.Y].Value = textBox7.Text; }
					if (textBox8.Text != "")
					{ table[7, cel.Y].Value = textBox8.Text; }
					if (textBox9.Text != "")
					{ table[8, cel.Y].Value = textBox9.Text; }
					
				}
			}
			else { MessageBox.Show("Сохраните предыдущие изменения"); }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if ((checkBox1.Checked == false) && (checkBox2.Checked == false))

			{
				Point cel;
				cel = table.CurrentCellAddress; if (cel.X != 0)
				{ MessageBox.Show("Удаление только по ID!", "Error!!!"); }
				else
				{
					bool flag = true; con.Open();
                    String quertString = @"select Clients.ID_client from Clients where Clients.ID_client='" + this.table.CurrentCell.Value + "';";
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					if (reader.Read())
					{ flag = true; }
					con.Close();
					if (flag)
					{
						checkBox3.Checked = true; textBox1.Text =
                        Convert.ToString(this.table.CurrentCell.Value);
						this.table.Rows.RemoveAt(cel.Y);
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
				(textBox8.Text != "") && (textBox9.Text != "") )
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						String quertString = @"insert into Clients (First_name, Middle_name, Last_name,Date_BD,  Series_passport,
                            Number_passport, Login, Password, ID_role, Mobile_number) 
						values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" +
									textBox6.Text + "','" + Convert.ToDateTime(textBox7.Text) + "','" + textBox8.Text + "','" +textBox9.Text + "', 3,'" + textBox10.Text + "');";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close(); this.table.Rows.Clear();
						quertString = @"select * from Clients;"; con.Open();
						SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
						int i = 0;
						while (reader.Read())
						{
							this.table.Rows.Add();
							this.table[0, i].Value = reader[0];
							this.table[1, i].Value = reader[1];
							this.table[2, i].Value = reader[2];
							this.table[3, i].Value = reader[3];
							this.table[4, i].Value = reader[4];
							this.table[5, i].Value = reader[5];
							this.table[6, i].Value = reader[6];
							this.table[7, i].Value = reader[7];
							this.table[8, i].Value = reader[8];
							this.table[9, i].Value = reader[9];

							i++;
						}
						reader.Close(); con.Close();
					}
					else
					{
						table[1, table.RowCount - 1].Value = ""; textBox1.Text = "";
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
						String quertString = @"update Clients set First_name='" + textBox2.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox2.Text = "";
					}

					if (textBox3.Text != "")
					{
						String quertString = @"update Clients set Middle_name='" + textBox3.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox3.Text = "";
					}

					if (textBox4.Text != "")
					{
						String quertString = @"update Clients set Last_name='" + textBox4.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox4.Text = "";
					}

					if (textBox5.Text != "")
					{
						String quertString = @"update Clients set Series_passport='" + textBox5.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox5.Text = "";
					}

					if (textBox6.Text != "")
					{
						String quertString = @"update Clients set Number_pasport='" + textBox6.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox6.Text = "";
					}

					if (textBox7.Text != "")
					{
						String quertString = @"update Clients set Date_BD='" + Convert.ToDateTime(textBox7.Text) + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox7.Text = "";
					}

					if (textBox8.Text != "")
					{
						String quertString = @"update Clients set Login='" + textBox8.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox8.Text = "";
					}

					
					if (textBox9.Text != "")
					{
						String quertString = @"update Clients set Password='" + textBox9.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox9.Text = "";
					}

					if (textBox10.Text != "")
					{
						String quertString = @"update Clients set Mobile_number='" + textBox10.Text + "' where ID_client='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox10.Text = "";
					}



					this.table.Rows.Clear(); con.Open();
					String quertString1 = @"select * from Clients;";
					SqlCommand table = new SqlCommand(quertString1, con);
					SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						this.table.Rows.Add();
						this.table[0, i].Value = reader[0];
						this.table[1, i].Value = reader[1];
						this.table[2, i].Value = reader[2];
						this.table[3, i].Value = reader[3];
						this.table[4, i].Value = reader[4];
						this.table[5, i].Value = reader[5];
						this.table[6, i].Value = reader[6];
						this.table[7, i].Value = reader[7];
						this.table[8, i].Value = reader[8];
						this.table[9, i].Value = reader[9];

						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				else { MessageBox.Show("Не введено значение клиента!"); }
				checkBox2.Checked = false;
				textBox1.Text = "";
			}

			if (checkBox3.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					String quertString = @"delete from Clients where ID_client='" + textBox1.Text + "'";
					SqlCommand insert = new SqlCommand(quertString, con); con.Open();
					insert.ExecuteNonQuery(); con.Close(); this.table.Rows.Clear();
					quertString = @"select * from Clients;"; con.Open();
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						this.table.Rows.Add();
						this.table[0, i].Value = reader[0];
						this.table[1, i].Value = reader[1];
						this.table[2, i].Value = reader[2];
						this.table[3, i].Value = reader[3];
						this.table[4, i].Value = reader[4];
						this.table[5, i].Value = reader[5];
						this.table[6, i].Value = reader[6];
						this.table[7, i].Value = reader[7];
						this.table[8, i].Value = reader[8];
						this.table[9, i].Value = reader[9];

						i++;
					}

					reader.Close(); con.Close(); textBox1.Text = "";
				}
				if (result == DialogResult.No)
				{
					this.table.Rows.Clear(); con.Open();
					String quertString = @"select * from Clients;"; SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						this.table.Rows.Add();
						this.table[0, i].Value = reader[0];
						this.table[1, i].Value = reader[1];
						this.table[2, i].Value = reader[2];
						this.table[3, i].Value = reader[3];
						this.table[4, i].Value = reader[4];
						this.table[5, i].Value = reader[5];
						this.table[6, i].Value = reader[6];
						this.table[7, i].Value = reader[7];
						this.table[8, i].Value = reader[8];
						this.table[9, i].Value = reader[9];

						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				checkBox3.Checked = false;
			}
		}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			con.Open();
			int id = (int)table.Rows[e.RowIndex].Cells[0].Value;
			//MessageBox.Show(this.con.State.ToString());
			String quertString = "select file_photo from Clients where id_client=" + id;
            SqlCommand t = new SqlCommand(quertString, con);
            SqlDataReader reader = t.ExecuteReader();
			reader.Read();
            string filePath = (string)reader[0];
            //MessageBox.Show(filePath);
            pictureBox.Image = Image.FromFile(filePath);
			con.Close();
		}
    }
}
