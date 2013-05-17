using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public class KeyboardUserInterface : IUserInterface
    {

        public event EventHandler OnLeftPressed;
        public event EventHandler OnRightPressed;
        public event EventHandler OnActionPressed;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (OnLeftPressed != null)
                    {
                        OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyPressed.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (OnRightPressed != null)
                    {
                        OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyPressed.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (OnActionPressed != null)
                    {
                        OnActionPressed(this, new EventArgs());
                    }
                }
            }
        }
    }
}
