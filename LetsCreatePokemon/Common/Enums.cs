//------------------------------------------------------
// 
// Copyright - (c) - 2016 - Mille Boström 
//
// Youtube channel - https://www.speedcoding.net
//------------------------------------------------------
namespace LetsCreatePokemon.Common
{
    public enum Inputs
    {
        Left, 
        Up,
        Right,
        Down,
        None,
        A
    }

    public enum Directions
    {
        Left = 2, 
        Up = 1, 
        Right = 3,
        Down = 0
    }

    public enum PokemonStates
    {
        Normal,
        Dead, 
        StatusEffect
    }

    public enum Genders
    {
        Male, 
        Female
    } 
}