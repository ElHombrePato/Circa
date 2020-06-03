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
    public class GenericEvent
    {
        //protected const int DEFAULT_ID = 0; //Temporary ID
        protected AppUser DEFAULT_ADMIN = App.myUser; //TODO no es constante y el acceso es irregular
        protected const string DEFAULT_TITLE = "";
        protected const string DEFAULT_DESCRIPTION = "";
        protected const string DEFAULT_UBICATION = "";
        protected const int DEFAULT_FIELD_KEY = -1;
        protected static readonly DateTime VOTING_DEADLINE = DateTime.UtcNow.Date.AddDays(7).AddHours(12);

        protected const bool DEFAULT_PROPOSING_IS_ENABLED = false;
        protected const int DEFAULT_MAX_PROPOSITIONS_PER_USER = 3;
        protected static readonly DateTime DEFAULT_PROPOSING_DEADLINE = DateTime.UtcNow.Date.AddDays(4).AddHours(12);

        /*
        protected const string DEFAULT_TITLE = "<Sin título>";
        protected const string DEFAULT_DESCRIPTION = "<Sin ubicación>";
        protected const string DEFAULT_UBICATION = "<Sin ubicacion>";
        protected const string DEFAULT_FIELD = "<Sin tipo>";
        protected static readonly DateTime VOTING_DEADLINE = DateTime.UtcNow.AddDays(7);

        protected const bool DEFAULT_PROPOSING_IS_ENABLED = false;
        protected const int DEFAULT_MAX_PROPOSITIONS_PER_USER = 3;
        protected static readonly DateTime DEFAULT_PROPOSING_DEADLINE = DateTime.UtcNow.AddDays(4);
        */

        // public static readonly Color Black = new Color(0, 0, 0);

        /*
        public static readonly string[] eventFieldArray = new string[]
        {
            "Familia",
            "Trabajo",
            "Amigos",
            "Médico",
            "Otros"
        };
        */

        public static Dictionary<int, string> EVENT_FIELDS = new Dictionary<int, string>()
        {
            //[-1] is the Picker code for Default display (empty/blanked)
            [0] = "Familia",
            [1] = "Trabajo",
            [2] = "Amigos",
            [3] = "Salud",
            [DEFAULT_FIELD_KEY] = "Otro"
        };

        public static readonly int[] maxPropositionsPerUserArray = new int[]
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
        };

        //private int id;
        private AppUser admin;
        private string title;
        private string description;
        private string ubication;
        private int fieldKey;
        //collection notas
        private DateTime votingDeadline;

        private bool proposingIsEnabled;
        private int maxPropositionsPerUser;
        private DateTime proposingDeadline;

        public GenericEvent()
        {
            //Id = 
            Admin = DEFAULT_ADMIN;
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            Ubication = DEFAULT_UBICATION;
            FieldKey = DEFAULT_FIELD_KEY;
            VotingDeadline = VOTING_DEADLINE;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;
        }
        
        public GenericEvent(AppUser admin)
        {
            Admin = admin;
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            Ubication = DEFAULT_UBICATION;
            FieldKey = DEFAULT_FIELD_KEY;
            VotingDeadline = VOTING_DEADLINE;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;
        }


        public GenericEvent(AppUser admin, string title, string description, string ubication, int fieldKey, DateTime votingDeadline)
        {
            Admin = admin;
            Title = title;
            Description = description;
            Ubication = ubication;
            FieldKey = fieldKey;
            VotingDeadline = votingDeadline;

            ProposingIsEnabled = DEFAULT_PROPOSING_IS_ENABLED;
            MaxPropositionsPerUser = DEFAULT_MAX_PROPOSITIONS_PER_USER;
            ProposingDeadline = DEFAULT_PROPOSING_DEADLINE;

        }

        public GenericEvent(AppUser admin, string title, string description, string ubication, int fieldKey, DateTime votingDeadline, bool proposingIsEnabled, int maxPropositionsPerUser, DateTime proposingDeadline)
        {
            Admin = admin;
            Title = title;
            Description = description;
            Ubication = ubication;
            FieldKey = fieldKey;
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

        //public int Id { get => id; set => id = value; }
        internal AppUser Admin { get => admin; set => admin = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Ubication { get => ubication; set => ubication = value; }
        public int FieldKey { get => fieldKey; set => fieldKey = value; }
        public DateTime VotingDeadline { get => votingDeadline; set => votingDeadline = value; }
        public int MaxPropositionsPerUser { get => maxPropositionsPerUser; set => maxPropositionsPerUser = value; }
        public DateTime ProposingDeadline { get => proposingDeadline; set => proposingDeadline = value; }
        public bool ProposingIsEnabled { get => proposingIsEnabled; set => proposingIsEnabled = value; }
    }
}
