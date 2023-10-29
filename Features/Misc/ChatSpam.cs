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
        
        public static void Loop()
        {
            Spam();
        }

        // for some reason there is a limit of sending messages the spamming works!
        // But it only sends around 10 msgs then it stops and doesn't work again :(
        // still figuring out why

        public static void Spam()
        {
            if (!bSpam)
                return;

            Client client = Client.cs;

            client.send_chatmsg(0, e.Utilities.Utils.GenerateRandomString(40));
        }
    }
}
