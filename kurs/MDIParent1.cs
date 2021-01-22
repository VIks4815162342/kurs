using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;

namespace kurs
{
	public partial class MDIParent1 : Form
	{

		private int childFormNumber = 0;

        private string periodTime = "";

		public SqlConnection con;

		public int r { get; set; }

		public MDIParent1(SqlConnection con)
		//Объект SqlConnection передается из формы авторизации в родительскую форму       
		{             
			InitializeComponent();             
			this.con = con;        
		}

        public MDIParent1()
        {
        }

        private void ShowNewForm(object sender, EventArgs e)
		{
			Form childForm = new Form();
			childForm.MdiParent = this;
			childForm.Text = "Окно " + childFormNumber++;
			childForm.Show();
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			Form1 auth = new Form1();
			this.Close();
			auth.Show();
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void MDIParent1_Load(object sender, EventArgs e)
		{ 
			if (r == 3 ||  r == 0)
			{
				изменениеToolStripMenuItem.Visible = false;
				материалыToolStripMenuItem.Visible = false;
				отпускаToolStripMenuItem.Visible = false;
			}
			услугиToolStripMenuItem.PerformClick();
			if (r == 3 || r == 0 || r == 1)
            {
				мастераToolStripMenuItem.Visible = false;

			}
		}

		private bool swapForm(ToolStripMenuItem item)
		{
			foreach (ToolStripItem Item in справочникиToolStripMenuItem.DropDownItems)
			{
				((ToolStripMenuItem)Item).Checked = false;
			}
			foreach (ToolStripItem Item in отчётыToolStripMenuItem.DropDownItems)
			{
				((ToolStripMenuItem)Item).Checked = false;
			}
			item.Checked = true;
            if (item == оказанныеУслугиToolStripMenuItem || item == списокЗаказовToolStripMenuItem)
            {
                периодToolStripMenuItem.Visible = true;
            }
            else
            {
                периодToolStripMenuItem.Visible = false;
                File.WriteAllText("Period\\date1.txt", "");
                File.WriteAllText("Period\\date2.txt", "");
            }
			ToolStripItem s = item;
			foreach (ToolStripItem Item in действияToolStripMenuItem.DropDownItems)
			{
				if (((ToolStripMenuItem)Item).Checked)
					s = ((ToolStripMenuItem)Item);
			}
			if (s == изменениеToolStripMenuItem)
			{
				return true;
			}
			return false;
		}

		private void command(string query)
		{
			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter(query, con);
			sda.Fill(dt);
			dataGridView1.DataSource = dt;
			con.Close();
		}

		private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(услугиToolStripMenuItem))
			{
				Form5 service = new Form5(con);
				service.ShowDialog();
			}
			else
			{
				command(@"select * from Services;");
			}
		}

			
		private void мастераToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(мастераToolStripMenuItem))
			{
				Form3 masters = new Form3(con);
				masters.ShowDialog();
			}
			else
			{
				command(@"select ID_employee, First_name, Middle_name, Last_name, Mobile_number, 
				Date_BD, Login, CONVERT(NVARCHAR(10),HashBytes('MD5', Password),2) as 'Password_MD5', ID_position, City, Street, Home, Number_apartment, 
				ID_role, Serier_passport, Number_passport from Employers;");
			}
		}

		private void отпускаToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (swapForm(отпускаToolStripMenuItem))
			{
				var otchet = new Form15(con);
                otchet.r = r;
                otchet.ShowDialog();
			}
			else
			{
				command(@"select v.ID_vacation, v.ID_employee, CONCAT_WS(e.First_name, e.Middle_name, e.Last_name), v.ID_of_absence, t.Type, v.Start_date, v.End_date, v.Permit from  Vacations as v
			join Type_of_absence as t on t.ID_of_absence=v.ID_of_absence
			join Employers as e on e.ID_employee=v.ID_employee ;");
			}
		}

		private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(клиентыToolStripMenuItem))
			{
				Form4 clients = new Form4(con);
				clients.ShowDialog();
			}
			else
			{
				command(@"select ID_client, First_name, Middle_name, Last_name, Series_passport, 
				Number_passport, Date_BD, Mobile_number, Login, CONVERT(NVARCHAR(10),HashBytes('MD5', Password),2) as 'Password_MD5', 
				ID_role, File_photo from Clients;");
			}
		}

		private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(расписаниеToolStripMenuItem))
			{
				Form6 rasp = new Form6(con);
				rasp.ShowDialog();
			}
			else
			{
				command(@"select b.ID_booking, c.ID_client, CONCAT_WS( c.Last_name, c.First_name, c.Middle_name) as Client_name,
				s.Name_service, b.Date_time, s.Cost, e.ID_employee, CONCAT_WS(e.Last_name, e.First_name, e.Middle_name) as masters_name
				from Booking as b
				join Clients as c on c.ID_client=b.ID_client
				join Employers as e on e.ID_employee=b.ID_employee
				join Services as s on s.ID_service=b.ID_service;");
			}
		}

		private void материалыToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (swapForm(материалыToolStripMenuItem))
			{
				Form7 materials = new Form7(con);
				materials.r = r;
				materials.ShowDialog();
			}
			else
			{
				command(@"select * from Material;");
			}
		}

		private void остаткиРасходныхМатериаловToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(остаткиРасходныхМатериаловToolStripMenuItem))
			{
				Form9 leftovers = new Form9(con);
				leftovers.ShowDialog();
			}
			else
			{
				command(@"select m.Name_material, m.Shelf_life, m.Quantity from Material as m;");
			}
		}

		private void оказанныеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(оказанныеУслугиToolStripMenuItem))
			{
				Form10 service2 = new Form10(con);
				service2.ShowDialog();
			}
			else
			{
                string date1 = File.ReadAllText("Period\\date1.txt");
                string date2 = File.ReadAllText("Period\\date2.txt");
                periodTime = $"HAVING b.Date_time BETWEEN '{date1}' and '{date2}'";
                if (date1 != "" && date2 != "")
                {
                    command($@"select s.ID_service, s.Name_service, s.Cost, COUNT(b.ID_service) as Quantity,
				    sum(s.cost) as Sum_cost, b.Date_time
				    from Services as s
				    join Booking as b on b.ID_service=s.ID_service
				    group by s.ID_service, s.Name_service, s.Cost, b.ID_service, b.Date_time
				    {periodTime};");
                }
                else
                {
                    command($@"select s.ID_service, s.Name_service, s.Cost, COUNT(b.ID_service) as Quantity,
				    sum(s.cost) as Sum_cost, b.Date_time
				    from Services as s
				    join Booking as b on b.ID_service=s.ID_service
				    group by s.ID_service, s.Name_service, s.Cost, b.ID_service, b.Date_time;");
                }
            }
		}

		private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (swapForm(списокЗаказовToolStripMenuItem))
			{
				Form11 listOrder = new Form11(con);
				listOrder.ShowDialog();
			}
			else
			{
                string date1 = File.ReadAllText("Period\\date1.txt");
                string date2 = File.ReadAllText("Period\\date2.txt");
                periodTime = $"HAVING b.Date_time BETWEEN '{date1}' and '{date2}'";
                if (date1 != "" && date2 != "")
                {
                    command($@"select CONCAT_WS('', c.Last_name, c.First_name) as Client_name, 
				    s.Name_service, b.Date_time, s.Cost,  
				    CONCAT_WS('',e.Last_name, e.First_name) as masters_name 
				    from Booking as b 
				    join Clients as c on c.ID_client=b.ID_client 
				    join Employers as e on e.ID_employee=b.ID_employee 
				    join Services as s on s.ID_service=b.ID_service 
				    group by c.Last_name,c.First_name , e.Last_name , e.First_name, 
				    s.Name_service, b.Date_time, s.Cost 
                    {periodTime};");
                }
                else
                {
                    command(@"select CONCAT_WS('', c.Last_name, c.First_name) as Client_name, 
				    s.Name_service, b.Date_time, s.Cost,  
				    CONCAT_WS('',e.Last_name, e.First_name) as masters_name 
				    from Booking as b 
				    join Clients as c on c.ID_client=b.ID_client 
				    join Employers as e on e.ID_employee=b.ID_employee 
				    join Services as s on s.ID_service=b.ID_service 
				    group by c.Last_name,c.First_name , e.Last_name , e.First_name, 
				    s.Name_service, b.Date_time, s.Cost;");
                }
            }
		}

		private void изменениеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			изменениеToolStripMenuItem.Checked = true;
			foreach (ToolStripItem Item in справочникиToolStripMenuItem.DropDownItems)
			{
				if (((ToolStripMenuItem)Item).Checked)
				{
					((ToolStripMenuItem)Item).PerformClick();
					изменениеToolStripMenuItem.Checked = false;
					return;
				}
			}
			foreach (ToolStripItem Item in отчётыToolStripMenuItem.DropDownItems)
			{
				if (((ToolStripMenuItem)Item).Checked)
				{
					((ToolStripMenuItem)Item).PerformClick();
					изменениеToolStripMenuItem.Checked = false;
					return;
				}
			}
		}

		private void сохранениеВExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
				app.Visible = false;
				worksheet = workbook.ActiveSheet;// Определение значения объекта 
				string table = "";
				foreach (ToolStripMenuItem item in справочникиToolStripMenuItem.DropDownItems)
				{
					if (item.Checked)
					{
						table = item.Text;
						break;
					}
				}
				foreach (ToolStripMenuItem item in отчётыToolStripMenuItem.DropDownItems)
				{
					if (item.Checked)
					{
						table = item.Text;
						break;
					}
				}
				worksheet.Name = table; // Изменение имени рабочего листа
				// Заполнение Excel документа
				worksheet.Cells[1, 1] = table;
				for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
				{
					worksheet.Cells[2, i] = dataGridView1[i - 1, 0].Value;
					//В некоторых версиях программа может выводить ошибку на 2 следующие

					worksheet.Columns[i].ColumnWidth = 30;//Установление ширины столбцов 

				}
				for (int i = 1; i < dataGridView1.RowCount; i++)
					for (int j = 0; j < dataGridView1.ColumnCount; j++)
					{ worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString(); }
				// Сохраняет документ
				workbook.SaveAs(saveFileDialog1.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
									false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
									Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				workbook.Close();
				Marshal.ReleaseComObject(workbook);
				app.Quit();// Закрывает документ
				Marshal.ReleaseComObject(app);
				MessageBox.Show($"Документ успешно сохранен!\nПуть: {saveFileDialog1.FileName}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			printDialog1.Document = printDocument1;
			if (printDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
				MessageBox.Show($"Документ напечатан!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string table = "";
			foreach (ToolStripMenuItem item in справочникиToolStripMenuItem.DropDownItems)
			{
				if (item.Checked)
				{
					table = item.Text;
					break;
				}
			}
			foreach (ToolStripMenuItem item in отчётыToolStripMenuItem.DropDownItems)
			{
				if (item.Checked)
				{
					table = item.Text;
					break;
				}
			}
			Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
			e.Graphics.DrawString(table, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(10, 10));
			dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
			e.Graphics.DrawImage(bitmap, 0, 40);
		}

		private void printToolStripButton_Click(object sender, EventArgs e)
		{
			печатьToolStripMenuItem.PerformClick();
		}

		private void отправкаНаПочтуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var email = new Form13();
			//Создание Excel документа 
			Microsoft.Office.Interop.Excel._Application app = new
			Microsoft.Office.Interop.Excel.Application();
			// Создание новой рабочей книги в этом документе 
			Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
			// Создание нового листа в вышесозданной книге 
			Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
			// Устанавливает свойство видимости документа за программой. 
			app.Visible = false;
			worksheet = workbook.ActiveSheet;// Определение значения объекта 
			string table = "";
			foreach (ToolStripMenuItem item in справочникиToolStripMenuItem.DropDownItems)
			{
				if (item.Checked)
				{
					table = item.Text;
					break;
				}
			}
			foreach (ToolStripMenuItem item in отчётыToolStripMenuItem.DropDownItems)
			{
				if (item.Checked)
				{
					table = item.Text;
					break;
				}
			}
			worksheet.Name = table; // Изменение имени рабочего листа
			// Заполнение Excel документа
			worksheet.Cells[1, 1] = table;

			for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
			{
				worksheet.Cells[2, i] = dataGridView1[i - 1, 0].Value;
				//В некоторых версиях программа может выводить ошибку на 2 следующие

				worksheet.Columns[i].ColumnWidth = 30;//Установление ширины столбцов 

			}
			for (int i = 1; i < dataGridView1.RowCount; i++)
				for (int j = 0; j < dataGridView1.ColumnCount; j++)
				{ worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString(); }
			string filenameString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 5);
			string[] incorrectSymb = { "=", "+", "/" };
			for (int i = 0; i < incorrectSymb.Length; i++)
				filenameString = filenameString.Replace(incorrectSymb[i], "");
			string fname = $"{filenameString}({table}).xlsx";
			string excelFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Excel\\";
			workbook.SaveAs(excelFolder + fname, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
									false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
									Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			workbook.Close();
			Marshal.ReleaseComObject(workbook);
			app.Quit();// Закрывает документ
			Marshal.ReleaseComObject(app);
			email.theme = fname;
			email.ShowDialog();
		}

		private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("САЛОН КРАСОТЫ 'BEAUTIFULDAY'\n\n Информационная система для автоматизированной работы администратора салона красоты.\n\n  Система позволяет эффективно хранить, быстро извлекать нужную информацию и управлять большими объёмами данных. \n\n©Груздева Виктория ЭИС-37, 2021", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

        private void периодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 period = new Form14();
            period.ShowDialog();
            foreach (ToolStripMenuItem item in отчётыToolStripMenuItem.DropDownItems)
            {
                if (item.Checked && (item == оказанныеУслугиToolStripMenuItem))
                {
                    оказанныеУслугиToolStripMenuItem.PerformClick();
                    break;
                }
                if (item.Checked && (item == списокЗаказовToolStripMenuItem))
                {
                    списокЗаказовToolStripMenuItem.PerformClick();
                    break;
                }
            }
        }


    }
}
