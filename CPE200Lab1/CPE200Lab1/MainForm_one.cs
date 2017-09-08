using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand, secondOperand;
        private string operate,tempOperate, combine;
        private double mem;

        private CalculatorEngine engine;
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            isAfterOperater = false;

        }

        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }

            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
            hasDot = false;
        }


        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                string secondOperand = lblDisplay.Text;
                string result = engine.calculate(operate, firstOperand, secondOperand);
                lblDisplay.Text = result;
            }

            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    tempOperate = operate;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(tempOperate, firstOperand, secondOperand);
                    break;
                case "1/x":
                    engine.calculate(operate, firstOperand, "0");
                    break;
                case "√":
                    engine.calculate(operate, firstOperand, "0");
                    break;
            }
            //อัพละทำไมไม่ขึ้น
            isAllowBack = false;
            isAfterOperater = true;
        }
        string result;
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (isAfterEqual)
            {
                string firstOperand = lblDisplay.Text;
                result = engine.calculate(operate, firstOperand, secondOperand);
                lblDisplay.Text = result;
            }
            else
            {
                if (lblDisplay.Text is "Error")
                {
                    return;
                }
                secondOperand = lblDisplay.Text;
                result = engine.calculate(tempOperate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
                isAfterEqual = true;
                isAfterOperater = false;
               
            }

        }
        //ggwp55
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnMemory_Click(object sender, EventArgs e)
        {

            switch (((Button)sender).Text)
            {
                case "MC":
                    mem = 0;
                    break;
                case "MR":
                    lblDisplay.Text = mem.ToString();
                    break;
                case "MS":
                    mem = Convert.ToDouble(lblDisplay.Text);
                    break;
                case "M+":
                    mem += Convert.ToDouble(lblDisplay.Text);
                    break;
                case "M-":
                    mem -= Convert.ToDouble(lblDisplay.Text);
                    break;
            }
        }


    }
}
