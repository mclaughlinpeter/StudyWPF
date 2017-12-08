using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudyWPFClient.ViewModels;

namespace StudyWPFClient.Cmds
{
    public class ClearNewEntryFormCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public ClearNewEntryFormCommand(MainWindowViewModel vM)
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
            viewModel.ResetTimer();
            viewModel.NewEntry.ClearEntry();
        }
    }
}
