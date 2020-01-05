using NovaCleanClient.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaCleanClient.ViewModels
{
    public class DaysVisitPageViewModel : ViewModelBase
    {
        private TodaysEvent _SelectedEventItem;
        public TodaysEvent SelectedEventItem { get => _SelectedEventItem;
            set {
                //do navigation here
                SetProperty(ref _SelectedEventItem, value);
            }
        }
        public List<TodaysEvent> TodaysEventsList { get => _todaysEventList; set => SetProperty(ref _todaysEventList, value); }
        List<TodaysEvent> _todaysEventList;
        DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value);
        }
       
        public DaysVisitPageViewModel(INavigationService navigationService):base(navigationService)
        {
            

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            DateTime temp;
            if(!parameters.TryGetValue<DateTime>("DAY",out temp))
            {
                temp = DateTime.Now;
            }
            CurrentDateTime = temp;
            
        }
    }

    public class TodaysEvent
    {
        public string Location { get; set; }
        public List<VisitEvent> VisitEvents {get;set;}
    }
}
