using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace kurs
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        public string theme { get; set; }
        public Microsoft.Office.Interop.Excel.Workbook workBook { get; set; }

        private string excelFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Excel";

        private void Form13_Load(object sender, EventArgs e)
        {
            textBox3.Text = "Таблица: \"" + theme.Split('(', ')')[1] + "\"";
            textBox4.Text = "Здравствуйте!";
            label5.Text = label5.Text + theme;
            if (label5.Text.Length > 50)
                label5.Text = label5.Text.Substring(0, 50) + "...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Select();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ошибка: email получателя\nне заполнен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                MailAddress from = new MailAddress("beautifulday2021@mail.ru", textBox1.Text);
                MailAddress to = new MailAddress(textBox2.Text);
                MailMessage message = new MailMessage(from, to);
                message.Subject = textBox3.Text;
                message.Body = textBox4.Text;
                if (label5.Text != "")
                    message.Attachments.Add(new Attachment($"{excelFolder}\\{theme}"));
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("beautifulday2021@mail.ru", "AATE?rauto11");
                smtp.EnableSsl = true;
                smtp.Send(message);
                MessageBox.Show("Письмо отправлено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
