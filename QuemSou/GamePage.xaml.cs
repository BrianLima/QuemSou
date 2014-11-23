using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        private readonly DispatcherTimer _interfaceTimer;
        private bool _started, _playing;
        private int _seconds;

        public GamePage()
        {
            InitializeComponent();
            
            TitlePanel.Visibility = Visibility.Collapsed;
            ContentPanel.Visibility = Visibility.Collapsed;
            
            var accelerometer = new Accelerometer {TimeBetweenUpdates = TimeSpan.FromMilliseconds(1000)};
            accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            accelerometer.Start();

            _playing = _started = false;

            //Using this to update the UI each second
            _interfaceTimer = new DispatcherTimer {Interval = new TimeSpan(0,0,1)};
            _interfaceTimer.Tick += _interfaceTimer_Tick;
            _seconds = 5;
        }

        void _interfaceTimer_Tick(object sender, EventArgs e)
        {
            if (!_playing)
            {
                this.Dispatcher.BeginInvoke((Action) (() => CountdownBlock.Text = _seconds.ToString()));
                _seconds--;
            }
            else if (_playing)
            {
                var text = TimeSpan.FromSeconds((_seconds));
                this.Dispatcher.BeginInvoke((Action)(() => ClockBlock.Text = text.Minutes + ":" + text.Seconds));
                _seconds--;
            }
            
            if (_seconds == 0 && ! _playing)
            {
                this.Dispatcher.BeginInvoke((Action)(() => { InstructionsPanel.Visibility = Visibility.Collapsed; }));
                this.Dispatcher.BeginInvoke((Action)(() => { ContentPanel.Visibility = Visibility.Visible; }));
                this.Dispatcher.BeginInvoke((Action)(() => { TitlePanel.Visibility = Visibility.Visible; }));
                _seconds = 300;
                _playing = true;
            }
            else if (_seconds == 0 && _playing)
            {
                MessageBox.Show("Fim de jogo");
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            // If user tilts the phone with 0.35 in X axis, Handle/Change the pivot index
            if (acceleration.X < -.60 || acceleration.X > .60)
            {
                if (_started) return;
                this.Dispatcher.BeginInvoke((Action) (() => _interfaceTimer.Start()));
                _started = true;
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