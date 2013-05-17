using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface ICollidable
    {
        string GetCollisionGroup();
        bool CanCollideWith(string collisionProfile);
        void RespondToCollision(IEnumerable<string> collisionGroups); 
    }
}
