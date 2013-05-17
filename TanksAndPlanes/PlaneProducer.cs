using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class PlaneProducer : IEnemyFactory
    {
        Random planeRand = new Random();
        private int firstRowChance, secondRowChance, thirdRowChance;
        private int difficulty;
        private const int giftPlaneChance = 1;
        protected Coordinates worldEnd;
        private double scoreMultiplier;

        public double ScoreMultiplier
        {
            get
            {
                return this.scoreMultiplier;
            }
            private set
            {
                this.scoreMultiplier = value;
            }
        }

        public PlaneProducer(Coordinates worldEnd, int difficulty)
        {
            this.ScoreMultiplier = 1;
            this.worldEnd = worldEnd;
            this.difficulty = difficulty;
            CalculateChances();
        }

        private void CalculateChances()
        {
            firstRowChance = difficulty;
            secondRowChance = difficulty / 4;
            thirdRowChance = difficulty / 8;
        }

        public void NextLevel()
        {
            this.difficulty++;
            this.ScoreMultiplier += 0.25;
            CalculateChances();
        }

        public IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();

            int firstRowRandom = planeRand.Next(0, 100);
            int secondRowRandom = planeRand.Next(0, 100);
            int thirdRowRandom = planeRand.Next(0, 100);
            int giftPlaneRandom;

            Coordinates firstRow = new Coordinates(0, worldEnd.Colum - 1);
            Coordinates secondRow = new Coordinates(1, worldEnd.Colum - 1);
            Coordinates thirdRow = new Coordinates(2, worldEnd.Colum - 1);

            if (firstRowRandom <= firstRowChance)
            {
                giftPlaneRandom = planeRand.Next(0, 100);

                if (giftPlaneRandom < giftPlaneChance) produced.Add(new GiftPlane(firstRow, 1));
                else produced.Add(new Plane(firstRow, 1));
            }
            if (secondRowRandom <= secondRowChance)
            {
                giftPlaneRandom = planeRand.Next(0, 100);

                if (giftPlaneRandom < giftPlaneChance) produced.Add(new GiftPlane(secondRow, 1));
                else produced.Add(new Plane(secondRow, 1));
            }

            if (thirdRowRandom <= thirdRowChance)
            {
                giftPlaneRandom = planeRand.Next(0, 100);

                if (giftPlaneRandom < giftPlaneChance) produced.Add(new GiftPlane(thirdRow, 1));
                else produced.Add(new Plane(thirdRow, 1));
            }
            
            return produced;
        }
    }
}
