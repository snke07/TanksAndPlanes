using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Bomb : MovingObject
    {
        public Bomb(Coordinates topLeft)
            : base(topLeft, new char[,] { { '@' } }, new Coordinates(1, 0))
        {
        }

        public override bool CanCollideWith(string collisionGroup)
        {
            return collisionGroup == "tank";
        }

        public override string GetCollisionGroup()
        {
            return "bomb";
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            this.IsDestroyed = true;
        }
    }
}
