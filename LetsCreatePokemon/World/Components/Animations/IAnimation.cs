using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Animations
{
    internal interface IAnimation
    {
        int AnimationCooldown { get; set; }
        Rectangle GetNewAnimationState();
    }
}
