﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudyWPFClient.ViewModels;

namespace StudyWPFClient.Cmds
{
    public class ResetTimerCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public ResetTimerCommand(MainWindowViewModel vM)
        {
            viewModel = vM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.DurationTimer.Stop();
            viewModel.NewEntry.ResetDuration();
        }
    }
}
