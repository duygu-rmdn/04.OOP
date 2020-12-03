namespace _7._Military_Elite.Interfaces
{
    public interface IMitions
    {
        string CodeName { get; }
        MissionStateEnum MissionStateEnum { get; }
        void CompleteMissiont(string mussionName);
    }
}