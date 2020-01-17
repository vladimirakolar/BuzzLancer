using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class PlayerWeapons 
    {
        private readonly Player _player;
        private readonly Camera _camera;
        private readonly PlayerController _controller;
        private readonly IEnumerable<BasicWeponMount> _basicWepons;

        public PlayerWeapons(Player player, Camera camera, PlayerController controller, IEnumerable<BasicWeponMount> basicWepons)
        {
            _player = player;
            _camera = camera;
            _controller = controller;
            _basicWepons= basicWepons;
        }

        public void Update()
        {
            if (!Input.GetMouseButton(0))
                return;

            var ray = _camera.ScreenPointToRay(_controller.MousePosition);
            var direction = (ray.origin + ray.direction * 100) - _player.transform.position;
            direction.Normalize();

            foreach (var weapon in _basicWepons)
                weapon.Fire(direction);
        }
    }
}
