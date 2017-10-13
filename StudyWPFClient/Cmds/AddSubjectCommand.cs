using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudyWPFClient.ViewModels;

namespace StudyWPFClient.Cmds
{
    public class AddSubjectCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public AddSubjectCommand(MainWindowViewModel vM)
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
            if (((NewEntry)parameter)?.NewSubjectError == true)
            {
                return false;
            }
            else
                return true;
        }

        public void Execute(object parameter)
        {
            viewModel.uniqueSubjects.Add(((NewEntry)parameter)?.NewSubject);
            viewModel.newEntry.NewSubject = string.Empty;
        }
    }
}
