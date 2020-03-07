﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;
namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        List<Order> myOrders = new List<Order>();
        public string KeyWord1 { get; set; }
        public string KeyWord2 { get; set; }
        public string KeyWord3 { get; set; }
        public string KeyWord4 { get; set; }
        public string KeyWord5 { get; set; }
        public string KeyWord6 { get; set; }
        public string KeyWord7 { get; set; }
        public string KeyWord8 { get; set; }
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i <= 3; i++)
            {
                myOrders.Add(new Order(Convert.ToString(i + 1), Order.List2[i], OrderDetails.List1[i]));
            }
            using (var db=new OrderDB())
            {
                for(int i=0;i<=3;i++)
                {
                    db.Order.Add(myOrders[i]);
                }
                db.SaveChanges();
            }
            
            bindingSource1.DataSource = myOrders;
            textBox1.DataBindings.Add("Text", this, "KeyWord1");
            textBox2.DataBindings.Add("Text", this, "KeyWord2");
            textBox3.DataBindings.Add("Text", this, "KeyWord3");
            textBox4.DataBindings.Add("Text", this, "KeyWord4");
            textBox5.DataBindings.Add("Text", this, "KeyWord5");
            textBox6.DataBindings.Add("Text", this, "KeyWord6");
            textBox7.DataBindings.Add("Text", this, "KeyWord7");
            textBox8.DataBindings.Add("Text", this, "KeyWord8");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = myOrders.Where
                (s => { return s.Name == KeyWord1 ||s.ID == KeyWord1 || s.Orders == KeyWord1;});
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<=3;i++)
            {
                if(myOrders[i].ID==KeyWord2)
                {
                    myOrders[i].Orders += KeyWord3;
                }
            }
            bindingSource1.DataSource = myGetOrder.GetAllOrders();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (myOrders[i].ID == KeyWord4)
                {
                    myOrders[i].Orders = OrderService.delete(Int32.Parse(KeyWord4) - 1, Int32.Parse(KeyWord5));
                }
            }
            bindingSource1.DataSource = myGetOrder.GetAllOrders();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (myOrders[i].ID == KeyWord6)
                {
                    myOrders[i].Orders = OrderService.Adjust(Int32.Parse(KeyWord6) - 1, Int32.Parse(KeyWord7), Int32.Parse(KeyWord7));
                }
            }
            bindingSource1.DataSource = myGetOrder.GetAllOrders();
        }
    }
}