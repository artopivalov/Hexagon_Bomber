///
///
///
using Application.Entities;
using Application;

using UnityEngine;

namespace Application.Managers
{
  public static partial class GenerationManager
  {
    private static Level level;
    private static GroundGenerator groundGenerator;

    static GenerationManager()
    {
      Subscribe();
    }

    private static void Subscribe()
    {
      Events.PreReset     += OnPreReset;
      Events.Reset        += OnReset;
    }

    private static void OnPreReset()
    {
      if(level != null)
      {
        GameObject.Destroy(level.gameObject);
      }
    }

    private static void OnReset()
    {
      CreateLevel();
    }

    private static void CreateLevel()
    {
      var data = LevelsManager.GetCurrentLevelData();
      level = GameObject.Instantiate(data.levelPrefab);
      groundGenerator = level.GetComponentInChildren<GroundGenerator>();
    }

    public static float GetGroundBlocksOffset()
    {
      return groundGenerator.offsetX;
    }

    public static Level GetLevel()
    {
      return level;
    }
  }
}
