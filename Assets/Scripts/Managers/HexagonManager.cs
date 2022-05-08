///
///
///
using Application.Entities;
using Application;

using UnityEngine;
using System.Collections.Generic;

namespace Application.Managers
{
  public static partial class HexagonManager
  {
    private static List<Vector3> directions;

    static HexagonManager()
    {
      Init();
    }

    private static void Init()
    {
      directions = new List<Vector3>();
      for(int i = 0; i < 6; i++)
      {
        var direction = Quaternion.Euler(0, 60 * i, 0) * Vector3.left;
        directions.Add(direction);
      }
    }

    public static List<Vector3> GetDirections()
    {
      return directions;
    }
  }
}
