using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class passwords : Form
    {
        Random rnd = new Random();
        string fileName = "history.txt";

        public passwords()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int length = Convert.ToInt32(txtLength.Text);

                if (length <= 0)
                {
                    MessageBox.Show("Введіть правильну довжину!");
                    return;
                }

                string symbols = "";

                if (checkUpper.Checked)
                    symbols += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                if (checkLower.Checked)
                    symbols += "abcdefghijklmnopqrstuvwxyz";

                if (checkNumbers.Checked)
                    symbols += "0123456789";

                if (checkSpecial.Checked)
                    symbols += "!@#$%^&*()_+-=";

                if (symbols == "")
                {
                    MessageBox.Show("Оберіть хоча б один тип символів!");
                    return;
                }

                string password = "";

                for (int i = 0; i < length; i++)
                {
                    password += symbols[rnd.Next(symbols.Length)];
                }

                txtPassword.Text = password;

                // оцінка складності
                int score = 0;

                if (checkUpper.Checked) score++;
                if (checkLower.Checked) score++;
                if (checkNumbers.Checked) score++;
                if (checkSpecial.Checked) score++;

                if (length >= 12) score++;

                if (score <= 2)
                    lblPower.Text = "Слабкий";

                else if (score <= 4)
                    lblPower.Text = "Середній";

                else
                    lblPower.Text = "Сильний";

                // історія
                File.AppendAllText(fileName,
                    password + " | " + lblPower.Text + Environment.NewLine);

                listBox1.Items.Add(password + " | " + lblPower.Text);
            }
            catch
            {
                MessageBox.Show("Помилка! Введіть число.");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                Clipboard.SetText(txtPassword.Text);
                MessageBox.Show("Пароль скопійовано!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (File.Exists(fileName))
            {
                File.WriteAllText(fileName, "");
            }

            MessageBox.Show("Історію очищено");
        }

        private void passwords_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }
        }
    }
}