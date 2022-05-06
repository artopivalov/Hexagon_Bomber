///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class ScreenMenu : Screen
  {
    public virtual void OnStartButtonClicked()
    {
      GameStatesManager.ChangeState(GameStates.Game);
    }

    protected override GameStates GetLinkedState()
    {
      return GameStates.Menu;
    }
  }
}
