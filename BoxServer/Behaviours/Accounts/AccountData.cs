using System;

namespace BoxServer.Behaviours.Accounts
{
    [Serializable]
    public class AccountData
    {
        public string userId;
        public bool tutorialComplete = false;
        public int accountLevel = 1;
        public int accountExperience = 0;
        public string ip = string.Empty;
    }
}
