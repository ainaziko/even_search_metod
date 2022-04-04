using parserDecimal.Parser;
using System;
using System.Windows.Forms;
using System.IO; 
using Microsoft.Office.Interop.Excel; 
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Even_Search_Method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string func = ""; //функция


        private void button1_Click(object sender, EventArgs e)
        {
            Computer computer = new Computer();
            
            decimal x0, x1 = 0, tol, H = 0, YF0, YF1 = 0, F1,F2;
            int max, k = 0, cond = 0;

            func = comboBox1.Text;
            func = func.ToLower();
            Stopwatch swatch = new Stopwatch();
            swatch.Start(); //начало подсчета времени
            try
            {
                x0 = decimal.Parse(textBox1.Text);
                YF0 = computer.Compute(func, x0);
                tol = Convert.ToDecimal(Convert.ToDouble(textBox2.Text));
                max = int.Parse(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте входные данные.", 
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (max <= 0)
            {
                MessageBox.Show("Значение итерации должно быть больше единицы!",
                 "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tol <= 0)
            {
                MessageBox.Show("Погрешность должно быть больше нуля",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
             
                if (radioButton1.Checked)
                {
                    H = tol;
                    YF0 = aziretParser.ParserDecimal.Compute(func, x0);
                    
                    while (k < max)
                    {
                        k = k + 1;
                        progressBar1.Visible = true;
                        progressBar1.Maximum = k + 1;
                        progressBar1.Value = k;
                        x1 = x0 + H;
                        YF1 = aziretParser.ParserDecimal.Compute(func, x1);

                        if (YF1 >= YF0)
                        {
                            if (k == 1)
                            {
                                cond = 1;
                            }
                            x1 = x0;
                            YF1 = YF0;
                            break;
                        }
                        else
                        {
                            x0 = x1;
                            YF0 = YF1;
                            x1 = x0 + H;
                            YF1 = aziretParser.ParserDecimal.Compute(func, x1);
                        }
                    }
                    swatch.Stop();
                    progressBar1.Value = k;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    textBox8.Text = (swatch.Elapsed).ToString();
                    textBox4.Text = x1.ToString();
                    textBox5.Text = YF1.ToString("0E0");
                    textBox6.Text = k.ToString();
                    textBox7.Text = H.ToString("0E0");

                    F1 = computer.Compute(func, x1 - tol);
                    textBox10.Text = F1.ToString("0E0");
                    F2 = computer.Compute(func, x1 + tol);
                    textBox11.Text = F2.ToString("0E0");

                    if (YF1 <= F1 && YF1 <= F2)
                    {
                        label12.ForeColor = System.Drawing.Color.Green;
                        label12.Visible = true;
                        label12.Text =  "\r\n" +
                            "\r\n" +
                            "The result x* is the minimizer of \r\nthis function because \r\n" +
                            "F(x*) <= F(x*–Tolerance) \r\n" +
                            "And \r\n" +
                            "F(x*) <= F(x*+Tolerance) \r\n";
                    }
                    else 
                    {
                        label12.ForeColor = System.Drawing.Color.DarkRed;
                        label12.Visible = true;
                        label12.Text = "\r\n" +
                            "\r\n" +
                            "The result x* is not the minimizer of\r\nthis function because \r\n" +
                            "F(x*) <= F(x*–Tolerance) \r\n" +
                            "And \r\n" +
                            "F(x*) >= F(x*+Tolerance) \r\n"; 
                    }
                 
                    if (cond == 1)
                    {
                        label12.ForeColor = System.Drawing.Color.DarkRed;
                        DialogResult result = MessageBox.Show("Метод не выполнил ни одну итерацию, \r\n" +
                            "поскольку начальное значение уже является \r\n" +
                            "оптимальной или находится справо от оптимальной. \r\n" +
                            "\r\n" +
                            "Хотите проверить график функции?", "Внимание", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result ==DialogResult.Yes)
                        {
                            button3_Click(sender, e);
                        }
                    }
                    else if (k == max)
                    {
                        DialogResult result = MessageBox.Show("Решение не может быть найдено с данной погрешностью \r\n" +
                            "из-за лимита количества итераций. \r\n" +
                            "\r\n" + 
                            "Хотите добавит допольнительную итерацию?", "Внимание",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            max = max + max;
                            textBox3.Text = max.ToString();
                            button1_Click(sender, e);
                        }
                    }
                }

                else if (radioButton2.Checked) 
                {
                    H = tol;
                    YF0 = computer.Compute(func, x0);

                    while (k < max)
                    {
                        k = k + 1;
                        progressBar1.Visible = true;
                        progressBar1.Maximum = k + 1;
                        progressBar1.Value = k;
                        x1 = x0 + H;
                        YF1 = computer.Compute(func, x1);

                        if (YF1 <= YF0)
                        {
                            if (k == 1)
                            {
                                cond = 1;
                            }
                            x1 = x0;
                            YF1 = YF0;   
                            break;
                        }
                        else
                        {
                            x0 = x1;
                            YF0 = YF1;
                            x1 = x0 + H;
                            YF1 = computer.Compute(func, x1);
                        }
                    }
                    swatch.Stop();
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    textBox8.Text = (swatch.Elapsed).ToString();
                    textBox4.Text = x1.ToString();
                    textBox5.Text = YF1.ToString("0E0");
                    textBox6.Text = k.ToString();
                    textBox7.Text = H.ToString("0E0");
                    
                    
                    F1 = computer.Compute(func, x1 - tol);
                    textBox10.Text = F1.ToString("0E0");
                    F2 = computer.Compute(func, x1 + tol);
                    textBox11.Text = F2.ToString("0E0");
                    
                    if (YF1 >= F1 && YF1 >= F2)
                    {
                        label12.ForeColor = System.Drawing.Color.Green;
                        label12.Visible = true;
                        label12.Text = "\r\n" +
                            "\r\n" +
                           "The result x* is the maximizer of \r\nthis function because \r\n" +
                           "F(x*) >= F(x*–Tolerance) \r\n" +
                           "And \r\n" +
                           "F(x*) >= F(x*+Tolerance) \r\n";
                    }
                    else 
                    {
                        label12.ForeColor = System.Drawing.Color.DarkRed;
                        label12.Visible = true;
                        label12.Text = "\r\n" +
                            "\r\n" +
                        "The result x* is not the maximizer of \r\nthis function because \r\n" +
                        "F(x*) >= F(x*–Tolerance) \r\n" +
                        "And \r\n" +
                        "F(x*) <= F(x*+Tolerance) \r\n";
                    }

                    if (cond == 1)
                    {
                        DialogResult result = MessageBox.Show("Метод не выполнил ни одну итерацию, \r\n" +
                           "поскольку начальное значение уже является \r\n" +
                           "оптимальной или находится справо от оптимальной. \r\n" +
                           "\r\n" +
                           "Хотите проверить график функции?", "Внимание",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            button3_Click(sender, e);
                        }
                    }
                    else if (k == max)
                    {
                        DialogResult result = MessageBox.Show("Решение не может быть найдено с данной погрешностью \r\n" +
                           "из-за лимита количества итераций. \r\n" +
                           "\r\n" +
                           "Хотите добавит допольнительную итерацию?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            max = max + max;
                            textBox3.Text = max.ToString();
                            button1_Click(sender, e);
                        }
                    }
                }
            }
           
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            label12.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mySheet = Path.Combine(System.Windows.Forms.Application.StartupPath, "Grafic.xlsx");
        
            decimal b, c;

            Excel.Application ExcelApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ExcelApp.Workbooks.Open(mySheet);
            Worksheet ws = (Worksheet)wb.ActiveSheet;

            ExcelApp.Visible = true;
            
            func = comboBox1.Text;
            ws.Cells[2, 2] = func;
            func = func.Replace("exp", "!");
            func = func.Replace("x", "D4"); 
            func = "=" + func.Replace("!", "exp");
            ws.Cells[4, 9] = textBox1.Text; 
            b = decimal.Parse(textBox1.Text);
            c = Math.Abs(b) + 3;
            ws.Cells[4, 10] = c;
            ws.Range["E4", "E10003"].Value = func;

        }
        private void button4_Click(object sender, EventArgs e)
        {

            string mySheet = Path.Combine(System.Windows.Forms.Application.StartupPath, "Grafic.xlsx");
            Excel.Application ExcelApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ExcelApp.Workbooks.Open(mySheet);

            Worksheet sh = (Worksheet)wb.ActiveSheet;

            Microsoft.Office.Interop.Excel.Range cell = sh.Cells[4, 9] as Excel.Range;
            string value = cell.Value2.ToString();
            textBox1.Text = value;

            Microsoft.Office.Interop.Excel.Range cell2 = sh.Cells[4, 10] as Excel.Range;
            string value2 = cell2.Value2.ToString();


            decimal a = decimal.Parse(value);
            decimal b = decimal.Parse(value2);

            decimal c = decimal.Parse(textBox3.Text);

            decimal result = (a + b) / c;
            textBox2.Text = result.ToString();
          
            wb.Close();

            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            label12.Visible = false;
        }

        
    }
}
