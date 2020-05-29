using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.Models
{
    public class DateOption
    {
        //private int id;
        private DateTime date = new DateTime();
        private AppUser proposer;
        private List<OptionVote> votes;

        public DateOption(DateTime date, AppUser proposer, List<OptionVote> votes)
        {
            Date = date;
            Proposer = proposer;
            Votes = votes;
        }

        public DateOption(DateTime date, AppUser proposer)
        {
            Date = date;
            Proposer = proposer;
            Votes = new List<OptionVote>();
        }

        public DateOption(DateTime date)
        {
            Date = date;
            Proposer = proposer;
            Votes = new List<OptionVote>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(date.Day);
            sb.Append(" de ");
            sb.Append(date.Month);
            sb.Append(" de ");
            sb.Append(date.Year);
            sb.Append(" - ");
            sb.Append(Proposer.Nickname);

            return sb.ToString();
        }

        /*
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        */

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            DateOption objAsDateOption = obj as DateOption;
            if (objAsDateOption == null) return false;
            else return Equals(objAsDateOption);
        }

        public bool Equals(DateOption other)
        {
            if (other == null) return false;
            return (this.Date.Equals(other.Date));
        }
        
        public DateTime Date { get => date; set => date = value; }
        public AppUser Proposer { get => proposer; set => proposer = value; }
        internal List<OptionVote> Votes { get => votes; set => votes = value; }
    }
}
