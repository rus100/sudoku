using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     
        int i1;
              int[,] mass = new int[9, 9];
              int[,] sudoku = new int[2, 60];
              int[,] otvet = new int[9, 9];
              int[,] dobav= new int[9,9] ;
            Graphics gr;
        private void button1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++) { 
                     dobav[i,j] = 0;
                    } 
                }
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    if (i < 3) {
                        if ((i % 3) * 3 + j + 1 <= 9)
                        {
                            mass[i, j] = (i % 3) * 3 + j + 1;
                        }
                        else {
                            mass[i, j] = (i % 3) * 3 + j + 1;
                            mass[i, j] = mass[i, j]-9;
                        }
                    }
                    if ((i < 6) && (i >= 3)) {
                        if ((i % 3) * 3 + j + 2 <= 9)
                        {
                            mass[i, j] = (i % 3) * 3 + j + 2;
                        }
                        else
                        {
                            mass[i, j] = (i % 3) * 3 + j + 2;
                            mass[i, j] =  mass[i, j]-9;
                        }
                    }
                    if ((i < 9) && (i >= 6))
                    {
                        if ((i % 3) * 3 + j + 3 <= 9)
                        {
                            mass[i, j] = (i % 3) * 3 + j + 3;
                        }
                        else
                        {
                            mass[i, j] = (i % 3) * 3 + j + 3;
                            mass[i, j] =  mass[i, j]-9;
                        } } }  }  
            gr = this.CreateGraphics();
            gr.Clear(Color.AliceBlue);
            for (int i = 0; i < 10; i++) {
                    gr.DrawLine(Pens.Black, 20 + 30 * (i), 20, 20 + 30 * (i), 290);
                    gr.DrawLine(Pens.Black, 20,20 + 30 * (i),  290, 20 + 30 * (i));
                    if (i % 3 == 0) {
                        Pen p=new Pen(Brushes.Black,5);
                        gr.DrawLine(p, 20 + 30 * (i), 20, 20 + 30 * (i), 290);
                        gr.DrawLine(p, 20, 20 + 30 * (i), 290, 20 + 30 * (i));
                    }
            }
            Random rnd = new Random();
            int d1 = rnd.Next(1, 100);
            for (int i=0;i<d1;i++){
                stolb();
                stroka();
                blockgoriz();
                blockvertik();
                transpon();
            } 
                Random r = new Random();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        otvet[i, j] = 0;
                    }
                }
           for (int i = 0; i < 60; i++) {
                i1 = r.Next(0, 80);
               sudoku[1, i] = (i1 / 9);
               sudoku[0, i] = (i1 % 9);
                float x = (i1%9) * 30 + 30;
                float y = (i1/9) * 30 + 30;
                gr.DrawString(mass[(i1/9), (i1%9)].ToString(), Font, Brushes.Black,x,y );
                otvet[i1 / 9, i1 % 9] = mass[i1 / 9, i1 % 9];
            }
        }
        void transpon()
        {
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    int d = mass[i, j];
                    mass[i, j] = mass[j, i];
                    mass[j, i] = d;
                    } } }
        void stroka() {
            Random r=new Random();
            int b1= r.Next(0,2);
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 9; j++) {
                    int d = mass[(i ) * 3+b1, j];
                    mass[(i) * 3 + b1, j] = mass[(i) * 3, j];
                    mass[(i) * 3, j] = d; } }}
        void stolb()
        {
            Random r = new Random();
            int b2 = r.Next(0, 2);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int d = mass[i,( j ) * 3 + b2];
                    mass[ i,(j ) * 3 + b2] = mass[ i,(j ) * 3];
                    mass[i,(j) * 3] = d;
                }
            }
        }
        void blockgoriz() {
              Random r=new Random();
            int b3= r.Next(0,2);
         for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                  int d = mass[(i) +b3*3, j];
                    mass[(i) + b3* 3, j] = mass[(i), j];
                    mass[(i), j] = d; 
                }
            }
        }
        void blockvertik(){
         Random r=new Random();
            int b4= r.Next(0,2);
        for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                  int d = mass[ i,(j) +b4*3];
                    mass[i,(j) + b4 * 3 ] = mass[i,(j)];
                    mass[i,(j)] = d; 
                }
            }
        }
        string cifr = " ";
        TextBox t;
        Button bt;
        Form f;
        int x0;
        int y0;
        int kolvo;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
            bool popal = false;
            if ((x0 >= 20) && (x0 <= 290) && (y0 >= 20) && (y0 <= 290))
            {  
                for (int i = 0; i < 60; i++)
                {
                    if (!(((y0 - 20) / 30 == sudoku[1, i]) && ((x0 - 20) / 30 == sudoku[0, i])))
                    {
                        popal = true;
                    }
                    else { popal =false;
                    break;
                    }
                }
            }
            if (popal == true) {
                f = new Form();
                f.Size = new System.Drawing.Size(200, 200);
                t = new TextBox();
                t.Size = new System.Drawing.Size(50, 20);
                t.Location = new System.Drawing.Point(20, 20);
                bt = new Button();
                bt.Size = new System.Drawing.Size(70, 20);
                bt.Location = new System.Drawing.Point(100, 100);
                bt.Click += new EventHandler(bClick);
                bt.Text = "Ввести";
                f.Controls.Add(t);
                f.Controls.Add(bt);
                f.Visible = true; }
         
        }
       private void bClick(object sender, EventArgs e)
        {   
        int[] cifri=new int[9];
        gr.Clear(Color.AliceBlue);
        for (int i = 0; i < 10; i++)
        {
            gr.DrawLine(Pens.Black, 20 + 30 * i, 20, 20 + 30 * i, 290);
            gr.DrawLine(Pens.Black, 20, 20 + 30 * i, 290, 20 + 30 * i);
            if (i % 3 == 0)
            {
                Pen p = new Pen(Brushes.Black, 5);
                gr.DrawLine(p, 20 + 30 * (i), 20, 20 + 30 * (i), 290);
                gr.DrawLine(p, 20, 20 + 30 * (i), 290, 20 + 30 * (i));
            }
                   }
        for (int i = 0; i < 9; i++)
        {
            cifri[i] = i + 1;
        }
        float x = ((x0 - 20) / 30) * 30 + 30;
        float y = ((y0 - 20) / 30) * 30 + 30;
        cifr = t.Text;
        for (int i = 0; i < 9; i++)
        {
            if (cifr == cifri[i].ToString())
            {
                otvet[(y0 - 20) / 30, (x0 - 20) / 30] = Convert.ToInt32(cifr);
                  dobav.SetValue(Convert.ToInt32(cifr),(y0-20)/30,(x0-20)/30);
                gr.DrawString(cifr, Font, Brushes.Red, x, y);
                f.Hide();
            }                          
        }
        for (int i = 0; i < 60; i++)
        {
            float y1 =sudoku[1,i] * 30 + 30;
            float x1 = sudoku[0, i] * 30 + 30;
            gr.DrawString(otvet[sudoku[1, i], sudoku[0, i]].ToString(), Font, Brushes.Black, x1, y1);
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++) {
                float y1=0;
                float x1=0;
                if (dobav[i, j] > 0) { 
                 y1 = i * 30 + 30;
             x1 = j* 30 + 30; 
                    gr.DrawString(dobav[i,j].ToString(), Font, Brushes.Red, x1, y1);
                }
            }
        }
        kolvo = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (otvet[i, j] == mass[i, j])
                {
                    kolvo++;
                }
            }
        }
        f.Dispose();
        if (kolvo == 81)
        {
            MessageBox.Show("Вы выиграли");
        }
        }
        }
        }     
            
        
        
        
                
            
            
            
           
           
    
