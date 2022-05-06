///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class ScreenLose : ScreenFinish
  {
    protected override GameStates GetLinkedState()
    {
      return GameStates.Lose;
    }
  }
}
