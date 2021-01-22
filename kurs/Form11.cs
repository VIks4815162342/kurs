using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using excel = Microsoft.Office.Interop.Excel;

namespace kurs
{
	public partial class Form11 : Form
	{
		public Form11(SqlConnection con)
		{
			InitializeComponent(); this.con = con;

		}
		public SqlConnection con;

		private void Form11_Load(object sender, EventArgs e)
		{

			String quertString = @"select CONCAT_WS('', c.Last_name, c.First_name) as Client_name,
			s.Name_service, b.Date_time, s.Cost, 
			CONCAT_WS('',e.Last_name, e.First_name) as masters_name
			from Booking as b
			join Clients as c on c.ID_client=b.ID_client
			join Employers as e on e.ID_employee=b.ID_employee
			join Services as s on s.ID_service=b.ID_service
			group by c.Last_name,c.First_name , e.Last_name , e.First_name,
			s.Name_service, b.Date_time, s.Cost
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
				dataGridView1[3, i].Value = reader[3];
				dataGridView1[4, i].Value = reader[4];

				i++;
			}
			reader.Close(); con.Close();
		}

		private void button1_Click(object sender, EventArgs e)
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
				worksheet.Name = "клиенты"; // Изменение имени рабочего листа
														// Заполнение Excel документа
				worksheet.Cells[1, 1] = "Клиенты:";

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
}