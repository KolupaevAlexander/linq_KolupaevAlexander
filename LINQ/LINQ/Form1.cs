using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Задание 1
        private void button1_Click(object sender, EventArgs e)
        {
            string employees = "employees.txt";
            if (File.Exists(employees))
            { 
                var info = File.ReadAllText(employees).Split('\n').Where(x=> Convert.ToInt16(x.Split(' ').ToArray()[3])<40);
                foreach (var person in info)  { label2.Text += person + "\n"; }
            }
        }

        //Задание 2
        List<Department> department = new List<Department>()
            {
                new Department ( "Отдел закупок", "Германия" ),
                new Department ("Отдел продаж", "Испания" ),
                new Department ("Отдел маркетинга", "Испания" )
            };

        List<Employ> employes = new List<Employ>()
            {
                new Employ ("Иванов", "Отдел закупок"),
                new Employ ("Петров", "Отдел закупок"),
                new Employ ("Сидоров", "Отдел продаж"),
                new Employ ("Лямин", "Отдел продаж"),
                new Employ ("Сидоренко", "Отдел маркетинга"),
                new Employ ("Кривоносов", "Отдел продаж")
            };        
        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            var result = employes.Join(department,
                                       employe=>employe.Department,
                                       depart=>depart.Name, 
                                       (employe, depart) => new {Name = employe.Name, Department = depart.Name , Country = depart.Reg});

            foreach (var thing in result)
                label4.Text += thing.Name + " " + thing.Department + " " + thing.Country + "\n";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            var result = employes.Join(department, 
                                       employe => employe.Department, 
                                       depart => depart.Name, 
                                       (employe, depart) => new { Name = employe.Name, Department = depart.Name, Country = depart.Reg })
                                 .Where(x => x.Country[0]=='И');
            foreach (var thing in result)
                label4.Text += thing.Name + " " + thing.Department + " " + thing.Country + "\n";
        }

        //Телефонная книга
        Dictionary<string, string> telephones = new Dictionary<string, string>();
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && !telephones.ContainsKey(textBox2.Text))
            { 
                telephones.Add(textBox2.Text, textBox1.Text);
                listBox1.Items.Add(textBox1.Text+" "+textBox2.Text);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            telephones.Remove(listBox1.SelectedItem.ToString().Split(' ')[1]);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (telephones.ContainsKey(textBox4.Text))
                label8.Text = telephones[textBox4.Text];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            var keys = telephones.Where(x=>x.Value==textBox4.Text);
            foreach (var item in keys)
                label8.Text += item.Key + "\n";
        }

    }
}
