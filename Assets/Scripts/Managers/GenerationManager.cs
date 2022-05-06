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
    }

    public static Level GetLevel()
    {
      return level;
    }
  }
}
