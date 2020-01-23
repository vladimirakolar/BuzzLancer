using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class LevelManager : MonoBehaviour
    {
        public float TimeLeft;
        public string NextLevel;

        public void Update()
        {
            TimeLeft -= Time.deltaTime;

            if (TimeLeft < 0)
                GameManagerInstance.Instance.EndGame(false);
        }

       public void AsteroidDestroyedByPlayer(Asteroid asteroid)
        {
            GameManagerInstance.Instance.Points += asteroid.Level * 50;
        }

        public void WayPointHitByPlayer(Waypoint waypoint)
        {
            if (waypoint.Next == null)
            {
                GameManagerInstance.Instance.Points +=(int)Mathf.Ceil(TimeLeft) * 10;

                if (!string.IsNullOrEmpty(NextLevel))
                {
                    if (GameManagerInstance.Instance.IsDebug)
                        Debug.Log("You are moving on to the next level!");
                    else
                        Application.LoadLevel(NextLevel);
                }
                else
                    GameManagerInstance.Instance.EndGame(true);
            }

            TimeLeft += waypoint.TmeModifier;
        }
    }
}
