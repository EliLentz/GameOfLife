using Cells;
using Interface;
using System;
using System.Xml;

namespace XMLReader
{
    class XMLInput
    {
        static XmlDocument xDoc = new XmlDocument();

        /// <summary>
        /// Converts information about a cell from XML to a cell in a matrix
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Cell [,] ConverterXMLToMatrix(string path)
        {
            Cell[,] newMatrix = new Cell[Matrix.matrixSize, Matrix.matrixSize];

            try
            {
                xDoc.Load(path);
            }
            catch
            {
                newMatrix = Logic.GenerateInitialMatrix();
                return newMatrix;
            }

            XmlElement xRoot = xDoc.DocumentElement;

            int XCoordinate;
            int YCoordinate;

            foreach (XmlNode xnode in xRoot)
            {
                XCoordinate = ParseCoordinateX(xnode);
                YCoordinate = ParseCoordinateY(xnode);

                if (XCoordinate >= 0 && YCoordinate >= 0 && XCoordinate < Matrix.matrixSize && YCoordinate < Matrix.matrixSize)
                    newMatrix[YCoordinate, XCoordinate] = ParseColorCell(xnode);
            }

            return newMatrix;
        }

        #region HelpFunctions
        /// <summary>
        /// Converts a cell 'x' coordinate from XML to xCoordinate
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns>int</returns>
        private static int ParseCoordinateX(XmlNode xnode)
        {
            int XCoordinate = -1;

            foreach (XmlNode childAttr in xnode.Attributes)
                if (childAttr.Name == "X")
                    Int32.TryParse(childAttr.InnerText, out XCoordinate);

            return XCoordinate;
        }

        /// <summary>
        /// Converts a cell 'y' coordinate from XML to yCoordinate
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns>int</returns>
        private static int ParseCoordinateY(XmlNode xnode)
        {
            int YCoordinate = -1;

            foreach (XmlNode childAttr in xnode.Attributes)
                if (childAttr.Name == "Y")
                    Int32.TryParse(childAttr.InnerText, out YCoordinate);

            return YCoordinate;
        }

        /// <summary>
        /// Creates a new cell based on the color received in the XML file
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns>Cell</returns>
        private static Cell ParseColorCell(XmlNode xnode)
        {
            Cell.Color ColorOfCell;

            Enum.TryParse(xnode.InnerText, out ColorOfCell);

            if (ColorOfCell == Cell.Color.Blue)
                return new BlueCell();
            else return new RedCell();
        }
        #endregion
    }
}
