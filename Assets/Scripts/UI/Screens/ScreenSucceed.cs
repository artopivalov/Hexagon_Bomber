///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class ScreenSucceed : ScreenFinish
  {
    protected override GameStates GetLinkedState()
    {
      return GameStates.Succeed;
    }
  }
}
