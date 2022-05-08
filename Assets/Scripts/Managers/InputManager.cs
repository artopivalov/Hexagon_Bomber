///
///
///
using UnityEngine;

namespace Application.Managers
{
  public static class InputManager
  {
    static InputManager()
    {
      InputManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.Update += OnUpdate;
    }

    private static void OnUpdate()
    {
      if(Input.GetKeyDown(KeyCode.R))
      {
        Events.RequestReset();
      }
      if(Input.GetKeyDown(KeyCode.S))
      {
        LevelsManager.PerformLevelSucceed();
      }
      if(Input.GetKeyDown(KeyCode.L))
      {
        LevelsManager.PerformLevelFailed();
      }
      if(Input.GetKeyDown(KeyCode.Space))
      {
        CharactersManager.GetPlayer()?.SpawnBomb();
      }
    }
  }
}
