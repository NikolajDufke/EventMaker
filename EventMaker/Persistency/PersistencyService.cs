using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Interop;
using EventMaker.Model;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    public class PersistencyService
    {
        private static string directory = "EventsAsJson.dat";

        public static async Task<bool> SaveEventsAsJsonAsync(ObservableCollection<Event> Events)
        {
           string serilizedObject = JsonConvert.SerializeObject(Events);
           SerializeEventsFileAsync(serilizedObject, directory);
           return true;
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            return await DeserializeFileAsync(directory);
        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            int count = 0;
            bool isNotAvalible = true;
            bool approved = false;
            while ( isNotAvalible)
            {
                if (localFile.IsAvailable == true)
                {
                    isNotAvalible = false;
                    approved = true;
                }

                if (count > 5000)
                {
              
                    new Exception("to long waittime");
                    isNotAvalible = false;
                }
                else
                {
                    count++;
                }
            }

            if (approved == false)
            {
                await FileIO.WriteTextAsync(localFile, eventsString);
            }
      
          
        }

        public static async Task<List<Event>> DeserializeFileAsync(string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            string JsonfileContent = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<List<Event>>(JsonfileContent);
        }




    }
}

