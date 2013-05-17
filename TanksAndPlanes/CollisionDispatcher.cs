using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class CollisionDispatcher : ICollisionDispatcher
    {
        public CollisionDispatcher()
        {
        }

        public void HandleCollisions(IEnumerable<GameObject> objects)
        {
            foreach (var obj1 in objects)
            {
                List<string> collided = new List<string>();

                foreach (var obj2 in objects)
                {
                    if (obj1.topLeft == obj2.topLeft && obj1.CanCollideWith(obj2.GetCollisionGroup())) collided.Add(obj2.GetCollisionGroup());
                }

                if( collided.Count > 0 ) obj1.RespondToCollision(collided);
            }
        }
    }
}
