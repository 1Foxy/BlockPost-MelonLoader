using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace e
{
    internal class Render
    {
        // Fields
        public static Texture2D lineTex;

        // Methods
        public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
        {
            DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
            DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
            DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
            DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
        }

        public static void DrawCircle(Vector2 center, float radius, Color color, float numSegments = 40f)
        {
            Quaternion quaternion = Quaternion.AngleAxis(360f / numSegments, Vector3.forward);
            Vector2 vector = new Vector2(radius, 0f);
            for (int i = 0; i < numSegments; i++)
            {
                Vector2 vector2 = (Vector2)(quaternion * vector);
                DrawLine(center + vector, center + vector2, color, 2f);
                vector = vector2;
            }
        }

        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
        {
            Matrix4x4 matrix = GUI.matrix;
            if (!lineTex)
            {
                lineTex = new Texture2D(1, 1);
            }
            GUI.color = color;
            float angle = Vector3.Angle((Vector3)(pointB - pointA), (Vector3)Vector2.right);
            if (pointA.y > pointB.y)
            {
                angle = -angle;
            }
            GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
            GUIUtility.RotateAroundPivot(angle, pointA);
            GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
            GUI.matrix = matrix;
            GUI.color = GUI.color;
        }

        // Properties
        public static Color Color
        {
            get =>
                GUI.color;
            set =>
                GUI.color = value;
        }

    }
}
