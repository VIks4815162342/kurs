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
    public partial class Form15 : Form
    {
        public Form15(SqlConnection con)
        {
            InitializeComponent();
			this.con = con;
		}
		public SqlConnection con;
        public int r { get; set; }

        private void Form15_Load_1(object sender, EventArgs e)
		{
			String quertString = @"select v.ID_vacation, v.ID_employee, CONCAT_WS(e.First_name, e.Middle_name, e.Last_name), v.ID_of_absence, t.Type, v.Start_date, v.End_date, v.Permit from  Vacations as v
			join Type_of_absence as t on t.ID_of_absence=v.ID_of_absence
			join Employers as e on e.ID_employee=v.ID_employee;";
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


				i++;
			}
			reader.Close(); con.Close();
			//MessageBox.Show(string.Format("R: {0}", r));
            if (r == 1 || r == 0 || r==3)
            {
                label6.Visible = false;
                textBox6.Visible = false;
            }
		
		}
		

		private void button1_Click(object sender, EventArgs e)
		{
			
				if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
				(textBox5.Text != ""))
				{
					DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						String quertString = @"insert into Vacations ( ID_employee, ID_of_absence, Start_date,End_date, Permit) values('"
						+ textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToDateTime(textBox4.Text) + "','" +
						Convert.ToDateTime(textBox5.Text) + "', '"+textBox6+"');";
			
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
				//	SqlCommand insert = new SqlCommand(quertString1, con); con.Open();
					insert.ExecuteNonQuery();
						con.Close();
						dataGridView1.Rows.Clear();
						quertString = @"select v.ID_vacation, v.ID_employee, CONCAT_WS(e.First_name, e.Middle_name, e.Last_name), v.ID_of_absence, t.Type, v.Start_date, v.End_date, v.Permit from  Vacations as v
			join Type_of_absence as t on t.ID_of_absence=v.ID_of_absence
			join Employers as e on e.ID_employee=v.ID_employee
		;";
						con.Open();
						SqlCommand table = new SqlCommand(quertString, con);
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


							i++;
						}
						reader.Close(); con.Close();
					}
					else
					{
						dataGridView1[1, dataGridView1.RowCount - 1].Value = "";
						textBox1.Text = "";
					}
				}
				else { MessageBox.Show("Не введено какое-то значение!"); }
				checkBox1.Checked = false;
				if ((checkBox2.Checked == false) && (checkBox3.Checked == false))
				{
					if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") &&
					(textBox5.Text != "")  )
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
			if (checkBox2.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{ //Если поле не пустое, то отправляется запрос на изменение 
					if (textBox2.Text != "")
					{
						String quertString = @"update Vacations set ID_employee='" + textBox2.Text + "' where ID_vacation='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con);
						con.Open();
						insert.ExecuteNonQuery();
						con.Close();
						textBox2.Text = "";
					}

					if (textBox3.Text != "")
					{
						String quertString = @"update Vacations set ID_of_absence='" + textBox3.Text + "' where ID_vacation='" + textBox1.Text + "'"; SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery();
						con.Close();
						textBox3.Text = "";
					}

					if (textBox4.Text != "")
					{
						String quertString = @"update Vacations set Start_date='" + textBox4.Text + "' where ID_vacation='" + textBox1.Text + "'"; SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery();
						con.Close();
						textBox4.Text = "";
					}


					if (textBox5.Text != "")
					{
						String quertString = @"update Vacations set End_date='" + Convert.ToDateTime(textBox5.Text) + "' where ID_vacation='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery();
						con.Close();
						textBox5.Text = "";
					}

					if (textBox6.Text != "")
					{
						String quertString = @"update Vacations set Permit='" + textBox6.Text + "' where ID_vacation='" + textBox1.Text + "'";
						SqlCommand insert = new SqlCommand(quertString, con); con.Open();
						insert.ExecuteNonQuery();
						con.Close();
						textBox6.Text = "";
					}

				}
			}
		}

				private void button3_Click(object sender, EventArgs e)
				{
			if (checkBox3.Checked == true)
			{
				DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					String quertString = @"delete from Vacations where ID_vacation='" + textBox1.Text + "'";
					SqlCommand insert = new SqlCommand(quertString, con); con.Open();
					insert.ExecuteNonQuery(); con.Close(); dataGridView1.Rows.Clear();
					quertString = @"select v.ID_vacation, v.ID_employee, CONCAT_WS(e.First_name, e.Middle_name, e.Last_name), v.ID_of_absence, t.Type, v.Start_date, v.End_date, v.Permit from  Vacations as v
	join Type_of_absence as t on t.ID_of_absence=v.ID_of_absence
	join Employers as e on e.ID_employee=v.ID_employee;"; con.Open();
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

						i++;
					}

					reader.Close(); con.Close(); textBox1.Text = "";
				}
				if (result == DialogResult.No)
				{
					dataGridView1.Rows.Clear(); con.Open();
					String quertString = @"select v.ID_vacation, v.ID_employee, CONCAT_WS(e.First_name, e.Middle_name, e.Last_name), v.ID_of_absence, t.Type, v.Start_date, v.End_date, v.Permit from  Vacations as v
					join Type_of_absence as t on t.ID_of_absence=v.ID_of_absence
					join Employers as e on e.ID_employee=v.ID_employee;";
					SqlCommand table = new SqlCommand(quertString, con);
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

						i++;
					}
					reader.Close(); con.Close(); textBox1.Text = "";
				}
				checkBox3.Checked = false;
			}
		}

        private void button4_Click(object sender, EventArgs e)
        {
			Form17 NewForm = new Form17();
			NewForm.Show();
			this.Hide();
		}
    }

      
    }





