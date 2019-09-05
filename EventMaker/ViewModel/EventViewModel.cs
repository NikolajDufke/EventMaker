using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    public class EventViewModel
    {
        private EventCalalogSingleton _events;
        private Handler.EventHandler _eventhandler;
        private static Event _selectedEvent;
        private ICommand _deleteEventCommand;
        private ICommand _selectEventCommand;

        public EventViewModel()
        {
            _events = EventCalalogSingleton.Instance;
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year,dt.Month,dt.Day,dt.Hour,dt.Minute,0,0,new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
           _eventhandler = new Handler.EventHandler(this);
            CreateEventCommand = new RelayCommand(CreateEvent);
            SaveEventCommand = new RelayCommand(SaveEvent);
         
        }

        public EventCalalogSingleton EventCatalog
        {
            get { return _events; }
        }

        public ObservableCollection<Event> Events
        {
            get { return _events.Events; }
        }

        public static Event SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; }
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Place
        {
            get;
            set;
        }

        public DateTimeOffset Date
        {
            get;
            set;
        }

        public TimeSpan Time
        {
            get;
            set;
        }

        public Handler.EventHandler EventHandler
        {
            get { return _eventhandler; }
        }

        public ICommand CreateEventCommand { get; set; }

        public void CreateEvent()
        {
            EventHandler.CreateEvent();
        }

        public ICommand SaveEventCommand { get; set; }

        public void SaveEvent()
        {
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }

       

        public ICommand DeleteEventCommand
        {
            get { return _deleteEventCommand ?? (_deleteEventCommand = new RelayCommand(EventHandler.DeleteEvent)); }
            set { _deleteEventCommand = value; }
        }


        public ICommand SelectEventCommand
        {
            get
            {
                return _selectEventCommand ?? (_selectEventCommand =
                           new RelayArgCommand<Event>(ev => EventHandler.SetSelectedEvent(ev)));
                
            }
            set { _selectEventCommand = value; }
        }


        //public RelayCommand CreateEventCommand
        //{
        //    get { return _eventCommand; }
        //}
    }
}
