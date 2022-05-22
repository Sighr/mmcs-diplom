using BehaviourSystem.Entities;
using UnityEngine;

namespace AbilitySystem
{
    public class ThrowProjectileAbility : CooldownDrivenAbility
    {
        public GameObject projectilePrefab;
        
        protected override void ApplyImpl(Unit unit)
        {
            Vector3 target = EntitiesUtils.GetNearest(unit, EnemiesList.Instance.GetAllEntities(unit));
            if (target == Vector3.zero)
                return;
            var transform = unit.transform;
            var position = transform.position;
            var direction = (target - position).normalized;
            var projectile = Object.Instantiate(projectilePrefab, position + direction * 3, Quaternion.LookRotation(direction) * projectilePrefab.transform.rotation);
            var rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = direction * 10 + unit.rb.velocity;
        }
    }
}