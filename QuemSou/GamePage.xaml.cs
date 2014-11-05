using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.Windows.Media;

namespace QuemSou
{
    public partial class GamePage : PhoneApplicationPage
    {
        int test;
        Accelerometer accelerometer;
        SolidColorBrush brush2 = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 255, 0));
        SolidColorBrush brush1 = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 0, 0)); 

        public GamePage()
        {
            InitializeComponent();

            accelerometer = new Accelerometer();
            accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500);
            accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            accelerometer.Start();

            tbxtest.DataContext = test;
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            // If user tilts the phone with 0.35 in X axis, Handle/Change the pivot index
            if (acceleration.Z <= -0.35)
            {
                // Application Logic
                // Change the pivot control index by -1
                test++;
                this.Dispatcher.BeginInvoke((Action)(() => { tbxtest.Text = test.ToString(); }));
            }
            if (acceleration.Z >= 0.35)
            {

                // Application Logic
                // change the pivot control index by +1
                test--;
                this.Dispatcher.BeginInvoke((Action)(() => { ContentPanel.Background = brush2; }));
            }
        }
    }
}