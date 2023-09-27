using System;
using System.Collections;
using System.Collections.Generic;
using Invector.CharacterController;
using JustPlay.Localization;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Localization;

namespace JustBad
{
    internal class Menu : MonoBehaviour
    {
        private void Awake()
        {
            base.StartCoroutine(UpdateRegionInfo());
            base.StartCoroutine(UpdateLobbyPlayers());
            rect_0 = new Rect(vector2_0.x + 100f, vector2_0.y + 100f, float_0, float_1);
            rect_1 = new Rect(rect_0.x, rect_0.y - rect_0.height / 10f, rect_0.width, 70f);
            int_1 = 0;
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00005678 File Offset: 0x00003878
        private void Start()
        {
            UiManager uiManager = UnityEngine.Object.FindObjectOfType<UiManager>();
            uiManager.ShowToast(new DefaultedLocalizedString(new LocalizedString("", ""), "JustBad Paid - Full Deobf By Kanati <3"), 10f);
            FirebaseManager firebaseManager = UnityEngine.Object.FindObjectOfType<FirebaseManager>();
            ServerSkinsEntry skins = firebaseManager.JLPGEKNJLMG.Skins;
            string text = "lol.1v1.playeremotes.pack.";
            string text2 = "lol.1v1.playerstickers.pack.";
            if (skins.EquippedWeaponSkins.Contains("lol.1v1.weaponskins.melee.pickaxe.default"))
            {
                skins.EquippedWeaponSkins.Remove("lol.1v1.weaponskins.melee.pickaxe.default");
            }
            skins.EquippedWeaponSkins.Add("lol.1v1.weaponskins.melee.pickaxe.scifihammer");
            skins.WeaponSkins.Add("lol.1v1.weaponskins.melee.pickaxe.scifihammer");
            for (int i = 1; i <= 50; i++)
            {
                firebaseManager.JLPGEKNJLMG.Skins.OwnedEmotes.Add(string.Format("{0}{1}", text, i));
            }
            for (int j = 1; j <= 80; j++)
            {
                firebaseManager.JLPGEKNJLMG.Skins.OwnedEmotes.Add(string.Format("{0}{1}", text2, j));
            }
        }

        // Token: 0x06000052 RID: 82 RVA: 0x000022E0 File Offset: 0x000004E0
        public System.Collections.IEnumerator UpdateRegionInfo()
        {
            return null;
        }

        // Token: 0x06000053 RID: 83 RVA: 0x000022EF File Offset: 0x000004EF
        public System.Collections.IEnumerator UpdateLobbyPlayers()
        {
            return null;
        }

        // Token: 0x06000054 RID: 84 RVA: 0x000057A4 File Offset: 0x000039A4
        public static Color RainbowEffect()
        {
            float time = Time.time;
            return Color.HSVToRGB(time % 1f, 1f, 1f);
        }

        // Token: 0x06000055 RID: 85 RVA: 0x000057D8 File Offset: 0x000039D8
        public float NormalizeValueInRange(float float_2, float float_3, float float_4)
        {
            float num = float_4 - float_3;
            float num2 = (float_2 - float_3) / num;
            if (num2 < 0f)
            {
                num2 = 0f;
            }
            else if (num2 > 1f)
            {
                num2 = 1f;
            }
            return num2;
        }

        // Token: 0x06000056 RID: 86 RVA: 0x00005820 File Offset: 0x00003A20
        private void method_0()
        {
            if (Input.GetMouseButtonDown(0))
            {
                rect_1 = new Rect(rect_0.x, rect_0.y - rect_0.height / 10f, rect_0.width, 70f);
                if (Event.current.mousePosition.x >= rect_1.x && Event.current.mousePosition.x <= rect_1.x + rect_1.width && Event.current.mousePosition.y >= rect_1.y && Event.current.mousePosition.y <= rect_1.y + rect_1.height)
                {
                    vector2_1.x = Event.current.mousePosition.x - rect_0.x;
                    vector2_1.y = Event.current.mousePosition.y - rect_0.y;
                    bool_1 = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                bool_1 = false;
            }
        }

        // Token: 0x06000057 RID: 87 RVA: 0x00005970 File Offset: 0x00003B70
        private void OnGUI()
        {
            if (bool_1)
            {
                rect_0.x = Event.current.mousePosition.x - vector2_1.x;
                rect_0.y = Event.current.mousePosition.y - vector2_1.y;
            }
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontStyle = FontStyle.Bold;
            GUIStyle guistyle2 = new GUIStyle(GUI.skin.textField);
            guistyle2.normal.textColor = Color.white;
            guistyle2.fontStyle = FontStyle.Bold;
            GUIStyle guistyle3 = new GUIStyle(GUI.skin.button);
            guistyle3.fontStyle = cheat_UniversalfontStyle;
            guistyle3.fontSize = cheat_UniversalFontSize + 5;
            GUIStyle guistyle4 = new GUIStyle(GUI.skin.label);
            guistyle4.fontStyle = cheat_UniversalfontStyle;
            guistyle4.fontSize = cheat_UniversalFontSize + 2;
            GUIStyle guistyle5 = new GUIStyle(GUI.skin.label);
            guistyle5.alignment = TextAnchor.MiddleCenter;
            guistyle5.fontStyle = cheat_UniversalfontStyle;
            guistyle5.fontSize = cheat_UniversalFontSize + 25;
            guistyle5.normal.textColor = Color.white;
            if (!bool_0)
            {
                GUIStyle guistyle6 = new GUIStyle(GUI.skin.label);
                guistyle6.fontStyle = cheat_UniversalfontStyle;
                guistyle6.fontSize = cheat_UniversalFontSize;
                guistyle6.normal.textColor = RainbowEffect();
                GUI.Label(new Rect(0f, 0f, 300f, 100f), "JustBad - Full Deobf By Kanati <3", guistyle6);
            }
            else
            {
                if (bool_0)
                {
                    Cursor.visible = true;
                }
                Color black = Color.black;
                black.a = 0.3f;
                GUI.color = black;
                GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), Texture2D.whiteTexture, 0);
                GUI.color = Color.white;
                Color red = Color.red;
                GUI.color = red;
                GUI.backgroundColor = red;
                Rect rect = new Rect(rect_0.x, rect_0.y - rect_0.height / 10f, rect_0.width, 70f);
                GUI.DrawTexture(rect, Texture2D.whiteTexture, 0);
                GUI.color = Color.white;
                Color color = new Color(0.08235294f, 0.08235294f, 0.09019608f);
                GUI.color = color;
                GUI.backgroundColor = color;
                GUI.DrawTexture(rect_0, Texture2D.whiteTexture, 0);
                GUI.color = Color.white;
                if (rect_0.x < 0f || rect_0.y < 0f || rect_0.x + rect_0.width > (float)Screen.width || rect_0.y + rect_0.height > (float)Screen.height)
                {
                    rect_0.x = 0f;
                    rect_0.y = 0f + rect.height;
                }
                Color black2 = Color.black;
                GUI.color = black2;
                GUI.backgroundColor = black2;
                Rect rect2 = new Rect(rect_0.x - rect_0.width + 700f, rect_0.y, 200f, rect_0.height);
                GUI.DrawTexture(rect2, Texture2D.whiteTexture, 0);
                GUI.color = Color.white;
                GUI.Label(new Rect(rect.x + (rect.width - 220f) / 2f, rect.y + rect.height - 75f, 260f, 100f), "JustBad <3", guistyle5);
                GUI.Label(new Rect(rect_0.x + rect_0.width - 170f, rect_0.y + rect_0.height - 20f, 200f, 100f), string.Format("Players In Region: {0}", int_0), guistyle4);
                string[] array = new string[] { "Combat", "Movement", "Visuals", "Misc", "Players", "Aimbot" };
                float num = 40f;
                float num2 = 10f;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == int_1)
                    {
                        GUI.contentColor = Color.white;
                        GUI.backgroundColor = Color.clear;
                    }
                    else
                    {
                        GUI.contentColor = Color.gray;
                        GUI.backgroundColor = Color.clear;
                    }
                    Rect rect3 = new Rect(rect_0.x, rect_0.y + 5f + (float)i * (num + num2), 200f, num);
                    if (GUI.Toggle(rect3, int_1 == i, new GUIContent(array[i]), guistyle3))
                    {
                        int_1 = i;
                    }
                    GUI.backgroundColor = Color.clear;
                }
                GUI.contentColor = Color.white;
                if (int_1 != 0)
                {
                    if (int_1 == 1)
                    {
                        Rect rect4 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                        if (GUI.Button(new Rect(rect4.x, rect4.y, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            noclipEnabled = !noclipEnabled;
                        }
                        Render.smethod_8(rect4.x, rect4.y, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect4.x + (noclipEnabled ? 40f : 2f), rect4.y + 2f, 18f, 18f, (!noclipEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect4.x + 70f, rect4.y + 4f), "Noclip (Caps)", Color.white, false, 13);
                        noclipSpeed = GUI.HorizontalSlider(new Rect(rect4.x, rect4.y + 30f, 100f, 15f), noclipSpeed, 0.5f, 2f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                        Render.smethod_8(rect4.x, rect4.y + 30f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                        Render.smethod_8(rect4.x, rect4.y + 30f, NormalizeValueInRange(noclipSpeed, 0.5f, 2f) * 100f, 22f, Color.green);
                        Render.smethod_7(new Vector2(rect4.x + NormalizeValueInRange(noclipSpeed, 1f, 5f) * 100f, rect4.y + 30f), string.Format("Noclip Speed: {0}", (int)noclipSpeed), Color.white, true, 12);
                        if (GUI.Button(new Rect(rect4.x, rect4.y + 60f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            developerFlyEnabled = !developerFlyEnabled;
                        }
                        Render.smethod_8(rect4.x, rect4.y + 60f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect4.x + (developerFlyEnabled ? 40f : 2f), rect4.y + 62f, 18f, 18f, (!developerFlyEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect4.x + 70f, rect4.y + 64f), "Developer Fly (G)", Color.white, false, 13);
                        developerFlySpeed = GUI.HorizontalSlider(new Rect(rect4.x, rect4.y + 90f, 100f, 15f), developerFlySpeed, 5f, 200f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                        Render.smethod_8(rect4.x, rect4.y + 90f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                        Render.smethod_8(rect4.x, rect4.y + 90f, NormalizeValueInRange(developerFlySpeed, 5f, 200f) * 100f, 22f, Color.green);
                        Render.smethod_7(new Vector2(rect4.x + NormalizeValueInRange(developerFlySpeed, 5f, 200f) * 100f, rect4.y + 90f), string.Format("Developer Fly Speed: {0}", (int)developerFlySpeed), Color.white, true, 12);
                        if (GUI.Button(new Rect(rect4.x, rect4.y + 120f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            changeJumpHeightEnabled = !changeJumpHeightEnabled;
                        }
                        Render.smethod_8(rect4.x, rect4.y + 120f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect4.x + ((!changeJumpHeightEnabled) ? 2f : 40f), rect4.y + 122f, 18f, 18f, (!changeJumpHeightEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect4.x + 70f, rect4.y + 124f), "Change Jump Height", Color.white, false, 13);
                        jumpHeight = GUI.HorizontalSlider(new Rect(rect4.x, rect4.y + 150f, 100f, 15f), jumpHeight, 5.5f, 50f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                        Render.smethod_8(rect4.x, rect4.y + 150f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                        Render.smethod_8(rect4.x, rect4.y + 150f, NormalizeValueInRange(jumpHeight, 5.5f, 50f) * 100f, 22f, Color.green);
                        Render.smethod_7(new Vector2(rect4.x + NormalizeValueInRange(jumpHeight, 5.5f, 50f) * 100f, rect4.y + 150f), string.Format("Jump Height: {0}", (int)jumpHeight), Color.white, true, 12);
                        if (GUI.Button(new Rect(rect4.x, rect4.y + 190f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            tpToVisiblePlayerEnabled = !tpToVisiblePlayerEnabled;
                        }
                        Render.smethod_8(rect4.x, rect4.y + 190f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect4.x + ((!tpToVisiblePlayerEnabled) ? 2f : 40f), rect4.y + 192f, 18f, 18f, tpToVisiblePlayerEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect4.x + 70f, rect4.y + 194f), "TP To Visible Player (T)", Color.white, false, 13);
                    }
                    else if (int_1 != 2)
                    {
                        if (int_1 != 3)
                        {
                            if (int_1 == 4)
                            {
                                Rect rect5 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                            }
                            else if (int_1 == 5)
                            {
                                Rect rect6 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                                GUI.backgroundColor = Color.white;
                                if (GUI.Button(new Rect(rect6.x, rect6.y, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    mouseEvent_AimbotEnabled = !mouseEvent_AimbotEnabled;
                                    silentAim_Enabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!mouseEvent_AimbotEnabled) ? 2f : 40f), rect6.y + 2f, 18f, 18f, mouseEvent_AimbotEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 4f), "Mouse Aimbot", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 30f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    silentAim_Enabled = !silentAim_Enabled;
                                    mouseEvent_AimbotEnabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 30f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!silentAim_Enabled) ? 2f : 40f), rect6.y + 32f, 18f, 18f, silentAim_Enabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 34f), "Silent Aimbot", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 60f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbotBind_LeftMouse = !aimbotBind_LeftMouse;
                                    aimbotBind_RightMouse = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 60f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbotBind_LeftMouse ? 40f : 2f), rect6.y + 62f, 18f, 18f, (!aimbotBind_LeftMouse) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 64f), "Bind To Left Mouse", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 90f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbotBind_RightMouse = !aimbotBind_RightMouse;
                                    aimbotBind_LeftMouse = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 90f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbotBind_RightMouse ? 40f : 2f), rect6.y + 92f, 18f, 18f, aimbotBind_RightMouse ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 94f), "Bind To Right Mouse", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 120f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_FovCircleEnabled = !aimbot_FovCircleEnabled;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 120f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbot_FovCircleEnabled ? 40f : 2f), rect6.y + 122f, 18f, 18f, aimbot_FovCircleEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 124f), "Draw Fov", Color.white, false, 13);
                                aimbot_FOV = GUI.HorizontalSlider(new Rect(rect6.x, rect6.y + 150f, 100f, 15f), aimbot_FOV, 10f, 500f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                                Render.smethod_8(rect6.x, rect6.y + 150f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                                Render.smethod_8(rect6.x, rect6.y + 150f, NormalizeValueInRange(aimbot_FOV, 10f, 500f) * 100f, 22f, Color.green);
                                Render.smethod_7(new Vector2(rect6.x + NormalizeValueInRange(aimbot_FOV, 10f, 500f) * 100f, rect6.y + 150f), string.Format("Fov: {0}", (int)aimbot_FOV), Color.white, true, 12);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 180f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_SmoothingEnabled = !aimbot_SmoothingEnabled;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 180f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!aimbot_SmoothingEnabled) ? 2f : 40f), rect6.y + 182f, 18f, 18f, aimbot_SmoothingEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 184f), "Aimbot Smoothing", Color.white, false, 13);
                                mouseAimbot_Smoothing = GUI.HorizontalSlider(new Rect(rect6.x, rect6.y + 210f, 100f, 15f), mouseAimbot_Smoothing, 0f, 100f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                                Render.smethod_8(rect6.x, rect6.y + 210f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                                Render.smethod_8(rect6.x, rect6.y + 210f, NormalizeValueInRange(mouseAimbot_Smoothing, 0f, 100f) * 100f, 22f, Color.green);
                                Render.smethod_7(new Vector2(rect6.x + NormalizeValueInRange(mouseAimbot_Smoothing, 0f, 100f) * 100f, rect6.y + 210f), string.Format("Smoothing: {0}", (int)mouseAimbot_Smoothing), Color.white, true, 12);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 240f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_VisCheckEnabled = !aimbot_VisCheckEnabled;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 240f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbot_VisCheckEnabled ? 40f : 2f), rect6.y + 242f, 18f, 18f, (!aimbot_VisCheckEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 244f), "Visiblity Check", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 270f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_HeadBoneEnabled = !aimbot_HeadBoneEnabled;
                                    aimbot_NeckBoneEnabled = false;
                                    aimbot_ChestBoneEnabled = false;
                                    aimbot_RandomBoneEnabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 270f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbot_HeadBoneEnabled ? 40f : 2f), rect6.y + 272f, 18f, 18f, (!aimbot_HeadBoneEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 274f), "Target Head", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 300f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_NeckBoneEnabled = !aimbot_NeckBoneEnabled;
                                    aimbot_HeadBoneEnabled = false;
                                    aimbot_ChestBoneEnabled = false;
                                    aimbot_RandomBoneEnabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 300f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!aimbot_NeckBoneEnabled) ? 2f : 40f), rect6.y + 302f, 18f, 18f, aimbot_NeckBoneEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 304f), "Target Neck", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 330f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_ChestBoneEnabled = !aimbot_ChestBoneEnabled;
                                    aimbot_NeckBoneEnabled = false;
                                    aimbot_HeadBoneEnabled = false;
                                    aimbot_RandomBoneEnabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 330f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!aimbot_ChestBoneEnabled) ? 2f : 40f), rect6.y + 332f, 18f, 18f, aimbot_ChestBoneEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 334f), "Target Chest", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 360f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbot_RandomBoneEnabled = !aimbot_RandomBoneEnabled;
                                    aimbot_ChestBoneEnabled = false;
                                    aimbot_NeckBoneEnabled = false;
                                    aimbot_HeadBoneEnabled = false;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 360f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + (aimbot_RandomBoneEnabled ? 40f : 2f), rect6.y + 362f, 18f, 18f, (!aimbot_RandomBoneEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 364f), "Randomise Target Bone", Color.white, false, 13);
                                if (GUI.Button(new Rect(rect6.x, rect6.y + 390f, 60f, 22f), new GUIContent(""), guistyle))
                                {
                                    aimbotTargetLinesEnabled = !aimbotTargetLinesEnabled;
                                }
                                Render.smethod_8(rect6.x, rect6.y + 390f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                                Render.smethod_8(rect6.x + ((!aimbotTargetLinesEnabled) ? 2f : 40f), rect6.y + 392f, 18f, 18f, aimbotTargetLinesEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                                Render.smethod_7(new Vector2(rect6.x + 70f, rect6.y + 394f), "Draw Aimbot Target", Color.white, false, 13);
                            }
                        }
                        else
                        {
                            Rect rect7 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                            if (GUI.Button(new Rect(rect7.x, rect7.y, 60f, 22f), new GUIContent(""), guistyle))
                            {
                                spoofUserIdEnabled = !spoofUserIdEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + (spoofUserIdEnabled ? 40f : 2f), rect7.y + 2f, 18f, 18f, spoofUserIdEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 4f), "Spoof User ID (Recommended)", Color.white, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 30f, 60f, 22f), new GUIContent(""), guistyle))
                            {
                                changeEnemySkinsEnabled = !changeEnemySkinsEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 30f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + ((!changeEnemySkinsEnabled) ? 2f : 40f), rect7.y + 32f, 18f, 18f, changeEnemySkinsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 34f), "Change Enemy Skins", Color.white, false, 13);
                            customNicknameButtonPressed = GUI.Button(new Rect(rect7.x + 130f, rect7.y + 60f, 120f, 22f), new GUIContent(""), guistyle);
                            Render.smethod_8(rect7.x + 130f, rect7.y + 60f, 120f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 130f + 60f, rect7.y + 60f), "Change Nickname", Color.white, true, 13);
                            Render.smethod_8(rect7.x, rect7.y + 60f, 120f, 22f, new Color(0.25f, 0.26f, 0.27f, 1f));
                            GUI.backgroundColor = Color.clear;
                            GUI.color = Color.white;
                            Rect rect8 = new Rect(rect7.x, rect7.y + 60f, 120f, 22f);
                            GUILayout.BeginArea(rect8);
                            customNickname = GUILayout.TextField(customNickname, guistyle2, Array.Empty<GUILayoutOption>());
                            GUILayout.EndArea();
                            skinChangerButtonPressed = GUI.Button(new Rect(rect7.x + 130f, rect7.y + 90f, 120f, 22f), new GUIContent(""), guistyle);
                            Render.smethod_8(rect7.x + 130f, rect7.y + 90f, 120f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 130f + 60f, rect7.y + 90f), "Change Skin", Color.white, true, 13);
                            Render.smethod_8(rect7.x, rect7.y + 90f, 120f, 22f, new Color(0.25f, 0.26f, 0.27f, 1f));
                            GUI.backgroundColor = Color.clear;
                            GUI.color = Color.white;
                            Rect rect9 = new Rect(rect7.x, rect7.y + 90f, 120f, 22f);
                            GUILayout.BeginArea(rect9);
                            selectedSkin = GUILayout.TextField(selectedSkin, guistyle2, Array.Empty<GUILayoutOption>());
                            GUILayout.EndArea();
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 120f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                kickAllEnabled = !kickAllEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 120f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + (kickAllEnabled ? 40f : 2f), rect7.y + 122f, 18f, 18f, kickAllEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 124f), "Kick Players Connecting To Current Server", Color.white, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 150f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                spawnDomeEnabled = !spawnDomeEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 150f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + ((!spawnDomeEnabled) ? 2f : 40f), rect7.y + 152f, 18f, 18f, spawnDomeEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 154f), "Build Giant Circle (U)", Color.white, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 180f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                rapidFireForAllEnabled = !rapidFireForAllEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 180f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + ((!rapidFireForAllEnabled) ? 2f : 40f), rect7.y + 182f, 18f, 18f, (!rapidFireForAllEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 184f), "Give Lobby Rapidfire", Color.yellow, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 210f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                autoDeclineFriendsEnabled = !autoDeclineFriendsEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 210f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + (autoDeclineFriendsEnabled ? 40f : 2f), rect7.y + 212f, 18f, 18f, (!autoDeclineFriendsEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 214f), "Auto Decline Friends", Color.white, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 240f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                lagEnemiesEnabled = !lagEnemiesEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 240f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + ((!lagEnemiesEnabled) ? 2f : 40f), rect7.y + 242f, 18f, 18f, (!lagEnemiesEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 244f), "Lag Enemies", Color.white, false, 13);
                            if (GUI.Button(new Rect(rect7.x, rect7.y + 270f, 160f, 22f), new GUIContent(""), guistyle))
                            {
                                boogeyBombEnabled = !boogeyBombEnabled;
                            }
                            Render.smethod_8(rect7.x, rect7.y + 270f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                            Render.smethod_8(rect7.x + (boogeyBombEnabled ? 40f : 2f), rect7.y + 272f, 18f, 18f, boogeyBombEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                            Render.smethod_7(new Vector2(rect7.x + 70f, rect7.y + 274f), "Boogey Bomb Lobby", Color.white, false, 13);
                        }
                    }
                    else
                    {
                        Rect rect10 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                        if (GUI.Button(new Rect(rect10.x, rect10.y, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espEnabled = !espEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espEnabled) ? 2f : 40f), rect10.y + 2f, 18f, 18f, (!espEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 4f), "Enemy ESP", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 30f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espPlayerNameEnabled = !espPlayerNameEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 30f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espPlayerNameEnabled) ? 2f : 40f), rect10.y + 32f, 18f, 18f, (!espPlayerNameEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 34f), "ESP Player Name", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 60f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espPlayerHealthEnabled = !espPlayerHealthEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 60f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espPlayerHealthEnabled) ? 2f : 40f), rect10.y + 62f, 18f, 18f, (!espPlayerHealthEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 64f), "ESP Health Bar", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 90f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espPlayerRankEnabled = !espPlayerRankEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 90f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espPlayerRankEnabled) ? 2f : 40f), rect10.y + 92f, 18f, 18f, (!espPlayerRankEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 94f), "ESP Player Rank", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 120f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espPlayerWeaponEnabled = !espPlayerWeaponEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 120f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espPlayerWeaponEnabled) ? 2f : 40f), rect10.y + 122f, 18f, 18f, (!espPlayerWeaponEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 124f), "ESP Player Current Weapon", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 150f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espPlayerDistanceEnabled = !espPlayerDistanceEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 150f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!espPlayerDistanceEnabled) ? 2f : 40f), rect10.y + 152f, 18f, 18f, espPlayerDistanceEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 154f), "ESP Player Distance", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 180f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            chamsEnabled = !chamsEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 180f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!chamsEnabled) ? 2f : 40f), rect10.y + 182f, 18f, 18f, chamsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 184f), "Enemy Chams", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 210f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            pickupableEspWeaponsEnabled = !pickupableEspWeaponsEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 210f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (pickupableEspWeaponsEnabled ? 40f : 2f), rect10.y + 212f, 18f, 18f, pickupableEspWeaponsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 214f), "Pickupable ESP Weapons", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 240f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            pickupableEspMaterialsEnabled = !pickupableEspMaterialsEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 240f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (pickupableEspMaterialsEnabled ? 40f : 2f), rect10.y + 242f, 18f, 18f, (!pickupableEspMaterialsEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 244f), "Pickupable ESP Materials", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 270f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            pickupableEspAmmoEnabled = !pickupableEspAmmoEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 270f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (pickupableEspAmmoEnabled ? 40f : 2f), rect10.y + 272f, 18f, 18f, pickupableEspAmmoEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 274f), "Pickupable ESP Ammo", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 300f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            chestEspEnabled = !chestEspEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 300f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (chestEspEnabled ? 40f : 2f), rect10.y + 302f, 18f, 18f, chestEspEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 304f), "Chest ESP", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 330f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            rainbowPlayerEnabled = !rainbowPlayerEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 330f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!rainbowPlayerEnabled) ? 2f : 40f), rect10.y + 332f, 18f, 18f, rainbowPlayerEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 334f), "Rainbow Player", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 360f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            cameraZoomEnabled = !cameraZoomEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 360f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + ((!cameraZoomEnabled) ? 2f : 40f), rect10.y + 362f, 18f, 18f, (!cameraZoomEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 364f), "Camera Zoom (X)", Color.white, false, 13);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 390f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            customFovEnabled = !customFovEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 390f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (customFovEnabled ? 40f : 2f), rect10.y + 392f, 18f, 18f, (!customFovEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 394f), "Change Field Of View", Color.white, false, 13);
                        cameraFov = GUI.HorizontalSlider(new Rect(rect10.x, rect10.y + 420f, 100f, 15f), cameraFov, 50.53402f, 150f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                        Render.smethod_8(rect10.x, rect10.y + 420f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                        Render.smethod_8(rect10.x, rect10.y + 420f, NormalizeValueInRange(cameraFov, 50.53402f, 150f) * 100f, 22f, Color.green);
                        Render.smethod_7(new Vector2(rect10.x + NormalizeValueInRange(cameraFov, 50.53402f, 150f) * 100f, rect10.y + 420f), string.Format("Current FOV: {0}", (int)cameraFov), Color.white, true, 12);
                        if (GUI.Button(new Rect(rect10.x, rect10.y + 460f, 60f, 22f), new GUIContent(""), guistyle))
                        {
                            espSnaplinesEnabled = !espSnaplinesEnabled;
                        }
                        Render.smethod_8(rect10.x, rect10.y + 460f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                        Render.smethod_8(rect10.x + (espSnaplinesEnabled ? 40f : 2f), rect10.y + 462f, 18f, 18f, (!espSnaplinesEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                        Render.smethod_7(new Vector2(rect10.x + 70f, rect10.y + 464f), "Enemy Snaplines", Color.white, false, 13);
                    }
                }
                else
                {
                    Rect rect11 = new Rect(rect_0.x + rect2.width + 25f, rect.y + 82f, 220f, 30f);
                    if (GUI.Button(new Rect(rect11.x, rect11.y, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        godmodeEnabled = !godmodeEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!godmodeEnabled) ? 2f : 40f), rect11.y + 2f, 18f, 18f, godmodeEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 4f), "Infinite Player Health", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 30f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        materialsAndAmmoEnabled = !materialsAndAmmoEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 30f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!materialsAndAmmoEnabled) ? 2f : 40f), rect11.y + 32f, 18f, 18f, materialsAndAmmoEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 34f), "Infinite Ammo/Materials", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 60f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        rapidFireEnabled = !rapidFireEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 60f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!rapidFireEnabled) ? 2f : 40f), rect11.y + 62f, 18f, 18f, (!rapidFireEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 64f), "Rapidfire", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 90f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        destroyAllBuildsEnabled = !destroyAllBuildsEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 90f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + (destroyAllBuildsEnabled ? 40f : 2f), rect11.y + 92f, 18f, 18f, destroyAllBuildsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 94f), "Destroy All Buildings (V)", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 120f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        killAllPlayersEnabled = !killAllPlayersEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 120f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + (killAllPlayersEnabled ? 40f : 2f), rect11.y + 122f, 18f, 18f, killAllPlayersEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 124f), "Kill All Enemies (P)", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 150f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        removeEnemyWeaponsEnabled = !removeEnemyWeaponsEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 150f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + (removeEnemyWeaponsEnabled ? 40f : 2f), rect11.y + 152f, 18f, 18f, removeEnemyWeaponsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 154f), "Remove All Enemies Weapons (K)", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 180f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        onlyHeadshotsEnabled = !onlyHeadshotsEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 180f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!onlyHeadshotsEnabled) ? 2f : 40f), rect11.y + 182f, 18f, 18f, onlyHeadshotsEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 184f), "Only Hit Headshots", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 210f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        aimAssistControllerOnlyEnabled = !aimAssistControllerOnlyEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 210f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!aimAssistControllerOnlyEnabled) ? 2f : 40f), rect11.y + 212f, 18f, 18f, (!aimAssistControllerOnlyEnabled) ? new Color(0.25f, 0.26f, 0.27f, 1f) : new Color(0f, 128f, 0f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 214f), "Increase Aim Assist (Controller Only)", Color.white, false, 13);
                    if (GUI.Button(new Rect(rect11.x, rect11.y + 240f, 60f, 22f), new GUIContent(""), guistyle))
                    {
                        changeEnemySizeEnabled = !changeEnemySizeEnabled;
                    }
                    Render.smethod_8(rect11.x, rect11.y + 240f, 60f, 22f, new Color(0.15f, 0.16f, 0.17f, 1f));
                    Render.smethod_8(rect11.x + ((!changeEnemySizeEnabled) ? 2f : 40f), rect11.y + 242f, 18f, 18f, changeEnemySizeEnabled ? new Color(0f, 128f, 0f) : new Color(0.25f, 0.26f, 0.27f, 1f));
                    Render.smethod_7(new Vector2(rect11.x + 70f, rect11.y + 244f), "Change Enemy Size/Hitbox", Color.white, false, 13);
                    changeEnemySizeSlider = GUI.HorizontalSlider(new Rect(rect11.x, rect11.y + 270f, 100f, 15f), changeEnemySizeSlider, 0.95f, 5f, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);
                    Render.smethod_8(rect11.x, rect11.y + 270f, 100f, 22f, new Color(0.08f, 0.09f, 0.1f, 1f));
                    Render.smethod_8(rect11.x, rect11.y + 270f, NormalizeValueInRange(changeEnemySizeSlider, 0.95f, 5f) * 100f, 22f, Color.green);
                    Render.smethod_7(new Vector2(rect11.x + NormalizeValueInRange(changeEnemySizeSlider, 0.95f, 5f) * 100f, rect11.y + 270f), string.Format("Enemy Size: {0}", (int)changeEnemySizeSlider), Color.white, true, 12);
                }
            }
        }

        // Token: 0x06000058 RID: 88 RVA: 0x0000A0D8 File Offset: 0x000082D8
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                bool_0 = !bool_0;
            }
            if (bool_0)
            {
                method_0();
            }
        }

        // Token: 0x0400004B RID: 75
        public static string enemyFirebaseID;

        // Token: 0x0400004C RID: 76
        public static string enemyNickname;

        // Token: 0x0400004D RID: 77
        public static string selectedSkin = "";

        // Token: 0x0400004E RID: 78
        public static string customNickname = "";

        // Token: 0x0400004F RID: 79
        public static string skinIdList = "https://pastebin.com/L0jukbDQ";

        // Token: 0x04000050 RID: 80
        public static float jumpHeight = 25f;

        // Token: 0x04000051 RID: 81
        public static float cameraFov = 50.53402f;

        // Token: 0x04000052 RID: 82
        public static float aimbot_FOV = 250f;

        // Token: 0x04000053 RID: 83
        public static float noclipSpeed = 1.5f;

        // Token: 0x04000054 RID: 84
        public static float mouseAimbot_Smoothing = 50f;

        // Token: 0x04000055 RID: 85
        public static float developerFlySpeed = 100f;

        // Token: 0x04000056 RID: 86
        public static float changeEnemySizeSlider = 25f;

        // Token: 0x04000057 RID: 87
        public vThirdPersonController thirdPersonController;

        // Token: 0x04000058 RID: 88
        public static Vector3 normalEnemySize = new Vector3(0.95f, 0.95f, 0.95f);

        // Token: 0x04000059 RID: 89
        public static Vector3 enemySliderSizeMin = new Vector3(0.95f, 0.95f, 0.95f);

        // Token: 0x0400005A RID: 90
        public static Vector3 enemySizeSliderMax = new Vector3(50f, 50f, 50f);

        // Token: 0x0400005B RID: 91
        private List<ConnectionHandler> list_0 = new List<ConnectionHandler>();

        // Token: 0x0400005C RID: 92
        private List<PlayerController> list_1 = new List<PlayerController>();

        // Token: 0x0400005D RID: 93
        private static int int_0;

        // Token: 0x0400005E RID: 94
        public static bool farmWinsEnabled = false;

        // Token: 0x0400005F RID: 95
        public static bool changeEnemySizeEnabled = false;

        // Token: 0x04000060 RID: 96
        public static bool rapidFireForAllEnabled = false;

        // Token: 0x04000061 RID: 97
        public static bool removeEnemyWeaponsEnabled = false;

        // Token: 0x04000062 RID: 98
        public static bool killAllPlayersEnabled = false;

        // Token: 0x04000063 RID: 99
        public static bool onlyHeadshotsEnabled = false;

        // Token: 0x04000064 RID: 100
        public static bool aimAssistControllerOnlyEnabled = false;

        // Token: 0x04000065 RID: 101
        public static bool rapidFireEnabled = false;

        // Token: 0x04000066 RID: 102
        public static bool materialsAndAmmoEnabled = false;

        // Token: 0x04000067 RID: 103
        public static bool godmodeEnabled = false;

        // Token: 0x04000068 RID: 104
        public static bool destroyAllBuildsEnabled = false;

        // Token: 0x04000069 RID: 105
        public static bool changeJumpHeightEnabled = false;

        // Token: 0x0400006A RID: 106
        public static bool tpToVisiblePlayerEnabled = false;

        // Token: 0x0400006B RID: 107
        public static bool spinbotEnabled = false;

        // Token: 0x0400006C RID: 108
        public static bool noclipEnabled = false;

        // Token: 0x0400006D RID: 109
        public static bool developerFlyEnabled = false;

        // Token: 0x0400006E RID: 110
        public static bool espSnaplinesEnabled = false;

        // Token: 0x0400006F RID: 111
        public static bool aimbotTargetLinesEnabled = false;

        // Token: 0x04000070 RID: 112
        public static bool customFovEnabled = false;

        // Token: 0x04000071 RID: 113
        public static bool chamsEnabled = false;

        // Token: 0x04000072 RID: 114
        public static bool pickupableEspWeaponsEnabled = false;

        // Token: 0x04000073 RID: 115
        public static bool pickupableEspMaterialsEnabled = false;

        // Token: 0x04000074 RID: 116
        public static bool pickupableEspAmmoEnabled = false;

        // Token: 0x04000075 RID: 117
        public static bool chestEspEnabled = false;

        // Token: 0x04000076 RID: 118
        public static bool cameraZoomEnabled = false;

        // Token: 0x04000077 RID: 119
        public static bool espEnabled = false;

        // Token: 0x04000078 RID: 120
        public static bool espPlayerRankEnabled = false;

        // Token: 0x04000079 RID: 121
        public static bool espPlayerNameEnabled = false;

        // Token: 0x0400007A RID: 122
        public static bool espPlayerHealthEnabled = false;

        // Token: 0x0400007B RID: 123
        public static bool espPlayerDistanceEnabled = false;

        // Token: 0x0400007C RID: 124
        public static bool espPlayerWeaponEnabled = false;

        // Token: 0x0400007D RID: 125
        public static bool rainbowPlayerEnabled = false;

        // Token: 0x0400007E RID: 126
        public static bool boogeyBombEnabled = false;

        // Token: 0x0400007F RID: 127
        public static bool changeEnemyStateEnabled = false;

        // Token: 0x04000080 RID: 128
        public static bool spawnDomeEnabled = false;

        // Token: 0x04000081 RID: 129
        public static bool loadConfigButtonPressed;

        // Token: 0x04000082 RID: 130
        public static bool saveConfigButtonPressed;

        // Token: 0x04000083 RID: 131
        public static bool kickAllEnabled = false;

        // Token: 0x04000084 RID: 132
        public static bool lagEnemiesEnabled = false;

        // Token: 0x04000085 RID: 133
        public static bool isConfirmScreenShowing = false;

        // Token: 0x04000086 RID: 134
        public static bool removeAllFriendsCONFIRMButtonPressed = false;

        // Token: 0x04000087 RID: 135
        public static bool removeAllFriendsNOButtonPressed = false;

        // Token: 0x04000088 RID: 136
        public static bool removeAllFriendsButtonPressed = false;

        // Token: 0x04000089 RID: 137
        public static bool autoDeclineFriendsEnabled = false;

        // Token: 0x0400008A RID: 138
        public static bool spoofUserIdEnabled = true;

        // Token: 0x0400008B RID: 139
        public static bool changeEnemySkinsEnabled = false;

        // Token: 0x0400008C RID: 140
        public static bool skinChangerButtonPressed = false;

        // Token: 0x0400008D RID: 141
        public static bool aimbot_PredictionEnabled = false;

        // Token: 0x0400008E RID: 142
        public static bool managePlayerEnabled = false;

        // Token: 0x0400008F RID: 143
        public static bool aimbot_RandomBoneEnabled = false;

        // Token: 0x04000090 RID: 144
        public static bool aimbot_SmoothingEnabled = false;

        // Token: 0x04000091 RID: 145
        public static bool aimbot_VisCheckEnabled = false;

        // Token: 0x04000092 RID: 146
        public static bool aimbot_FovCircleEnabled = false;

        // Token: 0x04000093 RID: 147
        public static bool silentAim_Enabled = false;

        // Token: 0x04000094 RID: 148
        public static bool mouseEvent_AimbotEnabled = false;

        // Token: 0x04000095 RID: 149
        public static bool aimbot_ChestBoneEnabled = false;

        // Token: 0x04000096 RID: 150
        public static bool aimbot_HeadBoneEnabled = true;

        // Token: 0x04000097 RID: 151
        public static bool aimbot_NeckBoneEnabled = false;

        // Token: 0x04000098 RID: 152
        public static bool aimbotBind_RightMouse = true;

        // Token: 0x04000099 RID: 153
        public static bool aimbotBind_LeftMouse = false;

        // Token: 0x0400009A RID: 154
        public static float aimbot_PredictionDelay;

        // Token: 0x0400009B RID: 155
        public static bool kickAllPlayersButtonPressed = false;

        // Token: 0x0400009C RID: 156
        public static bool tpToPlayerButtonPressed = false;

        // Token: 0x0400009D RID: 157
        public static bool lobbyPlayerOptionsButtonPressed = false;

        // Token: 0x0400009E RID: 158
        public static bool customNicknameButtonPressed = false;

        // Token: 0x0400009F RID: 159
        public static bool skinIdListButtonPressed = false;

        // Token: 0x040000A0 RID: 160
        private int int_1 = 0;

        // Token: 0x040000A1 RID: 161
        private bool bool_0 = true;

        // Token: 0x040000A2 RID: 162
        private bool bool_1 = false;

        // Token: 0x040000A3 RID: 163
        private Rect rect_0;

        // Token: 0x040000A4 RID: 164
        private Rect rect_1;

        // Token: 0x040000A5 RID: 165
        private Vector2 vector2_0;

        // Token: 0x040000A6 RID: 166
        private float float_0 = 700f;

        // Token: 0x040000A7 RID: 167
        private float float_1 = 700f;

        // Token: 0x040000A8 RID: 168
        private Vector2 vector2_1;

        // Token: 0x040000A9 RID: 169
        public GUIStyle cheat_ToggleBoxStyle;

        // Token: 0x040000AA RID: 170
        public FontStyle cheat_UniversalfontStyle = FontStyle.Bold;

        // Token: 0x040000AB RID: 171
        public static int cheat_UniversalFontSize = 13;

        // Token: 0x040000AC RID: 172
        public Rect toggle_Positioning;

        // Token: 0x040000AD RID: 173
        public static PlayerController playerToDisplayOptionsOn;

        // Token: 0x040000AE RID: 174
        public static string nickname;

        // Token: 0x040000AF RID: 175
        public static bool isPlayerListShowing;

        // Token: 0x040000B0 RID: 176
        public static bool leavePlayerOptionsScreen;
    }
}
