using UnityEngine;

namespace AbilitySystem
{
    public abstract class CooldownDrivenAbility : IBaseAbility
    {
        public float baseCooldown;
        public float currentCooldown;

        public void Apply(Unit unit)
        {
            currentCooldown -= Time.fixedDeltaTime;
            if (currentCooldown > 0)
            {
                return;
            }
            currentCooldown = baseCooldown;
            ApplyImpl(unit);
        }
        
        protected abstract void ApplyImpl(Unit unit);
    }
}