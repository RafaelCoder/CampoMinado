using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoLibrary.Model
{
    public class Match
    {
        private int bombsQuantity = 20;
        public List<Field> Fields = new List<Field>();
        public bool BombFounded { get; set; }

        public Match()
        {
            BombFounded = false;
            CreateFields();
            InstallBombs();
            CalculateBombsAround();
        }
        private bool IsBomb(int X, int Y)
        {
            var field = GetField(X, Y);
            if (field == null)
                return false;
            return field.Bomb;
        }
        private Field GetField(int X, int Y)
        {
            X = X<=0 ? 0 : X;
            Y = Y<=0 ? 0 : Y;
            return Fields.Where(f => f.CoordX == X & f.CoordY == Y).FirstOrDefault();
        }
        private void CreateFields()
        {
            Fields.Clear();
            for (int x = 1; x <= 10; x++)
                for (int y = 1; y <= 10; y++)
                    Fields.Add(new Field(x, y));
        }
        private void InstallBombs() { 
            Random rnd = new Random();            

            while(Fields.Where(i => i.Bomb).ToList().Count < bombsQuantity)
            {
                int r = rnd.Next(Fields.Count);
                Fields[r].Bomb = true;
            }
        }
        private void CalculateBombsAround()
        {
            foreach (var field in Fields)
            {
                if (field.Bomb)
                {
                    field.BombsAround = -1;
                    continue;
                }

                if (IsBomb(field.CoordX - 1, field.CoordY - 1))
                    field.BombsAround++;
                if (IsBomb(field.CoordX - 1, field.CoordY - 0))
                    field.BombsAround++;
                if (IsBomb(field.CoordX - 1, field.CoordY + 1))
                    field.BombsAround++;
                if (IsBomb(field.CoordX - 0, field.CoordY - 1))
                    field.BombsAround++;
                if (IsBomb(field.CoordX - 0, field.CoordY + 1))
                    field.BombsAround++;
                if (IsBomb(field.CoordX + 1, field.CoordY - 1))
                    field.BombsAround++;
                if (IsBomb(field.CoordX + 1, field.CoordY - 0))
                    field.BombsAround++;
                if (IsBomb(field.CoordX + 1, field.CoordY + 1))
                    field.BombsAround++;
            }
        }
        public void ShowFields()
        {
            foreach (var field in Fields)
                Console.Write(field.ToString + (field.CoordY >= 10 ? "\n" : ""));
        }
        public bool Reveal(int X, int Y)
        {
            var field = GetField(X, Y);
            if (field == null)
                return false;

            if (field.Revealed)
                return false;

            field.Revealed = true;

            if (field.BombsAround == 0)
            {
                if (!IsBomb(field.CoordX - 1, field.CoordY - 1))
                    Reveal(field.CoordX - 1, field.CoordY - 1);

                if (!IsBomb(field.CoordX - 1, field.CoordY - 0))
                    Reveal(field.CoordX - 1, field.CoordY - 0);

                if (!IsBomb(field.CoordX - 1, field.CoordY + 1))
                    Reveal(field.CoordX - 1, field.CoordY + 1);

                if (!IsBomb(field.CoordX - 0, field.CoordY - 1))
                    Reveal(field.CoordX - 0, field.CoordY - 1);

                if (!IsBomb(field.CoordX - 0, field.CoordY + 1))
                    Reveal(field.CoordX - 0, field.CoordY + 1);

                if (!IsBomb(field.CoordX + 1, field.CoordY - 1))
                    Reveal(field.CoordX + 1, field.CoordY - 1);

                if (!IsBomb(field.CoordX + 1, field.CoordY - 0))
                    Reveal(field.CoordX + 1, field.CoordY - 0);

                if (!IsBomb(field.CoordX + 1, field.CoordY + 1))
                    Reveal(field.CoordX + 1, field.CoordY + 1);
            }
            if (field.Bomb)
                BombFounded = true;
            return field.Bomb;
        }

        public bool Winner()
        {
            int total = Fields.Count();

            int nonBombs = Fields.Count(f => !f.Bomb);

            int revealed = Fields.Count(f => f.Revealed & !f.Bomb);

            return nonBombs == revealed;
        }
    }
}
