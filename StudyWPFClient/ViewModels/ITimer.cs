using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFClient.ViewModels
{
    public interface ITimer
    {
        void Toggle();

        void Start();

        void Stop();
    }
}
