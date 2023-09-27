using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    internal class Render
    {
        static Render()
        {
            material_0.SetInt("_SrcBlend", 5);
            material_0.SetInt("_DstBlend", 10);
            material_0.SetInt("_Cull", 0);
            material_0.SetInt("_ZWrite", 0);
        }

        public static bool smethod_0(Vector3 vector3_0, Vector3 vector3_1)
        {
            Vector3 vector = vector3_1 - vector3_0;
            float num = vector.magnitude * 0.9f;
            return Physics.Raycast(new Ray(vector3_0, vector), num, PlayerController.JPIGHMOLDBI.OFGEHBLDKHD.JCDMCKDPDML, 0);
        }

        public static bool smethod_1(Vector3 vector3_0)
        {
            return vector3_0.y > 0.01f && vector3_0.y < (float)Screen.height - 5f && vector3_0.z > 0.01f;
        }

        public static void smethod_2(Vector2 vector2_0, Vector2 vector2_1, Color color_1, float float_0)
        {
            Color color = GUI.color;
            Vector2 vector = vector2_1 - vector2_0;
            float num = 57.29578f * Mathf.Atan(vector.y / vector.x);
            if (vector.x < 0f)
            {
                num += 180f;
            }
            int num2 = (int)Mathf.Ceil(float_0 / 2f);
            smethod_3(num, vector2_0);
            GUI.color = color_1;
            GUI.DrawTexture(new Rect(vector2_0.x, vector2_0.y - (float)num2, vector.magnitude, float_0), Texture2D.whiteTexture, 0);
            smethod_3(-num, vector2_0);
            GUI.color = color;
        }
        public static void smethod_3(float float_0, Vector2 vector2_0)
        {
            Matrix4x4 matrix = GUI.matrix;
            GUI.matrix = Matrix4x4.identity;
            GUI.matrix = Matrix4x4.TRS(vector2_0, Quaternion.identity, Vector3.one);
            Vector2 vector = new Vector2(vector2_0.x, (float)Screen.height - vector2_0.y);
            GUI.matrix = Matrix4x4.TRS(vector, Quaternion.Euler(0f, 0f, float_0), Vector3.one) * Matrix4x4.TRS(-vector, Quaternion.identity, Vector3.one) * matrix;
        }

        public static void WiEcgCkd9(Color color_1, Vector2 vector2_0, float float_0)
        {
            GL.PushMatrix();
            material_0.SetPass(0);
            GL.Begin(1);
            GL.Color(color_1);
            for (float num = 0f; num < 6.2831855f; num += 0.05f)
            {
                GL.Vertex(new Vector3(Mathf.Cos(num) * float_0 + vector2_0.x, Mathf.Sin(num) * float_0 + vector2_0.y));
                GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * float_0 + vector2_0.x, Mathf.Sin(num + 0.05f) * float_0 + vector2_0.y));
            }
            GL.End();
            GL.PopMatrix();
        }

        public static void smethod_4(Vector2 vector2_0, float float_0, float float_1, float float_2, Color color_1, bool bool_0)
        {
            int num = (int)(float_0 / 4f);
            int num2 = num;
            if (bool_0)
            {
                smethod_8(vector2_0.x - float_0 / 2f - 1f, vector2_0.y - 1f, (float)(num + 2), 3f, Color.black);
                smethod_8(vector2_0.x - float_0 / 2f - 1f, vector2_0.y - 1f, 3f, (float)(num2 + 2), Color.black);
                smethod_8(vector2_0.x + float_0 / 2f - (float)num - 1f, vector2_0.y - 1f, (float)(num + 2), 3f, Color.black);
                smethod_8(vector2_0.x + float_0 / 2f - 1f, vector2_0.y - 1f, 3f, (float)(num2 + 2), Color.black);
                smethod_8(vector2_0.x - float_0 / 2f - 1f, vector2_0.y + float_1 - 4f, (float)(num + 2), 3f, Color.black);
                smethod_8(vector2_0.x - float_0 / 2f - 1f, vector2_0.y + float_1 - (float)num2 - 4f, 3f, (float)(num2 + 2), Color.black);
                smethod_8(vector2_0.x + float_0 / 2f - (float)num - 1f, vector2_0.y + float_1 - 4f, (float)(num + 2), 3f, Color.black);
                smethod_8(vector2_0.x + float_0 / 2f - 1f, vector2_0.y + float_1 - (float)num2 - 4f, 3f, (float)(num2 + 3), Color.black);
            }
            smethod_8(vector2_0.x - float_0 / 2f, vector2_0.y, (float)num, 1f, color_1);
            smethod_8(vector2_0.x - float_0 / 2f, vector2_0.y, 1f, (float)num2, color_1);
            smethod_8(vector2_0.x + float_0 / 2f - (float)num, vector2_0.y, (float)num, 1f, color_1);
            smethod_8(vector2_0.x + float_0 / 2f, vector2_0.y, 1f, (float)num2, color_1);
            smethod_8(vector2_0.x - float_0 / 2f, vector2_0.y + float_1 - 3f, (float)num, 1f, color_1);
            smethod_8(vector2_0.x - float_0 / 2f, vector2_0.y + float_1 - (float)num2 - 3f, 1f, (float)num2, color_1);
            smethod_8(vector2_0.x + float_0 / 2f - (float)num, vector2_0.y + float_1 - 3f, (float)num, 1f, color_1);
            smethod_8(vector2_0.x + float_0 / 2f, vector2_0.y + float_1 - (float)num2 - 3f, 1f, (float)(num2 + 1), color_1);
        }

        public static void smethod_5(Vector2 vector2_0, float float_0, Color color_1, Color color_2, Color color_3, bool bool_0 = false)
        {
            if (bool_0)
            {
                vector2_0 -= new Vector2(26f, 0f);
            }
            vector2_0 += new Vector2(0f, 18f);
            smethod_6(new Rect(vector2_0.x, vector2_0.y, 52f, 5f), Color.black);
            vector2_0 += new Vector2(1f, 1f);
            Color color = color_1;
            if (float_0 <= 50f)
            {
                color = color_2;
            }
            if (float_0 <= 25f)
            {
                color = color_3;
            }
            smethod_6(new Rect(vector2_0.x, vector2_0.y, 0.5f * float_0, 3f), color);
        }

        public static void smethod_6(Rect rect_0, Color color_1)
        {
            if (color_1 != color_0)
            {
                texture2D_0.SetPixel(0, 0, color_1);
                texture2D_0.Apply();
                color_0 = color_1;
            }
            GUI.DrawTexture(rect_0, texture2D_0);
        }

        public static void smethod_7(Vector2 vector2_0, string string_0, Color color_1, bool bool_0 = true, int int_0 = 12, FontStyle fontStyle_0 = FontStyle.Bold)
        {
            guistyle_0.fontSize = int_0;
            guistyle_0.richText = true;
            guistyle_0.normal.textColor = color_1;
            guistyle_0.fontStyle = fontStyle_0;
            guistyle_1.fontSize = int_0;
            guistyle_1.richText = true;
            guistyle_1.normal.textColor = new Color(0f, 0f, 0f, 1f);
            guistyle_1.fontStyle = fontStyle_0;
            GUIContent guicontent = new GUIContent(string_0);
            if (bool_0)
            {
                vector2_0.x -= guistyle_0.CalcSize(guicontent).x / 2f;
            }
            GUI.Label(new Rect(vector2_0.x + 1f, vector2_0.y + 1f, 300f, 25f), guicontent, guistyle_1);
            GUI.Label(new Rect(vector2_0.x, vector2_0.y, 300f, 25f), guicontent, guistyle_0);
        }

        public static void smethod_8(float float_0, float float_1, float float_2, float float_3, Color color_1)
        {
            if (!texture2D_0)
            {
                texture2D_0 = new Texture2D(1, 1);
            }
            if (color_1 != XuaiktfnF)
            {
                texture2D_0.SetPixel(0, 0, color_1);
                texture2D_0.Apply();
                XuaiktfnF = color_1;
            }
            GUI.DrawTexture(new Rect(float_0, float_1, float_2, float_3), texture2D_0);
        }

        private static Texture2D texture2D_0;

        private static Color XuaiktfnF;

        private static Material material_0 = new Material(Shader.Find("Hidden/Internal-Colored"))
        {
            hideFlags = HideFlags.DontSave
        };

        private static GUIStyle guistyle_0 = new GUIStyle();

        private static GUIStyle guistyle_1 = new GUIStyle();

        private static Color color_0;
    }

}

