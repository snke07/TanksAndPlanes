using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface IEnemyFactory : IObjectProducer
    {
        double ScoreMultiplier { get; }
        IEnumerable<GameObject> ProduceObjects();
        void NextLevel();
    }
}
