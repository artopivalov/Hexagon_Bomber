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

    public virtual void InitBrainSmart()
    {
      currentBrain = new BotBrainSmart().Init(this);
    }

    public virtual void InitBrainStupid()
    {
      currentBrain = new BotBrainStupid().Init(this);
    }

    [SubscribeToMainMethod]
    protected virtual void ResetBrain()
    {
      currentBrain?.Reset();
    }

    [SubscribeToMainMethod]
    protected virtual void SubscribeBrain()
    {
      Events.GameStateChanged += OnGameStateChanged;
    }

    [SubscribeToMainMethod]
    protected virtual void UnsubscribeBrain()
    {
      Events.GameStateChanged -= OnGameStateChanged;
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
