﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class GameManager : MonoBehaviour
    {
        public bool IsDebug { get; set; }

        public int Points { get; set; }

        public bool DidWin { get; private set; }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void StartGame()
        {
            Points = 0;
            DidWin = false;
        }

        public void EndGame(bool didWin)
        {
            if (IsDebug)
            {
                Debug.Log("The game ednded!");
                return;
            }
                DidWin = didWin;
                Application.LoadLevel("EndScreem");
        }
    }
}
