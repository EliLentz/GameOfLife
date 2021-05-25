using System.Xml.Linq;
using System;
using System.IO;

namespace XMLReader
{
    class XMLOutput
    {
        /// <summary>
        /// Outputs game results to the "GamesPlayed" folder in an XML file
        /// </summary>
        /// <param name="currentMatrix"></param>
        /// <param name="timeOfGameStart"></param>
        public static void OutputToNewXMLFile(Cells.Cell [,] currentMatrix, DateTime timeOfGameStart)
        {
            XDocument xDoc = new XDocument();
            
            xDoc.Add(XMLElementCreator(currentMatrix));

            Directory.CreateDirectory("GamesPlayed");
            xDoc.Save(@"GamesPlayed/" + $"{timeOfGameStart.ToString("yyyy-dd-M--HH-mm-ss")}.xml");
        }

        /// <summary>
        /// Builds XML Element based on existing cells in the matrix
        /// </summary>
        /// <param name="currentMatrix"></param>
        /// <returns></returns>
        private static XElement XMLElementCreator(Cells.Cell [,] currentMatrix)
        {
            XElement border = new XElement("Border");

            for (int i = 0; i < Interface.Matrix.matrixSize; i++)
                for (int j = 0; j < Interface.Matrix.matrixSize; j++)
                    if (currentMatrix[i, j] != null)
                    {
                        XElement cell = new XElement("Cell", currentMatrix[i, j].ColorOfCell);

                        XAttribute xCoordinate = new XAttribute("X", j.ToString());
                        XAttribute yCoordinate = new XAttribute("y", i.ToString());

                        cell.Add(xCoordinate);
                        cell.Add(yCoordinate);
                        border.Add(cell);
                    }

            return border;
        }
    }
}
