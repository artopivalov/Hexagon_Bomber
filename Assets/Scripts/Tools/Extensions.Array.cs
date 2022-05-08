///
///
///
using UnityEngine;
using System.Collections.Generic;

namespace Application.Entities
{
  public static partial class Extensions
  {
    public static T Random<T>(this T[] array)
    {
      return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T Random<T>(this List<T> list)
    {
      return list[UnityEngine.Random.Range(0, list.Count)];
    }
  }
}
