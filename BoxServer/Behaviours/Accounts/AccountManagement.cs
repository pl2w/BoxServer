using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace BoxServer.Behaviours.Accounts
{
    public static class AccountManagement
    {
        public static void GetAccount(string userid, out AccountData data)
        {
            if(File.Exists(userid + ".account"))
            {
                data = JsonConvert.DeserializeObject<AccountData>(File.ReadAllText(userid + ".account"));
                Console.WriteLine($"Account found for '{userid}'");
            }
            else
            {
                AccountData accountData = new AccountData();
                accountData.userId = userid;
                data = accountData;

                SaveAccountData(accountData);
            }
        }

        public static void SaveAccountData(AccountData account)
        {
            File.WriteAllText(account.userId + ".account", JsonConvert.SerializeObject(account));
        }
    }
}
