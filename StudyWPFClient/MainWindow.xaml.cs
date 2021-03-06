﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyWPFClient.ViewModels;
using System.Windows.Media.Animation;

namespace StudyWPFClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
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

        private void timerExpander_Expanded(object sender, RoutedEventArgs e)
        {
            durationComboBox.IsEnabled = false;
            durationComboBox.Opacity = 0.5;
            lblDuration.Opacity = 0.5;

            lblManual.Opacity = 0.5;
            timerExpanderHeader.Opacity = 1.0;
        }

        private void timerExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            durationComboBox.IsEnabled = true;
            durationComboBox.Opacity = 1.0;
            lblDuration.Opacity = 1.0;

            lblManual.Opacity = 1.0;
            timerExpanderHeader.Opacity = 0.5;
        }

        private void newSubjectExpander_Expanded(object sender, RoutedEventArgs e)
        {
            newSubjectExpanderHeader.Opacity = 1.0;
        }

        private void newSubjectExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            newSubjectExpanderHeader.Opacity = 0.5;
        }
    }
}
