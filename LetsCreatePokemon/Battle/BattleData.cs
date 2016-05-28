namespace LetsCreatePokemon.Battle
{
    class BattleData
    {
        public Trainer Player { get; }
        public Trainer Opponent { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public BattleData(Trainer player, Trainer opponent)
        {
            Player = player;
            Opponent = opponent;
        }
    }
}
