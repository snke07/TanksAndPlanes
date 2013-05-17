using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Coordinates
    {
        public int Row { get; set; }
        public int Colum { get; set; }
        public readonly static int worldRows = 10, worldColums = 40;

        public Coordinates(int row, int colum)
        {
            this.Row = row;
            this.Colum = colum;
        }

        public override bool Equals(object obj)
        {
            Coordinates coords = obj as Coordinates;
            return coords.Row == this.Row && coords.Colum == this.Colum;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsInRange()
        {
            return this.Row < worldRows && this.Colum < worldColums && this.Row >= 0 && this.Colum >= 0;
        }

        public static bool operator ==(Coordinates first, Coordinates second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Coordinates first, Coordinates second)
        {
            return !first.Equals(second);
        }
    }
}
