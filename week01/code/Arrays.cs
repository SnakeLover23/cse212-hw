public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //create a new array
        double[] result = new double[length];

        // loop through numbers one to "length"
        for (int i = 1; i <= length; ++i)
        {
            // create multiples and populate array
            result[i - 1] = number * i;
        }

        // returen results
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // create new list
        int[] result = new int[data.Count];

        // create index
        int index = amount;

        // loop through list
        for (int i = 0; i < data.Count; ++i)
        {
            // loop for absurd amounts
            bool end = false;
            do
            {
                // wrap around to start
                if (index >= data.Count)
                {
                    index = index - data.Count;
                }
                // for negative amounts
                else if (index < 0)
                {
                    index = index + data.Count;
                }
                // end loop
                else
                {
                    end = true;
                }
            }while (end == false);

            // populate new list
            result[index] = data[i];

            // next index
            index ++;
        }

        // clear data list
        data.Clear();

        // repopulate data list
        for (int i = 0; i < result.Length; ++i)
        {
            data.Add(result[i]);
        } 
    }
}
