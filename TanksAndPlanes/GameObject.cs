using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public abstract class GameObject : IObjectProducer, IRenderable, ICollidable
    {
        protected char[,] body;
        public Coordinates topLeft;
        public bool IsDestroyed { get; protected set; }

        public GameObject(Coordinates topLeft, char[,] body)
        {
            this.topLeft = topLeft;
            this.body = body;
            this.IsDestroyed = false;
        }

        public virtual void Update()
        {
        }

        public abstract IEnumerable<GameObject> ProduceObjects();

        public char[,] GetAppearance()
        {
            return this.body;
        }

        public virtual string GetCollisionGroup()
        {
            return "object";
        }

        public virtual double GetScore()
        {
            return 0;
        }

        public abstract bool CanCollideWith(string collisionProfile);
        public abstract void RespondToCollision(IEnumerable<string> collisionGroups);

    }
}
