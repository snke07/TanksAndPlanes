using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectOOPExam
{
    class TanksAndPlanesMain
    {
        static void Main()
        {
            int worldRows = Coordinates.worldRows;
            int worldColums = Coordinates.worldColums;
            Coordinates endOfWorld = new Coordinates(worldRows, worldColums);

            IUserInterface userInterface = new KeyboardUserInterface();
            ICollisionDispatcher collisionDispatcher = new CollisionDispatcher();
            IRenderer renderer = new ConsoleRenderer(worldRows, worldColums);
            Tank theTank = new Tank(new Coordinates(worldRows - 1, worldColums / 2));
            IEnemyFactory enemy = new PlaneProducer(endOfWorld, 8);

            Engine gameEngine  = new Engine(userInterface, collisionDispatcher, renderer, theTank, enemy, 100);

            gameEngine.Run();
        }
    }
}
