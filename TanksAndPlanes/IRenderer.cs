using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface IRenderer
    {
        void RenderAll();
        void EnqueueForRendering(GameObject obj);
        void ClearQueue();
        void UpdateScore(int newScore);
        void GameOverScreen();
    }
}
