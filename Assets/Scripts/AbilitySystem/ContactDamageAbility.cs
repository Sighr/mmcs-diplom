namespace AbilitySystem
{
    public class ContactDamageAbility : CooldownDrivenAbility
    {
        public float damage;
        
        protected override void ApplyImpl(UnitProperties properties)
        {
            var collisions = properties.collisionsList.currentCollisionsList;
            if (collisions.Count == 0)
            {
                return;
            }

            foreach (var collision in collisions)
            {
                var other = collision.gameObject.GetComponent<UnitProperties>();
                // TODO: remove for after masked collisions implemented
                if (other == null)
                {
                    continue;
                }
                // TODO: add damagecomponent, components container in unitproperties and separate system to deal with it
                other.hp -= damage;
            }
        }
    }
}