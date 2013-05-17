using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class Tank : GameObject
    {
        public bool HasToShoot { get; set; }
        private int shootingLevel;

        public Tank(Coordinates topLeft)
            : base(topLeft, new char[,] { { '^' } })
        {
            shootingLevel = 1;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();

            if (this.HasToShoot)
            {
                Coordinates missileCoordinates1 = new Coordinates(this.topLeft.Row - 1, this.topLeft.Colum);
                Coordinates missileCoordinates2 = new Coordinates(this.topLeft.Row - 1, this.topLeft.Colum + 1);
                Coordinates missileCoordinates3 = new Coordinates(this.topLeft.Row - 1, this.topLeft.Colum - 1);

                if( this.shootingLevel == 1 ) produced.Add(new Missile(missileCoordinates1));
                if (this.shootingLevel == 2)
                {
                    produced.Add(new Missile(missileCoordinates2));
                    produced.Add(new Missile(missileCoordinates3));
                }
                if (this.shootingLevel > 2)
                {
                    produced.Add(new Missile(missileCoordinates1));
                    produced.Add(new Missile(missileCoordinates2));
                    produced.Add(new Missile(missileCoordinates3));
                }
            }

            this.HasToShoot = false;
            return produced;
        }

        public override string GetCollisionGroup()
        {
            return "tank";
        }

        public override bool CanCollideWith(string collisionProfile)
        {
            return collisionProfile == "bomb" || collisionProfile == "gift";
        }

        public override void RespondToCollision(IEnumerable<string> collisionGroups)
        {
            foreach (var collisionGroup in collisionGroups)
            {
                if (collisionGroup == "bomb") this.IsDestroyed = true;
                if (collisionGroup == "gift") this.shootingLevel++;
            }
        }
        public void Destroy()
        {
            this.IsDestroyed = true;
        }
    }
}
