﻿using Prism;
using Prism.Ioc;
using NovaCleanClient.ViewModels;
using NovaCleanClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NovaCleanClient.Services.BackendServices;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NovaCleanClient
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<DaysVisitPage, DaysVisitPageViewModel>();
            containerRegistry.RegisterForNavigation<CalendarPage, CalendarPageViewModel>();
            containerRegistry.RegisterForNavigation<NonConformityReportPage, NonConformityReportPageViewModel>();
            containerRegistry.RegisterForNavigation<EvaluationPage, EvaluationPageViewModel>();
            containerRegistry.RegisterForNavigation<UserProfilePage, UserProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<NovaMasterDetailPage1, NovaMasterDetailPage1ViewModel>();

            containerRegistry.RegisterSingleton<IUserCredentialsProvider, UserCredentialsProvider>();
            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IEventsService, EventsService>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
