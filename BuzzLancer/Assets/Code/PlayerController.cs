﻿using UnityEngine;

namespace Assets.Code
{
    public class PlayerController 
    {
        private readonly Player _player;

        private float
            _baseVelosity,
            _targetVelosity,
            _variableVelosity;

        public Vector3 MousePosition { get; private set; }
        
        public float CurrentVelocity { get; private set; }

        public float MaxVariableVelocity { get; set; }
        
        public float MinimumVelocity { get; set; }

        public float Acceleration { get; set; }

        public float VelacityDanp { get; set; }

        public float RotationSpeed { get; set; }

        public bool UseRelativeMovement { get; set; }

        public Vector2 MouseSensitivity { get; set; }

        public PlayerController(Player player)
        {
            MaxVariableVelocity = 20;
            Acceleration = 150;//70
            VelacityDanp = 60;//20
            RotationSpeed = .3f;//.03f

            MouseSensitivity = new Vector2(700, 700);
            UseRelativeMovement = false;

            _player = player;
        }

        public void Updata()
         {
            Screen.lockCursor = UseRelativeMovement;

            if (UseRelativeMovement)
            {
                MousePosition += new Vector3(
                    Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity.x,
                    Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity.y);
            }
            else
                MousePosition = Input.mousePosition;

            UpdataPosition();
            UpdataRotation();
         }

        private void UpdataPosition()
        {
            _variableVelosity = Mathf.Clamp(
                _variableVelosity + Input.GetAxis("Vertical") * Time.deltaTime * Acceleration,
                0,
                MaxVariableVelocity);

            _targetVelosity = _variableVelosity + MinimumVelocity;

            CurrentVelocity = Mathf.Lerp(CurrentVelocity, _targetVelosity, Time.deltaTime * VelacityDanp);

            _player.transform.Translate(
                0,
                0,
                CurrentVelocity * Time.deltaTime,
                Space.Self);
        }
      
        private void UpdataRotation()
        {
            var mouseMovement = (MousePosition - (new Vector3(Screen.width / 2f, Screen.height / 2f))) * .2f;

            if (mouseMovement.sqrMagnitude >= 1)
                _player.transform.Rotate(new Vector3(-mouseMovement.y, mouseMovement.x, 0) * RotationSpeed);
        }
    }
}