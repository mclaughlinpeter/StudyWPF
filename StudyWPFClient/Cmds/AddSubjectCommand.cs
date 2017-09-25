using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            if (((bool)parameter) == true)
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
