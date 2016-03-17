using System;
using System.Collections.Generic;

namespace Infotools.StringLibrary
{
    /// <summary>
    /// Nested array data structure where ArrayNode represents to another 
    /// linked ArrayNode and value collection of int[]
    /// </summary>
    public class ArrayNode
    {
        public ArrayNode Node { get; set; }
        public int[] ValueCollection { get; set; }

        /// <summary>
        /// Flattern nested array to int[]
        /// </summary>
        /// <returns>Array of integers</returns>
        public int[] ToFlatternArray()
        {
            List<int> intArray = new List<int>();

            ToArray(this, intArray);

            intArray.Reverse();
            return intArray.ToArray();
        }

        /// <summary>
        /// Recursive ToArray implementation to convert each ArrayNode to List<int> array
        /// </summary>
        /// <param name="arrayNode"></param>
        /// <param name="intArray"></param>
        private void ToArray(ArrayNode arrayNode, List<int> intArray)
        {
            if (arrayNode != null)
            {
                ArrayNode node = arrayNode.Node;
                int[] valueCollection = arrayNode.ValueCollection;

                if (valueCollection != null && valueCollection.Length > 0)
                {
                    Array.Reverse(valueCollection);
                    intArray.AddRange(valueCollection);
                }
                
                if (node != null)
                {
                    ToArray(node, intArray);
                }
            }
        }
    }
}
