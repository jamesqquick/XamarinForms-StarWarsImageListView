using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StarWars_ListViewWithImages
{
	public class Home : ContentPage
	{
		Label chosenLabel;
		public Home ()
		{
			Label title = new Label
			{
				Text = "Star Wars ListView",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			ListView list = new ListView {
				ItemsSource = getItems(),
				ItemTemplate = new DataTemplate(typeof(ImageCell))
			};
			list.ItemTemplate.SetBinding(ImageCell.TextProperty, "Name");
			list.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "Source");

			chosenLabel = new Label
			{
				Text = "You Chose",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			list.ItemTapped += List_ItemTapped;

			StackLayout stack = new StackLayout
			{
				Children = { title, list, chosenLabel }
			};
			this.Content = stack;
			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
		}

		private void List_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			chosenLabel.Text = ((Character)e.Item).Name;
		}

		private ObservableCollection<Character> getItems()
		{
			ObservableCollection<Character> characters = new ObservableCollection<Character>();
			string[] characterNames = new string[] { "C-3PO", "Chewbacca", "Darth Vader", "Luke SkyWalker",
			"Princess Leia","R2D2", "Yoda" };
			string[] imageFileNames = new string[] { "C3PO.PNG", "Chewbacca.PNG", "DarthVader.PNG", "LukeSkyWalker.PNG",
			"PrincessLeia.PNG","R2D2.PNG", "Yoda.PNG" };
			for(int i = 0; i < characterNames.Length; i++)
			{
				characters.Add(new Character() { Name = characterNames[i], Source = imageFileNames[i] });
			}
			return characters;
		}
	}

	public class Character
	{
		private string name;
		private string source;
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public string Source {
			get { return source; }
			set {source = value; }
		}
	}
}
