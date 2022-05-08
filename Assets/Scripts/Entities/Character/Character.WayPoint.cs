///
///
///
using Application.Attributes;

using UnityEngine;

using System.Collections.Generic;

namespace Application.Entities
{
  public partial class Character
  {
    protected List<Vector3> wayPoints = new List<Vector3>();

    [SubscribeToMainMethod]
    protected virtual void ResetWayPoints()
    {
      wayPoints.Clear();
    }

    public virtual void StopWayPointMovement()
    {
      if(wayPoints.Count > 0)
      {
        wayPoints.Clear();

        WaypointCompleteMove();
      }
    }

    public virtual void SetWayPoint(Vector3 point)
    {
      StopWayPointMovement();

      wayPoints.Add(point);
    }

    public List<Vector3> GetWayPoints()
    {
      return wayPoints;
    }

    protected virtual void WaypointCompleteMove()
    {
      
    }

    [SubscribeToMainMethod]
    protected virtual void UpdateWayPoints()
    {
      if(wayPoints.Count > 0)
      {
        var moveDirection = wayPoints[0] - transform.position;
        moveDirection.y = 0;

        SetMovementDirection(moveDirection.normalized);

        if(moveDirection.magnitude < 0.1f)
        {
          wayPoints.RemoveAt(0);
          if(wayPoints.Count == 0)
          {
            WaypointCompleteMove();
          }
        }
      }
    }
  }
}
