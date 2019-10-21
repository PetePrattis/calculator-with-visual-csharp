using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

//Εργασία του μαθητή Παναγιώτη Πράττη Π15120
namespace WindowsFormsApplication
{


public partial class Form1 : Form
    {
        
        //εισάγω random μεταβλητή από την μέθοδο random για να το 
        //χρησιμοποιήσω αργότερα για να καλέσω τυχαία χρώματα
        private Random rnd = new Random();

        double a;//ο αριθμός του 1ου textbox
        double b;//ο αριθμός του 2ου textbox
        double c;//ο αριθμός του 3ου textbox ->το αποτέλεσμα


        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)//το 1ο πεδίο κειμένου
        {
            //κάθε φορά που ο χρήστης πατάει τελεία "." θα μετατρέπεται σε κόμμα "," 
            //ώστε να γίνονται οι πράξεις σωστά διότι: 1.2 = 12 (δεν διαβάζεται η τελεία)

            textBox1.Text= textBox1.Text.Replace(".", ",");
            textBox1.Focus();//για να είναι ο κέρσορας πάντα στο τέλος
            textBox1.SelectionStart = textBox1.Text.Length;

            double parsedValue;
            //έλεγχος αν γίνεται μετατροπή του κειμένου στο textbox σε αριθμό ώστε να γίνονται οι πράξεις
            if (Double.TryParse(textBox1.Text, out parsedValue) == false && textBox1.Text.Length != 0)
            {
                //συγκεκριμένα το πεδίο να μην δέχεται γράμματα και σύμβολα πέρα απο "." και ","
                //για να λειτουργεί σωστά επιτρέπω και το σύμβολο "-" για αρνητικούς αριθμούς 
                if (textBox1.Text != "-" && textBox1.Text.Length != 0)//το "-" επιτρέπεται μόνο στην αρχή
                {
                    MessageBox.Show("Please enter only numbers!");
                    if (textBox1.Text.Length != 0)//και ο λάθος χαρακτήρας αφαιρείται
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        textBox1.Focus();
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//η λίστα με τις μαθηματικές πράξεις
        {
            
            string operation = (string)comboBox1.SelectedItem;

             if (operation == "+")//εδώ εμφαωίζω στην ετικέτα την πράξη που διάλεξε ο χρήστης
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
            
            if (operation == "!" || operation == "√")//αν επιλεγεί η πράξη παραγοντικό ή τετραγωνική ρίζα κλειδώνω το 2ο πεδίο κειμένου
            {
                textBox2.Enabled = false;
            }
            else
                textBox2.Enabled = true;


        }

        //η ετικέτα θα δείχνει το σύμβολο της επιλεγμένης πράξης
        //και με το πάτημα της ο χρήστης θα λαμβάνει πληροφορίες για την πράξη
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

        private void textBox2_TextChanged(object sender, EventArgs e)//το 2ο πεδίο κειμένου
        {
            //τα ίδια χαρακτηριστικά με το 1ο πεδίο κειμένου
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
            
            long x;//θα το χρησιμοποιήσω για το παραγοντικό
            long parsedInt;
            bool text1 = false;//θα το χρησιμοποιήσω για να δω αν υπαρχει αριθμός στο 1ο πεδίο 
            bool text2 = false;//στο 2ο πεδίο
            bool op = false;//αν έχει επιλεγεί μαθηματική πράξη
            bool texts;//αν όλα ειναι εντάξει ώστε να γίνει ο υπολογισμός θα είναι true
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
                //αν όλα είναι εντάξει με τα πεδία που πρέπει να συμπληρώσει ο χρήστης
                //θα ξεκινήσει η διαδικασία διόρθωσης του input του χρήστη

                if (textBox1.Text.EndsWith(","))//αν τελειώνει ο αριθμός με "," το διαγράφω
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                if (textBox2.Text.EndsWith(","))
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);

                if (double.Parse(textBox1.Text) == 0)//αν ο αριθμός είναι μηδέν αλλά ο χρήστης το έχει δώσει αλλιώς
                    //π.χ. 00,0 -> 0 για να φαίνται καλύτερα στο χρήστη
                    textBox1.Text = "0";
                if(operation != "!" && operation != "√")
                    if (double.Parse(textBox2.Text) == 0)
                        textBox2.Text = "0";


                //αν ο αριθμός που έδωσε ο χρήστης έχει περιττά μηδενικά θα τα αφαιρέσω
                if (textBox1.Text.StartsWith("0") && !textBox1.Text.StartsWith("0,") && textBox1.Text.Length != 1)
                {
                    //αν ο αριθμός ξεκινάει με μηδενικά τα διαγράφω
                    //π.χ. 000002,1 -> 2,1
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
                    //αν ένας αρνητικός αριθμός έχει περιττά μηδενικά στην αρχή τα διαγράφω
                    //π.χ. -00099 -> -99
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

                //εδώ διαγράφω τα περιττά μηδενικά σε έναν δεκαδικό αριθμό
                if (textBox1.Text.EndsWith("0") && textBox1.Text.ToLower().Contains(','))
                {
                    //αν περιέχει κόμμα και στο τέλος υπάρχουν μηδενικά τα διαγράφω
                    bool zero1 = false;
                    while (zero1 == false)
                    {
                        if (textBox1.Text.EndsWith("0") && !textBox1.Text.EndsWith(",0"))
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        else if (textBox1.Text.EndsWith(",0"))
                        {
                            //αν υπάρχει και ένα κόμμα στο τέλος το διαγράφω επίσης
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
            

            if (texts == true)//αν όλα τα πεδία είναι συμπληρωμένα και σωστά κάνω τις πράξεις
            {
                //με το πάτημα του κουμπιού "=" αλλάζει κα ιτο χρώμα της φόρμας
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

            else if (operation == "/")//στην διαίρεση ελέγχω κιόλας να μην είναι το 2ο πεδίο 0
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

            else if (operation == "%")//ξανά έλεγχος να μην είναι 0 το 2ο πεδίο για το υπόλοιπο
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
                   //έλεγχος αν ο αριθμός στο 1ο πεδίο είναι φυσικός
                    x = Convert.ToInt64(textBox1.Text);
                    double f = 1;//υπολογισμός του παραγοντικού με for loop ως πραγματικός αριθμός
                    //για να έχω μεγαλύτερο εύρος αποτελεσμάτων
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
                    //έλεγχος αν ο αριθμός στο 1ο πεδίο είναι θετικός 

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



        private void textBox3_TextChanged(object sender, EventArgs e)//το πεδίο textbox του αποτελέσματος
        {
            textBox3.TextAlign = HorizontalAlignment.Center;//το κείμενο να έιναι στο κέντρο
            textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);//το κείμενο να έχει Bold style
        }



        private void button2_Click(object sender, EventArgs e)//το κουμπί εξόδου από την φόρμα
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)//το κουμπί "clear all"
        {
            
             textBox1.Text = null;//διαγράφει οτι κείμενο υπάρχει μέσα στο 1ο πεδίο κειμένου
             textBox2.Text = null;//και στο 2ο πεδίο κειμένου
             textBox3.Text = null;//και στο 3ο πεδίο του αποτελέσματος
             comboBox1.SelectedItem = null;//και αναιρεί την επιλογή της μαθηματικής πράξης του χρήστη
             label1.Text = null;
             BackColor = SystemColors.Control;//το χρώμα της φόρμας γίνεται όπως στην αρχή
             textBox1.Focus();//ο κέρσορας πηγαίνει στο 1ο πεδίο κειμένου
        }

        private void button4_Click(object sender, EventArgs e)//το κουμπί ελαχιστοποίηση
        {
            WindowState = FormWindowState.Minimized;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font, FontStyle.Bold);//Bold style για το κουμπί "="
            label1.Font = new Font(label1.Font, FontStyle.Bold);//Bold style για το label
            ControlBox = false;//αφαίρεση του control box ώστε η έξοδος και η ελαχιστοποίηση να είναι μόνο εφικτά απο τα κουμπιά
            MaximizeBox = false;//η μεγένθυνση και η σμίκρυνση να μην είναι δυνατές μέσω του ποντικιού από τα όρια της φόρμας
            MinimizeBox = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;//το κείμενο να έιναι στο κέντρο
            label1.BackColor = System.Drawing.Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;//δεν υπάρχουν όρια στην φόρμα
        }

        
    }
}
