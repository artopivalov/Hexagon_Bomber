///
/// 
///
using Application.Attributes;

using UnityEngine;
using System;

namespace Application.Entities
{
  public partial class Character
  {
    protected Vector3 velocityRaw;
    protected Vector3 previousVelocity;
    protected Vector3 interactionVelocity;

    private Vector3 currentVelocity;
    private Vector3 previousPosisiton;

    [SubscribeToMainMethod]
    protected virtual void ResetMovement()
    {
      velocityRaw = Vector3.zero;
      interactionVelocity = Vector3.zero;
      previousPosisiton = transform.position;
    }

    protected virtual Vector3 GetCurrentVelocity()
    {
      return currentVelocity;
    }

    protected virtual float GetPassedPerUpdateDistance()
    {
      return (transform.position - previousPosisiton).magnitude;
    }

    protected virtual void ApplyInteractionVelocity(Vector3 velocityToAdd)
    {
      velocityRaw = Vector3.zero;

      interactionVelocity = velocityToAdd;
    }

    public virtual void SetMovementDirection(Vector3 direction)
    {
      direction.y = 0;
      velocityRaw = direction;
    }

    public virtual void SetFacedToDirection(Vector3 direction)
    {
      direction.y = 0;
      transform.forward = direction;
    }

    public virtual void SetFacedToEnemy(Vector3 direction)
    {
      SetFacedToDirection(direction);
    }

    public virtual void SetFacedToMove(Vector3 direction)
    {
      SetFacedToDirection(direction);
    }

    protected virtual void UpdateVelocity()
    {
      currentVelocity = (velocityRaw * GetCurrentSpeed());
      currentVelocity.y = rigidbody.velocity.y;
      currentVelocity += interactionVelocity;
    }

    protected virtual void UpdatePosition()
    {
      this.SetVelocity(GetCurrentVelocity());
    }

    protected virtual void UpdateRotation()
    {
      if(velocityRaw.magnitude > float.Epsilon)
      {
        SetFacedToMove(velocityRaw);
      }
    }

    protected virtual void UpdateInteractionVelocity()
    {
      interactionVelocity = Vector3.Lerp(
        interactionVelocity,
        Vector3.zero,
        0.1f
      );
    }

    [SubscribeToMainMethod]
    protected virtual void FixedUpdateMovements()
    {
      this.UpdateVelocity();
      this.UpdatePosition();
      this.UpdateRotation();
      this.UpdateInteractionVelocity();

      previousVelocity = rigidbody.velocity;
      previousPosisiton = transform.position;
    }
  }
}
