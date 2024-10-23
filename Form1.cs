using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment5_1
{
    public partial class Form1 : Form
    {
        private int guessCount = 0;
        private int randomNumber;
        string numberLog = "";

        public Form1()
        {
            InitializeComponent();

            randomNumber = GenerateNumber();

            button2.Hide();
        }

        // Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            // guess count increment
            guessCount++;

            int guessedNumber;

            if (int.TryParse(textBox1.Text, out guessedNumber) && 
                guessedNumber > 0 && guessedNumber < 101)
            {
                if (guessedNumber > randomNumber)
                {
                    label2.Text = "Too high. Try again.\n" + LogStore();
                }
                else if (guessedNumber < randomNumber)
                {
                    label2.Text = "Too low. Try again.\n" + LogStore();
                }
                else
                {
                    label2.Text = $"Congratulations! You guessed correct!\nIt took you {guessCount} tries.";
                    button2.Show();
                }
            }
            else
            {
                label2.Text = "Invalid input.\nPlease enter an integer between 1 and 100.";                
            }
        }

        // Try again button
        private void button2_Click(object sender, EventArgs e)
        {
            guessCount = 0;

            randomNumber = GenerateNumber();

            label2.Text = "";
            textBox1.Text = "";

            button2.Hide();
        }

        // number generator
        private int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(1, 101);
        }

        // number log storage
        private string LogStore()
        {
            numberLog += $" {textBox1.Text},";
            textBox1.Text = "";
            return "Log:" + numberLog;
        }
    }
}
