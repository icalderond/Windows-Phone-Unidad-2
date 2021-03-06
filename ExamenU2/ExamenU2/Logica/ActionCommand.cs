﻿using System;
using System.Windows.Input;

namespace ExamenU2.Logica
{
    public class ActionCommand:ICommand
    {
        Action action;
        public ActionCommand(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
        }
    }
}
