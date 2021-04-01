using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class WinForm : Form
    {
        double result = 0;
        string operation = "";
        bool enter_value = false;
        char iOperation;
        public WinForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button btnNum = (Button)sender;

            if ((textDisplay.Text == "0") || (enter_value))
                textDisplay.Text = "";
            enter_value = false;

            if (btnNum.Text == ".") 
            {
                if (!textDisplay.Text.Contains("."))
                    textDisplay.Text = textDisplay.Text + btnNum.Text;
            }
            else 
            {
                textDisplay.Text = textDisplay.Text + btnNum.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button operat = (Button)sender;

            if(result !=0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = operat.Text;
                labShow.Text = result + " " + operation;
            }
            else
            {
                operation = operat.Text;
                result = Double.Parse(textDisplay.Text);
                enter_value = true;
                labShow.Text = result + " " + operation;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            labShow.Text = "";
            switch(operation)
            {
                case "+":
                    textDisplay.Text = (result + Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "-":
                    textDisplay.Text = (result - Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "/":
                    textDisplay.Text = (result / Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "X":
                    textDisplay.Text = (result * Double.Parse(textDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textDisplay.Text);
            operation = "";
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
            result = 0;
            labShow.Text = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if(textDisplay.Text.Length > 0)
            {
                textDisplay.Text = textDisplay.Text.Remove(textDisplay.Text.Length - 1, 1);
            }
            if(textDisplay.Text == "")
            {
                textDisplay.Text = "0";
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            textDisplay.Text = (!string.IsNullOrEmpty(textDisplay.Text)) ? Math.Sqrt(double.Parse(textDisplay.Text)).ToString() : "";
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            textDisplay.Text = Math.Pow(double.Parse(textDisplay.Text), 2).ToString();
        }

        private void btnOneOf_Click(object sender, EventArgs e)
        {
            if (textDisplay.Text != "0")
            {
                textDisplay.Text = (1 / double.Parse(textDisplay.Text)).ToString();
            }
        }

        private void btnPersent_Click(object sender, EventArgs e)
        {
            textDisplay.Text = (double.Parse(textDisplay.Text)).ToString();
        }
    }
}
