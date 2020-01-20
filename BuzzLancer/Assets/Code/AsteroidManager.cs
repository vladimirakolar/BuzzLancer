using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code
{
    public class AsteroidManager : MonoBehaviour
    {
        private List<Asteroid> _asteroids;

        private Player _player;

        public Asteroid AsteroidPrefabs;

        public int MaxAsteroids;
        public int MaxVisibleAsteroid;

        public void Awake()
        {
            _asteroids = new List<Asteroid>();
            _player = (Player)FindObjectOfType(typeof(Player));
        }

        public void Start()
        {
            for (var  i = 0; i < MaxAsteroids; i++)
            {
                var asteroid = (Asteroid)Instantiate(AsteroidPrefabs);
                asteroid.gameObject.name = "Asteroid" + i;
                asteroid.Deactivate();
                _asteroids.Add(asteroid);
            }
        }

        public void LateUpdate()
        {
            var totalVisible = 0;
            
            foreach (var asteroid in _asteroids.Where(a=> a.IsActive))
            {
                asteroid.UpdatePlayerPosition(_player.transform.position);

                if (asteroid.IsVisible)
                    totalVisible++;
            }

            for (var i=0; i< _asteroids.Count; i++)
            {
                var asteroid = _asteroids[i];

                if (asteroid.IsActive)
                {
                    if (asteroid.IsVisible)
                        continue;

                    if (asteroid.DistanceSquared < 50 * 50)
                        continue;
                }

                if (totalVisible < MaxAsteroids)
                {
                    ActivateAsteroid(asteroid);
                    totalVisible++;
                }
                else
                    asteroid.Deactivate();
            }
        }

        public void ActivateAsteroid(Asteroid asteroid)
        {
            asteroid.Activate();

            var rotation = new Vector3(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f));

            var direction = new Vector3(
                Random.Range(0f, 1f),
                 Random.Range(0f, 1f),
                  Random.Range(0f, 1f));

            var scale = Random.Range(0f, 1f) > .3f
                ? new Vector3(Random.Range(25f, 90f), Random.Range(25f, 90f), Random.Range(25f, 90f))
                : new Vector3(Random.Range(110f, 160f), Random.Range(110f, 160f), Random.Range(110f, 160f));

            var velocity = Random.Range(15f, 25f);

            var position = Camera.main.ViewportToWorldPoint(new Vector3(
                Random.Range(-.5f, 1.5f),
                Random.Range(-.5f, 1.5f),
               (Random.Range(0f, 1f) * 300) + 150));

            asteroid.Init(position, rotation, direction, scale, velocity);
        }
    }
}
