/******************
 * Ross Dougherty
 * 2014-02-25
 * ***************/

using System;
using System.Text;

namespace RallyNumberSpiral
{
    /// <summary>
    /// This class accepts an integer and prints the integers from 0 to the 
    /// input integer in a spiral format.  It does this by performing the following:
    /// 1. Create a 2 dimentional array to hold all the numbers
    ///     The array is indexed in a cartesian coordinate fasion with the X
    ///     coordinate running Left-Right with right being the positive direction,
    ///     and left the negative.  The Y coordinate runs Up-Down with down being
    ///     positive direction and up being negative.  This allows the algorithm to
    ///     easily keep track of what index is currently being written to, and which
    ///     index to move to for the next number.
    /// 2. Determine what index of the array to start adding numbers
    /// 3. Write the current number in that index
    /// 4. Move to the next index
    /// 5. Repeat 3 and 4 until the input integer is reached
    /// </summary>
    public class NumberSpiral
    {
        /// <summary>
        /// This factory allows for better handling of input errors.
        /// </summary>
        /// <param name="maxNumber">The highest number to go to
        /// in the spiral</param>
        /// <returns>The newly created NumberSpiral object</returns>
        public static NumberSpiral CreateNumberSpiral(string maxNumber)
        {
            int maxNumberInt;
            if (!int.TryParse(maxNumber, out maxNumberInt))
            {
                throw new Exception("Please enter a valid positive integer value.");
            }
            if (maxNumberInt < 0)
            {
                throw new Exception("Please enter a positive integer.");
            }

            return new NumberSpiral(maxNumberInt);
        }

        /// <summary>
        /// This will create a number spiral
        /// </summary>
        /// <param name="maxNumber">The highest number to go to
        /// in the spiral</param>
        private NumberSpiral(int maxNumber)
        {
            this.maxNumber = maxNumber;

            //Initialize the size of the array
            arrayLength = (int)Math.Floor(Math.Sqrt(maxNumber) + 1);
            spiralArray = new int[arrayLength, arrayLength];

            //Initialize the array with vales of -1.  This way it can be known what 
            //array elements are unoccupied and will assist with printing the spiral.
            for (int y = 0; y < arrayLength; y++)
                for (int x = 0; x < arrayLength; x++)
                    spiralArray[x, y] = -1;

            //Find the starting indices
            X_Index = (int)Math.Ceiling((double)arrayLength / 2) - 1;
            Y_Index = X_Index;

            //Initialize movement directions
            X_Direction = X_Movement.Right;
            Y_Direction = Y_Movement.NotMoving;

            //Build the array
            for (int currentNumber = 0; currentNumber <= maxNumber; currentNumber++)
            {
                spiralArray[X_Index, Y_Index] = currentNumber;
                Move(currentNumber);
            }
        }
        private readonly int maxNumber;
        private readonly int arrayLength;

        //This will hold the spiral
        private int[,] spiralArray;

        //These indicate where in the spiral array to write the next number
        private int X_Index, Y_Index;

        //These indicate which direction to move the indices once a number is written 
        //to the spiral array
        private X_Movement X_Direction;
        private Y_Movement Y_Direction;

        //These are used to figure out where to turn in the spiral.  If the number
        //that was just written is equal to the product of these numbers, it is
        //at a turning point
        private int X_Multiplier = 1;
        private int Y_Multiplier = 1;

        /// <summary>
        /// This method moves the array indices to the next correct spot in 
        /// the spiral array
        /// </summary>
        /// <param name="currentNumber">The current number being written to 
        /// the spiral array</param>
        private void Move(int currentNumber)
        {
            //If not at a turning point, simply move to the next 
            //position in the array
            if (currentNumber != X_Multiplier * Y_Multiplier)
            {
                X_Index += (int)X_Direction;
                Y_Index += (int)Y_Direction;
                return;
            }

            //Otherwise this is a turning point - decide what to do next

            //if moving in X, stop moving in X and change directions in Y
            if (Y_Direction == 0)
            {
                if (X_Direction == X_Movement.Right)
                    Y_Direction = Y_Movement.Down;
                else
                    Y_Direction = Y_Movement.Up;

                X_Direction = X_Movement.NotMoving;
                Y_Index += (int)Y_Direction;
                X_Multiplier++;
                return;
            }

            //Otherwise, stop moving in Y and change 
            //directions in X
            if (Y_Direction == Y_Movement.Down)
                X_Direction = X_Movement.Left;
            else
                X_Direction = X_Movement.Right;

            Y_Direction = Y_Movement.NotMoving;
            X_Index += (int)X_Direction;
            Y_Multiplier++;
        }

        /// <summary>
        /// This will print out the spiral in the proper format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //This is the length of the longest number in the series
            var numberLength = maxNumber.ToString().Length;

            //This string is used to format the individual numbers.  It will pad
            //the correct number of spaces in front of shorter numbers.
            string format = string.Format("{{0,{0}:{1}0}} ", numberLength, new String('#', numberLength - 1));

            string line;
            for (int y = 0; y < arrayLength; y++)
            {
                line = "";
                for (int x = 0; x < arrayLength; x++)
                {
                    if (spiralArray[x, y] != -1)
                        line += string.Format(format, spiralArray[x, y]);
                    else

                        //Print a blank space for empty array indices
                        line += new String(' ', numberLength + 1);
                }

                if (!string.IsNullOrEmpty(line.Trim()))
                    sb.AppendLine(line.TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// These enums exist to make keeping track of direction easier
        /// </summary>
        private enum X_Movement : int
        {
            Right = 1,
            Left = -1,
            NotMoving = 0
        }
        private enum Y_Movement : int
        {
            Down = 1,
            Up = -1,
            NotMoving = 0
        }
    }
}