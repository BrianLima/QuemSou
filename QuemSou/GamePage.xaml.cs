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

namespace QuemSou
{
    public partial class GamePage : PhoneApplicationPage
    {
        Player player;
        Accelerometer accelerometer;

        public GamePage()
        {
            InitializeComponent();

            accelerometer = new Accelerometer();
            accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500);
            accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            accelerometer.Start();
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            // If user tilts the phone with 0.35 in X axis, Handle/Change the pivot index
            if (acceleration.Z <= -0.35)
            {
                // Application Logic
                // Change the pivot control index by -1
            }
            else if (acceleration.Z >= 0.35)
            {

                // Application Logic
                // change the pivot control index by +1
                //this.Dispatcher.BeginInvoke((Action)(() => { ball.Visibility = Visibility.Visible; }));

            }
            else
            {
                //this.Dispatcher.BeginInvoke((Action)(() => { ball.Visibility = Visibility.Collapsed; }));

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string category = NavigationContext.QueryString["category"];
            player = new Player(category);
            base.OnNavigatedTo(e);
        }
    }

}