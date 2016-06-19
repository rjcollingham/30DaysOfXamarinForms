using System;
using System.Timers;
using Xamarin.Forms;

namespace Project_01_SimpleStopWatch
{
	public class StopWatchView : ContentPage
	{
		Button btnReset;
		Button btnPlay;
		Button btnPause;
		Label lblTime;
		Timer timer;

		double Counter = 0.0;

		public StopWatchView()
		{
			timer = new Timer(100);
			timer.Elapsed += Time_Trigger;

			btnReset = new Button();
			btnReset.Text = "Reset";
			btnReset.TextColor = Color.White;
			btnReset.BackgroundColor = Color.Transparent;
			btnReset.FontFamily = Device.OnPlatform(
					iOS: "AvenirNext-Regular",
					Android: "",
					WinPhone: ""
			);
			btnReset.FontSize = 14;
			btnReset.TextColor = Color.White;
			btnReset.IsEnabled = false;
			btnReset.HorizontalOptions = LayoutOptions.End;
			btnReset.VerticalOptions = LayoutOptions.Start;
			btnReset.Margin = new Thickness(0, 20, 20, 0);
			btnReset.Clicked += Reset_Clicked;

			lblTime = new Label();
			lblTime.LineBreakMode = LineBreakMode.TailTruncation;
			lblTime.FontFamily = Device.OnPlatform(
					iOS: "AvenirNext-UltraLight",
					Android: "",
					WinPhone: ""
			);
			lblTime.FontSize = 100;
			lblTime.TextColor = Color.White;
			lblTime.HorizontalTextAlignment = TextAlignment.Center;
			lblTime.VerticalTextAlignment = TextAlignment.Center;
			UpdateDisplay();

			btnPause = new Button();
			btnPause.BackgroundColor = Color.FromRgba(0.46F, 0.77F, 0.01F, 1);
			btnPause.TextColor = Color.White;
			btnPause.FontFamily = Device.OnPlatform(
					iOS: "FontAwesome",
					Android: "fontawesome.ttf",
					WinPhone: ""
			);
			btnPause.IsEnabled = false;
			btnPause.Text = "\uf04c";
			btnPause.FontSize = 30;
			btnPause.BorderRadius = 0;
			btnPause.Clicked += Pause_Clicked;

			btnPlay = new Button();
			btnPlay.BackgroundColor = Color.FromRgba(0.4F, 0.47F, 1, 1);
			btnPlay.TextColor = Color.White;
			btnPlay.FontFamily = Device.OnPlatform(
					iOS: "FontAwesome",
					Android: "fontawesome.ttf",
					WinPhone: ""
			);
			btnPlay.Text = "\uf04b";
			btnPlay.FontSize = 30;
			btnPlay.BorderRadius = 0;
			btnPlay.Clicked += Play_Clicked;

			Grid grid = new Grid();
			grid.Padding = 0;
			grid.RowSpacing = 0;
			grid.ColumnSpacing = 0;
			grid.BackgroundColor = Color.Black;
			grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

			grid.Children.Add(lblTime, 0, 2, 0, 1);
			grid.Children.Add(btnReset, 0, 2, 0, 1);
			grid.Children.Add(btnPlay, 0, 1);
			grid.Children.Add(btnPause, 1, 1);
			Content = grid;
		}

		void Pause_Clicked(object sender, EventArgs e)
		{
			btnReset.IsEnabled = true;
			btnPlay.IsEnabled = true;
			btnPause.IsEnabled = false;
			timer.Stop();
		}

		void Play_Clicked(object sender, EventArgs e)
		{
			btnPlay.IsEnabled = false;
			btnPause.IsEnabled = true;
			btnReset.IsEnabled = false;
			timer.Start();
		}

		void Reset_Clicked(object sender, EventArgs e)
		{
			btnReset.IsEnabled = false;
			btnPlay.IsEnabled = true;
			btnPause.IsEnabled = false;
			Counter = 0.0;
			UpdateDisplay();
		}

		void Time_Trigger(object sender, ElapsedEventArgs e)
		{
			UpdateTimer();
		}

		private void UpdateDisplay()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				lblTime.Text = Counter.ToString("F1");
			});
		}

		private void UpdateTimer()
		{
			Counter += 0.1;
			UpdateDisplay();
		}
	}
}


