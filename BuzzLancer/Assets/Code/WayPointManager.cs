using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class WayPointManager : MonoBehaviour
    {
        public Waypoint FirstWayPoint;

        private Player _player;
        private Waypoint _currentWayPoint;

        public void Start()
        {
            _player = (Player)FindObjectOfType(typeof(Player));

            _currentWayPoint = FirstWayPoint;

            var waypoint = _currentWayPoint.Next;
            while(waypoint != null)
            {
                waypoint.gameObject.SetActive(false);
                waypoint = waypoint.Next;
            }
        }

        public void PlayerHitWayPoint(Waypoint waypoint)
        {
            _player.MinimumVelocity = waypoint.MinimumVelocity;

            waypoint.Deactive();

            _currentWayPoint = waypoint.Next;
            if (_currentWayPoint == null)
                return;

            _currentWayPoint.gameObject.SetActive(true);
        }
    }
}
