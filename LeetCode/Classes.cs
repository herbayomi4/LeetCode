using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    class Classes
    {

    }
    public class Solution
    {
        public int MinMoves(int[] nums, int limit)
        {
            List<int> countArray = new List<int>();

            int count = 0;
            if (CheckComplimentary(nums, limit) == true)
            {
                return count;
            }

            bool checkComplimentaryRes = false;
            int[] replacer = new int[limit];

            if (limit != 0)
            {
                if (limit == 1)
                {
                    replacer[0] = limit;
                }
                else
                {
                    int i = 1; int x = 0;
                    while (i <= limit)
                    {
                        replacer[x] = i;
                        x++; i++;
                    }
                }
            }
            else
            {
                replacer[0] = limit;
            }
            int a, b, c, d, e;
            for (int x = 0; x < replacer.Length; x++)
            {
                count = 0;
                int[] numbers = new int[nums.Length];
                for (int y = 0; y < nums.Length; y++)
                {
                    numbers[y] = nums[y];
                }
                a = numbers[0]; b = nums[1]; c = numbers[2]; d = nums[3];

                //numbers = nums;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] != replacer[x])
                    {

                        numbers[i] = replacer[x];
                        count++;
                        a = numbers[0]; b = numbers[1]; c = numbers[2]; d = numbers[3];
                        checkComplimentaryRes = CheckComplimentary(numbers, limit);
                        if (checkComplimentaryRes == true)
                        {
                            //count++; 

                            break;
                        }
                    }

                }
                if (checkComplimentaryRes == true)
                {
                    //count += 1;

                    countArray.Add(count);
                    //break;
                }
            }
            return countArray.Min();
        }

        public bool CheckComplimentary(int[] nums, int limit)
        {
            bool response = false;
            int sumToCheck = nums[0] + nums[nums.Length - 1 - 0];

            for (int i = 1; i < nums.Length; i++)
            {
                int sumToCheckAgainst = nums[i] + nums[nums.Length - 1 - i];
                response = false;
                if (sumToCheckAgainst != sumToCheck)
                {
                    break;
                }
                response = true;
            }

            return response;
        }


        //EASY 9. Palindrome Number
        public bool IsPalindrome(int x)
        {
            string num = x.ToString();

            char[] charArray1 = num.ToCharArray();

            char[] charArray2 = new char[charArray1.Length];

            int y = 0;

            for (int i = charArray1.Length - 1; i >= 0; i--)
            {
                charArray2[y] = charArray1[i];
                y++;
            }

            try
            {
                int result = Convert.ToInt32(new string(charArray2));

                if (result == x)
                {
                    return true;
                }
            }
            catch (FormatException ex)
            {

                return false;
            }

            return false;
        }

        //MEDIUM 2. Add Two Numbers
        //public LinkedList AddTwoNumbers(LinkedList l1, LinkedList l2)
        //{

        //}

        //MEDIUM Smallest Integer Divisible by K
        //Given a positive integer k, you need to find the length of the smallest positive integer n such that n is divisible by k, and n only contains the digit 1.
        //Return the length of n.If there is no such n, return -1.

        public int SmallestRepunitDivByK(int k)
        {

            BigInteger n = 1;
            int x = 1;
            if (k % 2 == 0 || k % 5 == 0)
            {
                return -1;
            }
            while (n % k != 0 && x <= k)
            {
                n = n * 10 + 1;
                x++;
            }
            if (n % k == 0)
            {
                return x;
            }

            return -1;
        }


    }
   
}


