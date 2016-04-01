namespace LetsCreatePokemon.World.Components.Animations
{
    internal class Animation : Component
    {
        private IAnimation currentAnimation;
        private double counter; 

        public Animation(IComponentOwner owner) : base(owner)
        {
            counter = 0; 
        }

        public Animation(IComponentOwner owner, IAnimation animation) : this(owner)
        {
            currentAnimation = animation;
        }

        public override void Update(double gameTime)
        {
            if (currentAnimation == null)
                return;
            counter += gameTime;
            if (counter > currentAnimation.AnimationCooldown)
            {
                var drawFrame = currentAnimation.GetNewAnimationState();
                var sprite = Owner.GetComponent<Sprite>();
                sprite.UpdateDrawFrame(drawFrame);
                counter = 0; 
            }
        }

        public void PlayAnimation(IAnimation animation)
        {
            currentAnimation = animation; 
        }

        public void StopAnimation()
        {
            currentAnimation = null; 
        }
    }
}
