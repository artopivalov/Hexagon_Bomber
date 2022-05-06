///
///
///
using Application.Settings;

using UnityEngine;
using System;

namespace Application.Managers
{
  public enum GameStates
  {
    None,
    Menu,
    Game,
    Lose,
    Succeed
  }

  public static partial class GameStatesManager
  {
    public static GameStates currentState;

    static GameStatesManager()
    {
      GameStatesManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.PreReset += OnPreReset;
    }

    private static void OnPreReset()
    {
      ChangeState(GameStates.Menu);
    }

    public static void ChangeState(GameStates gameState)
    {
      currentState = gameState;

      Events.GameStateChanged.TryInvoke();
    }
  }
}
