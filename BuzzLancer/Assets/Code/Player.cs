using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Assets.Code
{
    public class Player : MonoBehaviour
    {
        public Camera Camera;
        public Destroyable Destroyable;
        public BasicWepon BasicWepon;

        private PlayerCamera _camera;
        private PlayerController _controller;
        private PlayerGUI _playerGUI;
        private PlayerWeapons _weapons;

        private IEnumerable<BasicWeponMount> _mounts;

        public float Health { get { return Destroyable.Health; } }

        public float MaxHealth { get { return Destroyable.MaxHealth; } }

        public float MinimumVelocity 
        {
            get { return _controller.MinimumVelocity; } 
            set {_controller.MinimumVelocity = value; }
        }

        public void Awake()
        {
            _mounts = GetComponentsInChildren<BasicWeponMount>();

            _camera = new PlayerCamera(this, Camera);
            _controller = new PlayerController(this);
            _playerGUI = new PlayerGUI(this, _controller);
            _weapons = new PlayerWeapons(this, Camera, _controller, _mounts);

            Equip(BasicWepon);
        }

        public void Destroyed()
        {
            GameManagerInstance.Instance.EndGame(false);
        }

        public void Equip(BasicWepon wepon)
        {
            foreach (var mount in _mounts)
                mount.Equip(wepon);
        }

        public void Update()
        {
            _controller.Update();
            _playerGUI.Update();
            _camera.Update();
            _weapons.Update();
        }

        public void OnGUI()
        {
            _playerGUI.OnGUI();
        }

    }
}