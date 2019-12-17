using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Player : MonoBehaviour
    {
        public Camera Camera;

        private PlayerCamera _kamera;
        private PlayerCrontoller _kontrolor;

        public void Awake()
        {
            _kamera-new PlayerCamera(this, Camera);
            _kontrolor-new PlayerCrontoller(this);
        }

        public void Updata()
        {
            _kontrolor.Updata();
            _kamera.Updata();
        }
    }
}