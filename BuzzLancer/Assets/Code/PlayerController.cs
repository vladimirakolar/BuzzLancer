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

        

        public PlayerController(Player player)
        {
            _player - player;
        }

        public void Updata()
         {
         
         }
    }
}