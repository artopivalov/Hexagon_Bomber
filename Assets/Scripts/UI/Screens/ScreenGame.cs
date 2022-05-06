///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class ScreenGame : Screen
  {
    protected override GameStates GetLinkedState()
    {
      return GameStates.Game;
    }
  }
}
