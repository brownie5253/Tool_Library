using System;
namespace Assignment
{
    class MergeSort
    {
        //static public void MergeSort(iTool[] toolArray)
        //{
        //    // Sorts (sub)array A into nondecreasing order, from position i
        //    // to position j, inclusive
        //    int middle;
        //    int endArray = toolArray.Length - 1;
        //    int startArray = 0;

        //    if (startArray < endArray)
        //    {
        //        middle = Math.Abs((startArray + endArray) / 2);
        //        MergeSort(toolArray[startArray..middle]);
        //        MergeSort(toolArray[(middle+1)..endArray]);
        //        Merge(ref toolArray, middle);
        //    }
        //    return;
        //}

        //static public void Merge(ref iTool[] toolArray, int middle)
        //{
        //    int endArray = toolArray.Length - 1;//j
        //    int startArray = 0; //p
        //    int tempIndexer = 0;//r
        //    int startArray2 = middle + 1;//q
        //    iTool[] temp = new iTool[toolArray.Length];

        //    while (startArray <= middle && startArray2 <= endArray)
        //    {
        //        if (toolArray[startArray].NoBorrowings <= toolArray[startArray2].NoBorrowings)
        //        {
        //            temp[tempIndexer] = toolArray[startArray];
        //            startArray++;
        //        }
        //        else
        //        {
        //            temp[tempIndexer] = toolArray[startArray2];
        //            startArray2++;
        //        }

        //        tempIndexer++;

        //        if (startArray <= middle)
        //        {
        //            int sourceIndex = startArray;
        //            int destinationIndex = tempIndexer;
        //            Array.Copy(toolArray, sourceIndex, temp, destinationIndex, middle - startArray);
        //        }
        //        if (startArray2 <= endArray)
        //        {
        //            int sourceIndex = startArray2;
        //            int destinationIndex = tempIndexer;
        //            Array.Copy(toolArray, sourceIndex, temp, destinationIndex, endArray - startArray);
        //        }
        //        toolArray = temp;
        //    }
        //}

        public static iTool[] mergeSort(iTool[] array)
        {
            iTool[] left;
            iTool[] right;
            iTool[] result = new iTool[array.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
                return array;
            // The exact midpoint of our array  
            int midPoint = array.Length / 2;
            //Will represent our 'left' array
            left = new iTool[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new iTool[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new iTool[midPoint + 1];

            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = mergeSort(left);
            //Recursively sort the right array
            right = mergeSort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        private static iTool[] merge(iTool[] left, iTool[] right)
        {
            int resultLength = right.Length + left.Length;
            iTool[] result = new iTool[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft].NoBorrowings >= right[indexRight].NoBorrowings)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
