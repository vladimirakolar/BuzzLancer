using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public abstract class BasicWepon : MonoBehaviour
    {
        public abstract void Fire(Vector3 position, Vector3 direction);
    }
}
