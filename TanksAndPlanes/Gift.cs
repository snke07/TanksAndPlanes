using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Gift : MovingObject
    {
        private const double giftScore = 200;

        public Gift(Coordinates topLeft)
            : base(topLeft, new char[,] { { '+' } }, new Coordinates(1, 0))
        {
        }

        public override bool CanCollideWith(string collisionGroup)
        {
            return collisionGroup == "tank";
        }

        public override string GetCollisionGroup()
        {
            return "gift";
        }

        public override double GetScore()
        {
            if (this.IsDestroyed) return giftScore;
            return 0;
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            foreach (var collisionGroup in collisionGroups)
            {
                if (collisionGroup == "tank") this.IsDestroyed = true;
            }
        }
    }
}
