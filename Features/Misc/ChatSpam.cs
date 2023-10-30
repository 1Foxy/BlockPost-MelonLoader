using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.Features.Misc
{
    internal class ChatSpam
    {
        public static bool bSpam = false;
        public static bool bTeamchat = false;
        public static bool monke = false;

        public static void Loop()
        {
            Spam();
        }

        // for some reason there is a limit of sending messages the spamming works!
        // But it only sends around 10 msgs then it stops and doesn't work again :(
        // still figuring out why

        // prob a limit :(

        public static void Spam()
        {
            if (!bSpam)
                return;

            Client client = Client.cs;

            if (bTeamchat)
            {
                if (monke)
                {
                    client.send_chatmsg(1, e.Utilities.Utils.GenerateSwastik(50));

                }
                else
                {
                    client.send_chatmsg(1, e.Utilities.Utils.GenerateRandomString(50));
                }

            }
            else
            {
                if (monke)
                {
                    client.send_chatmsg(0, e.Utilities.Utils.GenerateSwastik(50));

                }
                else
                {
                    client.send_chatmsg(0, e.Utilities.Utils.GenerateRandomString(50));
                }
            }
        }
    }
}
