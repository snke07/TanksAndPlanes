﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface ICollisionDispatcher
    {
        void HandleCollisions(IEnumerable<GameObject> objects);
    }
}
