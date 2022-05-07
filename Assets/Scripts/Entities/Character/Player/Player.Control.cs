///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Player
  {
    [SubscribeToMainMethod]
    protected virtual void UpdateControl()
    {
      SetClampedMoveDirection(new Vector3(
        Control.instance.GetJoystick().GetDirection().x, 
        0, 
        Control.instance.GetJoystick().GetDirection().y
      ));
    }
  }
}
