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
using System.Windows.Media.Animation;

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

            try
            {
                using (var repo = new EntryRepo())
                {
                    _entries = new List<Entry>(repo.GetAll());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to data source", "Study Application");
                Environment.Exit(1);
            }            

            /*{
                new Entry { EntryID = 1, Subject = "C#", Duration = new TimeSpan(2, 30, 0), DateTimeStamp = DateTime.Now.AddHours(1) },
                new Entry { EntryID = 2, Subject = "JS", Duration = new TimeSpan(0, 45, 0), DateTimeStamp = DateTime.Now.AddMinutes(30) },
                new Entry { EntryID = 3, Subject = "C++", Duration = new TimeSpan(1, 15, 0), DateTimeStamp = DateTime.Now.AddDays(2) },
                new Entry { EntryID = 4, Subject = "Linux", Duration = new TimeSpan(0, 30, 0), DateTimeStamp = DateTime.Now.AddMonths(1) },
                new Entry { EntryID = 5, Subject = "C++", Duration = new TimeSpan(1, 30, 0), DateTimeStamp = DateTime.Now.AddDays(3) },
                new Entry { EntryID = 6, Subject = "Linux", Duration = new TimeSpan(0, 45, 0), DateTimeStamp = DateTime.Now.AddMonths(2) }
            };*/
            studySubjects.ItemsSource = new HashSet<string>(from e in _entries select e.Subject);
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
            catch (Exception)
            {
                newEntry.DateTimeStamp = DateTime.Now;
            }

            try
            {
                using (var repo = new EntryRepo())
                {
                    repo.Add(newEntry);
                }
            }
            catch (Exception)
            {
                MessageAnimation("Error writing to database");
                return;
            }            

            MessageAnimation("Db write successful");
        }

        private void MessageAnimation(string msg)
        {
            lblMessage.Content = msg;

            DoubleAnimation opacityAnim = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                BeginTime = TimeSpan.FromSeconds(0.3),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            DoubleAnimation heightAnim = new DoubleAnimation { From = 0.0, To = 25.0, Duration = new Duration(TimeSpan.FromSeconds(0.3)) };

            var storyboard = new Storyboard()
            {
                Duration = TimeSpan.FromSeconds(1.5),
                AutoReverse = true,
            };
            storyboard.Completed += (o, s) => { lblMessage.Content = ""; };

            Storyboard.SetTarget(opacityAnim, lblMessage);
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath(Label.OpacityProperty));

            Storyboard.SetTarget(heightAnim, lblMessage);
            Storyboard.SetTargetProperty(heightAnim, new PropertyPath(Label.HeightProperty));

            storyboard.Children.Add(opacityAnim);
            storyboard.Children.Add(heightAnim);

            lblMessage.BeginStoryboard(storyboard);
        }
    }
}
