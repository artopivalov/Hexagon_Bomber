///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class ScreenFinish : Screen
  {
    public virtual void OnRestartButtonClicked()
    {
      Events.RequestReset();
    }
  }
}
