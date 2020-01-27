using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EndScreen : MonoBehaviour
    {
        private const float Width = 1920;
        private const float Height = 1080;

        public Texture 
            WinBackground,
            LoseBackground;

        public GUIStyle TextStyle;

        private GUIStyle
            _buttonStayle,
            _textFiledStayle;

        private string _name = "";
        private bool _hasAddScore;

        public void OnGUI()
        {
            if (_buttonStayle == null)
            {
                _buttonStayle = new GUIStyle(GUI.skin.button)
                {
                    fontSize = 32
                };

                _textFiledStayle = new GUIStyle(GUI.skin.textField)
                {
                    fontSize = 32,
                    margin =
                    {
                        bottom = 20
                    }
                };
            }

            var widthScale = Screen.width / Width;
            var heightScale = Screen.height / Height;
            
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(widthScale, heightScale, 1));

            if (GameManagerInstance.Instance.DidWin)
                GUI.DrawTexture(new Rect(0,0,Width,Height), WinBackground);
            else
                GUI.DrawTexture(new Rect(0, 0, Width, Height), LoseBackground);

            GUILayout.BeginArea(new Rect(406, 272, 298, 538));

            GUILayout.BeginVertical();   
            
            GUILayout.Label(string.Format("With {0} points", GameManagerInstance.Instance.Points), TextStyle);

                if (HighScoreManager.Instance.CanAddHighScore(GameManagerInstance.Instance.Points))
                {
                    if (!_hasAddScore)
                    {
                        GUILayout.Label("You got a high score! Enter your name:", TextStyle);
                        _name = GUILayout.TextField(_name, _textFiledStayle);

                        if (GUILayout.Button("Save Score",_buttonStayle))
                        {
                            HighScoreManager.Instance.AddHighScore(_name, GameManagerInstance.Instance.Points);
                            _hasAddScore = true;
                        }
                    }
                    else
                        GUILayout.Label("Score added!",TextStyle);
                }
                else
                    GUILayout.Label("You didn't get a high score :(", TextStyle);

                GUILayout.EndVertical();

                GUILayout.EndArea();

            if (!GameManagerInstance.Instance.DidWin && GUI.Button(new Rect(843, 840, 240, 86), ""))
                Application.LoadLevel("StartScreen");

            if (!GameManagerInstance.Instance.DidWin && GUI.Button(new Rect(843,840,240,86), ""))
                Application.LoadLevel("StartScreen");
        }
    }
}
