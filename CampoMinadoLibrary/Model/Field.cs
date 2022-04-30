using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoLibrary.Model
{
    public class Field
    {
        public int CoordX { get; set; } = 0;
        public int CoordY { get; set; } = 0;
        public bool Bomb { get; set; } = false;
        public int BombsAround { get; set; } = 0;
        public bool Revealed { get; set; } = false;
        public Field(int CoordX, int CoordY)
        {
            this.CoordX = CoordX;
            this.CoordY = CoordY;
        }

        public string ToString => !Revealed ? " ~ " : (Bomb ? " * " : $" {(BombsAround == 0 ? "" : BombsAround)} ");
    }
}
