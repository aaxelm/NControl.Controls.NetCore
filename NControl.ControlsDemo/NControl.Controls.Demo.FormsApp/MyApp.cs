﻿using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace NControl.Controls.Demo.FormsApp
{
	public class MyApp : Application
	{
        public static float DensityScale = 1.0f;

		public MyApp ()
		{
            //var demoPageList = new ContentPage[] {
            //	new CustomFontPage(),
            //	new MaterialDesignIconsPage(),
            //	new FontAwesomeLabelPage(),
            //	new RoundCornerViewPage(),
            //	new FloatingLabelPage(),
            //	new ActionButtonPage(),
            //	new CardPageDemo{BindingContext = new ViewModel("CardPage")},
            //	new BlurViewPage(),
            //	new RippleButtonPage(),
            //	new GalleryPage(),
            //	new PagingViewPage(),
            //	new TabStripPage(),
            //	new SvgImagePage(),
            //             new CalendarPage(),
            //	new WizardPage(),
            //	new WizardPageXaml(),
            //	new RepeaterPage(),
            //         };

            //BindingContext = new ViewModel("Should say CardPage");

            //var listView = new ListView {
            //	ItemsSource = demoPageList,
            //};

            //listView.ItemTemplate = new DataTemplate (typeof(TextCell));
            //listView.ItemTemplate.SetBinding (TextCell.TextProperty, "Title");

            //var contentLayout = new RelativeLayout ();
            //contentLayout.Children.Add (listView, () => contentLayout.Bounds);

            //var startPage = new ContentPage {
            //	Title = "NControl.Controls",
            //	Content = contentLayout              
            //};

            //listView.ItemSelected += async (sender, e) => {

            //	if(listView.SelectedItem == null)
            //		return;

            //	// Show page
            //	await startPage.Navigation.PushAsync(listView.SelectedItem as Page);					
            //};

            //listView.ItemTapped += (sender, e) => listView.SelectedItem = null;

            //// The root page of your application
            //MainPage = new NavigationPage(startPage);
            MainPage = new ActionButtonPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static void RegisterDeviceResolver(IDevice device)
        {
            if (!Resolver.IsSet)
            {
                var resolverContainer = new SimpleContainer();
                resolverContainer.Register<IDevice>(t => device);
                Resolver.SetResolver(resolverContainer.GetResolver());
            }
        }

	}

	public class ViewModel
	{
		public ViewModel(string title)
		{
			Title = title;
		}

		public string Title {
			get;
			private set;
		}

		public override string ToString ()
		{
			return string.Format ("[ViewModel: Title={0}]", Title);
		}
	}
}

