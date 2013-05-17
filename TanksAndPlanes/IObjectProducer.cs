using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface IObjectProducer
    {
        IEnumerable<GameObject> ProduceObjects();
    }
}
