using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudyWPFClient.ViewModels;

namespace StudyWPFClient.Cmds
{
    public class SubmitNewEntryCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public SubmitNewEntryCommand(MainWindowViewModel vM)
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
            if (viewModel.newEntry.Error != string.Empty)
            {
                return false;
            }
            else
                return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
