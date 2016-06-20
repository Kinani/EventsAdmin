using EventsAdmin.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAdmin.ViewModels
{
    public class EventTableViewModel
    {
        public MobileServiceCollection<Event, Event> items;
        private IMobileServiceTable<Event> eventTable;
        public EventTableViewModel()
        {
            try
            {
                eventTable = App.MobileService.GetTable<Event>();
            }
            catch
            {

            }
        }

        public async Task InsertEventItem(Event eventItem)
        {
            try
            {   
                await eventTable.InsertAsync(eventItem);
            }
            catch
            {

            }
        }

        public async Task<bool> RefreshEventItems()
        {

            MobileServiceInvalidOperationException exception = null;
            try
            {
                items = await eventTable
                    .Where(eventItem => eventItem.complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> GetUnfinshedEvents()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {   
                items = await eventTable
                    .Where(eventItem => eventItem.complete == false)
                    .ToCollectionAsync();
                if (items.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
                return false;
            }


        }

        public async Task<string> GetLastEventID()
        {
            Event _event;
            MobileServiceInvalidOperationException exception = null;
            try
            {   

                var lastItems = await eventTable.OrderByDescending(p => p.CreatedAt)
                    .Take(1).ToEnumerableAsync();

                _event = lastItems.FirstOrDefault();
                return _event.id;

            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
                return null;
            }
        }

        public async Task<bool> RefreshEventItem()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {

                await eventTable.UpdateAsync(App.ChosenEvent);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {

                return false;
            }
            else
            {
                return true;

            }
        }

        public async Task<bool> DeleteEventItem()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                App.EventIDForSesionsDelete = App.ChosenEvent.id;
                await eventTable.DeleteAsync(App.ChosenEvent);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {

                return false;
            }
            else
            {
                return true;

            }
        }
    }
}
