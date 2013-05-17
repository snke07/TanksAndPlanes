using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace GameProjectOOPExam
{
    public class Engine
    {
        private Tank theTank;
        private List<GameObject> allObjects;
        private IUserInterface userInterface;
        private ICollisionDispatcher collisionDispatcher;
        private IRenderer renderer;
        private IEnemyFactory enemy;
        private int sleepTime;
        private int score, lastLevelScore;
        private const int scoreForNewLevel = 1000;

        public Engine(IUserInterface userInterface, ICollisionDispatcher collisionDispatcher, IRenderer renderer, Tank theTank, IEnemyFactory enemy, int sleepTimeInMs)
        {
            this.userInterface = userInterface;
            this.collisionDispatcher = collisionDispatcher;
            this.renderer = renderer;
            this.theTank = theTank;
            this.sleepTime = sleepTimeInMs;
            this.enemy = enemy;
            this.score = 0;
            this.lastLevelScore = 0;

            allObjects = new List<GameObject>();
            allObjects.Add(theTank);
        }

        public void MoveTankLeft()
        {
            if (theTank.topLeft.Colum > 0) this.theTank.topLeft.Colum--;
        }

        public void MoveTankRight()
        {
            Coordinates newTankCoords = new Coordinates(theTank.topLeft.Row, theTank.topLeft.Colum + 1);
            if( newTankCoords.IsInRange() ) this.theTank.topLeft.Colum++;
        }

        public void Shoot()
        {
            this.theTank.HasToShoot = true;
        }

        public void AddObject(GameObject obj)
        {
            if (obj is Tank)
            {
                Tank newTank = obj as Tank;
                theTank.Destroy();
                theTank = newTank;
            }

            allObjects.Add(obj);
        }

        private void UpdatePlayerObjectsAction()
        {
            theTank.Update();
            EnqueueAll();
        }

        private void UpdateAllActon()
        {
            foreach (var obj in allObjects)
            {
                obj.Update();
            }

            collisionDispatcher.HandleCollisions(allObjects);

            List<GameObject> producedObjects = new List<GameObject>();

            foreach (var obj in allObjects)
            {
                producedObjects.AddRange(obj.ProduceObjects());
            }

            foreach (var obj in allObjects)
            {
                score += (int)(obj.GetScore() * enemy.ScoreMultiplier);
            }
            renderer.UpdateScore(score);

            allObjects.AddRange(producedObjects);
            allObjects.AddRange(enemy.ProduceObjects());

            allObjects.RemoveAll(obj => { return obj.IsDestroyed; });
            allObjects.RemoveAll(obj => { return !obj.topLeft.IsInRange(); });

            EnqueueAll();
        }

        private void EnqueueAll()
        {
            foreach (var obj in allObjects)
            {
                renderer.EnqueueForRendering(obj);
            }
        }

        private void Initialize()
        {
            foreach (var obj in allObjects)
            {
                renderer.EnqueueForRendering(obj);
            }

            userInterface.OnActionPressed += (sender, eventInfo) =>
            {
                Shoot();
            };
            userInterface.OnLeftPressed += (sender, eventInfo) =>
            {
                MoveTankLeft();
            };
            userInterface.OnRightPressed += (sender, eventInfo) =>
            {
                MoveTankRight();
            };
        }

        public void Run()
        {
            Initialize();

            DateTime timer = DateTime.Now;
            timer = timer.AddMilliseconds(sleepTime);
            bool updateAll = false;

            while (!theTank.IsDestroyed) 
            {
                userInterface.ProcessInput();

                renderer.RenderAll();
                renderer.ClearQueue();

                if (timer < DateTime.Now)
                {
                    updateAll = true;
                    timer = timer.AddMilliseconds(sleepTime);
                }

                if (updateAll)
                {
                    UpdateAllActon();
                    updateAll = false;

                    if (score - lastLevelScore > scoreForNewLevel)
                    {
                        enemy.NextLevel();
                        lastLevelScore = score;
                    }
                }
                else UpdatePlayerObjectsAction();
            }

            renderer.GameOverScreen();
        }
    }
}
