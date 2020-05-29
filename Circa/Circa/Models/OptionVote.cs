using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.Models
{
    public class OptionVote
    {

        public static readonly string[] optionVoteCodes = new string[]
        {
            "Me viene bien",                            //Green
            "No me viene bien, pero podría asistir",    //Yellow
            "No me viene bien"                          //Red
        };

        private AppUser voter;
        private int optionCode;

        public OptionVote(AppUser voter, int optionCode)
        {
            Voter = voter;
            OptionCode = optionCode;
        }

        public AppUser Voter { get => voter; set => voter = value; }
        public int OptionCode { get => optionCode; set => optionCode = value; }
    }
}
