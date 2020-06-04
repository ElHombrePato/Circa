using Circa.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.ViewModels
{
    public class DateOptionWrapper : IComparable<DateOptionWrapper>
    {
        private DateTime date;
        private string proposerNickname;
        private int voteCount;

        public DateOptionWrapper(DateOption dateOption)
        {
            if (dateOption != null)
            {
                Date = dateOption.Date;
                ProposerNickname = dateOption.Proposer.Nickname;
                VoteCount = dateOption.CountVotes();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error en DateOptionWrapper");
            }
        }

        /*
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            DateOptionWrapper objAsDateOptionWrapper = obj as DateOptionWrapper;
            if (objAsDateOptionWrapper == null) return false;
            else return Equals(objAsDateOptionWrapper);
        }

        public bool Equals(DateOptionWrapper other)
        {
            if (other == null) return false;
            return (this.Date.Equals(other.Date));
        }
        */

        public int CompareTo(DateOptionWrapper other)
        {
            int value = 0;

            if (other != null)
            {
                value = Date.CompareTo(other.Date);
            }

            return value;
        }

        public DateTime Date { get => date; set => date = value; }
        public string ProposerNickname { get => proposerNickname; set => proposerNickname = value; }
        public int VoteCount { get => voteCount; set => voteCount = value; }
    }
}
