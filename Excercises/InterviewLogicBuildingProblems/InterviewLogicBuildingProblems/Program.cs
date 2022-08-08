using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewLogicBuildingProblems
{
    public class TestModel
    {
        public int test { get; set; }
        public int? testNulable { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //TestModel tt = new TestModel();
            //tt.test = 3;
            //tt.testNulable = 3;
            //if (tt.testNulable == tt.test) { //true
            //    var s = true;
            //}
            //if (tt.testNulable.Value == tt.test) //true
            //{
            //    var s = true;
            //}
            //List<int> values = new List<int>();
            //values.Add(9);
            //values.Add(10);
            //values.Add(0);
            //values.Add(-1);
            //values.Add(8);
            //values.Add(0);
            //values.Add(5);

            //int[] arr = { -7, 1, 5, 2, -4, 3, 0 };
            //Console.WriteLine("Equilibrium Index : " + ReturnEquilibriumIndex(arr));
            //int[] arr2 = { 10, 4, 6, 3, 5 };
            //GetRightMaxElements(arr2);
            //sum = -7+1+5+2-4+3+0 // 0 ;
            //rightSum = sum;
            //for arr[0] = -7
            //leftSum = 0 && rightSum -= -7 = -14;
            //leftSum += -7;

            //for arr[1] = 1
            //leftSum = -7 && rightSum -= 1 = -6;
            //leftSum += 1 = -6;

            //for arr[2] = 5
            //leftSum = -6 && rightSum -= -1 = -6;
            //leftSum += 1 = -6;

            //Console.WriteLine("returned : "+ GetSecondLargest(values));
            //Console.WriteLine("Jumps : "+ FrogJumps(2,8,4));  
            Console.WriteLine(GetReverseStr("someT"));
            Console.WriteLine(GetReverseStr("some"));
            Console.WriteLine(GetReverseStr("som"));
            Console.WriteLine(GetReverseStr("The Quick Brown"));

            //Console.WriteLine("alone : " + GetFirstMostRecursiveChar("VVVCDABABCAasdasdAAbAA"));
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(10);

            List<List<int>> numbers2D = new List<List<int>>();
            numbers2D.Add(numbers);
            numbers2D.Add(numbers);
            numbers2D.Add(numbers);
            numbers2D.Add(numbers);
            fizzBuzz(15);

            //Console.WriteLine("Sum : "+ camelcase("s"));

            //Console.WriteLine("Sum : "+ simpleArraySum(numbers));

            //Console.WriteLine("Sum : " + diagonalDifference(numbers2D));
        }


        public static int countTeams(List<int> skills, int minPlayers, int minLevel, int maxLevel)
        {
            if (skills.Count >= 1 && skills.Count <= 20)
            {
                if (minPlayers >= 1 && minPlayers <= skills.Count)
                {
                    if (minLevel >= 1 && minLevel <= maxLevel && maxLevel <= 1000)
                    {
                        int meetingCriteriaCount = 0;
                        for (int i = 0; i < skills.Count; i++)
                        {

                            if (skills[i] >= minLevel && skills[i] <= maxLevel)
                            {
                                meetingCriteriaCount++;
                            }
                        }
                        return meetingCriteriaCount * minPlayers;
                    }
                }
            }
            return 0;
        }

        public static void closestNumbers(List<int> numbers)
        {
            if (numbers.Count >= 2 && numbers.Count <= 100000)
            {
                if (numbers.Count == 2)
                {
                    if (numbers[0] > numbers[1])
                    {
                        Console.WriteLine(numbers[1] + " " + numbers[0]);
                    }
                    else
                    {
                        Console.WriteLine(numbers[0] + " " + numbers[1]);
                    }
                }
                else
                {
                    int tempDifference = int.MaxValue, minimumDifference = int.MaxValue;
                    Dictionary<string, int> closestNumbers = new Dictionary<string, int>();


                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        for (int j = i + 1; j < numbers.Count; j++)
                        {
                            tempDifference = numbers[i] - numbers[j];

                            if (tempDifference < minimumDifference)
                            {
                                minimumDifference = tempDifference;
                                if (numbers[i] > numbers[j])
                                {
                                    closestNumbers.Add(numbers[j] + " " + numbers[i], minimumDifference);
                                }
                                else
                                {
                                    closestNumbers.Add(numbers[i] + " " + numbers[j], minimumDifference);
                                }
                            }
                        }
                    }

                    foreach (var item in closestNumbers)
                    {
                        if (item.Value == minimumDifference)
                        {
                            Console.WriteLine(item.Value);
                        }
                    }
                }

            }

        }

        public static void fizzBuzz(int n)
        {
            if (n > 0 && n < 20000)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (i % 3 == 0 && i % 5 != 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (i % 5 == 0 && i % 3 != 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }

        public static int camelcase(string s)
        {
            int wordsCount = 0;
            if (!string.IsNullOrEmpty(s))
            {
                if (s.Length >= 1 && s.Length <= 100000)
                {
                    if (s.Length == 1)
                    {
                        wordsCount = 1;
                    }
                    else
                    {
                        wordsCount = 1;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (Char.IsUpper(s[i]))
                                wordsCount++;
                        }
                    }
                }
            }
            return wordsCount;
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int leftToRightDiagonal = 0;
            int rightToLeftDiagnol = 0;

            if (arr != null && arr.Count > 0)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    for (int j = 0; j < arr.Count; j++)
                    {
                        if (i == j)
                        {
                            leftToRightDiagonal += arr[i][j];
                        }
                        if ((i + j) == arr.Count - 1)
                        {
                            rightToLeftDiagnol += arr[i][j];
                        }

                    }
                }
            }

            return Math.Abs(leftToRightDiagonal - rightToLeftDiagnol);
        }


        public static int simpleArraySum(List<int> ar)
        {
            int sum = 0;
            if (ar.Count > 0)
            {
                if (ar.Count == 1)
                {
                    sum = ar[0];
                }
                else
                {
                    foreach (int element in ar)
                    {
                        if (element < 1000)
                        {
                            sum = sum + element;
                        }
                        else
                        {
                            sum = -1;
                        }
                    }
                }
            }
            return sum;
        }

        static string GetReverseStr(string str)
        {

            char[] charArr = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                charArr[i] = str[j];
                charArr[j] = str[i];
            }

            //other way
            char[] otherCharArr = new char[str.Length];

            for (int i = str.Length - 1, j = 0; i > -1; i--, j++)
            {
                otherCharArr[j] = str[i];
            }
            return new string(charArr);
        }


        static int GetSecondLargest(List<int> values)
        {

            if (values.Count == 0)
                return 0;

            if (values.Count == 1)
                return values[0];

            int secondLargest = 0;
            int largest = 0;

            //Logic 1
            //foreach (var value in values)
            //{
            //    if (largest < value)
            //    {
            //        largest = value;
            //    }
            //}

            //foreach (var value in values)
            //    if (value < largest && value > secondLargest)

            //    {
            //        secondLargest = value;
            //    }

            //Logic 2
            foreach (var value in values)
            {
                if (value > largest)
                {
                    secondLargest = largest;
                    largest = value;

                }
                if (value > secondLargest && value < largest)
                {
                    secondLargest = value;
                }
            }

            return secondLargest;
        }

        //count frog jumps from X to Y by jumping distance D
        static int FrogJumps(int X, int Y, int D)
        {
            if ((Y - X) == D)
            {
                return 1;
            }
            else if (X > Y)
            {
                return -1;
            }
            else
            {
                int jumps = 0;
                while (Y > X)
                {
                    X = X + D;
                    jumps = jumps + 1;
                }
                return jumps;
            }
        }

        // get the max number of zeros b/w two 1's in binary number like 1010001001   returns 3.
        static int ReturnCountOf0BWBinary(int number)
        {
            if (number > 0 && number < 296574)
            {
                int maxGap = 0;
                int tempGap = 0;
                string binary = Convert.ToString(number, 16);
                Console.WriteLine("binary : " + binary);
                for (var i = 0; i < binary.Length; i++)
                {
                    if (binary[i] == '0')
                    {
                        tempGap++;
                    }
                    else if (binary[i] == '1')
                    {
                        if (maxGap < tempGap)
                        {
                            maxGap = tempGap;
                        }
                        tempGap = 0;
                    }
                }
                return maxGap;
            }
            return 0;
        }

        // get the unpaired value from array which is not same as any other e.g{1,3,10,1,4,3,4}   returns 10.
        static int ReturnUnPairedNumber(int[] numbers)
        {
            List<int> duplicates = new List<int>();
            if (numbers.Length > 0)
            {
                int alone = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    alone = numbers[i];
                    if (duplicates.Contains(alone) == false)
                    { //not found
                        duplicates.Add(alone);
                    }
                    else
                    {
                        duplicates.Remove(alone);
                    }
                }
                return duplicates[0];
            }
            else
            {
                return -1;
            }
        }

        static int GetFirstMostRecursiveChar(string givenStr)
        {
            if (givenStr != null)
            {
                Dictionary<char, int> occurances = new Dictionary<char, int>();
                for (int i = 0; i < givenStr.Length; i++)
                {
                    if (occurances.ContainsKey(givenStr[i]) == false)
                    {
                        occurances.Add(givenStr[i], 1);
                    }
                    else
                    {
                        occurances[givenStr[i]]++;
                    }
                }

                foreach (var i in occurances)
                {
                    Console.WriteLine("Key: {0}     Value: {1}", i.Key, i.Value);
                }

                return occurances.Values.Max();
            }
            return 0;
        }

        // Function to print all elements which are greater than all
        // elements present to their right
        static void GetRightMaxElements(int[] arrOfInt)
        {
            if (arrOfInt.Length > 0)
            {
                int maxRight = int.MinValue;
                Stack<int> elementsStack = new Stack<int>();
                for (var i = arrOfInt.Length - 1; i >= 0; i--)
                {
                    if (arrOfInt[i] > maxRight)
                    {
                        //elementsQ.Enqueue(arrOfInt[i]);
                        elementsStack.Push(arrOfInt[i]);
                        maxRight = arrOfInt[i];
                    }
                }

                Console.WriteLine("Elements which are greater than all elements present to their right");
                while (elementsStack.Count > 0)
                {
                    //Console.Write(" " + elementsQ.Dequeue());
                    Console.Write(" " + elementsStack.Pop());
                }
            }
            else
            {
                Console.WriteLine("There are no elements in the arry.");
            }
        }


        // get get first index from array such that prefix sum equals suffix e.g {-1,3,-4, 5,1,-6,-2}   returns index 1    as -1 == 3-4+5+1-6+2+1
        static int ReturnEquilibriumIndex(int[] numbers)
        {
            if (numbers.Length > 0)
            {
                int leftSum = 0;
                //int rightSum = 0;
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    leftSum += numbers[i];
                //    for (int j = i+1; j < numbers.Length; j++)
                //    {
                //        rightSum += numbers[j];
                //    }
                //    if (rightSum == leftSum)
                //    {
                //        return i;
                //    }
                //    rightSum = 0;
                //}

                int sum = 0;
                //get complete sum of array
                for (int i = 0; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }

                for (int j = 0; j < numbers.Length; j++)
                {
                    //minus the current element of this for loop and hence get right sum;
                    sum -= numbers[j];
                    if (sum == leftSum)
                    {
                        return j;
                    }
                    leftSum += numbers[j];
                }

                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}