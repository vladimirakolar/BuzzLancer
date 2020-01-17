using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class BasicWeponMount : MonoBehaviour
    {
        private BasicWepon _wepon;

        public void Equip(BasicWepon weponPrefabes)
        {
            if (_wepon != null)
                Destroy(_wepon.gameObject);

            _wepon = (BasicWepon)Instantiate(weponPrefabes);
        }

        public void Fire (Vector3 direction)
        {
            _wepon.Fire(transform.position, direction);
        }
    }
}
