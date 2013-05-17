using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Missile : MovingObject
    {
        public Missile(Coordinates topLeft)
            : base(topLeft, new char[,] { { '|' } }, new Coordinates(-1, 0))
        {
        }

        public override string GetCollisionGroup()
        {
            return "missile";
        }

        public override bool CanCollideWith(string collisionGroup)
        {
            return collisionGroup == "plane";
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            this.IsDestroyed = true;
        }
    }
}
