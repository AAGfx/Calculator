using System;
using System.Collections;

namespace Calculator
{

    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private static double ComputeResult()
        {
            string leftoper = string.Empty;
            string rightoper = string.Empty;
            string operat = string.Empty;

            string token;
            for (int i = Global.tokens.Count; i > 0; i--)
            {
                token = Global.tokens.ElementAt(i - 1);

                if ((token.Equals("+") || token.Equals("-")
                    || token.Equals("/") || token.Equals("*")
                    || token.Equals("^") || token.Equals("%"))
                    && string.IsNullOrEmpty(operat))
                {
                    operat = token.ToString();
                }
                else if (char.IsNumber(token.ElementAt(token.Length - 1)) && string.IsNullOrEmpty(rightoper))
                {
                    rightoper = token.ToString();
                }
                else if (char.IsNumber(token.ElementAt(token.Length - 1)) && string.IsNullOrEmpty(leftoper))
                {
                    leftoper = token.ToString();
                }
                else
                {

                }
            }
            return Calculate(leftoper, operat, rightoper);
        }

        private static double Calculate(string leftoper, string op, string rightoper)
        {

            try
            {
                return op switch
                {
                    "+" => Convert.ToDouble(leftoper) + Convert.ToDouble(rightoper),
                    "-" => Convert.ToDouble(leftoper) - Convert.ToDouble(rightoper),
                    "/" => Convert.ToDouble(leftoper) / Convert.ToDouble(rightoper),
                    "*" => Convert.ToDouble(leftoper) * Convert.ToDouble(rightoper),
                    "^" => Math.Pow(Convert.ToDouble(leftoper), Convert.ToDouble(rightoper)),
                    "%" => Convert.ToDouble(leftoper) % Convert.ToDouble(rightoper),
                    _ => throw new Exception(),
                };
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static void AddToStack(string text)
        {
            string calc = (string)text.Clone();
            string num = string.Empty;

            for (int i = calc.Length; i > 0; i--)
            {

                char element = calc.ElementAt(calc.Length - 1);
                char element2 = '?';

                if (calc.Length > 1)
                {
                    element2 = calc.ElementAt(calc.Length - 2);
                }

                if (element.Equals('(') || element.Equals(')')
                    || element.Equals('/') || element.Equals('*')
                    || element.Equals('+') || element.Equals('-')
                    || element.Equals('^') || element.Equals('%'))
                {
                    Global.tokens.Push(element + string.Empty);
                    num = string.Empty;
                }
                else
                {
                    num = string.Concat(element, num);

                    if (!(char.IsNumber(element2) || element2.Equals('.')))
                    {
                        if (element2.Equals('-'))
                        {
                            Global.tokens.Push("-" + num);
                            calc = calc[..^2] + "+" + element;
                        }
                        else
                        {
                            Global.tokens.Push(num);
                        }
                    }
                }
                calc = calc.Remove(calc.Length - 1);
            }
        }



        private void EqualBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBox.Text))
            {
                TxtBox.Text = TxtBox2.Text;
            }
            else
            {
                TxtBox.Text += TxtBox2.Text;
                AddToStack(TxtBox.Text);

                TxtBox2.Clear();
                TxtBox.Text = Convert.ToString(ComputeResult());

                Global.tokens.Clear();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0" || string.IsNullOrEmpty(TxtBox2.Text)))
                TxtBox2.Text = TxtBox2.Text.Remove(TxtBox2.Text.Length - 1);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            TxtBox.Clear();
            TxtBox2.Clear();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "1";
            }
            else
            {
                TxtBox2.Text += "1";
            }

        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "2";
            }
            else
            {
                TxtBox2.Text += "2";
            }

        }

        private void Btn3_Click_1(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "3";
            }
            else
            {
                TxtBox2.Text += "3";
            }
        }

        private void Btn4_Click_1(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "4";
            }
            else
            {
                TxtBox2.Text += "4";
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "5";
            }
            else
            {
                TxtBox2.Text += "5";
            }
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "6";
            }
            else
            {
                TxtBox2.Text += "6";
            }
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "7";
            }
            else
            {
                TxtBox2.Text += "7";
            }
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "8";
            }
            else
            {
                TxtBox2.Text += "8";
            }
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                TxtBox2.Text = "9";
            }
            else
            {
                TxtBox2.Text += "9";
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0"))
            {
                TxtBox2.Text += "0";
            }
        }

        private void DotBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text.EndsWith('.')))
            {
                TxtBox2.Text += ".";
            }
        }

        private void PlsBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                if (TxtBox.Text.EndsWith('0') || TxtBox.Text.EndsWith('-')
                    || TxtBox.Text.EndsWith('/') || TxtBox.Text.EndsWith('*'))
                {
                    TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.Length - 1) + "+";
                }
            }
            else
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "+") : (TxtBox.Text + TxtBox2.Text + "+");
                TxtBox2.Text = "0";
            }
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox2.Text == "0")
            {
                if (TxtBox.Text.EndsWith('0') || TxtBox.Text.EndsWith('+')
                    || TxtBox.Text.EndsWith('/') || TxtBox.Text.EndsWith('*'))
                {
                    TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.Length - 1) + "-";
                }
            }
            else
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "-") : (TxtBox.Text + TxtBox2.Text + "-");
                TxtBox2.Text = "0";
            }
        }

        private void DivBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0"))
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "/") : (TxtBox.Text + TxtBox2.Text + "/");
                TxtBox2.Text = "0";
            }
            else
            {
                /*
                int lastElement = int.Parse(TxtBox.Text.Substring(TxtBox.Text.Length - 1));
                if (lastElement >= 0 && lastElement <= 9)
                {
                    TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.Length - 1) + "/";
                }*/
            }
        }

        private void TimesBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0"))
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "*") : (TxtBox.Text + TxtBox2.Text + "*");
                TxtBox2.Text = "0";
            }
        }

        private void AbsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);

                if (num < 0)
                {
                    TxtBox.Text = Math.Abs(num).ToString();
                    //TxtBox.Text = TxtBox.Text.Remove(0, 1);
                }
            }
            catch (Exception)
            {
                //TxtBox.Text = "Input Not Found!";
            }
        }

        private void FlrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(TxtBox.Text == "0"))
                {
                    double num = Convert.ToDouble(TxtBox.Text);
                    TxtBox.Text = (Math.Floor(num)) + "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void CeilBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(TxtBox.Text == "0"))
                {
                    double num = Convert.ToDouble(TxtBox.Text);
                    TxtBox.Text = (Math.Ceiling(num)) + "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(TxtBox.Text == "0"))
                {
                    double num = Convert.ToDouble(TxtBox.Text);
                    TxtBox.Text = (Math.Log10(num)) + "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void SqrtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);
                TxtBox.Text = (Math.Sqrt(num)) + "";
            }
            catch (Exception)
            {

            }
        }

        private void ModBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0"))
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "%") : (TxtBox.Text + TxtBox2.Text + "%");
                TxtBox2.Text = "0";
            }
        }

        private void PowBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox2.Text == "0"))
            {
                TxtBox.Text = (TxtBox.Text == "0") ? (TxtBox2.Text + "^") : (TxtBox.Text + TxtBox2.Text + "^");
                TxtBox2.Text = "0";
            }
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            if (!(TxtBox.Text == "0" || string.IsNullOrEmpty(TxtBox.Text)) && TxtBox.TextLength > 0)
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.Length - 1);
        }

        private void FacBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);
                double res = 1;
                for (int i = 1; i <= num; i++)
                {
                    res *= i;
                }
                TxtBox.Text = (res) + "";
            }
            catch (Exception)
            {

            }
        }

        private void SignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);

                if (num < 0)
                {
                    TxtBox.Text = Math.Abs(num).ToString();
                }
                else
                {
                    TxtBox.Text = "-" + Math.Abs(num).ToString();
                }
            }
            catch (Exception)
            {
                //TxtBox.Text = "Input Not Found!";
            }
        }

        private void CosBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);
                TxtBox.Text = (Math.Cos(num)) + "";
            }
            catch (Exception)
            {

            }
        }

        private void RevBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);
                TxtBox.Text = (1 / num) + "";
            }
            catch (Exception)
            {

            }
        }

        private void SinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(TxtBox.Text);
                TxtBox.Text = (Math.Sin(num)) + "";
            }
            catch (Exception)
            {

            }
        }
    }
}