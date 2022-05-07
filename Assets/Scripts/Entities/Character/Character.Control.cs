///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected virtual void SetClampedMoveDirection(Vector3 direction)
    {
      // TODO hexagon control
      SetMovementDirection(direction);
    }
  }
}
