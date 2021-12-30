namespace BoardgameShowcase.Model.Entity.Enumeration
{
    /// <summary>
    /// A boardgame mechanim.
    /// </summary>
    public enum Mechanism
    {
        /// <summary>
        /// Use it when players have to manage something.
        /// </summary>
        Management,
        /// <summary>
        /// Use it when players have to handle resources.
        /// </summary>
        Ressources,
        /// <summary>
        /// Use it when players have to draft material.
        /// </summary>
        Draft,
        /// <summary>
        /// Use it when players have to use tiles.
        /// </summary>
        Tiles,
        /// <summary>
        /// Use it when players can make combinations.
        /// </summary>
        Combination,
        /// <summary>
        /// Use it when players can have powers.
        /// </summary>
        Powers,
        /// <summary>
        /// Use it when players fight each other on a map.
        /// </summary>
        Wargame,
        /// <summary>
        /// Use it when players can explore a map.
        /// </summary>
        Exploration,
        /// <summary>
        /// Use it when players can fight each other.
        /// </summary>
        Confrontation,
        /// <summary>
        /// Use it when players have to play cards.
        /// </summary>
        Cards,
        /// <summary>
        /// Use it when players have to roll dice.
        /// </summary>
        Dice,
        /// <summary>
        /// Use it when players can make collections.
        /// </summary>
        Collection,
        /// <summary>
        /// Use it when players must complete secret objectives.
        /// </summary>
        Secret_Objectives,
        /// <summary>
        /// Use it when players have to place material.
        /// </summary>
        Placement
    }
}
