using LetsCreatePokemon.Services.Content;

namespace LetsCreatePokemon.World
{
    interface ILoadContentComponent : IComponent
    {
        void LoadContent(IContentLoader contentLoader);
    }
}
