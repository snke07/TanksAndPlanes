using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class ConsoleRenderer : IRenderer
    {
        private char[][] worldMatrix;
        private int worldRows, worldColums;
        private int score;

        public ConsoleRenderer(int worldRows, int wolrdColums)
        {

            this.worldRows = worldRows;
            this.worldColums = wolrdColums;
            this.worldMatrix = new char[this.worldRows][];
            this.score = 0;

            for (int i = 0; i < this.worldRows; ++i)
            {
                this.worldMatrix[i] = new char[this.worldColums];
            }

            for (int i = 0; i < this.worldRows ; ++i)
            {
                for (int j = 0; j < this.worldColums; ++j)
                {
                    this.worldMatrix[i][j] = ' ';
                }
            }

            Console.BufferWidth = Console.WindowWidth = wolrdColums + 10;
            Console.BufferHeight = Console.WindowHeight = worldRows + 10;

            Console.Clear();
        }

        public void GameOverScreen()
        {
            Console.Clear();

            Console.WriteLine("Game over!");
            Console.WriteLine("Your score is {0}", score);
        }

        public void UpdateScore(int newScore)
        {
            this.score = newScore;
        }

        public void ClearQueue()
        {
            for (int i = 0; i < worldRows; ++i)
            {
                for (int j = 0; j < worldColums; ++j)
                {
                    this.worldMatrix[i][j] = ' ';
                }
            }
        }

        public void EnqueueForRendering(GameObject obj)
        {
            char [,] objBody = obj.GetAppearance();

            worldMatrix[obj.topLeft.Row][obj.topLeft.Colum] = objBody[0, 0];
        }

        public void PrintBorder()
        {
            for (int i = 0; i < worldColums + 2; ++i)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);
            PrintBorder();

            for (int i = 0; i < worldRows; ++i)
            {
                Console.Write("|");

                for (int j = 0; j < worldColums; ++j)
                {
                    Console.Write(worldMatrix[i][j]);
                }

                Console.WriteLine("|");
            }

            PrintBorder();
            Console.WriteLine("Score: {0}", score);
        }
    }
}
