using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace e.Features.Misc
{
    internal class LongNeck
    {
        //based of rust longneck

        //tested - Can destroy blocks when in long neck but can't damage or kill? invalids

        public static bool bLongneck = false;

        public static void Loop()
        {
            Longn();
        }

        public static void Longn() {

            if (!bLongneck)
                return;

            GameObject goCam = Controll.goCamera;

            if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            {
                goCam.transform.localPosition = new Vector3(0.0f, 5.5f, 0.0f);
            }
            else
            {
                goCam.transform.localPosition = new Vector3(0.0f, 2.3901f, 0.0f);
            }
        }
    }
}
