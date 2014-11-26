using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Device.Location;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace QuemSou
{
    public partial class GamePage : PhoneApplicationPage, IDisposable
    {
        private Player _player;
        private Game _game;
        private readonly DispatcherTimer _interfaceTimer;
        private bool _started, _playing;
        private int _seconds;
        private GeoCoordinateWatcher gcw = null;

        public GamePage()
        {
            InitializeComponent();
            
            TitlePanel.Visibility = Visibility.Collapsed;

            //Initiating the GeoCordinater and assigning it's handlers
            this.gcw = new GeoCoordinateWatcher();
            this.gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
            this.gcw.Start();


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
                var time = TimeSpan.FromSeconds((_seconds));
                string minutes = time.Minutes.ToString();
                string seconds = time.Seconds.ToString();

                if (seconds.Length == 1)
                {
                    seconds = "0" + seconds;
                }

                this.Dispatcher.BeginInvoke((Action)(() => ClockBlock.Text = minutes + ":" + seconds));
                _seconds--;
            }
            
            if (_seconds < 0 && ! _playing)
            {
                this.Dispatcher.BeginInvoke((Action)(() => { InstructionsPanel.Visibility = Visibility.Collapsed; }));
                this.Dispatcher.BeginInvoke((Action)(() => { TitlePanel.Visibility = Visibility.Visible; }));
                _seconds = 299;
                _playing = true;
            }
            else if (_seconds < 0 && _playing)
            {
                MessageBox.Show("Fim de jogo");
                _interfaceTimer.Stop();
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            // If user tilts the phone with 0.35 in X axis, start the timer and show the word to players.
            if (acceleration.X < -.60 || acceleration.X > .60)
            {
                if (_started) return;
                this.Dispatcher.BeginInvoke((Action) (() => _interfaceTimer.Start()));
                _started = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_player == null)
            {
                string category = NavigationContext.QueryString["category"];
                _player = new Player(category);
                _game = new Game();

                UpdateCurrentWord();

                LayoutRoot.DataContext = _player;

                base.OnNavigatedTo(e);
            }
        }

        void UpdateCurrentWord()
        {
            _player.setCurrentWord(_game.Play(_player.category));
        }

        private void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            // Stop the GeoCoordinateWatcher now that we have the device location.
            this.gcw.Stop();

            AdControl.Latitude = e.Position.Location.Latitude;
            AdControl.Longitude = e.Position.Location.Longitude;

            Debug.WriteLine("Device lat/long: " + e.Position.Location.Latitude + ", " + e.Position.Location.Longitude);
        }

        private void adControl1_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            Debug.WriteLine("AdControl error: " + e.Error.Message);
        }


        private void AdControl_AdRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine("AdControl new ad received");
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.gcw != null)
                {
                    this.gcw.Dispose();
                    this.gcw = null;
                }

                if (this._interfaceTimer.IsEnabled)
                {
                    this._interfaceTimer.Stop();
                }
            }
        }

        #endregion
    }
}