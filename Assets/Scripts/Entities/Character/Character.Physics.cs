///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected new Rigidbody rigidbody;
    protected new Collider collider;

    [SubscribeToMainMethod]
    protected virtual void InitPhysics()
    {
      collider = this.GetComponent<Collider>();
      rigidbody = this.GetComponent<Rigidbody>();
    }

    [SubscribeToMainMethod]
    protected virtual void ResetPhysics()
    {
      SetPhysicState(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
      OnCollisionEnterAll(collision, null);
    }

    private void OnCollisionExit(Collision collision)
    {
      OnCollisionExitAll(collision, null);
    }

    private void OnTriggerEnter(Collider other)
    {
      OnTriggerEnterAll(other, null);
    }

    private void OnTriggerExit(Collider other)
    {
      OnTriggerExitAll(other, null);
    }

    public virtual void OnCollisionEnterAll(Collision collision, Collider part)
    {
      OnInteraction(collision.collider);
    }

    public virtual void OnCollisionExitAll(Collision collision, Collider part)
    {
    }

    public virtual void OnTriggerEnterAll(Collider other, Collider part)
    {
      OnInteraction(other);
    }

    public virtual void OnTriggerExitAll(Collider other, Collider part)
    {
    }

    /// <summary> Reset collider to repeat receive OnEnter messages </summary>
    protected virtual void ResetCollider()
    {
      GetCollider().enabled = false;
      GetCollider().enabled = true;
    }

    public Collider GetCollider()
    {
      return collider;
    }

    public virtual void SetPhysicState(bool state)
    {
      rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;

      rigidbody.isKinematic = !state;
      GetCollider().enabled = state;

      if(state)
      {
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
      }
      else
      {
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
      }
    }

    public virtual void SetVelocity(Vector3 velocity)
    {
      rigidbody.velocity = velocity;
    }

    protected virtual bool IsPhysical()
    {
      return !rigidbody.isKinematic;
    }
  }
}
