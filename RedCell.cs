using Matrix;

namespace Cells
{
    class RedCell : Cell
    {
        public RedCell()
        {
            ColorOfCell = Color.red;
            isDead = false;
        }

        /// <summary>
        /// Establishes rules for red cells
        /// 1.If there are no red neighbouring cells, the cell dies
        /// 2.If the cell haas four or more neighbours, the cell dies
        /// </summary>
        /// <param name="numOfBlueNeighbors"></param>
        /// <param name="numOfRedNeighbors"></param>
        public override void CellLaws(int numOfBlueNeighbors, int numOfRedNeighbors)
        {
            if (numOfRedNeighbors == 0)
                isDead = true;
            else if (numOfBlueNeighbors + numOfRedNeighbors >= 4)
                isDead = true;
        }
    }
}