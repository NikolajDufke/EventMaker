using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using EventMaker.ViewModel;
using EventMaker.Converter;

namespace EventMaker.Handler
{
    public class EventHandler
    {
        private EventViewModel _evm;
      
        public EventHandler(EventViewModel evm)
        {
            _evm = evm;
            int H = _evm.Id;
        }

        public void CreateEvent()
        {
            _evm.EventCatalog.Add(new Event(_evm.Id, _evm.Name, _evm.Description,_evm.Place,DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(_evm.Date, _evm.Time)));
        }

        public void DeleteEvent()
        {
            if (EventViewModel.SelectedEvent != null)
            {
                _evm.EventCatalog.Remove(EventViewModel.SelectedEvent);
            }
        }

        public void SetSelectedEvent(Event e)
        {
            EventViewModel.SelectedEvent = e;
        }
    }
}
