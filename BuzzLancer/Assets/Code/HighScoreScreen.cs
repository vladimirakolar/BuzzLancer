using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class HighScoreScreen : MonoBehaviour
    {
        private const float Width = 1920;
        private const float Height = 1080;

        public Texture Background;

        public GUIStyle
            RowStyle,
            TextStyle,
            PointStyle;

        public void OnGUI()
        {
            var widthScale = Screen.width / Width;
            var heightScale = Screen.height / Height;

            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(widthScale, heightScale, 1));

            GUI.DrawTexture(new Rect(0, 0, Width, Height), Background);

            var scores = HighScoreManager.Instance.Scores;

            GUILayout.BeginArea(new Rect(173, 186, 1035, 724));

            foreach(var score in scores)
            {
                GUILayout.BeginHorizontal(RowStyle);

                GUILayout.Label(score.Name, TextStyle);
                GUILayout.Label(string.Format("(0) points", score.Points),PointStyle);

                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();

            if (GUI.Button(new Rect(845, 960, 205, 71), ""))
                Application.LoadLevel("StartScreen");
        }
    }
}
