using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.Threading;

namespace QuemSou
{
    public partial class GamePage : PhoneApplicationPage
    {
        private Player _player;
        private Game _game;
        private Accelerometer _accelerometer;
        private DispatcherTimer _timer;
        private bool _started;
        public GamePage()
        {
            InitializeComponent();
            
            TitlePanel.Visibility = Visibility.Collapsed;
            ContentPanel.Visibility = Visibility.Collapsed;
            
            _accelerometer = new Accelerometer();
            _accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500);
            _accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            _accelerometer.Start();

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,1,0);
            _timer.Tick += _timer_Tick;
            _started = false;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Testando");
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            // If user tilts the phone with 0.35 in X axis, Handle/Change the pivot index
            if (acceleration.X < -.60 || acceleration.X > .60)
            {

                //this.Dispatcher.BeginInvoke((Action)(() => { InstructionsPanel.Visibility = Visibility.Collapsed; }));
                //this.Dispatcher.BeginInvoke((Action)(() => { ContentPanel.Visibility = Visibility.Visible; }));
                //this.Dispatcher.BeginInvoke((Action)(() => { TitlePanel.Visibility = Visibility.Visible; }));
                if (!_started)
                {
                    this.Dispatcher.BeginInvoke((Action) (() => _timer.Start()));
                    _started = true;
                }
            }
            else if (acceleration.Z >= 0.35)
            {

               // Application Logic
                // change the pivot control index by +1
                //this.Dispatcher.BeginInvoke((Action)(() => { ball.Visibility = Visibility.Visible; }));

            }
            else if (acceleration.X < 0)
            {
                
            }
            else
            {
                //this.Dispatcher.BeginInvoke((Action)(() => { ball.Visibility = Visibility.Collapsed; }));

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string category = NavigationContext.QueryString["category"];
            _player = new Player(category);
            _game = new Game();

            UpdateCurrentWord();

            LayoutRoot.DataContext = _player;

            //todo: Work with timer to update the clock on the screen

            base.OnNavigatedTo(e);
        }

        void UpdateCurrentWord()
        {
            _player.setCurrentWord(_game.Play(_player.category));
        }
    }
}