///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class Screen : Presentation
  {
    protected virtual void Awake()
    {
      Subscribe();
    }

    protected virtual void Subscribe()
    {
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
