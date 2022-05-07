///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class Screen : Presentation
  {
    public override void Subscribe()
    {
      base.Subscribe();

      Events.GameStateChanged += OnGameStateChanged;
    }

    protected virtual void OnGameStateChanged()
    {
      gameObject.SetActive(GetLinkedState() == GameStatesManager.currentState);
    }

    protected virtual GameStates GetLinkedState()
    {
      return GameStates.None;
    }
  }
}
