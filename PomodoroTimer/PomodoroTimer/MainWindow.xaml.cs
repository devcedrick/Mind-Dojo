using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PomodoroTimer
{
    public partial class MainWindow : Window
    {
        Window mainWindow;
        private int sessionLength;
        private int sbLength; // short break length
        private int lbLength; // long break length
        private readonly DispatcherTimer _timer;
        private TimeSpan _time;
        private bool isBreakTime;
        private bool _isRunning;
        private int currentSession;
        private SessionState currentState;
        private readonly SoundPlayer ringtone;


        public MainWindow()
        {
            InitializeComponent();

            this.mainWindow = Application.Current.MainWindow;
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.WindowState = WindowState.Maximized;
            mainWindow.WindowStyle = WindowStyle.None;

            this.sessionLength = 25;
            this.sbLength = 5;
            this.lbLength = 25;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerTick;

            _isRunning = false;
            isBreakTime = false;
            this.currentSession = 1;
            this.currentState = SessionState.WorkSession;

            var ringtoneUri = new Uri("pack://application:,,,/PomodoroTimer;component/Resources/homepad.wav");
            ringtone = new SoundPlayer(Application.GetResourceStream(ringtoneUri).Stream);
        }

        private void SetWorkSession(object sender, MouseButtonEventArgs e)
        {
            Border session_button = sender as Border;
            string selectedBorder = session_button.Name;
            List<Border> buttons = new List<Border> { ws15_button, ws25_button, ws45_button, ws60_button };
            this.ResetBorderBackgrounds(buttons);

            switch (selectedBorder)
            {
                case "ws15_button":
                    this.sessionLength = 15;
                    ws15_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E")); ;
                    TimerTextBlock.Text = "15:00";
                    break;
                case "ws25_button":
                    this.sessionLength = 25;
                    ws25_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    TimerTextBlock.Text = "25:00";
                    break;
                case "ws45_button":
                    this.sessionLength = 45;
                    ws45_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    TimerTextBlock.Text = "45:00";
                    break;
                case "ws60_button":
                    this.sessionLength = 60;
                    ws60_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    TimerTextBlock.Text = "60:00";
                    break;
                default:
                    break;
            }
        }

        private void SetShortBreak(object sender, MouseButtonEventArgs e)
        {
            Border shortBreak = sender as Border;
            string selectedBorder = shortBreak.Name;
            List<Border> buttons = new List<Border> { sb3_button, sb5_button, sb15_button, sb25_button };
            this.ResetBorderBackgrounds(buttons);

            switch (selectedBorder)
            {
                case "sb3_button":
                    this.sbLength = 3;
                    sb3_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E")); ;
                    break;
                case "sb5_button":
                    this.sbLength = 5;
                    sb5_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                case "sb15_button":
                    this.sbLength = 15;
                    sb15_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                case "sb25_button":
                    this.sbLength = 25;
                    sb25_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                default:
                    break;
            }
        }

        private void SetLongBreak(object sender, MouseButtonEventArgs e)
        {
            Border longBreak = sender as Border;
            string selectedBorder = longBreak.Name;
            List<Border> buttons = new List<Border> { lb15_button, lb25_button, lb45_button, lb60_button };
            this.ResetBorderBackgrounds(buttons);

            switch (selectedBorder)
            {
                case "lb15_button":
                    this.lbLength = 15;
                    lb15_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E")); ;
                    break;
                case "lb25_button":
                    this.lbLength = 25;
                    lb25_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                case "lb45_button":
                    this.lbLength = 45;
                    lb45_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                case "lb60_button":
                    this.lbLength = 60;
                    lb60_button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05120E"));
                    break;
                default:
                    break;
            }

        }

        private void ResetBorderBackgrounds(List<Border> buttons)
        {
            foreach (var button in buttons)
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1b4332"));
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_time == TimeSpan.Zero)
            {
                _timer.Stop();
                _isRunning = false;
                HandleStateTransition();
            }
            else
            {
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = _time.ToString(@"mm\:ss");
            }
        }

        private async void HandleStateTransition()
        {
            timer_buttons.Visibility = Visibility.Hidden;
            ringtone.Play();
            await Task.Delay(5000);
            ringtone.Stop();

            if (currentSession > 4)
            {
                // Reset for next pomodoro cycle
                currentSession = 1;
                currentState = SessionState.WorkSession;
                timer_buttons.Visibility = Visibility.Hidden;
                disable_reset.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Reset.png"));
                isBreakTime = false;
                _time = TimeSpan.FromMinutes(this.sessionLength);
                session_text.Text = $"Session {currentSession} out of 4";
                TimerTextBlock.Text = _time.ToString(@"mm\:ss");
                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                timer_buttons.Visibility = Visibility.Hidden;
                return;
            }

            switch (currentState)
            {
                case SessionState.WorkSession:
                    if (currentSession < 4)
                    {
                        currentState = SessionState.ShortBreak;
                        timer_buttons.Visibility = Visibility.Visible;
                        disable_reset.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Disable.png"));
                        isBreakTime = true;
                        _time = TimeSpan.FromMinutes(this.sbLength);
                        _timer.Start();
                        session_text.Text = "Take a Break!";
                    }
                    else
                    {
                        currentState = SessionState.LongBreak;
                        timer_buttons.Visibility = Visibility.Visible;
                        disable_reset.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Disable.png"));
                        isBreakTime = true;
                        _time = TimeSpan.FromMinutes(this.lbLength);
                        _timer.Start();
                        session_text.Text = "Relax and Chill";
                    }
                    this.currentSession++;
                    break;
                case SessionState.ShortBreak:
                    // Start Work Session
                    currentState = SessionState.WorkSession;
                    timer_buttons.Visibility = Visibility.Visible;
                    disable_reset.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Reset.png"));
                    isBreakTime = false;
                    _time = TimeSpan.FromMinutes(this.sessionLength);
                    _timer.Start();
                    session_text.Text = $"Session {currentSession} out of 4";
                    break;
            }
        }


        private async void StartTimer(object sender, MouseButtonEventArgs e)
        {
            Border startSession = sender as Border;

            mainGrid.ColumnDefinitions[0].Width = new GridLength(0);
            timer_buttons.Visibility = Visibility.Visible;

            //Start the Set
            await StartPomodoroSequence();
        }

        private async Task StartPomodoroSequence()
        {
            _time = TimeSpan.FromMinutes(this.sessionLength);
            TimerTextBlock.Text = _time.ToString(@"mm\:ss");
            session_text.Text = $"Session {currentSession} out of 4";
            _timer.Start();
            _isRunning = true;
            await WaitForTimer();
        }

        private async Task WaitForTimer()
        {
            while (_isRunning)
            {
                await Task.Delay(1000);
            }
        }

        private void ClickPause(object sender, MouseButtonEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                _isRunning = false;
                session_text.Text = "Paused";
                pauseplay_button.Source = new BitmapImage(new Uri("Resources/Play.png", UriKind.Relative));
            }
            else
            {
                _timer.Start();
                _isRunning = true;
                session_text.Text = $"Session {currentSession} out of 4";
                pauseplay_button.Source = new BitmapImage(new Uri("Resources/Pause.png", UriKind.Relative));
            }
        }

        private async void ResetTimer(object sender, MouseButtonEventArgs e)
        {
            if (!isBreakTime)
            {
                _time = TimeSpan.FromMinutes(this.sessionLength);
                await WaitForTimer();
            }
        }

        private void StopSession(object sender, MouseButtonEventArgs e)
        {
            _timer.Stop();
            timer_buttons.Visibility = Visibility.Visible;
            mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
            currentSession = 1;
            currentState = SessionState.WorkSession;
            _time = TimeSpan.FromMinutes(this.sessionLength);
            session_text.Text = $"Session {currentSession} out of 4";
            TimerTextBlock.Text = _time.ToString(@"mm\:ss");
        }

        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    mainWindow.WindowState = WindowState.Maximized;

                    minimize_button.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Minimize.png"));
                    break;
                case WindowState.Maximized:
                    mainWindow.WindowState = WindowState.Normal;
                    var screen = System.Windows.SystemParameters.WorkArea;
                    this.Left = (screen.Width - this.Width) / 2;
                    this.Top = (screen.Height - this.Height) / 2;
                    minimize_button.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Maximize.png"));
                    break;
            }
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }


}
