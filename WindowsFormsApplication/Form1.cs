using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

/*
Author Παναγιώτης Πράττης/Panagiotis Prattis
*/

namespace WindowsFormsApplication
{


public partial class Form1 : Form
    {
        
        // enter a random variable from the random method to
        // use later to call random colors
        private Random rnd = new Random();

        double a;//the number of the first textbox
        double b;//the number of the second textbox
        double c;//the number of the third textbox -> the result

        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)// the 1st text field
        {
            // every time the user presses a dot "." will be converted to a "," comma
            // to get things done correctly because: 1.2 = 12 (dot not read)

            textBox1.Text= textBox1.Text.Replace(".", ",");
            textBox1.Focus();// to be the cursor always at the end
            textBox1.SelectionStart = textBox1.Text.Length;

            double parsedValue;
            // check if the text in the textbox is converted to a number so that the actions can be done
            if (Double.TryParse(textBox1.Text, out parsedValue) == false && textBox1.Text.Length != 0)
            {
                // specifically the field should not accept letters and symbols other than "." and ","
                // to allow it to work properly let the "-" symbol for negative numbers
                if (textBox1.Text != "-" && textBox1.Text.Length != 0)//the symbol "-" allowed only first
                {
                    MessageBox.Show("Please enter only numbers!");
                    if (textBox1.Text.Length != 0)//wrong characters are removed
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        textBox1.Focus();
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//the list of mathematical operations
        {
            
            string operation = (string)comboBox1.SelectedItem;

             if (operation == "+")// here I display the action the user chose
                label1.Text = "+";
            else if (operation == "-")
                label1.Text = "-";
            else if (operation == "*")
                label1.Text = "*";
            else if (operation == "/")
                label1.Text = "/";
            else if (operation == "%")
                label1.Text = "%";
            else if (operation == "^")
                label1.Text = "^";
            else if (operation == "!")
                label1.Text = "!";
            else if (operation == "√")
                label1.Text = "√";
            
            if (operation == "!" || operation == "√")// if the operation is factorial or square root I lock the 2nd text field
            {
                textBox2.Enabled = false;
            }
            else
                textBox2.Enabled = true;


        }

        // the label will show the symbol of the selected operation
        // and when pressed the user will receive information about the action
        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == null)
            {
                MessageBox.Show("You haven't chosen an operation");
            }
            else
            {
                if (label1.Text == "+")
                {
                    MessageBox.Show("You have chosen the addition operation" + "\n" + "The symbol is the plus '+' " + "\n" + "E.g. 1 + 1 = 2");
                }
                else if (label1.Text == "-")
                {
                    MessageBox.Show("You have chosen the subtraction operation" + "\n" + "The symbol is the minus '-' " + "\n" + "E.g. 2 - 1 = 1");
                }
                else if (label1.Text == "*")
                {
                    MessageBox.Show("You have chosen the multiplication operation" + "\n" + "The symbol is the asterisk '*' or the times '×' or multiplication dot '·'" + "\n" + "E.g. 2 C 2 = 4");
                }
                else if (label1.Text == "/")
                {
                    MessageBox.Show("You have chosen the division operation" + "\n" + "The symbol is the slash '/' or the obelus '÷'" + "\n" + "E.g. 4 ÷ 2 = 2");
                }
                else if (label1.Text == "%")
                {
                    MessageBox.Show("You have chosen the remainder or modulus operation" + "\n" + "The symbol is the percent '%' or modulo 'mod'" + "\n" + "Formula: remainder = number - divisor × (number ÷ divisor)" + "\n" + "E.g. 5 % 2 = 1");
                }
                else if (label1.Text == "^") 
                {
                    MessageBox.Show("You have chosen the power operation" + "\n" + "The symbol is the caret '^' or exponent" + "\n" + "Formula: a^b = a × a × ... × a (b times), a^0 = 1 and a^1 = a " + "\n" + "E.g. 3 ^ 2 = 9");
                }
                else if (label1.Text == "!")
                {
                    MessageBox.Show("You have chosen the factorial operation" + "\n" + "The symbol is the exclamation mark '!' " + "\n" + "Formula: n! = 1 × 2 × ... × (n-1) × n, 0! = 1! =1 " + "\n" + "E.g. 5! = 1 × 2 × 3 × 4 × 5 = 120");
                }
                else if (label1.Text == "√")
                {
                    MessageBox.Show("You have chosen the square root operation" + "\n" + "The symbol is the square root '√' " + "\n" + "Formula: a ^ (1/2) = √a, √a × √a = a " + "\n" + "E.g. √9 = ±3");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)// the 2nd text field
        {
            // same attributes as 1st text field
            textBox2.Text = textBox2.Text.Replace(".", ",");
            textBox2.Focus();
            textBox2.SelectionStart = textBox2.Text.Length;

            double parsedValue;
            if (Double.TryParse(textBox2.Text, out parsedValue) == false && textBox2.Text.Length != 0)
            {
                if (textBox2.Text != "-" && textBox2.Text.Length != 0)
                {
                    MessageBox.Show("Please enter only numbers!");
                    if (textBox2.Text.Length != 0)
                    {
                        textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                        textBox2.Focus();
                        textBox2.SelectionStart = textBox2.Text.Length;
                    }
                }
            }
        }

        
        private void button1_Click(object sender, EventArgs e)//το κουμπί υπολογισμού
        {
            
            long x;//for factorial
            long parsedInt;
            bool text1 = false;//to check if there is number at first text field
            bool text2 = false;//for the 2nd textfield
            bool op = false;//to check if an operetion is selected
            bool texts;//if everything is ok it is true
            string operation = (string)comboBox1.SelectedItem;

            if (textBox1.Text.Length == 0)
                MessageBox.Show("Please put a number at the 1st TextBox!");
            else
                text1 = true;

            if (operation == null)
                MessageBox.Show("Please pick a math operation!");
            else
                op = true;

            if (textBox2.Text.Length == 0 && operation != "!" && operation != "√")
                MessageBox.Show("Please put a number at the 2nd TextBox!");
            else
                text2 = true;

            texts = text1 && text2 && op;


            if (texts == true)
            {
                // if all is ok with the fields the user has to fill
                // will begin the process of correcting the user's input

                if (textBox1.Text.EndsWith(","))// if the number ends with "," I delete it
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                if (textBox2.Text.EndsWith(","))
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);

                if (double.Parse(textBox1.Text) == 0)// if the number is zero but the user has given it otherwise
                    //example 00,0 -> 0 to make it look better
                    textBox1.Text = "0";
                if(operation != "!" && operation != "√")
                    if (double.Parse(textBox2.Text) == 0)
                        textBox2.Text = "0";


                // if the number given by the user is redundant I will subtract them
                if (textBox1.Text.StartsWith("0") && !textBox1.Text.StartsWith("0,") && textBox1.Text.Length != 1)
                {
                    //if the number starts with zero I delete them
                    //example 000002,1 -> 2,1
                    bool zero11 = false;
                    while (zero11 == false)
                    {
                        if (textBox1.Text.StartsWith("0") && !textBox1.Text.StartsWith("0,") && textBox1.Text.Length != 1)
                            textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                        else
                            zero11 = true;
                    }
                }

                if (textBox2.Text.StartsWith("0") && !textBox2.Text.StartsWith("0,") && textBox2.Text.Length != 1)
                {
                    bool zero21 = false;
                    while (zero21 == false)
                    {
                        if (textBox2.Text.StartsWith("0") && !textBox2.Text.StartsWith("0,") && textBox2.Text.Length != 1)
                            textBox2.Text = textBox2.Text.Substring(1, textBox2.Text.Length - 1);
                        else
                            zero21 = true;
                    }
                }

                if (textBox1.Text.StartsWith("-0") && !textBox1.Text.StartsWith("-0,") && textBox1.Text.Length != 2)
                {
                    // if a negative number has unnecessary zeros in the beginning I delete them
                    //example -00099 -> -99
                    bool zero12 = false;
                    while (zero12 == false)
                    {
                        if (textBox1.Text.StartsWith("-0") && !textBox1.Text.StartsWith("-0,") && textBox1.Text.Length != 2)
                        {
                            textBox1.Text = textBox1.Text.Replace("-0", "-");
                        }
                        else
                            zero12 = true;
                    }
                }

                if (textBox2.Text.StartsWith("-0") && !textBox2.Text.StartsWith("-0,") && textBox2.Text.Length != 2)
                {
                    bool zero22 = false;
                    while (zero22 == false)
                    {
                        if (textBox2.Text.StartsWith("-0") && !textBox2.Text.StartsWith("-0,") && textBox2.Text.Length != 2)
                        {
                            textBox2.Text = textBox2.Text.Replace("-0", "-");
                        }
                        else
                            zero22 = true;
                    }
                }

                // here I delete unnecessary zeros in a decimal number
                if (textBox1.Text.EndsWith("0") && textBox1.Text.ToLower().Contains(','))
                {
                    // if it contains a comma and at the end there are zero delete
                    bool zero1 = false;
                    while (zero1 == false)
                    {
                        if (textBox1.Text.EndsWith("0") && !textBox1.Text.EndsWith(",0"))
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        else if (textBox1.Text.EndsWith(",0"))
                        {
                            // if there is a comma at the end I delete it too
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 2);
                            zero1 = true;
                        }
                        else
                            zero1 = true;
                    }
                }

                if (textBox2.Text.EndsWith("0") && textBox2.Text.ToLower().Contains(','))
                {
                    bool zero2 = false;
                    while (zero2 == false)
                    {
                        if (textBox2.Text.EndsWith("0") && !textBox2.Text.EndsWith(",0"))
                            textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                        else if (textBox2.Text.EndsWith(",0"))
                        {
                            textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 2);
                            zero2 = true;
                        }
                        else
                            zero2 = true;
                    }
                }
            }
            

            if (texts == true)// if all fields are complete and I do the actions correctly
            {
                // Pressing the "=" button also changes the color of the form
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                BackColor = randomColor;
            }
            if (operation == "+")
            {
                
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                c = a + b;
                textBox3.Text = c.ToString();
            }

            else if (operation == "-")
            {
                
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                c = a - b;
                textBox3.Text = c.ToString();


            }
            else if (operation == "*")
            {
                
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                c = a * b;
                textBox3.Text = c.ToString();

            }

            else if (operation == "/")// in the division I check the 2nd field not to be 0
            {
                
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                if (b == 0)
                {
                    MessageBox.Show("You can't devide a number by zero");
                    textBox3.Text = "error";
                }
                else
                {
                    c = a / b;
                    textBox3.Text = c.ToString();
                }

            }

            else if (operation == "%")// check again not to be the 2nd field for the rest
            {
                
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                if (b == 0)
                {
                    MessageBox.Show("You can't devide a number by zero");
                    textBox3.Text = "error";
                }
                else
                {
                    c = a % b;
                    textBox3.Text = c.ToString();
                }

            }

            else if (operation == "^")
            {
                

                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);

                c = Math.Pow(a, b);
                textBox3.Text = c.ToString();

            }
            
            else if (operation == "!")
            {
                
                a = double.Parse(textBox1.Text);

                if (Int64.TryParse(textBox1.Text, out parsedInt) == true && Convert.ToInt64(textBox1.Text) >= 0)
                {
                   // check if the number in the 1st field is natural
                    x = Convert.ToInt64(textBox1.Text);
                    double f = 1;// calculate the factorial with for loop as the real number
                    // to get a wider range of results
                    for (double i = 1; i <= a; i++)
                    {
                        f *= i;
                    }
                    textBox2.Text = null;
                    textBox3.Text = f.ToString();
                    
                }
                else if (Int64.TryParse(textBox1.Text, out parsedInt) == false || Convert.ToInt64(textBox1.Text) < 0)
                {
                    textBox2.Text = null;
                    textBox3.Text = "error";
                    MessageBox.Show("Please enter only positive integer or zero for the factorial!");
                }
            }
            else if (operation == "√")
            {
                
                a = double.Parse(textBox1.Text);
                if (a >= 0)
                {
                    // check if the number in the 1st field is positive

                    c = Math.Sqrt(a);
                    textBox2.Text = null;
                    if (a != 0)
                        textBox3.Text = "±" + c.ToString();
                    else
                        textBox3.Text = c.ToString();

                }
                else
                {
                    textBox2.Text = null;
                    textBox3.Text = "error";
                    MessageBox.Show("Please enter only positive number or zero for the square root!");
                }
            }

        }



        private void textBox3_TextChanged(object sender, EventArgs e)// the textbox of the result
        {
            textBox3.TextAlign = HorizontalAlignment.Center;// text to be centered
            textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);// Bold style text
        }



        private void button2_Click(object sender, EventArgs e)// the exit form button
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)// the "clear all" button
        {
            
             textBox1.Text = null;// deletes text within the 1st text field
             textBox2.Text = null;// and in the 2nd text field
             textBox3.Text = null;// and in the 3rd field of the result
             comboBox1.SelectedItem = null;// and disables the user's choice of mathematical action
             label1.Text = null;
             BackColor = SystemColors.Control;// the color of the form is as in the beginning
             textBox1.Focus();// the cursor goes to the 1st text field
        }

        private void button4_Click(object sender, EventArgs e)// the minimize button
        {
            WindowState = FormWindowState.Minimized;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font, FontStyle.Bold);// Bold style for "=" button
            label1.Font = new Font(label1.Font, FontStyle.Bold);// Bold style for the label
            ControlBox = false;// remove the control box so that output and minimization are only possible from the buttons
            MaximizeBox = false;// zoom in and out of the mouse will not be possible by form boundaries
            MinimizeBox = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;// text to be centered
            label1.BackColor = System.Drawing.Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;// no boundaries in the form
        }

        
    }
}
