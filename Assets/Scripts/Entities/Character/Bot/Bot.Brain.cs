///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Bot
  {
    protected BotBrain currentBrain;

    [SubscribeToMainMethod]
    protected virtual void InitBrain()
    {
      currentBrain = new BotBrainStupid().Init(this);
    }

    [SubscribeToMainMethod]
    protected virtual void ResetBrain()
    {
      currentBrain.Reset();
    }

    [SubscribeToMainMethod]
    protected virtual void SubscribeBrain()
    {
      currentBrain.Subscribe();

      Events.GameStateChanged += OnGameStateChanged;
    }

    [SubscribeToMainMethod]
    protected virtual void UnsubscribeBrain()
    {
      currentBrain.Unsubscribe();
    }

    protected virtual void OnGameStateChanged()
    {
      if(GameStatesManager.currentState == GameStates.Game)
      {
        currentBrain.GameStarted();
      }
    }

    [SubscribeToMainMethod]
    protected virtual void UpdateBrain()
    {
      if(GameStatesManager.currentState == GameStates.Game)
      {
        currentBrain.Update();
      }
    }
  }
}
