namespace LetsCreatePokemon.Services.Windows
{
    interface IWindowQueuer
    {
        void QueueWindow(Window window);
        bool WindowActive { get; }
    }
}
