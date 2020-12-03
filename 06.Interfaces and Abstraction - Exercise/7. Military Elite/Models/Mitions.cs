using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Mitions : IMitions
    {
        public Mitions(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }
        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; }

        public void CompleteMissiont(string mussionName)
        {
            throw new NotImplementedException();
        }
    }
}
