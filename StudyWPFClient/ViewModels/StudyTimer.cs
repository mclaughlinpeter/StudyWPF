using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyWPFClient.ViewModels
{
    public class StudyTimer : ITimer
    {
        private Timer _timer;
        private bool _timerRunning;

        public StudyTimer(TimerCallback callback, int period)
        {
            _timer = new Timer(callback, null, Timeout.Infinite, period);

            _timerRunning = false;
        }
        
        public void Start()
        {
            _timer.Change(1000, 1000);
            _timerRunning = true;
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timerRunning = false;
        }

        public void Toggle()
        {
            if (_timerRunning)
                this.Stop();
            else
                this.Start();
        }
    }
}
