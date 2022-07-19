using System;
using System.Collections.Generic;

namespace Delete_and_Earn
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var nums = new int[] { 7, 5, 7, 5, 8, 8 };
      var answer = s.DeleteAndEarn(nums);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int DeleteAndEarn(int[] nums)
    {
      // populate the frequency with each no * no of times it has appeared 
      SortedDictionary<int, int> frequency = new SortedDictionary<int, int>();
      foreach (int i in nums)
      {
        if (!frequency.ContainsKey(i))
          frequency.Add(i, 0);
        frequency[i] += i;
      }

      int previous = 0; int currentMaxPoint = 0;
      // as the keys are sorted here, so if we found a key - 1 is also present in that case will consider
      //  frequency[key] + prev consider prev is the (i - 2) position max that we had found
      // as it is sorted and no - 1 element always will be found in i - 1 position
      // so we will take current max and previous seen max

      // when key - 1 is not present which means we can take the current and previous max as well
      foreach (var key in frequency.Keys)
      {
        if (!frequency.ContainsKey(key - 1))
        {
          previous = currentMaxPoint;
          currentMaxPoint += frequency[key];
        }
        else
        {
          var newMax = Math.Max(frequency[key] + previous, currentMaxPoint);
          previous = currentMaxPoint;
          currentMaxPoint = newMax;
        }
      }

      return currentMaxPoint;
    }
  }
}
