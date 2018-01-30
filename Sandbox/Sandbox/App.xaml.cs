using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Sandbox
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new Sandbox.Views.ReactPage();
            bool isEnabled =  Crashes.IsEnabledAsync().Result;

            var a =Crashes.HasCrashedInLastSessionAsync();
            
        }

		protected override void OnStart ()
		{
            AppCenter.Start("android=b4422757-3589-40f4-a032-397227f0ee61;" + "uwp={Your UWP App secret here};" +
       "ios={Your iOS App secret here}",
       typeof(Analytics), typeof(Crashes));

            
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
	}
}
