//------------------------------------------------------
// 
// Copyright - (c) - 2016 - Mille Boström 
//
// Youtube channel - https://www.speedcoding.net
//------------------------------------------------------
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Content
{
    public interface IContentLoader
    {
        Texture2D LoadTexture(string textureName);
        SpriteFont LoadFont(string fontName);
    }
}
