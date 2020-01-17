using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class ProjectalWepon : BasicWepon
    {
        public Projectile Prefabs;

        public float
            Speed,
            Damage,
            FireRate,
            TimeToLive;

        public override void Fire(Vector3 position, Vector3 direction)
        {
          
        }
    }
}
