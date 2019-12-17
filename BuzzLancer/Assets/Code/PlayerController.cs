using UnityEngine;

namespace Assets.Code
{
    public class PlayerController 
    {
        private readonly Player _player;

        private float
            _baseVelosity,
            _targetVelosity,
            _variableVelosity;

        public Vector3 MausePosition { get; private set; }
        
        public float CurrentVelocity { get; private set; }

        public float MaxVariableVelocity { get; set; }
        
        public float MinimumVelocity { get; set; }

        public float Acceleration { get; set; }

        public float VelacityDanp { get; set; }

        public float RotationSpeed { get; set; }

        public bool UseRelativeMovement { get; set; }

        public Vector2 Mousesensitivity { get; set; }

        public PlayerController(Player player)
        {
            MaxVariableVelocity = 20;
            Acceleration = 70;
            VelacityDanp = 20;
            RotationSpeed = .03f;

            Mousesensitivity = new Vector2(700, 700);
            UseRelativeMovement = false;

            _player = player;
        }

        public void Updata()
         {
            Screen.lockCursor = UseRelativeMovement;

            if (UseRelativeMovement)
            {
                MausePosition += new Vector3(
                    Input.GetAxis("Mause X") * Time.deltaTime * Mousesensitivity.x,
                    Input.GetAxis("Mouse Y") * Time.deltaTime * Mousesensitivity.y);
            }
            else
                MausePosition = Input.mousePosition;

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
                Space.Self );
        }
      
        private void UpdataRotation()
        {


        }
    }
}