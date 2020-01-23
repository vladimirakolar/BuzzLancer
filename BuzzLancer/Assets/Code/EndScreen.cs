using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class EndScreen : MonoBehaviour
    {
        public void OnGUI()
        {
            GUILayout.BeginVertical();
            {
                if (GameManagerInstance.Instance.DidWin)
                    GUILayout.Label("YOU WON!");
                else
                    GUILayout.Label("YOU LOST!");

                GUILayout.Label(string.Format("With {0} points", GameManagerInstance.Instance.Points));

                if (GUILayout.Button("Close"))
                    Application.LoadLevel("StartScreen");

                GUILayout.EndVertical();
            }
        }
    }
}
