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
using excel = Microsoft.Office.Interop.Excel;

namespace kurs
{
	public partial class Form9 : Form
	{
		public Form9(SqlConnection con)
		{
			InitializeComponent(); this.con = con;

		}
		public SqlConnection con;

		private void Form9_Load(object sender, EventArgs e)
		{

			String quertString = @"select
			m.Name_material, m.Shelf_life, m.Quantity from Material as m
			where DATEDIFF(day, m.Shelf_life, GETDATE())<=0
			;"; 
			SqlCommand table = new SqlCommand(quertString, con);
			con.Open();
			SqlDataReader reader = table.ExecuteReader(); int i = 0;
			while (reader.Read())
			{
				dataGridView1.Rows.Add();
				dataGridView1[0, i].Value = reader[0];
				dataGridView1[1, i].Value = reader[1];
				dataGridView1[2, i].Value = reader[2];
			//	dataGridView1[3, i].Value = reader[3];
				
				i++;
			}
			reader.Close(); con.Close();


		}
		//private Microsoft.Office.Interop.Excel.Application app = null;
		//private Microsoft.Office.Interop.Excel.Workbook workbook = null;
		//private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
		private void button1_Click(object sender, EventArgs e)
		{
			{ 
				saveFileDialog1.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls;*.xlsx";//Отображаютя только файлы Exel


				if (saveFileDialog1.ShowDialog() == DialogResult.OK)//Если пользователь сохранил документ
				{

					//Создание Excel документа 
					Microsoft.Office.Interop.Excel._Application app = new
					Microsoft.Office.Interop.Excel.Application();
					// Создание новой рабочей книги в этом документе 
					Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
					// Создание нового листа в вышесозданной книге 
					Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
					// Устанавливает свойство видимости документа за программой. 

					app.Visible = true;
					worksheet = workbook.ActiveSheet;// Определение значения объекта 
					worksheet.Name = "сотрудники"; // Изменение имени рабочего листа
												// Заполнение Excel документа
					worksheet.Cells[1, 1] = "Сотрудники:";

					for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
					{
						worksheet.Cells[2, i] = dataGridView1[i - 1, 0].Value;
						//В некоторых версиях программа может выводить ошибку на 2 следующие

						worksheet.Columns[i].ColumnWidth = 30;//Установление ширины столбцов 

					}
						for (int i = 1; i < dataGridView1.RowCount; i++)
							for (int j = 0; j < dataGridView1.ColumnCount; j++)
							{ worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value; }
						// Сохраняет документ
						workbook.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing,

						Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
						app.Quit();// Закрывает документ
					}


				}
			}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
	}
