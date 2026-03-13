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
        
        
        //i will create a for loop, where i used int i = 1, where int i <= length then increments i.
        //i will create a variable containing a new list and multiple  that new list by i so it will return a new list with double
        //i will return that variable containing a new list 

        var results = new double[length];
        for (int i = 1; i <= length; i++)
        {
            results[i - 1] = number * i;
        }

        return results;
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

        //i will create a new variable1 that will use the data list with  GetRange(index, count) by using as index = data.count - amount, then count = amount
        //i will create a new variable2 that will get the rest of list using GetRange(index, count) , this time the inde start with 0, count = data.count - amount
        //i will create a new variable combined in order to create in new list with variable1
        //i will clear data list with data.Clear()
        // i will use data.Addrange(combned) with variable combined list as parameter to copy rotated values back in
        //i will create a new variable1 using GetRange(data.Count - amount, amount) → last 'amount' elements
        //i will create a new variable2 using GetRange(0, data.Count - amount) → the rest of the elements
        //i will create a new variable combined starting with variable1
        //i will use combined.AddRange(variable2) to append the rest
        //i will clear data and copy combined back into it to modify the original list

        var variable1 = data.GetRange(data.Count - amount, amount);
        var variable2 = data.GetRange(0, data.Count - amount);
        var combined = new List<int>(variable1);
        combined.AddRange(variable2);
        data.Clear();
        data.AddRange(combined);

    }
}
