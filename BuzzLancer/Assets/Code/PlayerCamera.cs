using UnityEngine;


namespace Assets.Code
{ 

    public class PlayerCamera
    {
        private readonly Player _player;
        private readonly Camera _camera;

        public float MovementDanp { get; set; }

        public float RotationDanp { get; set; }

        public PlayerCamera(Player player, Camera camera)
        {
            MovementDanp = 8;

            _player = player;
            _camera = camera;
        }

        public void Updata()
        {
            var position = _player.transform.TransformPoint(0, .5f, -5);
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, position, Time.deltaTime * MovementDanp);

            _camera.transform.LookAt(_player.transform.TransformPoint(0, 0, 50), _player.transform.up);
        }

    }
}