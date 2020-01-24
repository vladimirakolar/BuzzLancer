using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Projectile : MonoBehaviour
    {

        private float _timeToLive;
        private Vector3 _direction;
        private ProjectalWepon _wepon;

        public GameObject Effect;


        public void Init(ProjectalWepon wepon, Vector3 direction)
        {
            transform.LookAt(direction + transform.position);

            _wepon = wepon;
            _timeToLive = wepon.TimeToLive;
            _direction = direction;
        }

        private void Update()
        {
            if((_timeToLive -= Time.deltaTime)<0)
            {
                Destroy(gameObject);
                return;
            }

            transform.Translate(_direction * _wepon.Speed * Time.deltaTime, Space.World);
        }

        public void OnTriggerEnter(Collider collision)
        {

            var destroyable = collision.GetComponent<Destroyable>();
            if (destroyable == null)
                return;

            destroyable.TakeDamage(_wepon.Damage, gameObject);

            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
