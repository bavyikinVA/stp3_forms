using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3_18_bavykin_va
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton1 = (RadioButton)sender;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton2 = (RadioButton)sender;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Task1();
            }
            if (radioButton2.Checked)
            {
                Task2();
            }
        }

        public void Task1()
        {
            Reader1();
            string[] s = Reader1().Split(';');
            string s1 = s[0];
            string s2 = s[1];
            words(s1);
            for (int i = 0; i < words(s1).Length - 1; i++)
            {
                textBox2.Text += (words(s1)[i] + " ");
            }
            words(s2);
            for (int i = 0; i < words(s2).Length - 1; i++)
            {
                textBox5.Text += (words(s2)[i] + " ");
            }
            check(words(s1),words(s2),SMaxLength(s1,s2));
            label6.Text = Convert.ToString(check(words(s1), words(s2), SMaxLength(s1, s2)));
        }

        public void Task2()
        {
            Reader2_1();
            Reader2_2();
            words(Reader2_1());
            words(Reader2_2());
            check(words(Reader2_1()), words(Reader2_2()) , SMaxLength(Reader2_1(),Reader2_2()));
            label6.Text = Convert.ToString(check(words(Reader2_1()), words(Reader2_2()), SMaxLength(Reader2_1(), Reader2_2())));
        }


        public string Reader1()
        {
            bool flag = true;
            StreamReader file = null;
            do
            {
                try
                {
                    string fname = textBox1.Text;
                    file = new StreamReader(fname);
                    flag = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Данный файл не найден!");
                    Environment.Exit(0); // выход из программы
                    flag = false;
                }
            } while (!flag);
            
            string text = "";
            while (true)
            {
                string s0 = file.ReadLine();
                if (s0 == null) break;
                text += s0;
                text += ";";
            }
            return text;
        }
        

        public int SMaxLength(string s1, string s2)
        {
            int result = Math.Max(s1.Length, s2.Length);
            return result;
        }
        public string[] words(string s1)
        {
            string[] words = s1.Split(' ');
            return words;
        }

        public double check(string[] words1, string[] words2, int result)
        {
            int k = 0;
            int allW = 0;
            for (int i = 0; i < result; i++)
            {
                allW++;
                if (words1[i] == words2[i])
                {
                    k++;
                }
            }
            return (allW / k) * 100; //кол-во всех слов делим на кол-во совпадающих слов 
        }


        public string Reader2_1()
        {
            Console.Write("Enter s1");
            string s1 = textBox3.Text;
            return s1;
        }
        public string Reader2_2() 
        { 
            Console.Write("Enter s2");
            string s2 = textBox4.Text;
            return s2;
        }

        
    }
}
