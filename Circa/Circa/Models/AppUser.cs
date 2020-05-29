using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.Models
{
    public class AppUser
    {
        private int id;
        private string nickname = "<Sin Apodo>";
        private List<DateEvent> events;
        //private ObservableCollection<CalendarEvent> events = new ObservableCollection<CalendarEvent>();

        public AppUser(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        public AppUser(int id, string nickname, List<DateEvent> events)
        {
            Id = id;
            Nickname = nickname;
            Events = events;
        }

        public void AddEvent(DateEvent dateEvent)
        {
            Events.Add(dateEvent);
            //Events.Sort();
        }

        

        public int Id { get => id; private set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        internal List<DateEvent> Events { get => events; set => events = value; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Id);
            sb.Append(Nickname);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AppUser))
                return false;
            else
                return this.Id == ((AppUser)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}