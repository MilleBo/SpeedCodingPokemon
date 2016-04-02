namespace LetsCreatePokemon.World
{
    internal abstract class Component : IComponent
    {
        protected IComponentOwner Owner;
        public bool Killed { get; protected set; }

        protected Component(IComponentOwner owner)
        {
            Owner = owner; 
        }
    }
}
