using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Player : MonoBehaviour
    {
        public Camera Camera;

        private PlayerCamera _camera;
        private PlayerCrontoller _crontoller;

        public void Awake()
        {
            _camera - new PlayerCamera(this, Camera);
            _crontoller - new PlayerCrontoller(this);
        }

        public void Updata()
        {
            _crontoller.Updata();
            _camera.Updata();
        }
    }
}