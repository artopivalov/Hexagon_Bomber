///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Player
  {
    protected const int angleTreshold = 45;
    protected const bool useHexagonRestriction = true; // in my opinion false is better)))

    protected virtual void FindWayPoint(Vector3 targetDirection)
    {
      var direction = GetNearestDirection(targetDirection, availableDirections);

      if(Vector3.Angle(direction, targetDirection) > angleTreshold)
      {
        StopMovement();
      }
      else
      {
        SetWayPoint(GetCurrentGroundBlock().GetPosition() + direction * GenerationManager.GetGroundBlocksOffset());
      }
    }

    protected virtual void StopMovement()
    {
      wayPoints.Clear();
      SetMovementDirection(Vector3.zero);
    }

    [SubscribeToMainMethod]
    protected virtual void UpdateControl()
    {
      var joystickDirection = new Vector3(
        Control.instance.GetJoystick().GetDirection().x,
        0,
        Control.instance.GetJoystick().GetDirection().y
      );

      if(useHexagonRestriction)
      {
        if(wayPoints.Count <= 0)
        {
          FindWayPoint(joystickDirection);
        }

        currentSpeedFactor = joystickDirection.magnitude;

        if(!Control.IsPointerDown() || Control.instance.GetJoystick().GetDirection().magnitude <= float.Epsilon)
        {
          StopMovement();
        }
      }
      else
      {
        SetMovementDirection(joystickDirection);
      }
    }
  }
}
