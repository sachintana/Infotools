using System;

namespace Infotools.StringLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            flatternArrayTest();

            // Test 2
            htmlValidationTest();

            Console.ReadLine();
        }

        /// <summary>
        /// Test 1
        /// </summary>
        private static void flatternArrayTest()
        {
            // Input data structure [[1,2,[3]],4]
            ArrayNode arrayNodes = GetArrayDataStruture();

            // Convert nested array to single dimention array
            int[] flatternArray = arrayNodes.ToFlatternArray();

            foreach (int intValue in flatternArray)
            {
                Console.WriteLine(intValue);
            }
        }

        /// <summary>
        /// Test 2
        /// </summary>
        private static void htmlValidationTest()
        {
            string htmlString = @"<B>This should be in boldface, but there is an extra closing tag</B></C>";
            HtmlValidator.Validate(htmlString);
        }

        /// <summary>
        /// Construct nested array data structure where ArrayNode represents to another 
        /// linked ArrayNode and value collection of int[]
        /// </summary>
        /// <returns>ArrayNode root element</returns>
        private static ArrayNode GetArrayDataStruture()
        {
            ArrayNode rootNode = new ArrayNode
            {
                Node = new ArrayNode()
                {
                    Node = new ArrayNode()
                    {
                        ValueCollection = new int[] { 1, 2 }
                    },
                    ValueCollection = new int[] { 3 }
                },
                ValueCollection = new int[] { 4, 5 }
            };
            return rootNode;
        }
    }
}