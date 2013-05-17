using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class GiftPlane : Plane
    {
        private bool dropGift;
        private const double giftPlaneScore = 100;

        public GiftPlane(Coordinates topLeft, int difficulty)
            : base(topLeft, difficulty)
        {
            this.dropGift = false;
            this.body = new char[,] { { '«' } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>(base.ProduceObjects());

            if (dropGift) produced.Add(new Gift(this.topLeft));

            return produced;
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            this.dropGift = true;
            base.RespondToCollision(collisionGroups);
        }

        public override double GetScore()
        {
            if (this.IsDestroyed) return giftPlaneScore;
            return 0;
        }
    }
}
