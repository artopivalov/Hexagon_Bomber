///
///
///
using UnityEngine;

namespace Application.Managers
{
  public static partial class LevelsManager
  {
    private const string levelStorageKey = "values.level";

    private static int currentSavedLevelIndex;
    private static int currentLevelIndex;
    private static int previousLevelIndex;

    private static bool isCurrentLevelStarted;
    private static bool isCurrentLevelFinished;
    private static bool isCurrentLevelSucceed;

    static LevelsManager()
    {
      LevelsManager.Load();
      LevelsManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.OnPreReset += OnPreReset;
    }

    private static void Load()
    {
      LevelsManager.currentSavedLevelIndex = PlayerPrefs.GetInt(LevelsManager.levelStorageKey, 1);
    }

    private static void Save()
    {
      PlayerPrefs.SetInt(LevelsManager.levelStorageKey, LevelsManager.currentSavedLevelIndex);
      PlayerPrefs.Save();
    }

    private static void OnPreReset()
    {
      Debug.Log("reset");

      LevelsManager.ResetIndexes();

      LevelsManager.isCurrentLevelSucceed = false;
      LevelsManager.isCurrentLevelStarted = false;
      LevelsManager.isCurrentLevelFinished = false;
    }

    private static void ResetIndexes()
    {
      LevelsManager.previousLevelIndex = LevelsManager.currentLevelIndex;
      LevelsManager.currentLevelIndex = LevelsManager.currentSavedLevelIndex;
    }

    public static void PerformLevelFinish(bool isSucceed)
    {
      if(!isCurrentLevelFinished)
      {
        if(isSucceed)
        {
          PerformLevelSucceed();
        }
        else
        {
          PerformLevelFailed();
        }
      }
    }

    public static void PerformLevelSucceed()
    {
      LevelsManager.isCurrentLevelSucceed = true;
      LevelsManager.isCurrentLevelFinished = true;

      LevelsManager.currentSavedLevelIndex++;

      LevelsManager.Save();
    }

    public static void PerformLevelFailed()
    {
      LevelsManager.isCurrentLevelSucceed = false;
      LevelsManager.isCurrentLevelFinished = true;
    }

    public static void SetCurrentLevelIndex(int level)
    {
      LevelsManager.currentSavedLevelIndex = level;
      LevelsManager.Save();
    }

    public static int GetCurrentLevelIndex()
    {
      return LevelsManager.currentLevelIndex;
    }

    public static bool IsCurrentLevelStarted()
    {
      return LevelsManager.isCurrentLevelStarted;
    }

    public static bool IsCurrentLevelFinished()
    {
      return LevelsManager.isCurrentLevelFinished;
    }

    public static bool IsCurrentLevelSucceed()
    {
      return LevelsManager.isCurrentLevelSucceed;
    }

    public static bool IsCurrentLevelRestarted()
    {
      return LevelsManager.currentLevelIndex == LevelsManager.previousLevelIndex;
    }
  }
}
