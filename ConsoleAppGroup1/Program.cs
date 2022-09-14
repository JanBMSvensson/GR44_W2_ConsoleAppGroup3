


/*
 
    DISCLAIMER: My comments might be wrong (occasionally) so they are not to be considered as absolute facts (I'm also trying to learn this) ... 
    Please let me know if you find anything that you think is wrong ... ;o)
 
*/

using static System.Console;
using System.Text;

namespace ConsoleAppGroup1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            do
            {
                Console.Clear();

                Console.WriteLine("---- Menu ----\n1: ArrayEx\n2: ListEx\n3: DictionaryEx\n4: PrimitiveVariable \n5: StringBuilder \n6: SpeedTest\n7: ExceptionsEx\n8: RandomEx\n0: Exit\n\nPress number to run Example.\n\n");
                char selection = Console.ReadKey(true).KeyChar;
                switch (selection)
                {
                    case '1':
                        ArrayEx();
                        break;

                    case '2':
                        ListEx();
                        break;

                    case '3':
                        DictionaryEx();
                        break;

                    case '4':
                        int startNumber = 13;
                        WriteLine($"Before call startNumber = {startNumber}");
                        PrimitiveVariable(startNumber);
                        WriteLine($"After call startNumber = {startNumber}");
                        WriteLine(startNumber == 13 ? "The number didn't change" : "The number has changed");
                        break;

                    case '5':
                        StringBuilder sb1 = new StringBuilder();
                        sb1.Append("Some text ... ");
                        string sbtext1 = sb1.ToString();
                        WriteLine($"StringBuilder content before call: {sbtext1}");

                        AddWorld (sb1);
                        string sbtext2 = sb1.ToString();
                        WriteLine($"StringBuilder content after call: {sbtext2}");

                        WriteLine(sbtext1 == sbtext2 ? "The StringBuilder didn't change" : "The StringBuilder has changed");

                        break;

                    case '6':
                        SpeedTest();
                        break;

                    case '7':
                        ExceptionsEx();
                        break;

                    case '8':
                        RandomEx();
                        break;

                    case '0':
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            } while (loop);

        }// End of Main
        private static void RandomEx()
        {
            Random random = new Random(1);//seed number tells the random what table of random numbers to use
            //Random random = new Random();//uses the computer clock to get as a seed number
            //Random random = new Random(DateTime.Now.Ticks);//same as new Random()

            int randomNumber = random.Next();

            Console.WriteLine("Random Number was: " + randomNumber); //0 to 2.1B


            Console.WriteLine("0 to 10");
            for (int i = 0; i < 10; i++)
            {
                // 0-10 max
            }

            Console.WriteLine("1 to 10");
            for (int i = 0; i < 10; i++)
            {
                //min and max 1-10
            }
        }

        private static void ExceptionsEx()
        {
            bool notNumber = true;

            while (notNumber)
            {
                

                try
                {
                   //this line of code will not run if Convert above has a exception
                }
                catch (FormatException)
                {
                    
                }
                catch (OverflowException)
                {
                   
                }
                finally//will always run this part
                {

                }
            }
            Console.WriteLine("after loop");

        }

        private static void SpeedTest()
        {
            string starsString = "";
            DateTime stringStart = DateTime.Now;

            for (int i = 0; i < 10000; i++)
            {
                starsString += "*";
            }

            DateTime stringEnd = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            DateTime sbStart = DateTime.Now;

            for (int i = 0; i < 10000; i++)
            {
                sb.Append("*");
            }

            DateTime sbEnd = DateTime.Now;

            Console.WriteLine($"string time: {stringEnd - stringStart}");
            Console.WriteLine($"StringBuilder time: {sbEnd - sbStart}");
        }

        private static void AddWorld(StringBuilder stringBuilder) //ref to original varible
        {
            // This method might have been called like this: AddWorld ( sb );

            // The local variable stringBuilder does not contain the actual object, it's just a reference to that object (somewhere on the heap/in memory)
            // The same it true for the variable used when calling this method (sb doesn't contain the object, it's just a reference/a pointer to the actual object)
            // So, the local variable stringBuilder is actually a copy of the variable sb but since they both are pointing to the same place (in memory), they point to the SAME object (in this case the same StringBuilder).

            // This will affect the StringBuilder that was created outside of this method 
            stringBuilder.Append("Hello ");

            StringBuilder MyNewStringBuilder = stringBuilder; // This new variable is copy of stringBulder reference (pointer) but it still points to the same object (we still only have a single StringBuilder, but we have two local references)
            MyNewStringBuilder.Append("world!");
        }

        static void PrimitiveVariable(int numberIn) //int is a copy
        {
            // This method might have been called like this: PrimitiveVariable ( intX );

            numberIn = 1000; // overwriting the value sent in

            // Even though we change numberIn inside this method, the intX variable will be unchanged because numberIn is a COPY of intX.
            // When passing along a primitive value (int, double, date, bool, etc) to a method, that value is allways copied (as default, but can change)
        }

        static void ListEx()
        {
            List<float> temperature = new List<float> { (float)1.2, (float)2.2, 5f, 221.302f, -5.99f }; // can't add values like 1.23 because as code it's a double (and the list contains floats) but 1.23f and (float)1.23 are both floats 

            WriteLine("As entered: " + String.Join("; ", temperature));
            temperature.Sort();
            WriteLine("Sorted: " + String.Join("; ", temperature));

            // do some aggregations/calculations
            double sum = temperature.Sum();
            float avg = temperature.Average();
            float avg2 = temperature.Sum() / temperature.Count();
            decimal min = (decimal)temperature.Min();

            // Write the values to the console.
            WriteLine($"SUM={sum.ToString("F2").Replace(",", ".")}; AVG1={avg:F0}; AVG2={avg2:F1}; MIN={min}; MAX={temperature.Max()}");
        }


        static void ArrayEx()
        {
            //sort
            string[] names = { "Maria", "Helio", "Marco", "Jan", "Jaime" };

            // Write the content of the Array to the console.
            WriteLine("As added: " + String.Join(", ", names));

            // Write the content of the Array to the console.
            Array.Sort(names);
            WriteLine("Sorted: " + String.Join(", ", names));
        }

        static void DictionaryEx()
        {

            Dictionary<int, string> socialNumberVualt = new Dictionary<int, string>();

            
            // ADDING to the Dictionary

            // socialNumberVualt.Add(UNIQUE-INTEGER-KEY, ANY-STRING-VALUE);
            socialNumberVualt.Add(5, "Maria");
            socialNumberVualt.Add(1, "Helio");
            socialNumberVualt.Add(3, "Marco");
            socialNumberVualt.Add(2, "Janne");
            socialNumberVualt.Add(4, "Jaime");

            // Write the content of the Disctionary to the console.
            WriteLine("As added: " + String.Join(", ", socialNumberVualt));

            // If you add an item with a key that allready exist, the Dictionary will throw an exception.
            try
            {
                socialNumberVualt.Add(4, "Kalle"); // Key 4 has been added before
            }
            catch (Exception ex)
            {
                WriteLine("Could not add Kalle ... Error: " + ex.Message);
                // throw; // Only catching the exception, not re-throwing it
            }

            // A better way to handle this (instead of catch the exception)
            if (!socialNumberVualt.ContainsKey(4)) // NOT contains key 4
                socialNumberVualt.Add(4, "Kalle");

            WriteLine();




            // REMOVING from the Dictionary

            int KEY = 3;

            // Remove an item by using its key
            socialNumberVualt.Remove(KEY);

            WriteLine($"After removing ID {KEY}: {String.Join(", ", socialNumberVualt)}");

            // If you try to remove an item with a key that doesn't exist, the Dictionary will throw an exception.
            try
            {
                socialNumberVualt.Remove(999); // Key 999 doesn't exit in the Dictionary
            }
            catch (Exception ex)
            {
                WriteLine("Could not remove the item ... Error: " + ex.Message);
                // throw; 
            }

            // A better way to handle this
            if (socialNumberVualt.ContainsKey(999))
                socialNumberVualt.Remove(999);

            WriteLine();




            // FINDING a specific value using its key

            string name = socialNumberVualt[1]; // this will return the value associated with key 1 (it will not return the second item [index 1] in the Dictionary)
            WriteLine($"Got the name by using key 1: {name}");

            // It you try to get an item with a key that doesn't exist, the Dictionary will throw an exception.
            try
            {
                name = socialNumberVualt[999]; // Key 999 doesn't exit in the Dictionary
            }
            catch (Exception ex)
            {
                WriteLine("Could not get the item ... Error: " + ex.Message);
                // throw; 
            }

            // A better way to handle this
            if (socialNumberVualt.ContainsKey(5))
                name = socialNumberVualt[5];
            else
                name = "key 5 doesn't exit";

            WriteLine();




            // Sort KeyValuePair by Value
            var list1 = socialNumberVualt.ToList(); // Make a copy of all items (KeyValuePair)
            list1.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value)); // lambda-expr sorting the KeyValuePair (that contains both the Key and the Value) and sort the using the value
            WriteLine("Sorted KeyValuePairs by value: " + String.Join(", ", list1));

            // Sort Values only
            var list2 = socialNumberVualt.Values.ToList(); // Make a copy of all values (not any keys)
            list2.Sort((str1, str2) => str1.CompareTo(str2)); // sort
            WriteLine("Sorted values: " + String.Join(", ", list2));

            // Sort Key only
            var list3 = socialNumberVualt.Keys.ToList(); // Make a copy of all keys (not any values)
            list3.Sort((int1, int2) => int1.CompareTo(int2)); // sort
            WriteLine("Sorted keys: " + String.Join(", ", list3));

        }
    }
}