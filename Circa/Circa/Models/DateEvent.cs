using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.Models
{
    //public class DateEvent : IEquatable<DateEvent>
    public class DateEvent : GenericEvent
    {
        //private const List<DateOption> DEFAULT_DATE_OPTIONS = new List<DateOption>();

        private List<DateOption> dateOptions;

        public DateEvent() : base()
        {
            DateOptions = new List<DateOption>();
        }

        public DateEvent(AppUser admin) : base(admin)
        {
            //Admin = admin;
        }
        
        public DateEvent(AppUser admin, string title, string description, string ubication, int fieldKey, DateTime votingDeadline, List<DateOption> dateOptions)
            :base(admin, title, description, ubication, fieldKey, votingDeadline)
        {
            DateOptions = dateOptions;
        }

        public DateEvent(AppUser admin, string title, string description, string ubication, int fieldKey, DateTime votingDeadline, bool proposingIsEnabled, int maxPropositionsPerUser, DateTime proposingDeadline, List<DateOption> dateOptions)
            :base(admin, title, description, ubication, fieldKey, votingDeadline, proposingIsEnabled, maxPropositionsPerUser, proposingDeadline)
        {
            DateOptions = dateOptions;
        }

        public DateEvent(GenericEvent genericEvent)
        {
            Title = genericEvent.Title;
            Description = genericEvent.Description;
            FieldKey = genericEvent.FieldKey;
            Admin = genericEvent.Admin;
            VotingDeadline = genericEvent.VotingDeadline;
            ProposingIsEnabled = genericEvent.ProposingIsEnabled;
            MaxPropositionsPerUser = genericEvent.MaxPropositionsPerUser;
            ProposingDeadline = genericEvent.ProposingDeadline;

            DateOptions = new List<DateOption>();
        }



        public static List<DateOption> createUserDatesList(List<DateTime> toBeAddedDates, AppUser proposer)
        {
            var votedDates = new List<DateOption>();
            
            if(toBeAddedDates != null && proposer != null)
            {
                //toBeAddedDates.Sort();


                foreach (DateTime item in toBeAddedDates)
                {
                    //votedDates.Add(new DateOption(item, new AppUser(proposer.Id, proposer.Nickname)));
                }
            }

            votedDates.Sort(); //Por seguridad, aunque en prinicipio inececesario

            return votedDates;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Title);
            sb.Append(" - ");
            sb.Append(Admin.Nickname);
            sb.Append(" - ");
            sb.Append(VotingDeadline);

            return sb.ToString();
        }

        /*
        public bool Equals(DateEvent other)
        {
            throw new NotImplementedException();
        }
        */

        internal List<DateOption> DateOptions { get => dateOptions; set => dateOptions = value; }
    }
}
