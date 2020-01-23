using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Waypoint : MonoBehaviour
    {
        public WayPointManager _manager;
        private IEnumerable<Renderer> _renderers;

        public Waypoint Next;

        public Shader AlphaShader;

        public float 
            TmeModifier,
            MinimumVelocity;

        private bool _deactivating;
        private float _alpha;
       

        public void Start()
        {
            _manager = (WayPointManager)FindObjectOfType(typeof(WayPointManager));
            _alpha = 1;
            _renderers = GetComponentsInChildren<Renderer>();
        }

        public void OnTriggerEnter(Collider colision)
        {
            if (colision.gameObject.FindComponent<Player>() == null)
                return;

            _manager.PlayerHitWayPoint(this);
        }

        public void Deactive() 
        {
            _deactivating = true;

            foreach (var render in _renderers)
                render.material.shader = AlphaShader;
        }

        public void Update()
        {
            if (!_deactivating)
                return;

            _alpha = Mathf.Lerp(_alpha, 0, Time.deltaTime * 5);

            foreach (var render in _renderers)
                render.material.color = new Color(1, 1, 1, _alpha);

            if (_alpha < 0.01f)
                gameObject.SetActive(false);
        }
    }
}
