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
	public partial class Form7 : Form
	{
		public Form7(SqlConnection con)
		{
			InitializeComponent(); this.con = con;
		}
		public SqlConnection con;
		public int r { get; set; }
		private void Form7_Load(object sender, EventArgs e)
		{
			String quertString = @"select * from Material;"; SqlCommand table = new SqlCommand(quertString, con);

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
		//	MessageBox.Show(r.ToString());
			if (r == 0|| r==1)
			{
				button1.Visible = false;
				button2.Visible = false;
				button3.Visible = false;
				button4.Visible = false;
				checkBox1.Visible = false;
				checkBox2.Visible = false;
				checkBox3.Visible = false;
				label1.Visible = false;
				label2.Visible = false;
				label3.Visible = false;
				label4.Visible = false;
				label5.Visible = false;
				textBox1.Visible = false;
				textBox2.Visible = false;
				textBox3.Visible = false;
				textBox4.Visible = false;
				textBox5.Visible = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			/*int idc = Convert.ToInt32(textBox1.Text);
			SqlCommand quant = new SqlCommand($@" select m.Quantity from Material as m where m.ID_material=1", con);
			con.Open();
			SqlDataReader quantRead = quant.ExecuteReader();
			quantRead.Read();
			quantRead["Quantity"].ToString();
			int quantc = int.Parse(quantRead["Quantity"].ToString());
			quantRead.Close();
			MessageBox.Show(string.Format("Quant: "));
			con.Close();*/
			if ((checkBox2.Checked == false) && (checkBox3.Checked == false))//Если остальные checkBox не активны
			{
					if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))//Если текстовое поле не пустое
				{
					dataGridView1[1, dataGridView1.RowCount - 1].Value = textBox2.Text;
					dataGridView1[2, dataGridView1.RowCount - 1].Value = textBox3.Text;
					dataGridView1[3, dataGridView1.RowCount - 1].Value = textBox4.Text;
					dataGridView1[4, dataGridView1.RowCount - 1].Value = textBox5.Text;
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
					String quertString = @"select Material.ID_material from Material where Material.ID_material='" + dataGridView1.CurrentCell.Value + "';";
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
				if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);//Диалоговое окно вопроса, содержащее кнопки Да и Нет
					if (result == DialogResult.Yes)//Если пользователь согласился на изменения
					{
						String quertString = @"insert into Material  (Name_material, Quantity, Shelf_life, Cost)
 
                            values('" + textBox2.Text + "', '" + textBox3.Text + "', '" + Convert.ToDateTime(textBox4.Text) + "', '" +
						textBox5.Text + "');";//Строка запроса
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
						//Выполнение запроса con.Close();
						quertString = @"select * from Material;"; con.Open();
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
					{//Если пользователь не согласился на изменения, запись в последней

						dataGridView1[1, dataGridView1.RowCount - 1].Value = ""; textBox1.Text = "";

					}
				}



				else { MessageBox.Show("Не введено значение материала!"); }
				checkBox1.Checked = false;//После выполнения действия checkBox перестает

			}
			if (checkBox2.Checked == true)

			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (textBox2.Text != "")
					{
						String quertString = @"update Material set Name_material='" + textBox2.Text + "' where ID_material='" + textBox1.Text + "'"; SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox2.Text = "";
					}


					if (textBox3.Text != "")
					{
						String quertString = @"update Material set Quantity='" + textBox3.Text + "' where ID_material='" + textBox1.Text + "'"; SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox3.Text = "";
					}

					if (textBox4.Text != "")
					{
						String quertString = @"update Material set Shelf_life='" + Convert.ToDateTime(textBox4.Text) + "' where ID_material='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox4.Text = "";
					}

					if (textBox5.Text != "")
					{
						String quertString = @"update Material set Cost='" + textBox5.Text + "' where ID_material='" + textBox1.Text + "'"; SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery(); con.Close();
						textBox5.Text = "";
					}


					dataGridView1.Rows.Clear(); con.Open();
					String quertString1 = @"select * from Material;";
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
						dataGridView1[4, i].Value = reader[4]; i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}


				else { MessageBox.Show("Не введено значение материала!"); }
				checkBox2.Checked = false;
				textBox1.Text = "";
			}

			if (checkBox3.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					String quertString = @"delete from Material where ID_material='" + textBox1.Text + "'";
					SqlCommand insert = new SqlCommand(quertString, con); con.Open();
					insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
					quertString = @"select * from Material;"; con.Open();
					SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4]; i++;
					}

					reader.Close(); con.Close(); textBox1.Text = "";
				}
				if (result == DialogResult.No)
				{
					dataGridView1.Rows.Clear(); con.Open();
					String quertString = @"select * from Material;"; SqlCommand table = new SqlCommand(quertString, con); SqlDataReader reader = table.ExecuteReader();
					int i = 0;
					while (reader.Read())
					{
						dataGridView1.Rows.Add();
						dataGridView1[0, i].Value = reader[0];
						dataGridView1[1, i].Value = reader[1];
						dataGridView1[2, i].Value = reader[2];
						dataGridView1[3, i].Value = reader[3];
						dataGridView1[4, i].Value = reader[4]; i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				checkBox3.Checked = false;
			}
		}
	}
	}

