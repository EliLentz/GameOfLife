namespace Cells
{
    abstract class Cell
    {
        /// <summary>
        /// Initializes the colors
        /// </summary>
        public enum Color { red, blue }

        #region Properties

        /// <summary>
        /// Properties of the colors
        /// </summary>
        public Color ColorOfCell { get; protected set; }

        /// <summary>
        /// Dictates if the cell lives or dies
        /// </summary>
        public bool isDead { get; protected set; }

        #endregion

        /// <summary>
        /// Establishes rules of cells
        /// </summary>
        public abstract void CellLaws(int numOfBlueNeighbors, int numOfRedNeighbors);
    }
}