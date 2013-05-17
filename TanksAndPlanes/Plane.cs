using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Plane : MovingObject
    {
        private Random bombRand;
        private bool HasToDropBombs;
        private int difficulty;
        private const double planeScore = 50;

        public Plane(Coordinates topLeft, int difficulty)
            : base(topLeft, new char[,] { { '<' } }, new Coordinates(0, -1) )
        {
            this.HasToDropBombs = false;
            this.difficulty = difficulty;
            this.bombRand = new Random();
        }

        public override double GetScore()
        {
            if (this.IsDestroyed) return planeScore;
            return 0;
        }

        public override bool CanCollideWith(string collisionGroup)
        {
            return collisionGroup == "missile";
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();

            if (HasToDropBombs)
            {
                HasToDropBombs = false;
                Coordinates bombCoords = new Coordinates(this.topLeft.Row + 1, this.topLeft.Colum);

                produced.Add(new Bomb(bombCoords));
            }
            return produced;
        }

        public override void Update()
        {
            int num = bombRand.Next(0, 100);
            if (num < difficulty) this.HasToDropBombs = true;
            base.Update();
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            this.IsDestroyed = true;
        }
    }
}
