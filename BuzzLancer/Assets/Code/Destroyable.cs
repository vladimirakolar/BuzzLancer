﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Destroyable : MonoBehaviour
    {
        public float MaxHealth;
        public float Health;

        public void TakeDamage(float damage, GameObject from)
        {
            Health -= damage;

            SendMessage("TookDamage", from, SendMessageOptions.DontRequireReceiver);

            if (Health > 0)
                return;

            SendMessage("Destroyed", from, SendMessageOptions.DontRequireReceiver);
        }
    }
}
