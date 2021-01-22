using System;
using System.IO;
using System.Windows.Forms;

namespace kurs
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private string date1 = "";
        private string date2 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Select();
            date1 = dateTimePicker1.Value.ToString("dd.MM.yyyy") + " " + dateTimePicker2.Value.ToString("HH:mm");
            date2 = dateTimePicker3.Value.ToString("dd.MM.yyyy") + " " + dateTimePicker4.Value.ToString("HH:mm");
            if (Math.Min(DateTime.Parse(date1).Ticks, DateTime.Parse(date2).Ticks) != DateTime.Parse(date1).Ticks)
            {
                MessageBox.Show("Ошибка: неправильный период.\n" +
                    "Дата и время начала периода не может быть\n" +
                    "больше даты и время конца периода!", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date1 = "";
                date2 = "";
                return;
            }
            File.WriteAllText("Period\\date1.txt", date1);
            File.WriteAllText("Period\\date2.txt", date2);
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            label1.Select();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
        }

        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (date1 == "" || date2 == "")
            {
                File.WriteAllText("Period\\date1.txt", "");
                File.WriteAllText("Period\\date2.txt", "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date1 = "";
            date2 = "";
            File.WriteAllText("Period\\date1.txt", "");
            File.WriteAllText("Period\\date2.txt", "");
            this.Close();
        }
    }
}
