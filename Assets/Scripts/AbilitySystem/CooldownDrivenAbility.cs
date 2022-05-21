using UnityEngine;

namespace AbilitySystem
{
    public abstract class CooldownDrivenAbility : IBaseAbility
    {
        public float baseCooldown;
        public float currentCooldown;

        public void Apply(UnitProperties properties)
        {
            currentCooldown -= Time.fixedDeltaTime;
            if (currentCooldown > 0)
            {
                return;
            }
            currentCooldown = baseCooldown;
            ApplyImpl(properties);
        }
        
        protected abstract void ApplyImpl(UnitProperties properties);
    }
}