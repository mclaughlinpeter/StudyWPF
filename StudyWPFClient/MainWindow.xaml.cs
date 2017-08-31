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
using StudyDAL.Repos;

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

            _entries = new List<Entry>(new EntryRepo().GetAll());
            /*{
                new Entry { EntryID = 1, Subject = "C#", Duration = new TimeSpan(2, 30, 0), DateTimeStamp = DateTime.Now.AddHours(1) },
                new Entry { EntryID = 2, Subject = "JS", Duration = new TimeSpan(0, 45, 0), DateTimeStamp = DateTime.Now.AddMinutes(30) },
                new Entry { EntryID = 3, Subject = "C++", Duration = new TimeSpan(1, 15, 0), DateTimeStamp = DateTime.Now.AddDays(2) },
                new Entry { EntryID = 4, Subject = "Linux", Duration = new TimeSpan(0, 30, 0), DateTimeStamp = DateTime.Now.AddMonths(1) },
                new Entry { EntryID = 5, Subject = "C++", Duration = new TimeSpan(1, 30, 0), DateTimeStamp = DateTime.Now.AddDays(3) },
                new Entry { EntryID = 6, Subject = "Linux", Duration = new TimeSpan(0, 45, 0), DateTimeStamp = DateTime.Now.AddMonths(2) }
            };*/
            studySubjects.ItemsSource = new HashSet<string>(from e in _entries select e.Subject);

            //durationHours.ItemsSource = new List<int> { 1, 2, 3, 4 };
            //durationMinutes.ItemsSource = new List<int> { 0, 15, 30, 45 };
        }

        private void btnSubmitEntry_Click(object sender, RoutedEventArgs e)
        {
            Entry newEntry = new Entry();

            newEntry.Subject = this.studySubjects.SelectedItem?.ToString() ?? "No subject";

            int hours = 0;
            try
            {
                hours = Convert.ToInt32((this.durationHours.SelectedItem as ComboBoxItem)?.Content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            int minutes = 0;
            try
            {
                minutes = Convert.ToInt32((this.durationMinutes.SelectedItem as ComboBoxItem)?.Content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            newEntry.Duration = new TimeSpan(hours, minutes, 0);

            try
            {
                newEntry.DateTimeStamp = (DateTime)studyDate.SelectedDate;
            }
            catch (Exception ex)
            {
                newEntry.DateTimeStamp = DateTime.Now;
            }
            
            MessageBox.Show(newEntry.ToString(), "New Entry");

            using (var repo = new EntryRepo())
            {
                repo.Add(newEntry);
            }
        }
    }
}
