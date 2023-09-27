using JustBad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    internal class AimbotStuff : MonoBehaviour
    {
            [DllImport("user32.dll")]
            private static extern void mouse_event(int int_0, int int_1, int int_2, int int_3, int int_4);

            private void Start()
            {
                base.StartCoroutine(this.method_0());
                base.StartCoroutine(this.method_1());
            }

            public IEnumerator method_0()
            {
            return null;
            }

            public IEnumerator method_1()
            {
            return null;
            }

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
                                humanBodyBones = HumanBodyBones.LeftHand;
                            }
                            else if (num == 5)
                            {
                                humanBodyBones = HumanBodyBones.Spine;
                            }
                            else
                            {
                                humanBodyBones = HumanBodyBones.RightLowerLeg;
                            }
                        }
                        else
                        {
                            humanBodyBones = HumanBodyBones.Chest;
                        }
                    }
                    else
                    {
                        humanBodyBones = HumanBodyBones.RightHand;
                    }
                }
                else
                {
                    humanBodyBones  = HumanBodyBones.Head;
                }
                return humanBodyBones;
            }

            public static PlayerController smethod_0(float float_5)
            {
                PlayerController playerController = null;
                Camera main = Camera.main;
                foreach (PlayerController playerController2 in list_0)
                {
                    if (!(main == null))
                    {
                        Mathf.Round(Vector3.Distance(main.transform.position, playerController2.transform.position));
                        if (!playerController2.OIIOCKHDKMO && playerController2 != null && Vector3.Distance(main.transform.position, playerController2.transform.position) <= 400f)
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

            private void method_3(Vector3 vector3_2, PlayerController playerController_0, Vector3 vector3_3)
            {
                Camera main = Camera.main;
                FOALBIIKMNK weaponType = PlayerController.JPIGHMOLDBI.OFGEHBLDKHD.KOBBJGHNHKE.BKEJFFENCPI.WeaponType;
                float num = Vector3.Distance(vector3_3, vector3_2);
                if (num > 0.001f)
                {
                    num -= ((weaponType == FOALBIIKMNK.SniperRifle) ? (num / 1.5f) : 0f);
                    float num2 = 200f;
                    float num3 = num / num2;
                    Vector3 vector = playerController_0.GetComponent<Rigidbody>().velocity * ((weaponType == FOALBIIKMNK.Shotgun) ? 0.3f : ((weaponType == FOALBIIKMNK.SniperRifle) ? 5f : 1.2f)) * num3 * (num2 / PlayerController.JPIGHMOLDBI.OFGEHBLDKHD.KOBBJGHNHKE.BKEJFFENCPI.Range);
                    vector3_2 += vector;
                    vector3_2.y -= ((weaponType == FOALBIIKMNK.SniperRifle) ? 0.5f : 0f);
                    Vector3 vector2 = main.WorldToScreenPoint(vector3_2);
                    if (Render.smethod_1(vector2))
                    {
                        Vector2 vector3 = new Vector3(vector2.x, (float)Screen.height - vector2.y);
                        double num4 = (double)(vector3.x - (float)Screen.width / 2f);
                        double num5 = (double)(vector3.y - (float)Screen.height / 2f);
                        num4 /= 10.0;
                        num5 /= 10.0;
                        mouse_event(1, (int)num4, (int)num5, 0, 0);
                    }
                }
            }

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
                    this.humanBodyBones_0 = HumanBodyBones.Chest;
                }
                else if (!Menu.aimbot_HeadBoneEnabled)
                {
                    if (Menu.aimbot_NeckBoneEnabled)
                    {
                        this.humanBodyBones_0 = HumanBodyBones.Neck;
                    }
                }
                else
                {
                    this.humanBodyBones_0 = HumanBodyBones.Head;
                }
                if (Menu.mouseEvent_AimbotEnabled && Input.GetKey(this.keyCode_0))
                {
                    PlayerController playerController = smethod_0(Menu.aimbot_FOV);
                    this.animator_0 = playerController.GetComponent<Animator>();
                    Transform boneTransform = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                    this.vector3_1 = boneTransform.transform.position;
                    Camera.main.WorldToScreenPoint(this.vector3_1);
                    bool flag = !Render.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
                    this.method_3(boneTransform.transform.position + new Vector3(0f, 1.5f, 0f), playerController, Vector3.zero);
                }
                if (Menu.silentAim_Enabled && Input.GetKey(this.keyCode_0))
                {
                    if (Menu.aimbot_FovCircleEnabled)
                    {
                        PlayerController playerController2 = smethod_0(Menu.aimbot_FOV);
                        this.animator_0 = playerController2.GetComponent<Animator>();
                        Transform boneTransform2 = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                        this.vector3_1 = boneTransform2.transform.position;
                        Vector3 vector = Camera.main.WorldToScreenPoint(this.vector3_1);
                        bool flag2 = !Render.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
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
                        List<PlayerController> list = list_0.OrderBy((PlayerController x) => Vector3.Distance(x.transform.position, PlayerController.JPIGHMOLDBI.transform.position)).ToList<PlayerController>();
                        list.Remove(PlayerController.JPIGHMOLDBI);
                        PlayerController playerController3 = list.FirstOrDefault<PlayerController>();
                        this.animator_0 = playerController3.GetComponent<Animator>();
                        Transform boneTransform3 = this.animator_0.GetBoneTransform(this.humanBodyBones_0);
                        this.vector3_1 = boneTransform3.transform.position;
                        Vector3 vector2 = Camera.main.WorldToScreenPoint(this.vector3_1);
                        bool flag3 = !Render.smethod_0(Camera.main.transform.position, this.vector3_1 + new Vector3(0f, 1.2f, 0f));
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

            public void Update()
            {
                if (Menu.aimbotBind_LeftMouse)
                {
                    this.keyCode_0 = KeyCode.Mouse0;
                }
                if (Menu.aimbotBind_RightMouse)
                {
                    this.keyCode_0 = KeyCode.Mouse1;
                }
            }

            public static float float_0;

            private Animator animator_0;

            private HumanBodyBones humanBodyBones_0;

            public Vector3 vector3_0;

            public Vector3 vector3_1;

            private KeyCode keyCode_0;

            public float float_1 = 1f;

            public float oBdsgowxY = 2f;

            public float float_2 = 3f;

            public Camera camera_0 = Camera.main;

            public static List<PlayerController> list_0 = new List<PlayerController>();

            public static List<SupplyCrate> list_1 = new List<SupplyCrate>();

            public static List<Pickupable> list_2 = new List<Pickupable>();

            public bool zPyeNsjg7;

            public float float_3;

            public float float_4 = 3f;
        }
    }



