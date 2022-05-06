///
/// my legacy levels manager
///
using Application.Settings;

using UnityEngine;

namespace Application.Managers
{
  public static partial class LevelsManager
  {
    private const string levelStorageKey = "values.level";
    private const string levelDataFolder = "Data/Levels";

    private static int currentSavedLevelIndex;
    private static int currentLevelIndex;
    private static int previousLevelIndex;

    private static bool isCurrentLevelStarted;
    private static bool isCurrentLevelFinished;
    private static bool isCurrentLevelSucceed;

    private static LevelData[] levelData;

    static LevelsManager()
    {
      LevelsManager.Load();
      LevelsManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.PreReset += OnPreReset;
    }

    private static void Load()
    {
      LevelsManager.currentSavedLevelIndex = PlayerPrefs.GetInt(LevelsManager.levelStorageKey, 1);
      LevelsManager.levelData = UnityEngine.Resources.LoadAll<LevelData>(levelDataFolder);
    }

    private static void Save()
    {
      PlayerPrefs.SetInt(LevelsManager.levelStorageKey, LevelsManager.currentSavedLevelIndex);
      PlayerPrefs.Save();
    }

    private static void OnPreReset()
    {
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

      GameStatesManager.ChangeState(GameStates.Succeed);
    }

    public static void PerformLevelFailed()
    {
      LevelsManager.isCurrentLevelSucceed = false;
      LevelsManager.isCurrentLevelFinished = true;

      GameStatesManager.ChangeState(GameStates.Lose);
    }

    public static void SetCurrentLevelIndex(int level)
    {
      LevelsManager.currentSavedLevelIndex = level;
      LevelsManager.Save();
    }

    public static LevelData[] GetLevelData()
    {
      return LevelsManager.levelData;
    }

    public static int GetRepeatedLevelIndex()
    {
      return (int)UnityEngine.Mathf.Repeat(GetCurrentLevelIndex() - 1, GetLevelData().Length);
    }

    public static LevelData GetCurrentLevelData()
    {
      return LevelsManager.GetLevelData()[LevelsManager.GetRepeatedLevelIndex()];
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
