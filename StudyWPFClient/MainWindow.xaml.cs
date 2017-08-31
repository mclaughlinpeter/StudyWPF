using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyDAL.Models;

namespace StudyWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<Entry> _entries;
        public MainWindow()
        {
            InitializeComponent();
            _entries = new List<Entry>
            {
                new Entry { EntryID = 1, Subject = "C#", Duration = new TimeSpan(2, 30, 0), DateTimeStamp = DateTime.Now.AddHours(1) },
                new Entry { EntryID = 2, Subject = "JS", Duration = new TimeSpan(0, 45, 0), DateTimeStamp = DateTime.Now.AddMinutes(30) },
                new Entry { EntryID = 3, Subject = "C++", Duration = new TimeSpan(1, 15, 0), DateTimeStamp = DateTime.Now.AddDays(2) },
                new Entry { EntryID = 4, Subject = "Linux", Duration = new TimeSpan(0, 30, 0), DateTimeStamp = DateTime.Now.AddMonths(1) }
            };
            studySubjects.ItemsSource = _entries;
        }
    }
}
