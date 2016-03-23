using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Animations
{
    internal interface IAnimation
    {
        int AnimationSpeed { get; set; }
        Rectangle GetNewAnimationState();
    }
}
