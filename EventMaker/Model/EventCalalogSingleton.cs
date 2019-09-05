using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Persistency;


namespace EventMaker.Model
{
    public class EventCalalogSingleton
    {
        private ObservableCollection<Event> _events;
        private static EventCalalogSingleton _instance = null; 

        private EventCalalogSingleton()
        {
            _events = new ObservableCollection<Event>();
            LoadFile();
            //_events.Add(new Event(1, "name1", "desc1", "place1", new DateTime(2001, 1, 1)));
            //_events.Add(new Event(2, "name2", "desc2", "place2", new DateTime(2002, 2, 2)));
            //_events.Add(new Event(3, "name3", "desc3", "place3", new DateTime(2003, 3, 3)));

        }

        public static EventCalalogSingleton Instance
        {
            get
            {
               return _instance ?? (_instance = new EventCalalogSingleton());
            }
        }

        public void Add(Event e)
        {
            Events.Add(e);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        public async void Remove(Event e)
        {

            if (e != null)
            {
                Events.Remove(e);
                bool result = await PersistencyService.SaveEventsAsJsonAsync(Events);
                if (result = true)
                {
                    LoadFile();
                }
             
            }
        }

        public ObservableCollection<Event> Events
        {
            get { return _events; }
        }

        public async void LoadFile()
        {

            try
            {
                List<Event> listEventsLoaded = await PersistencyService.LoadEventsFromJsonAsync();

                if (listEventsLoaded != null)
                {
                    _events.Clear();
                    foreach (Event e in listEventsLoaded)
                    {
                        _events.Add(e);
                    }
                }
            }
            catch (Exception e)
            {
               
                throw new Exception("Load Events from Json Failed");
            }
          
        }

        //public async void LoadEventsAsync()
        //{
        //    List <Event> events = new List<Event>();
        //    events = await Persistency.PersistencyService.LoadEventsFromJsonAsync();

        //    foreach (Event e in events)
        //    {
        //        Events.Add(e);
        //    }

        //}
    }
}
