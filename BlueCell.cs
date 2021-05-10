namespace Cells
{
    class BlueCell : Cell
    {
        public BlueCell()
        {
            ColorOfCell = Color.Blue;
            isDead = false;
        }

        /// <summary>
        /// Establishes rules for blue cells
        /// 1. If there are no neighbouring blue cells, the cell dies
        /// 2. IF there are two or more blue neighbours, the cell dies
        /// 3. If the cell has one to three red neighbours, the cell lives
        /// </summary>
        /// <param name="numOfBlueNeighbors"></param>
        /// <param name="numOfRedNeighbors"></param>
        public override void CellLaws(int numOfBlueNeighbors, int numOfRedNeighbors)
        {
            if (numOfBlueNeighbors == 0)
                isDead = true;
            else if (numOfBlueNeighbors >= 2)
                isDead = true;
            else if (numOfRedNeighbors < 1 && numOfRedNeighbors > 3)
                isDead = true;
        }
    }
}