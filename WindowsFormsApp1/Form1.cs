using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
      
            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {


            }

            private void button1_Click(object sender, EventArgs e)
            {
                TbPassHash.Text = Encriptador.Encriptar(Tbpass.Text);
            }

            private void button2_Click(object sender, EventArgs e)
            {
                bool ValidarLogin;
                ValidarLogin = Encriptador.Validar(TbPassV.Text, TbPassHashV.Text);
                if (ValidarLogin == true)
                {
                    TbPassV.BackColor = Color.Green;
                    TbPassHashV.BackColor = Color.Green;
                }
                else
                {
                    TbPassV.BackColor = Color.Red;
                    TbPassHashV.BackColor = Color.Red;
                }

            }

        private void TbPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
