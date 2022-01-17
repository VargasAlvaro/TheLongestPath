// <copyright file="FormLongestSkiRun.cs" company="EasySolutions">
// Descripción de Funcionalidad   : Form to find the longest path in a matrix
// Nombre Programador             : Ing. Alvaro Vargas
// Creation date                  : 16 Enero 2022
// </copyright>

namespace WFALongestSkiRun
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Class FormLongestSkiRun
    /// </summary>
    public partial class FormLongestSkiRun : Form
    {
        #region Variables

        /// <summary>
        /// Indicates the rows of the loaded matrix
        /// </summary>
        private int rows;

        /// <summary>
        /// Indicates the columns of the loaded matrix
        /// </summary>
        private int columns;

        /// <summary>
        /// The loaded matrix
        /// </summary>
        private int[][] matrix = null;

        #endregion Variables

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormLongestSkiRun"/> class
        /// </summary>
        public FormLongestSkiRun()
        {
            this.InitializeComponent();
        }

        #endregion Contructors

        #region Events

        /// <summary>
        /// FormLongestSkiRun Load event
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Event e</param>
        private void FormLongestSkiRun_Load(object sender, EventArgs e)
        {
            this.rows = 0;
            this.columns = 0;
        }

        /// <summary>
        /// ButtonLoadInput Button click event
        /// </summary>
        /// <param name="sender">Object sender </param>
        /// <param name="e">Event e</param>
        private void ButtonLoadInput_Click(object sender, EventArgs e)
        {
            this.LoadInput();
        }

        /// <summary>
        /// Button Button click event
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Event e</param>
        private void ButtonProcces_Click(object sender, EventArgs e)
        {
            List<string> result = this.FindResults(this.matrix);

            this.textBoxResults.Text = string.Empty;

            foreach (var text in result)
            {
                this.textBoxResults.Text = this.textBoxResults.Text + text + "\r\n";
            }
        }

        /// <summary>
        /// ButtonCancel Button click event
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Event e</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Clean();
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Method for load matrix
        /// </summary>
        private void LoadInput()
        {
            try
            {
                DialogResult result = openFileDialogInput.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.textBoxInput.Text = openFileDialogInput.FileName;
                    if (this.textBoxInput.Text != string.Empty)
                    {
                        this.textBoxInput.ReadOnly = true;

                        if (this.LoadMatrix() == "OK")
                        {
                            this.textBoxResults.Text = string.Empty;
                            this.textBoxResults.Text = "The matrix was loaded successfully";
                        }
                        else
                        {
                            MessageBox.Show($"Failed to load matrix, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Clean();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error chargin input: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method to clear form fields
        /// </summary>
        private void Clean()
        {
            try
            {
                this.textBoxInput.Text = string.Empty;
                this.textBoxResults.Text = string.Empty;

                this.textBoxInput.ReadOnly = false;
                this.rows = 0;
                this.columns = 0;
                this.matrix = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cleaning: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Methods

        #region Functions 

        /// <summary>
        /// Function to load the array.
        /// </summary>
        /// <returns>Returns a matrix of type string</returns>
        private string LoadMatrix()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string patch = this.textBoxInput.Text;
                string[] lines = File.ReadAllLines(patch);

                string[] rowsAndColumns = lines[0].Split(' ');

                if (rowsAndColumns.Length != 2)
                {
                    MessageBox.Show($"The first line does not define the matrix, try another input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                else
                {
                    this.rows = Convert.ToInt32(rowsAndColumns[0]);
                    this.columns = Convert.ToInt32(rowsAndColumns[1]);
                }

                if (this.rows == 0 || this.columns == 0)
                {
                    MessageBox.Show($"Cannot define an array with value zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }

                int[,] matrixLocal = new int[this.rows, this.columns];

                for (int i = 0; i < this.rows; i++)
                {
                    string[] line = lines[i + 1].Split();

                    for (int j = 0; j < this.columns; j++)
                    {
                        matrixLocal[i, j] = Convert.ToInt32(line[j].ToString());
                    }
                }

                this.matrix = new int[this.rows][];

                for (int i = 0; i < this.rows; i++)
                {
                    int[] vector = new int[this.columns];
                    for (int j = 0; j < this.columns; j++)
                    {
                        vector[j] = matrixLocal[i, j];
                    }

                    this.matrix[i] = vector;
                }

                return "OK";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error chargin input: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Function that returns length of the longest path beginning with any cell
        /// </summary>
        /// <param name="mat">Loaded matrix</param>
        /// <returns>Returns a list of texts</returns>
        private List<string> FindResults(int[][] mat)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int result = 1;
                int majorValue = 0;
                List<string> listResult = new List<string>();

                // Create a lookup table and fill. All entries in it as -1
                int[][] dp = RectangularArrays.ReturnRectangularIntArray(this.rows, this.rows);
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        dp[i][j] = -1;
                    }
                }

                string[][] matPath = RectangularArrays.ReturnRectangularStringArray(this.rows, this.columns);

                ////Calculate longest path from all cells
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        if (dp[i][j] == -1 || mat[i][j] > majorValue)
                        {
                            matPath[i][j] = mat[i][j].ToString();
                            if (mat[i][j] > majorValue)
                            {
                                majorValue = mat[i][j];
                            }

                            this.FindLongestFromACell(i, j, mat, dp, matPath);
                        }

                        result = Math.Max(result, dp[i][j]);
                    }
                }

                ////Calculate path
                string resultPath = string.Empty;

                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        string actualPath = matPath[i][j];

                        if (actualPath.Split('-').Length == result)
                        {
                            if (resultPath != string.Empty)
                            {
                                if (Convert.ToInt32(actualPath.Split('-')[0]) > Convert.ToInt32(resultPath.Split('-')[0]))
                                {
                                    resultPath = actualPath;
                                }
                            }
                            else
                            {
                                resultPath = actualPath;
                            }
                        }
                    }
                }

                ////Length of calculated path
                string dropPath = string.Empty;
                string[] dropPathA = resultPath.Split('-');
                int dif = Convert.ToInt32(dropPathA[0]) - Convert.ToInt32(dropPathA[dropPathA.Length - 1]);

                ////Add results
                listResult.Add($"Length of calculated path: {result.ToString()}");
                listResult.Add($"Drop of calculated path: {dif.ToString()}");
                listResult.Add($"Calculated path: {resultPath}");

                this.Cursor = Cursors.Default;

                return listResult;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error finding results: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        /// <summary>
        /// Function that returns length of the longest path beginning with mat[i][j]
        /// </summary>
        /// <param name="i">Starting row to iterate</param>
        /// <param name="j">starting column to iterate</param>
        /// <param name="mat">Matrix with data</param>
        /// <param name="dp">Matrix with long paths</param>
        /// <param name="matPath">Matrix with calculated paths</param>
        /// <returns>Returns length</returns>
        private int FindLongestFromACell(int i, int j, int[][] mat, int[][] dp, string[][] matPath)
        {
            // Base case
            if (i < 0 || i >= this.rows || j < 0 || j >= this.columns)
            {
                return 0;
            }

            //// If this subproblem is
            //// already solved
            ////if (dp[i][j] != -1)
            ////{
            ////    return dp[i][j];
            ////}

            ////To store the path lengths in all the four directions
            int x = int.MinValue, y = int.MinValue, z = int.MinValue, w = int.MinValue;

            ////Move in possible directions
            if (j < this.rows - 1 && (mat[i][j] > mat[i][j + 1]))
            {
                if (matPath[i][j + 1] != null)
                {
                    string matPathAct = matPath[i][j + 1];
                    string matPathNew = matPath[i][j] + "-" + mat[i][j + 1].ToString();

                    string[] canPathAct = matPathAct.Split('-');
                    string[] canPathNew = matPathNew.Split('-');

                    if (canPathNew.Length > canPathAct.Length)
                    {
                        matPath[i][j + 1] = matPathNew;
                    }

                    if (canPathNew.Length == canPathAct.Length)
                    {
                        if (Convert.ToInt32(canPathNew[0]) > Convert.ToInt32(canPathAct[0]))
                        {
                            matPath[i][j + 1] = matPathNew;
                        }
                    }
                }
                else
                {
                    matPath[i][j + 1] = matPath[i][j] + "-" + mat[i][j + 1].ToString();
                }

                x = dp[i][j] = 1 + this.FindLongestFromACell(i, j + 1, mat, dp, matPath);
            }

            if (j > 0 && (mat[i][j] > mat[i][j - 1]))
            {
                if (matPath[i][j - 1] != null)
                {
                    string matPathAct = matPath[i][j - 1];
                    string matPathNew = matPath[i][j] + "-" + mat[i][j - 1].ToString();

                    string[] canPathAct = matPathAct.Split('-');
                    string[] canPathNew = matPathNew.Split('-');

                    if (canPathNew.Length > canPathAct.Length)
                    {
                        matPath[i][j - 1] = matPathNew;
                    }

                    if (canPathNew.Length == canPathAct.Length)
                    {
                        if (Convert.ToInt32(canPathNew[0]) > Convert.ToInt32(canPathAct[0]))
                        {
                            matPath[i][j - 1] = matPathNew;
                        }

                        if (canPathNew.Length == canPathAct.Length)
                        {
                            if (Convert.ToInt32(canPathNew[0]) > Convert.ToInt32(canPathAct[0]))
                            {
                                matPath[i][j - 1] = matPathNew;
                            }
                        }
                    }
                }
                else
                {
                    matPath[i][j - 1] = matPath[i][j] + "-" + mat[i][j - 1].ToString();
                }

                y = dp[i][j] = 1 + this.FindLongestFromACell(i, j - 1, mat, dp, matPath);
            }

            if (i > 0 && (mat[i][j] > mat[i - 1][j]))
            {
                if (matPath[i - 1][j] != null)
                {
                    string matPathAct = matPath[i - 1][j];
                    string matPathNew = matPath[i][j] + "-" + mat[i - 1][j].ToString();

                    string[] canPathAct = matPathAct.Split('-');
                    string[] canPathNew = matPathNew.Split('-');

                    if (canPathNew.Length > canPathAct.Length)
                    {
                        matPath[i - 1][j] = matPathNew;
                    }

                    if (canPathNew.Length == canPathAct.Length)
                    {
                        if (Convert.ToInt32(canPathNew[0]) > Convert.ToInt32(canPathAct[0]))
                        {
                            matPath[i - 1][j] = matPathNew;
                        }
                    }
                }
                else
                {
                    matPath[i - 1][j] = matPath[i][j] + "-" + mat[i - 1][j].ToString();
                }

                z = dp[i][j] = 1 + this.FindLongestFromACell(i - 1, j, mat, dp, matPath);
            }

            if (i < this.rows - 1 && (mat[i][j] > mat[i + 1][j]))
            {
                if (matPath[i + 1][j] != null)
                {
                    string matPathAct = matPath[i + 1][j];
                    string matPathNew = matPath[i][j] + "-" + mat[i + 1][j].ToString();

                    string[] canPathAct = matPathAct.Split('-');
                    string[] canPathNew = matPathNew.Split('-');

                    if (canPathNew.Length > canPathAct.Length)
                    {
                        matPath[i + 1][j] = matPathNew;
                    }

                    if (canPathNew.Length == canPathAct.Length)
                    {
                        if (Convert.ToInt32(canPathNew[0]) > Convert.ToInt32(canPathAct[0]))
                        {
                            matPath[i + 1][j] = matPathNew;
                        }
                    }
                }
                else
                {
                    matPath[i + 1][j] = matPath[i][j] + "-" + mat[i + 1][j].ToString();
                }

                w = dp[i][j] = 1 + this.FindLongestFromACell(i + 1, j, mat, dp, matPath);
            }

            // If none of the adjacent fours is one greater we will take 1
            // otherwise we will pick maximum from all the four directions
            dp[i][j] = Math.Max(x, Math.Max(y, Math.Max(z, Math.Max(w, 1))));

            return dp[i][j];
        }

        #endregion Functions 

        /// <summary>
        /// Class to create rectangular arrays
        /// </summary>
        public static class RectangularArrays
        {
            /// <summary>
            /// Function to return array of type integer
            /// </summary>
            /// <param name="size1">size for rows</param>
            /// <param name="size2">size for columns</param>
            /// <returns>Return array of type integer</returns>
            public static int[][] ReturnRectangularIntArray(int size1, int size2)
            {
                int[][] newArray = new int[size1][];
                for (int array1 = 0;
                     array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }

            /// <summary>
            /// Function to return array of type string
            /// </summary>
            /// <param name="size1">size for rows</param>
            /// <param name="size2">size for columns</param>
            /// <returns>Return array of type string</returns>
            public static string[][] ReturnRectangularStringArray(int size1, int size2)
            {
                string[][] newArray = new string[size1][];
                for (int array1 = 0;
                     array1 < size1; array1++)
                {
                    newArray[array1] = new string[size2];
                }

                return newArray;
            }
        }
    }
}