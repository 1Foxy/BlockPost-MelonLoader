using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.Features.Misc
{
    internal class UnlimtedAmmo
    {
        public static bool bUnAmmo = false;

        public static void Loop()
        {
            UnAmmo();
        }

        public static void UnAmmo()
        {
            if (!bUnAmmo)
                return;

            //unlimted ammo
            //needs to get a better look at im too lazy and this game shit
            PLH.RefillWeapons();
        }
    }
}
