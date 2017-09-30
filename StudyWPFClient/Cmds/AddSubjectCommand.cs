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
        private readonly IList<string> _uniqueSubjects;

        public AddSubjectCommand(IList<string> uniqueSubjects)
        {
            _uniqueSubjects = uniqueSubjects;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (((NewEntry)parameter)?.Error != string.Empty || ((NewEntry)parameter)?.NewSubject == string.Empty)
            {
                return false;
            }
            else
                return true;
        }

        public void Execute(object parameter)
        {
            _uniqueSubjects.Add(((NewEntry)parameter)?.NewSubject);
        }
    }
}
