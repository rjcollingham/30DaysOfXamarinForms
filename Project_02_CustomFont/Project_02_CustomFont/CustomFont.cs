using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project_02_CustomFont
{
	public class CustomFont : ContentPage
	{
		List<string> _sentences = new List<string>
		{
			"I wandered lonely as a cloud",
			"That floats on high o'er vales and hills,",
			"When all at once I saw a crowd,",
			"A host, of golden daffodils;",
			"Beside the lake, beneath the trees,",
			"Fluttering and dancing in the breeze."
		};

		List<FontFile> _fonts = new List<FontFile>
		{
			new FontFile { Name = "PT Sans", Filename = "PT-Sans-Web-Regular.ttf" },
			new FontFile { Name = "Raleway", Filename = "Raleway-Regular.ttf" },
			new FontFile { Name = "Ubuntu", Filename = "Ubuntu-Regular.ttf" },
			new FontFile { Name = "BebasNeueRegular", Filename = "BebasNeueRegular.ttf" },
			new FontFile { Name = "Cabin", Filename = "Cabin-Regular.ttf" },
			new FontFile { Name = "Lato", Filename = "Lato-Regular.ttf" },
			new FontFile { Name = "Montserrat", Filename = "Montserrat-Regular.ttf" },
			new FontFile { Name = "Open Sans", Filename = "OpenSans-Regular.ttf" },
		};

		Label lblFont;
		ListView lvSentences;
		int FontIndex = 0;

		public CustomFont()
		{
			Grid grMain = new Grid
			{
				Padding = new Thickness(10, 40, 10, 40),
				RowSpacing = 20,
				BackgroundColor = Color.Black,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				}
			};

		 	lblFont = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				Text = _fonts[0].Name,
				TextColor = Color.White
			};

			int height = 6 * Convert.ToInt32(Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
			AppButton btnChangeFont = new AppButton
			{
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.FromHex("#dfe30b"),
				TextColor = Color.Black,
				BorderWidth = 0,
				BorderRadius = height / 2,
				HeightRequest = height,
				MinimumHeightRequest = height,
				WidthRequest = height,
				MinimumWidthRequest = height,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				Text = "Change Font"
			};
			btnChangeFont.Clicked += Change_Font;

			lvSentences = new ListView
			{
				BackgroundColor = Color.Black,
				SeparatorVisibility = SeparatorVisibility.None,
				ItemTemplate = new DataTemplate(typeof(SentenceCell)),
				ItemsSource = MakeSentences()
			};

			grMain.Children.Add(lblFont, 0, 0);
			grMain.Children.Add(lvSentences, 0, 1);
			grMain.Children.Add(btnChangeFont, 0, 2);

			Content = grMain;
		}

		void Change_Font(object sender, EventArgs e)
		{
			FontIndex = (FontIndex + 1) % _fonts.Count;
			lblFont.Text = _fonts[FontIndex].Name;
			lvSentences.ItemsSource = null;
			lvSentences.ItemsSource = MakeSentences();
		}

		Sentence[] MakeSentences()
		{
			List<Sentence> sents = new List<Sentence>();
			foreach (string s in _sentences)
			{
				sents.Add(new Sentence { Text = s, TextFont = Device.OnPlatform(_fonts[FontIndex].Name, _fonts[FontIndex].Filename, "") });
			}
			return sents.ToArray();
		}

		public class FontFile
		{
			public string Name { get; set;}
			public string Filename { get; set;}
		}
		public class Sentence
		{
			public string Text { get; set;}
			public string TextFont { get; set;}
		}

		public class SentenceCell : ViewCell
		{
			public SentenceCell()
			{
				Label lblSentence = new Label
				{
					Margin = new Thickness(0, 10, 0, 10),
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					TextColor = Color.White
				};
				lblSentence.SetBinding(Label.TextProperty, "Text");
				lblSentence.SetBinding(Label.FontFamilyProperty, "TextFont");
				View = lblSentence;
			}
		}

	}

	public class AppButton : Button
	{
		// needed for Android Button renderer
	}
}

