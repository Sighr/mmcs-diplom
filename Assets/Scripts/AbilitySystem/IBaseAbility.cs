namespace AbilitySystem
{
    public interface IBaseAbility
    {
        public void Apply(Unit unit);
        public string GetDescription();
    }
}