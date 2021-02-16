using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        public static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(5);
            Names();
        }

        // Random Array
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values
        public static int[] RandomArray()
        {
            List<int> newList = new List<int>();
            Random rand = new Random();
            for (int val = 0; val < 10; val++)
            {
                newList.Add(rand.Next(5,25));
                Console.WriteLine(newList[val]);
            }
            int[] newArr = newList.ToArray();
            int min = newArr[0];
            int max = newArr[0];
            int sum = 0;

            foreach (var entry in newArr)
            {
                sum = entry + sum;
                if (entry > max)
                {
                    max = entry;
                }
                if (entry < min)
                {
                    min = entry;
                }
            }
            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
            return newArr;

            // or instead of converting from List to Array:
            // Random rand = new Random();
            // for (int val = 0; val < 10; val++)
            // {
            //     newArr[val] = (int)rand.Next(5,25);
            //     Console.WriteLine(newArr[val]);
            // }
        }

            // Coin Flip
            // Create a function called TossCoin() that returns a string
            // Have the function print "Tossing a Coin!"
            // Randomize a coin toss with a result signaling either side of the coin 
            // Have the function print either "Heads" or "Tails"
            // Finally, return the result
            public static string TossCoin()
            {
                Console.WriteLine("Tossing a Coin!");
                string result;
                Random rand = new Random();
                int value = rand.Next(0, 2);
                if (value == 0)
                {
                    result = "Heads!";
                }
                else
                {
                    result = "Tails!";
                }
                Console.WriteLine(result);
                return result;
            }
            
            // Create another function called TossMultipleCoins(int num) that returns a Double
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss
            public static double TossMultipleCoins(int num) 
            {
                int counter = 0;
                int countHeads = 0;
                while (counter < num)
                {
                    string result = TossCoin();
                    if (result == "Heads!")
                    {
                        countHeads++;
                    }
                    Console.WriteLine($"Flip: {counter} Result: {result}");
                    counter++;

                }

                double ratio = (double)countHeads / num;
                Console.WriteLine($"Double: {ratio}, Heads: {countHeads}, Total: {num}");
                return ratio;
            }

        // Names
        // Build a function Names that returns a list of strings.  In this function:
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the list and print the values in the new order
        // Return a list that only includes names longer than 5 characters
            public static List<string> Names()
            {
                List<string> names = new List<string> { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
                Random rand = new Random();
                // fisher-yates algorithm - range error
                // for (int i = 0; i < names.Count-1; i++)
                // {
                //     int j = rand.Next(names.Count - 1)-i;
                //     string temp = names[j];
                //     names[j] = names[i];
                //     names[i] = temp;
                // }

                int n = names.Count;
                while (n > 1) {
                    int k = rand.Next(n);
                    n--;
                    string temp = names[k];
                    names[k] = names[n];
                    names[n] = temp;
                }

                Console.WriteLine($"Shuffle: {names[0]}, {names[1]}, {names[2]}, {names[3]}, {names[4]} ");
                
                List<string> longNames = new List<string>();
                // string longNames;
                foreach (string entry in names)
                {
                    if (entry.Length > 5)
                    {
                        longNames.Add(entry);
                        Console.WriteLine($"Names longer than 5 characters: {entry}");
                    }
                }
                return longNames;
            }
    }
}
