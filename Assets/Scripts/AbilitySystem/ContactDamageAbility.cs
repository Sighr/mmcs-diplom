using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    public class ContactDamageAbility : CooldownDrivenAbility
    {
        public float damage;

        public override string GetDescription()
        {
            return $"ContactDamageAbility,CD{currentCooldown}/{baseCooldown},DMG{damage}";
        }

        protected override void ApplyImpl(Unit unit)
        {
            HashSet<GameObject> collisions = unit.components.currentCollisions;
            if (collisions.Count == 0)
            {
                currentCooldown = 0;
                return;
            }

            bool applied = false;
            foreach (GameObject otherGo in collisions)
            {
                if (otherGo.layer != LayerMask.NameToLayer("Units"))
                {
                    continue;
                }
                Unit other = otherGo.GetComponent<Unit>();
                // TODO: add damagecomponent and separate system to deal with it
                other.hp -= damage;
                applied = true;
            }
            if (!applied)
            {
                currentCooldown = 0;
            }
        }
    }
}