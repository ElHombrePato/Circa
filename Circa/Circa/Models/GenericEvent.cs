using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.Models
{
    /*
    IComparable, IComparable<DateTime>,
    IConvertible, IEquatable<DateTime>,
    IFormattable, System.Runtime.Serialization.ISerializable
    */
    public abstract class GenericEvent
    {
        protected const string DEFAULT_TITLE = "<Sin título>";
        protected const string DEFAULT_DESCRIPTION = "<Sin ubicación>";
        protected const string DEFAULT_UBICATION = "<Sin ubicacion>";
        protected const string DEFAULT_FIELD = "<Sin tipo>";
        protected static readonly DateTime VOTING_DEADLINE = DateTime.UtcNow.AddDays(7);

        protected const bool DEFAULT_PROPOSING_IS_ENABLED = false;
        protected const int DEFAULT_MAX_PROPOSITIONS_PER_USER = 3;
        protected static readonly DateTime DEFAULT_PROPOSING_DEADLINE = DateTime.UtcNow.AddDays(4);

        // public static readonly Color Black = new Color(0, 0, 0);

        public static readonly string[] eventFieldArray = new string[]
        {
            "Familia",
            "Trabajo",
            "Amigos",
            "Médico"
        };

        public static readonly int[] maxPropositionsPerUserArray = new int[]
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
        };

        //private int id;
        private string title;
        private string description;
        private string ubication;
        private string field;
        //collection notas
        private AppUser admin;
        private DateTime votingDeadline;

        private bool proposingIsEnabled;
        private int maxPropositionsPerUser;
        private DateTime proposingDeadline;

        public GenericEvent()
        {
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            Ubication = DEFAULT_UBICATION;
            Field = DEFAULT_FIELD;
            VotingDeadline = VOTING_DEADLINE;
            //Admin = admin;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;
        }
        
        public GenericEvent(AppUser admin)
        {
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            Ubication = DEFAULT_UBICATION;
            Field = DEFAULT_FIELD;
            VotingDeadline = VOTING_DEADLINE;
            Admin = admin;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;
        }


        public GenericEvent(string title, string description, string ubication, string field, AppUser admin, DateTime votingDeadline)
        {
            Title = title;
            Description = description;
            Ubication = ubication;
            Field = field;
            Admin = admin;
            VotingDeadline = votingDeadline;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;

        }

        public GenericEvent(string title, string description, string ubication, string field, AppUser admin, DateTime votingDeadline, bool proposingIsEnabled, int maxPropositionsPerUser, DateTime proposingDeadline)
        {
            Title = title;
            Description = description;
            Ubication = ubication;
            Field = field;
            Admin = admin;
            VotingDeadline = votingDeadline;

            ProposingIsEnabled = proposingIsEnabled;
            MaxPropositionsPerUser = maxPropositionsPerUser;
            ProposingDeadline = proposingDeadline;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Title);
            sb.Append(" - ");
            sb.Append(Admin.Nickname);
            sb.Append(" - ");
            sb.Append(VotingDeadline);
            sb.Append(" - ");
            sb.Append(ProposingIsEnabled);
            sb.Append(" - ");
            sb.Append(MaxPropositionsPerUser);
            sb.Append(" - ");
            sb.Append(ProposingDeadline);

            return sb.ToString();
        }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Ubication { get => ubication; set => ubication = value; }
        public string Field { get => field; set => field = value; }
        internal AppUser Admin { get => admin; set => admin = value; }
        public DateTime VotingDeadline { get => votingDeadline; set => votingDeadline = value; }
        public int MaxPropositionsPerUser { get => maxPropositionsPerUser; set => maxPropositionsPerUser = value; }
        public DateTime ProposingDeadline { get => proposingDeadline; set => proposingDeadline = value; }
        public bool ProposingIsEnabled { get => proposingIsEnabled; set => proposingIsEnabled = value; }

    }
}
