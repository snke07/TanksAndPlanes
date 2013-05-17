using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProjectOOPExam
{
    public interface IUserInterface
    {
        void ProcessInput();

        event EventHandler OnLeftPressed;
        event EventHandler OnRightPressed;
        event EventHandler OnActionPressed;
    }
}
