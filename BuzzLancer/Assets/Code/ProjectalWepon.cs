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

        private float _cooldown;

        public override void Fire(Vector3 position, Vector3 direction)
        {
            if ((_cooldown -= Time.deltaTime) > 0)
                return;

            var projectile = (Projectile)Instantiate(Prefabs, position, Quaternion.identity);
            projectile.Init(this, direction);

            _cooldown = FireRate;
        }
    }
}
