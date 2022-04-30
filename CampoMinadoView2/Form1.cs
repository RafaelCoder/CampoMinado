using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CampoMinadoLibrary.Model;

namespace CampoMinadoView2
{
    public partial class Form1 : Form
    {
        private Match match;
        public Form1()
        {
            InitializeComponent();
        }

        private void painel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            match = new Match();
            CriarBotoes();
        }

        private void CriarBotoes()
        {
            if(match == null)
                return;
            painel.Controls.Clear();
            foreach (var fld in match.Fields)
            {
                var btn = new Button();
                btn.Name = $"btn_{fld.CoordX}_{fld.CoordY}";
                btn.Text = $"{fld.ToString}";
                btn.BackColor = Color.SpringGreen;
                btn.Click += (s, evt) =>
                {
                    if (!match.Winner() & !match.BombFounded)
                    {
                        match.Reveal(fld.CoordX, fld.CoordY);
                        AtualizarBotoes();
                    }

                    if (match.BombFounded)
                        MessageBox.Show("Você MAMOU!");

                    if (match.Winner())
                        MessageBox.Show("PARABÃINS");
                };

                btn.Width = 50;
                btn.Height = 50;
                painel.Controls.Add(btn);
            }
        }

        private void AtualizarBotoes()
        {
            foreach (var fld in match.Fields)
            {
                foreach(Button b in painel.Controls.OfType<Button>())
                {
                    if (b.Name == $"btn_{fld.CoordX}_{fld.CoordY}")
                    {
                        b.Text = fld.ToString;
                        SetColor(b, fld);
                        break;
                    }
                }
            }
        }

        private void SetColor(Button b, Field fld)
        {
            if (!fld.Revealed)
                return;

            if (fld.Bomb)
                b.BackColor = Color.Brown;
            if (fld.BombsAround == 0)
                b.BackColor = Color.White;

            if (fld.BombsAround > 0)
                b.BackColor = Color.CadetBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
