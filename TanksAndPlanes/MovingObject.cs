using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public abstract class MovingObject : GameObject
    {
        private Coordinates speed;

        public MovingObject(Coordinates topLeft, char[,] body, Coordinates speed)
            : base(topLeft, body)
        {
            this.speed = speed;
        }

        public void UpdatePosition()
        {
            this.topLeft.Row = this.topLeft.Row + this.speed.Row;
            this.topLeft.Colum = this.topLeft.Colum + this.speed.Colum;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public override void Update()
        {
            UpdatePosition();
        }

        public abstract override bool CanCollideWith(string collisionGroup);
        public abstract override void RespondToCollision(IEnumerable<string> collisionGroups);
    }
}
