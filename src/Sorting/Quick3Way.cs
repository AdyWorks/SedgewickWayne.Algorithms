﻿
/******************************************************************************
 *  http://algs4.cs.princeton.edu/23quicksort/Quick3way.java.html
 *  
 *  QUICKSORT WITH 3-WAY PARTITIONING
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Diagnostics;

  /// <summary>
  /// Sorts a sequence of strings from standard input using 3-way quicksort.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public static class Quick3Way<T> where T : IComparable<T>
  {

    /// <summary>
    /// Rearranges the array in ascending order, using the natural order.
    /// </summary>
    /// <param name="a">the array to be sorted</param>
    public static void Sort(T[] a)
    {
      StdRandom.shuffle(a);
      sort(a, 0, a.Length - 1);
      Debug.Assert(SortingHelper<T>.isSorted(a));
    }

    /// <summary>
    /// quicksort the subarray a[lo .. hi] using 3-way partitioning
    /// </summary>
    /// <param name="a"></param>
    /// <param name="lo"></param>
    /// <param name="hi"></param>
    private static void sort(T[] a, int lo, int hi)
    {
      if (hi <= lo) return;
      int lt = lo, gt = hi;
      T v = a[lo];
      int i = lo;
      while (i <= gt)
      {
        int cmp = a[i].CompareTo(v);
        if (cmp < 0) SortingHelper<T>.exch(a, lt++, i++);
        else if (cmp > 0) SortingHelper<T>.exch(a, i, gt--);
        else i++;
      }

      // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]. 
      sort(a, lo, lt - 1);
      sort(a, gt + 1, hi);
      Debug.Assert(SortingHelper<T>.isSorted(a, lo, hi));
    }
  }
}
