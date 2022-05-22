using System;
using UnityEngine;

namespace AbilitySystem
{
    public class ProjectileScript : MonoBehaviour
    {
        public float lifeTime = 10;
        public float damage = 10;
        private void FixedUpdate()
        {
            lifeTime -= Time.fixedDeltaTime;
            if (lifeTime < 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Units"))
            {
                var unit = collision.gameObject.GetComponent<Unit>();
                unit.hp -= damage;
            }
            Destroy(gameObject);
        }
    }
}