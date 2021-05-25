using Cells;

namespace Interface
{
    class Matrix
    {

        public const int matrixSize = 15; //the matrix is symmetric, because the size, that indicated, is only one

        public Cell[,] matrix = new Cell[matrixSize, matrixSize];

        public Matrix()
        {
            Interface();
        }

        /// <summary>
        /// Intializes the interface
        /// </summary>
        private void Interface()
        {
            System.DateTime dateTimeOfGameStart = System.DateTime.Now;

            matrix = XMLReader.XMLInput.ConverterXMLToMatrix("InitialStates.xml");

            while(HasAnyoneAliveCell())
            {
                Print.PrintMatrix(matrix);

                Logic.GenerateNewCell(matrix);

                Logic.RefreshMatrix(matrix);
                Logic.KillCells(matrix);

                XMLReader.XMLOutput.OutputToNewXMLFile(matrix, dateTimeOfGameStart);

                Logic.DoSleep();
            }
        }

        /// <summary>
        /// If at least one cell is alive in the matrix
        /// </summary>
        /// <returns>boolean</returns>
        private bool HasAnyoneAliveCell()
        {
            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                    if (matrix[i, j] != null)
                        return true;

            return false;
        }
    }
}