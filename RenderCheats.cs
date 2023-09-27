using JustBad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad_Deobf
{
    internal class RenderCheats : MonoBehaviour
    {
        private void OnGUI()
        {
            if (Menu.aimbot_FovCircleEnabled && Event.current.type == EventType.Repaint)
            {
                Render.WiEcgCkd9(Menu.RainbowEffect(), new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), Menu.aimbot_FOV);
            }
            if (Menu.chamsEnabled)
            {
                this.float_2 += Time.deltaTime;
                if (this.float_2 > this.float_1)
                {
                    this.float_2 = 0f;
                    foreach (PlayerController playerController in AimbotStuff.list_0)
                    {
                        if (playerController != null)
                        {
                            PlayerSkinManager skinManager = playerController.BEPNKGCPMGH;
                            foreach (Renderer renderer in skinManager.GetComponentsInChildren<Renderer>())
                            {
                                if (!(renderer == null) && !(renderer.material == null) && !(renderer.material.shader == null) && !(renderer.material.GetColor("_Color") == Color.red))
                                {
                                    renderer.material = new Material(Shader.Find("Hidden/Internal-Colored"))
                                    {
                                        hideFlags = HideFlags.DontSave
                                    };
                                    renderer.material.SetInt("_Cull", 0);
                                    renderer.material.SetInt("_ZWrite", 0);
                                    renderer.material.SetInt("_ZTest", 8);
                                    renderer.material.SetColor("_Color", Color.red);
                                }
                            }
                        }
                    }
                }
            }
            if (Menu.chestEspEnabled)
            {
                this.vJeIcWfxvt += Time.deltaTime;
                if (this.vJeIcWfxvt > this.float_3)
                {
                    this.vJeIcWfxvt = 0f;
                    foreach (SupplyCrate supplyCrate in AimbotStuff.list_1)
                    {
                        if (supplyCrate != null)
                        {
                            foreach (Renderer renderer2 in supplyCrate.GetComponentsInChildren<Renderer>())
                            {
                                if (!(renderer2 == null) && !(renderer2.material == null) && !(renderer2.material.shader == null) && !(renderer2.material.GetColor("_Color") == Color.yellow))
                                {
                                    renderer2.material = new Material(Shader.Find("Hidden/Internal-Colored"))
                                    {
                                        hideFlags = HideFlags.DontSave
                                    };
                                    renderer2.material.SetInt("_Cull", 0);
                                    renderer2.material.SetInt("_ZWrite", 0);
                                    renderer2.material.SetInt("_ZTest", 8);
                                    renderer2.material.SetColor("_Color", Color.yellow);
                                }
                            }
                        }
                    }
                }
            }
            if (Menu.espEnabled)
            {
                foreach (PlayerController playerController2 in AimbotStuff.list_0)
                {
                    Camera main = Camera.main;
                    bool flag = !Render.smethod_0(main.transform.position, playerController2.transform.position + new Vector3(0f, 1.2f, 0f));
                    Vector3 position = playerController2.transform.position;
                    Vector3 vector = main.WorldToScreenPoint(position + new Vector3(0f, 0.1f, 0f));
                    Vector3 vector2 = main.WorldToScreenPoint(position + new Vector3(0f, 1.5f, 0f));
                    Vector3 vector3 = main.WorldToScreenPoint(position + new Vector3(0f, 1.2f, 0f));
                    if (!(vector2 == Vector3.zero) && !(vector == Vector3.zero) && !(vector3 == Vector3.zero))
                    {
                        PlayerHealth health = playerController2.LBFGDDPCNOJ;
                        int currentHealth = health.KIDCEFIMCOO;
                        int currentArmor = health.MGGGAMGKCPL;
                        FILLDJIAOFC playerInfo = playerController2.NANIIDLBNJO;
                        WeaponsController weapons = playerController2.OFGEHBLDKHD;
                        WeaponModel currentWeapon = weapons.KOBBJGHNHKE;
                        bool jokiendpjbd = playerController2.NANIIDLBNJO.JOKIENDPJBD;
                        float num = Vector3.Distance(main.transform.position, position);
                        float num2 = Mathf.Abs(vector2.y - vector.y);
                        float num3 = (float)Screen.height - vector2.y;
                        if (Render.smethod_1(vector2))
                        {
                            Render.smethod_4(new Vector2(vector2.x, num3), num2 / 2f, num2, 2f, flag ? Color.green : Color.red, true);
                        }
                        Vector3 vector4 = main.WorldToScreenPoint(position);
                        vector4.y = (float)Screen.height - (vector4.y + 1f);
                        if (Render.smethod_1(vector4))
                        {
                            if (Menu.espPlayerHealthEnabled)
                            {
                                Render.smethod_5(new Vector2(vector4.x - 5f, vector4.y + 5f), (float)currentHealth, Color.green, Color.yellow, Color.red, true);
                                Render.smethod_5(new Vector2(vector4.x - 5f, vector4.y + 10f), (float)currentArmor, Color.blue, Color.blue, Color.blue, true);
                            }
                            if (Menu.espPlayerNameEnabled && playerInfo.CGAJDDOIJLM != null)
                            {
                                string text = playerInfo.CGAJDDOIJLM ?? "";
                                Render.smethod_7(vector4, text, flag ? Color.green : Color.red, true, 12);
                            }
                            if (Menu.espPlayerDistanceEnabled)
                            {
                                string text2 = string.Format("{0} Meters", num);
                                Render.smethod_7(new Vector2(vector4.x, vector4.y + 40f), text2, flag ? Color.green : Color.red, true, 12);
                            }
                            if (Menu.espPlayerRankEnabled && !jokiendpjbd)
                            {
                                string text3 = string.Format("Rank ({0})", playerInfo.PHPJKFOKCKM);
                                Render.smethod_7(new Vector2(vector4.x, vector4.y + 55f), text3, (!flag) ? Color.red : Color.green, true, 12);
                            }
                            if (Menu.espPlayerWeaponEnabled && currentWeapon != null)
                            {
                                string id = currentWeapon.HPDLLFCCEAJ;
                                Render.smethod_7(new Vector2(vector4.x, vector4.y + 65f), id, (!flag) ? Color.red : Color.green, true, 12);
                            }
                        }
                    }
                }
            }
            if (Menu.pickupableEspAmmoEnabled || Menu.pickupableEspMaterialsEnabled || Menu.pickupableEspWeaponsEnabled)
            {
                foreach (Pickupable pickupable in AimbotStuff.list_2)
                {
                    camera_0 = Camera.main;
                    Vector3 position2 = pickupable.transform.position;
                    Vector3 vector5 = camera_0.WorldToScreenPoint(position2);
                    if (vector5.z >= 0f)
                    {
                        vector5.y = (float)Screen.height - (vector5.y + 1f);
                        if (Menu.pickupableEspWeaponsEnabled)
                        {
                            Render.smethod_7(vector5, string.Format("Weapon", Array.Empty<object>()).Trim(), Color.green, true, 12);
                        }
                        if (Menu.pickupableEspAmmoEnabled)
                        {
                            Render.smethod_7(vector5, string.Format("Ammo", Array.Empty<object>()).Trim(), Color.yellow, true, 12);
                        }
                        if (Menu.pickupableEspMaterialsEnabled)
                        {
                            Render.smethod_7(vector5, string.Format("Materials", Array.Empty<object>()).Trim(), Color.blue, true, 12);
                        }
                        
                    }
                }
            }
            if (Menu.aimbotTargetLinesEnabled)
            {
                Camera main2 = Camera.main;
                PlayerController playerController3 = AimbotStuff.smethod_0(Menu.aimbot_FOV);
                Vector3 vector6 = playerController3.transform.position + new Vector3(0f, 1.5f, 0f);
                Vector3 vector7 = main2.WorldToScreenPoint(vector6);
                vector7.y = (float)Screen.height - (vector7.y + 1f);
                if (Render.smethod_1(vector7))
                {
                    Render.smethod_2(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), vector7, Menu.RainbowEffect(), 2f);
                }
            }
            if (Menu.espSnaplinesEnabled)
            {
                Camera main3 = Camera.main;
                foreach (PlayerController playerController4 in AimbotStuff.list_0)
                {
                    Vector3 vector8 = playerController4.transform.position + new Vector3(0f, 1.5f, 0f);
                    Vector3 vector9 = main3.WorldToScreenPoint(vector8);
                    vector9.y = (float)Screen.height - (vector9.y + 1f);
                    if (Render.smethod_1(vector9))
                    {
                        Render.smethod_2(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), vector9, Menu.RainbowEffect(), 2f);
                    }
                }
            }
        }

        // Token: 0x0600004E RID: 78 RVA: 0x00005490 File Offset: 0x00003690
        public void Update()
        {
            if (Menu.cameraZoomEnabled && Input.GetKeyDown(KeyCode.X))
            {
                this.float_0 = Camera.main.fieldOfView;
                this.vector3_0 = Camera.main.transform.position;
                Camera.main.fieldOfView = 5f;
                this.bool_0 = false;
            }
            if (!this.bool_0 && Menu.cameraZoomEnabled && Input.GetKeyUp(KeyCode.X))
            {
                Camera.main.fieldOfView = this.float_0;
                this.bool_0 = true;
            }
            if (Menu.rainbowPlayerEnabled)
            {
                PlayerController.JPIGHMOLDBI.OFGEHBLDKHD.ToggleRendererOutline(Menu.RainbowEffect());
                PlayerController.JPIGHMOLDBI.ABOOMEPGFEC.ToggleRendererRimOutline(Menu.RainbowEffect());
            }
            if (!Menu.customFovEnabled)
            {
                if (!Menu.customFovEnabled && !this.bool_1)
                {
                    Camera.main.fieldOfView = 50.53402f;
                    this.bool_1 = true;
                }
            }
            else
            {
                Camera.main.fieldOfView = Menu.cameraFov;
                this.bool_1 = false;
            }
        }

        // Token: 0x04000042 RID: 66
        public float float_0;

        // Token: 0x04000043 RID: 67
        public Vector3 vector3_0;

        // Token: 0x04000044 RID: 68
        private bool bool_0 = false;

        // Token: 0x04000045 RID: 69
        private bool bool_1;

        // Token: 0x04000046 RID: 70
        private static Camera camera_0;

        // Token: 0x04000047 RID: 71
        public float float_1 = 8f;

        // Token: 0x04000048 RID: 72
        public float float_2;

        // Token: 0x04000049 RID: 73
        public float float_3 = 8f;

        // Token: 0x0400004A RID: 74
        public float vJeIcWfxvt;
    }
}
