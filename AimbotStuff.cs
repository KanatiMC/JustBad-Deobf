using JustBad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad_Deobf
{
    internal class AimbotStuff : MonoBehaviour
    {
            // Token: 0x0600000E RID: 14
            [DllImport("user32.dll")]
            private static extern void mouse_event(int int_0, int int_1, int int_2, int int_3, int int_4);

            // Token: 0x0600000F RID: 15 RVA: 0x00002BD0 File Offset: 0x00000DD0
            private void Start()
            {
                base.StartCoroutine(this.method_0());
                base.StartCoroutine(this.method_1());
            }

            // Token: 0x06000010 RID: 16 RVA: 0x00002245 File Offset: 0x00000445
            public IEnumerator method_0()
            {
            return null;
            }

            // Token: 0x06000011 RID: 17 RVA: 0x00002254 File Offset: 0x00000454
            public IEnumerator method_1()
            {
            return null;
            }

            // Token: 0x06000012 RID: 18 RVA: 0x00002BF8 File Offset: 0x00000DF8
            public HumanBodyBones method_2()
            {
                int num = UnityEngine.Random.Range(1, 7);
                HumanBodyBones humanBodyBones;
                if (num != 1)
                {
                    if (num != 2)
                    {
                        if (num != 3)
                        {
                            if (num == 4)
                            {
                                humanBodyBones = 17;
                            }
                            else if (num == 5)
                            {
                                humanBodyBones = 7;
                            }
                            else
                            {
                                humanBodyBones = 4;
                            }
                        }
                        else
                        {
                            humanBodyBones = 8;
                        }
                    }
                    else
                    {
                        humanBodyBones = 18;
                    }
                }
                else
                {
                    humanBodyBones = 10;
                }
                return humanBodyBones;
            }

            // Token: 0x06000013 RID: 19 RVA: 0x00002C58 File Offset: 0x00000E58
            public static PlayerController smethod_0(float float_5)
            {
                PlayerController playerController = null;
                Camera main = Camera.main;
                foreach (PlayerController playerController2 in Class1.list_0)
                {
                    if (!(main == null))
                    {
                        Mathf.Round(Vector3.Distance(main.transform.position, playerController2.transform.position));
                        if (!playerController2.IsTeammate && playerController2 != null && Vector3.Distance(main.transform.position, playerController2.transform.position) <= 400f)
                        {
                            Vector3 vector = main.WorldToScreenPoint(playerController2.transform.position + new Vector3(0f, 1.5f, 0f));
                            if (vector.z > 0f)
                            {
                                float num = Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector.x, vector.y));
                                if (num <= Menu.aimbot_FOV)
                                {
                                    if (!(playerController == null))
                                    {
                                        Vector3 vector2 = main.WorldToScreenPoint(playerController.transform.position + new Vector3(0f, 1.5f, 0f));
                                        float num2 = Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector2.x, vector2.y));
                                        if (num2 > Menu.aimbot_FOV)
                                        {
                                            playerController = null;
                                        }
                                        if (num < num2)
                                        {
                                            playerController = playerController2;
                                        }
                                    }
                                    else
                                    {
                                        playerController = playerController2;
                                    }
                                }
                            }
                        }
                    }
                }
                return playerController;
            }

            // Token: 0x06000014 RID: 20 RVA: 0x00002E48 File Offset: 0x00001048
            private void method_3(Vector3 vector3_2, PlayerController playerController_0, Vector3 vector3_3)
            {
                Camera main = Camera.main;
                FOALBIIKMNK weaponType = PlayerController.Mine.Weapons.CurrentWeapon.Stats.WeaponType;
                float num = Vector3.Distance(vector3_3, vector3_2);
                if (num > 0.001f)
                {
                    num -= ((weaponType == 4) ? (num / 1.5f) : 0f);
                    float num2 = 200f;
                    float num3 = num / num2;
                    Vector3 vector = playerController_0.GetComponent<Rigidbody>().velocity * ((weaponType == 3) ? 0.3f : ((weaponType == 4) ? 5f : 1.2f)) * num3 * (num2 / PlayerController.Mine.Weapons.CurrentWeapon.Stats.Range);
                    vector3_2 += vector;
                    vector3_2.y -= ((weaponType == 4) ? 0.5f : 0f);
                    Vector3 vector2 = main.WorldToScreenPoint(vector3_2);
                    if (Class0.smethod_1(vector2))
                    {
                        Vector2 vector3;
                        vector3..ctor(vector2.x, (float)Screen.height - vector2.y);
                        double num4 = (double)(vector3.x - (float)Screen.width / 2f);
                        double num5 = (double)(vector3.y - (float)Screen.height / 2f);
                        num4 /= 10.0;
                        num5 /= 10.0;
                        Class1.mouse_event(1, (int)num4, (int)num5, 0, 0);
                    }
                }
            }

            // Token: 0x06000015 RID: 21 RVA: 0x00002FBC File Offset: 0x000011BC
            private void OnGUI()
            {
                if (Menu.aimbot_RandomBoneEnabled)
                {
                    this.float_3 += Time.deltaTime;
                    if (this.float_3 > this.float_4)
                    {
                        this.float_3 = 0f;
                        this.humanBodyBones_0 = this.method_2();
                    }
                }
                if (Menu.aimbot_ChestBoneEnabled)
                {
                    this.humanBodyBones_0 = 8;
                }
                else if (!Menu.aimbot_HeadBoneEnabled)
                {
                    if (Menu.aimbot_NeckBoneEnabled)
                    {
                        this.humanBodyBones_0 = 9;
                    }
                }
                else
                {
                    this.humanBodyBones_0 = 10;
                }
                if (Menu.mouseEvent_AimbotEnabled && Input.GetKey(this.keyCode_0))
                {
                    PlayerController playerController = Class1.smethod_0(Menu.aimbot_FOV);
                    this.animator_0 = playerController.GetComponent<Animator>();
                    Transform boneTransform = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                    this.vector3_1 = boneTransform.transform.position;
                    Camera.main.WorldToScreenPoint(this.vector3_1);
                    bool flag = !Class0.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
                    this.method_3(boneTransform.transform.position + new Vector3(0f, 1.5f, 0f), playerController, Vector3.zero);
                }
                if (Menu.silentAim_Enabled && Input.GetKey(this.keyCode_0))
                {
                    if (Menu.aimbot_FovCircleEnabled)
                    {
                        PlayerController playerController2 = Class1.smethod_0(Menu.aimbot_FOV);
                        this.animator_0 = playerController2.GetComponent<Animator>();
                        Transform boneTransform2 = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                        this.vector3_1 = boneTransform2.transform.position;
                        Vector3 vector = Camera.main.WorldToScreenPoint(this.vector3_1);
                        bool flag2 = !Class0.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
                        if (vector.z > 0f)
                        {
                            if (Menu.aimbot_VisCheckEnabled)
                            {
                                if (flag2)
                                {
                                    Camera main = Camera.main;
                                    main.transform.LookAt(this.vector3_1);
                                }
                            }
                            else if (!Menu.aimbot_VisCheckEnabled)
                            {
                                Camera main2 = Camera.main;
                                main2.transform.LookAt(this.vector3_1);
                            }
                        }
                    }
                    else if (!Menu.aimbot_FovCircleEnabled)
                    {
                        List<PlayerController> list = Class1.list_0.OrderBy((PlayerController x) => Vector3.Distance(x.transform.position, PlayerController.Mine.transform.position)).ToList<PlayerController>();
                        list.Remove(PlayerController.Mine);
                        PlayerController playerController3 = list.FirstOrDefault<PlayerController>();
                        this.animator_0 = playerController3.GetComponent<Animator>();
                        Transform boneTransform3 = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                        this.vector3_1 = boneTransform3.transform.position;
                        Vector3 vector2 = Camera.main.WorldToScreenPoint(this.vector3_1);
                        bool flag3 = !Class0.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
                        if (vector2.z > 0f)
                        {
                            if (Menu.aimbot_VisCheckEnabled)
                            {
                                if (flag3)
                                {
                                    Camera main3 = Camera.main;
                                    main3.transform.LookAt(this.vector3_1);
                                }
                            }
                            else if (!Menu.aimbot_VisCheckEnabled)
                            {
                                Camera main4 = Camera.main;
                                main4.transform.LookAt(this.vector3_1);
                            }
                        }
                    }
                }
            }

            // Token: 0x06000016 RID: 22 RVA: 0x0000334C File Offset: 0x0000154C
            public void Update()
            {
                if (Menu.aimbotBind_LeftMouse)
                {
                    this.keyCode_0 = 323;
                }
                if (Menu.aimbotBind_RightMouse)
                {
                    this.keyCode_0 = 324;
                }
            }

            // Token: 0x04000008 RID: 8
            public static float float_0;

            // Token: 0x04000009 RID: 9
            private Animator animator_0;

            // Token: 0x0400000A RID: 10
            private HumanBodyBones humanBodyBones_0;

            // Token: 0x0400000B RID: 11
            public Vector3 vector3_0;

            // Token: 0x0400000C RID: 12
            public Vector3 vector3_1;

            // Token: 0x0400000D RID: 13
            private KeyCode keyCode_0;

            // Token: 0x0400000E RID: 14
            public float float_1 = 1f;

            // Token: 0x0400000F RID: 15
            public float oBdsgowxY = 2f;

            // Token: 0x04000010 RID: 16
            public float float_2 = 3f;

            // Token: 0x04000011 RID: 17
            public Camera camera_0 = Camera.main;

            // Token: 0x04000012 RID: 18
            public static List<PlayerController> list_0 = new List<PlayerController>();

            // Token: 0x04000013 RID: 19
            public static List<SupplyCrate> list_1 = new List<SupplyCrate>();

            // Token: 0x04000014 RID: 20
            public static List<Pickupable> list_2 = new List<Pickupable>();

            // Token: 0x04000015 RID: 21
            public bool zPyeNsjg7;

            // Token: 0x04000016 RID: 22
            public float float_3;

            // Token: 0x04000017 RID: 23
            public float float_4 = 3f;
        }
    }

}

