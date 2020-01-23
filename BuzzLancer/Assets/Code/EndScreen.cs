using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EndScreen : MonoBehaviour
    {
        private string _name = "";
        private bool _hasAddScore;

        public void OnGUI()
        {
           GUILayout.BeginVertical();
            {
                if (GameManagerInstance.Instance.DidWin)
                    GUILayout.Label("YOU WON!");
                else
                    GUILayout.Label("YOU LOST!");

                GUILayout.Label(string.Format("With {0} points", GameManagerInstance.Instance.Points));

                if (HighScoreManager.Instance.CanAddHighScore(GameManagerInstance.Instance.Points))
                {
                    if (!_hasAddScore)
                    {
                        GUILayout.Label("You got a high score! Enter your name:");
                        _name = GUILayout.TextField(_name);

                        if (GUILayout.Button("Save Score"))
                        {
                            HighScoreManager.Instance.AddHighScore(_name, GameManagerInstance.Instance.Points);
                            _hasAddScore = true;
                        }
                    }
                    else
                        GUILayout.Label("Score added!");
                }
                else
                    GUILayout.Label("You didn't get a high score :(");

                if (GUILayout.Button("Close"))
                    Application.LoadLevel("StartScreen");

                GUILayout.EndVertical();
            }
        }
    }
}
