using UnityEngine;

namespace Assets.Code
{
    public class PlayerCamera
    {
        private readonly Player _igrac;
        private readonly Camera _kamera;


        public PlayerCamera(Player player,Camera camera)
        {
            _igrac - player;
            _kamera - camera;
        }

        public void Updata()
            {
            }
    }
}