using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Spiner : MonoBehaviour
    {
        public bool Direction;

        public void Update()
        {
            transform.Rotate(0, 0, Time.deltaTime * 20 * (Direction ? 1 : -1), Space.Self);
        }
    }
}
