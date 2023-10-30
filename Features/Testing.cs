using e.Utilities;
using GameClass;
using Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;

namespace e.Features
{
    internal class Testing
    {
        public static bool sex = false; 

        public static void Loop()
        {
            Func();
        }

        public static void Func() {
            if(Input.GetKeyDown(KeyCode.F2)) {             
                sex =! sex;          
            }

            if (sex)
            {
                //ignore for testing
            }
        }
    }
}
