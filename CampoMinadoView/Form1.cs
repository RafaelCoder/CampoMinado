using System;
using System.Windows.Forms;


namespace CampoMinadoView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var btn = new Button();
            btn.Name = "btn_1_1";
            btn.Text = "Botão";
            btn.Click += (s, ea) => 
            {
                MessageBox.Show($"Aaaa {btn.Name}");
            };
            painel.Controls.Add(btn);

            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("lul");
        }
    }
}
