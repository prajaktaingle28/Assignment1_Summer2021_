using System;
using System.Linq;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] nums = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(nums);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);

            //Question 4:
            int[] arr1 = { 1, 7, 3, 6, 5, 6 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }



        /*   <summary>
/// Input: moves = "UD"     Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. 
//Therefore, we return true.*/
      
        private static bool JudgeCircle(string moves)
        {
            try
            {
                //taking x and y variables to indicate the X and Y axis respectively
                int x = 0, y = 0;
                int l = moves.Length;

                //Initiate loop from 0 to lenght of string moves
                for (int i = 0; i < l; i++)
                {

                    if (moves[i] == 'U') // check if the 'i'th character of the string moves is 'U'
                    {
                        y++;  //robot moves UP to positive Y-axis by 1 value
                    }

                    else if (moves[i] == 'D') // check if the 'i'th character of the string moves is 'D'
                    {
                        y--;// robot moves DOWN to negative Y-axis
                    }
                    else if (moves[i] == 'L') // check if the 'i'th character of the string moves is 'L'
                    {
                        x--; //robot moves LEFT to negative X-axis
                    }
                    else if (moves[i] == 'R') // check if the 'i'th character of the string moves is 'R'
                    {
                        x++;//robot moves RIGHT to negative X-axis
                    }
                    else  
                    {
                        // Display the below statement if the input does not contain the U,L,R,D letters
                        Console.WriteLine("Invalid input");
                    }
                }

                //Check the position of robot, if it is at origin (0,0) or not
                if (x == 0 & y == 0)
                {

                    //return true if robot is at the origin
                    return true;

                }

                else
                {
                    //return false if robot is not at the origin
                    return false;
                }

            }
            //catch the exception if error occurs
            catch (Exception)
            {
                throw;
            }
        }        
        

        /* <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.Given a string sentence containing only lowercase English letters, 
//return true if sentence is a pangram, or false otherwise. */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                //converting all the string to lower case,if in case uppercase letters comes in input
                string sentence = s.ToLower();

                //exporting all the distinct letters/chars from the input string and storing in a variable array
                var distinctCharArray = sentence.ToCharArray().Distinct().ToArray();

                // keeping the array values as a string in new string variable
                var finalStr = new string(distinctCharArray);

                //loop to check if the total length of the distinct letter string is 26 or not
                if (finalStr.Length == 26)
                {
                    return true;            /*if the string has all 26 distinct letters, return true
                                            i.e. it is a pangram string   */
                }
                else
                {
                    return false;       /*if the string doesn't have all 26 distinct letters, return false
                                            i.e. it is a pangram string  */
                }
            }
            //catch the exception if error occurs
            catch (Exception)
            {
                throw;
            }
        }


        /* <summary>
 Given an array of integers nums  A pair (i,j) is called good if nums[i] == nums[j] and i < j. Return the number of good pairs.     */

        private static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // initiating count variable with value 0
                int count = 0;
                // initiating loop from 0 to array length
                for (int i = 0; i < nums.Length; i++) // picking the nums[i] value to compare
                {
                    //initiating loop from 1 incremented value than i till array length
                    for (int j = i + 1; j < nums.Length; j++) 

                        /* picking the nums[j] value to compare,throughout the array */
                    {
                        //checking if the the 'i'th value of array nums is equal to 'j'th value of array nums
                        if (nums[i] == nums[j] & i < j)
                        { 
                            //the values found to be equal, increment the count else don't increment
                            count++;
                        }
                    }
                }
                // returning the final int value count of good pairs who fulfils the condition
                return count;

            }
            catch (Exception)
            {

                throw;
            }
        }      

        
        /*          <summary>   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of
        //all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
        //If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
        //Return the leftmost pivot index. If no such index exists, return -1.*/

        private static int PivotIndex(int[] arr1)
        {
            try
            {
                // taking total array arr1 length in len variable
                int len = arr1.Length;
                int[] leftsum = new int[len]; // Declared an integer leftsum array of arr1 length 
                int[] rightsum = new int[len];  // Declared an integer rightsum array of arr1 length 

                //initiating loop from 1 to arr1 length
                for (int i = 1; i < len; i++)
                {
                    // 'i'th element of leftsum array will be appended with the sum of array values to the left from index i
                    leftsum[i] = leftsum[i - 1] + arr1[i - 1];

                    //'i'th element of rightsum array will be appended with the sum of array values to the rigth from index i
                    rightsum[len - i - 1] = rightsum[len - i] + arr1[len - i];
                }

                //loop to check and compare if the leftsum and rigthsum values
                for (int i = 0; i < len; i++)
                {
                    //Compare the appended set of sum of values stored in arrays leftsum and rigthsum
                    if (leftsum[i] == rightsum[i])

                    {
                        //return the position of index value where the sum of it's left index values
                        //and sum of it's right index values are equal 
                        return i;
                    }
                }

                return -1;
            }
            //error handling 
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /*   /// <summary>    /// You are given two strings word1 and word2. Merge the strings by adding letters 
        /// in alternating order, starting with word1. If a string is longer than the other,
    /// append the additional letters onto the end of the merged string    */

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                //Declared a null string mergedstr
                string mergedstr = "";

                //loop to check the entered strings are NULL or not
                if (word1.Length != 0 || word2.Length != 0)
                {
                    //loop from 0 to the highest length value of either str word1 or str word2
                    for (int i = 0; i < word1.Length || i < word2.Length; i++)
                    {

                        // loop to check if the ith value has reached till the length of str word1
                        if (i < word1.Length)

                            //append the ith char of str word1 to the string mergedstr
                            mergedstr += word1[i];

                        // loop to check if the ith value has reached till the length of str word2
                        if (i < word2.Length)

                            //append the ith char of str word2 to the string mergedstr
                            mergedstr += word2[i];
                    }

                    //return the appended merged string of word1 and word2 srings
                    return mergedstr;
                }
                else
                {
                    //if the input string values are null,return NULL
                    return "null";
                }

            }
            //error handling
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }



        /* <summary>      /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
        //We would like to convert the 
        //sentence to "Goat Latin" (a made-up language similar to Pig Latin.) The rules of Goat Latin are as follows: */
        
        
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                //Declared a string to store upper and lower case vowels
                String vowel = "aeiouAEIOU";

                //split the input string by spaces and store the splitted strings as values in array strArr
                String[] strArr = sentence.Split(" ");

                int strlen = strArr.Length; // calculate array length 

                //Declared a string builder sb to do the modifications in the existing string array strArr
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //loop from 0 to length of array strArr
                for (int i = 0; i < strlen; i++)
                {
                    //Declared string cur to store the ith value of array strArr
                    String cur = strArr[i];

                    //loop to check the first letter (0th index) of the ith string is a vowel or not
                    if (vowel.IndexOf(cur[0]) >= 0)
                    {
                        //append the string stored in cur variable in the string builder variable sb
                        sb.Append(cur);

                        //append the suffix 'ma'to the string builder variable sb
                        sb.Append("ma");
                    }
                    else  //the first letter (0th index) of the ith string is not a vowel 
                    {
                        //append the substring of the string stored in cur variable from 1st index
                        //to it's end to the string builder variable sb
                        sb.Append(cur.Substring(1));

                        //substring the 1st letter of cur string and append it to the string builder sb
                        sb.Append(cur.Substring(0, 1));

                        //append the suffix 'ma'to the string builder variable sb
                        sb.Append("ma");
                    }

                    //loop from 0 to incremental value of i (to check the string index in the array strArr)
                    for (int j = 0; j < i + 1; j++)
                    {
                        //append the suffix 'a'to the string builder variable sb
                        sb.Append("a");
                        
                    }

                    //append  the string builder variable sb with space after every string value of array strArr
                    sb.Append(" ");
                }

                //remove all leading and trailing white-spacereturn and return the 'goat latin' formed sentence
                return sb.ToString().Trim();
            }
            //error handling
            catch (Exception)
            {
                throw;
            }
        }
    }
}
