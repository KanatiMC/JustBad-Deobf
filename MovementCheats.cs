using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    internal class MovementCheats : MonoBehaviour
    {
        public void Update()
        {
            if (Menu.spinbotEnabled && Input.GetKey(KeyCode.H))
            {
                Quaternion rotation = PlayerController.JPIGHMOLDBI.transform.rotation;
                MovementCheats.i += 24;
                PlayerController.JPIGHMOLDBI.transform.Rotate(rotation.x, (float)MovementCheats.i, rotation.z);
                if (MovementCheats.i > 360)
                {
                    MovementCheats.i = 0;
                }
            }
            else if (Menu.spinbotEnabled && Input.GetKeyUp(KeyCode.H))
            {
                PlayerController.JPIGHMOLDBI.transform.rotation = Quaternion.identity;
            }
            if (Menu.noclipEnabled && Input.GetKey(KeyCode.CapsLock))
            {
                Vector3 vector = Vector3.zero;
                if (Input.GetKey(KeyCode.Space))
                {
                    vector += Camera.main.transform.up * 0.4f;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    vector += Camera.main.transform.forward * Menu.noclipSpeed;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    vector += Camera.main.transform.right * -Menu.noclipSpeed;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    vector += Camera.main.transform.forward * -Menu.noclipSpeed;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    vector += Camera.main.transform.right * Menu.noclipSpeed;
                }
                PlayerController.JPIGHMOLDBI.transform.position += vector;
            }
            if (Menu.developerFlyEnabled)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    this.bool_0 = !this.bool_0;
                }
                if (!this.bool_0)
                {
                    PlayerController.JPIGHMOLDBI.SetGodMode(false);
                }
                else
                {
                    PlayerController.JPIGHMOLDBI.FGKNOFLGKBP.flySpeed = Menu.developerFlySpeed;
                    PlayerController.JPIGHMOLDBI.SetGodMode(true);
                }
            }
            if (Menu.changeJumpHeightEnabled)
            {
                PlayerController.JPIGHMOLDBI.FGKNOFLGKBP.jumpHeight = Menu.jumpHeight;
                this.bool_1 = false;
            }
            if (!Menu.changeJumpHeightEnabled && !this.bool_1)
            {
                PlayerController.JPIGHMOLDBI.FGKNOFLGKBP.jumpHeight = 5.5f;
                this.bool_1 = true;
            }
            if (Menu.tpToVisiblePlayerEnabled)
            {
                PlayerController playerController = AimbotStuff.smethod_0(600f);
                if (playerController != null && Input.GetKey(KeyCode.T))
                {
                    PlayerController.JPIGHMOLDBI.transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, playerController.transform.position.z);
                }
            }
        }

        // Token: 0x0400003F RID: 63
        private bool bool_0 = false;

        // Token: 0x04000040 RID: 64
        public static int i;

        // Token: 0x04000041 RID: 65
        private bool bool_1;
    }
}
