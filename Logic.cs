using Cells;
using System.Threading;

namespace Matrix
{
    class Logic
    {
        /// <summary>
        /// sleeps 3 seconds until it misses the move
        /// </summary>
        public static void DoSleep()
        {
            const int timeToSleep = 3000;

            Thread.Sleep(timeToSleep);
        }

        /// <summary>
        /// Generates new cells
        /// </summary>
        /// <param name="currentMatrix"></param>
        public static void GenerateNewCell(Cell [,] currentMatrix)
        {
            for (int i = 0; i < Matrix.matrixSize; i++)
                for (int j = 0; j < Matrix.matrixSize; j++)
                    if (currentMatrix[i, j] == null && GetNumOfNeighbors(GetNeighbors(i, j, currentMatrix)) == 3)
                        currentMatrix[i, j] = RandTypeOfANewCell();                      
        }

        /// <summary>
        /// Kills cells that do not adhear to rules
        /// </summary>
        /// <param name="currentMatrix"></param>
        public static void KillCells(Cell [,] currentMatrix)
        {
            for (int i = 0; i < Matrix.matrixSize; i++)
                for (int j = 0; j < Matrix.matrixSize; j++)
                {
                    if (currentMatrix[i, j] != null)
                        if (currentMatrix[i, j].isDead == true)
                            currentMatrix[i, j] = null;
                }
        }

        /// <summary>
        /// Updates the cells status
        /// </summary>
        /// <param name="currentMatrix"></param>
        public static void RefreshMatrix(Cell[,] currentMatrix)
        {
            for (int i = 0; i < currentMatrix.Length; i++)
                for (int j = 0; j < currentMatrix.Length; j++)
                    if(!IsItBeyoudTheBoarder(i, j))
                        if (currentMatrix[i, j] != null)
                            currentMatrix[i, j].CellLaws(GetNumOfBlueCells(GetNeighbors(i, j, currentMatrix)), GetNumOfRedCells(GetNeighbors(i, j, currentMatrix)));
        }

        #region HelpFunctions

        /// <summary>
        /// Get the number of neighbours of a cell
        /// </summary>
        /// <param name="neighbors"></param>
        /// <returns>int</returns>
        private static int GetNumOfNeighbors(Cell [] neighbors)
        {
            int numOfRedNeighbors = 0;

            for (int i = 0; i < neighbors.Length; i++)
                if (neighbors[i] != null)
                    numOfRedNeighbors++;

            return numOfRedNeighbors;
        }

        /// <summary>
        /// Get the number of red neighbours of a cell
        /// </summary>
        /// <param name="neighbors"></param>
        /// <returns>int</returns>
        private static int GetNumOfRedCells(Cell [] neighbors)
        {
            int numOfRedNeighbors = 0;

            for (int i = 0; i < neighbors.Length; i++)
                if (neighbors[i] != null)
                    if (neighbors[i].ColorOfCell == Cell.Color.red)
                        numOfRedNeighbors++;

            return numOfRedNeighbors;
        }

        /// <summary>
        /// Get the number of blue neighbours of a cell
        /// </summary>
        /// <param name="neighbors"></param>
        /// <returns>int</returns>
        private static int GetNumOfBlueCells(Cell [] neighbors)
        {
            int numOfBlueNeighbors = 0;

            for (int i = 0; i < neighbors.Length; i++)
                if(neighbors[i] != null)
                    if(neighbors[i].ColorOfCell == Cell.Color.blue)
                        numOfBlueNeighbors++;

            return numOfBlueNeighbors;
        }

        /// <summary>
        /// Get neighbours of a cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="currentMatrix"></param>
        /// <returns>an array of cell</returns>
        private static Cell[] GetNeighbors(int x, int y, Cell[,] currentMatrix)
        {
            const int MAX_Neighbors = 8;
            Cell[] neighbors = new Cell[MAX_Neighbors];

            int counter = 0;

            for (int i = x - 1; i < x + 2; i++)
                for (int j = y - 1; j < y + 2; j++)
                    if (!IsItBeyoudTheBoarder(i, j))
                        if (currentMatrix[i, j] != null && currentMatrix[i, j] != currentMatrix[x, y])
                        {
                            neighbors[counter] = currentMatrix[i, j];
                            counter++;
                        }

            return neighbors;
        }

        /// <summary>
        /// Determines if a cell is beyond the border
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>boolean</returns>
        private static bool IsItBeyondTheBorder(int x, int y)
        {
            bool isAbroad = false;

            if (x < 0 || y < 0 || x >= Matrix.matrixSize || y >= Matrix.matrixSize)
                isAbroad = true;

            return isAbroad;
        }

        /// <summary>
        /// Generates a new cell of a random type(blue or red)
        /// </summary>
        /// <returns>new cell</returns>
        private static Cell RandTypeOfANewCell()
        {
            System.Random rand = new System.Random();

            if (rand.Next(System.Enum.GetNames(typeof(Cell.Color)).Length) == (int)Cell.Color.red)
                return new RedCell();
            else
                return new BlueCell();
        }
        #endregion
    }
}