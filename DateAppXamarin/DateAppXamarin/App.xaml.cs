using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DateAppXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            AppActions.OnAppAction += AppActions_OnAppAction;
            MainPage = new MainPage();
        }

        private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            if (Application.Current != this && Application.Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (e.AppAction.Id == "MainPage")
                    await Shell.Current.GoToAsync("//" + typeof(MainPage));
               
            });
        }


        protected async override void OnStart()
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("MainPage", "Calculate Dates", icon: "icon.png")); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
