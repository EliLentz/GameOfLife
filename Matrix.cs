using Cells;

namespace Matrix
{
    class Matrix
    {
        #region InitialValesOfMatrix

        public const int matrixSize = 15; //the matrix is symmetric, because the size, that indicated, is only one

        public Cell[,] matrix = new Cell[matrixSize, matrixSize] {
            { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { null, new BlueCell(), null, null, null, null, null, null, null, null, null, new RedCell(), new BlueCell(), null, null},
            { null, null, new BlueCell(), null, new BlueCell(), null, null, null, null, null, null, new BlueCell(), new RedCell(), null, null},
            { null, null, new BlueCell(), new BlueCell(), null, new RedCell(), null, null, null, null, null, null, null, null, null},
            { null, new RedCell(), null, null, new BlueCell(), null, new RedCell(), null, null, null, null, null, null, null, null},
            { new RedCell(), null, new RedCell(), null, new BlueCell(), new RedCell(), null, new BlueCell(), null, null, null, null, null, null, null},
            { null, new RedCell(), null, new RedCell(), null, null, new RedCell(), null, new BlueCell(), null, null, null, null, null, null},
            { null, null, new RedCell(), null, new BlueCell(), null, null, null, null, null, null, null, null, null, null},
            { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { null, null, null, null, null, null, null, null, null, null, new BlueCell(), new BlueCell(), new RedCell(), new RedCell(), null},
            { null, null, null, null, null, null, null, null, null, null, new BlueCell(), null, null, new RedCell(), null},
            { new RedCell(), new BlueCell(), null, null, null, null, null, null, null, null, new RedCell(), null, null, new BlueCell(), null},
            { new RedCell(), new BlueCell(), null, null, null, null, null, null, null, null, new RedCell(), new RedCell(), new BlueCell(), new BlueCell(), null},
            { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null}
        };//the matrix initial initialization

        //14/  |  |  |  |  |  |  |  |  |  |  |  |  |  |  | 
        //13/  |♦ |  |  |  |  |  |  |  |  |  |  |♦ |♦ |  | 
        //12/  |  |♦ |  |♦ |  |  |  |  |  |  |  |♦ |♦ |  | 
        //11/  |  |♦ |♦ |  |♦ |  |  |  |  |  |  |  |  |  | 
        //10/  |♦ |  |  |♦ |  |♦ |  |  |  |  |  |  |  |  | 
        //9//♦ |  |♦ |  |♦ |♦ |  |♦ |  |  |  |  |  |  |  | 
        //8//  |♦ |  |♦ |  |  |♦ |  |♦ |  |  |  |  |  |  | 
        //7//  |  |♦ |  |♦ |  |  |  |  |  |  |  |  |  |  | 
        //6//  |  |  |  |  |  |  |  |  |  |  |  |  |  |  | 
        //5//  |  |  |  |  |  |  |  |  |  |  |  |  |  |  | 
        //4//  |  |  |  |  |  |  |  |  |  |♦ |♦ |♦ |♦ |  | 
        //3//  |  |  |  |  |  |  |  |  |  |♦ |  |  |♦ |  | 
        //2//♦ |♦ |  |  |  |  |  |  |  |  |♦ |  |  |♦ |  | 
        //1//♦ |♦ |  |  |  |  |  |  |  |  |♦ |♦ |♦ |♦ |  | 
        //0//  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
        //////0//1//2//3//4//5//6//7//8//9/10/11/12/13/14/
        
        #endregion

        public Matrix()
        {
            Interface();
        }

        /// <summary>
        /// Intializes the interface
        /// </summary>
        private void Interface()
        {
            while(HasAnyoneAliveCell())
            {
                Print.PrintMatrix(matrix);

                Logic.GenerateNewCell(matrix);

                Logic.RefreshMatrix(matrix);
                Logic.KillCells(matrix);

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