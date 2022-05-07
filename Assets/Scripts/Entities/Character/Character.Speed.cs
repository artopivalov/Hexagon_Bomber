///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected float currentSpeedFactor;

    [SubscribeToMainMethod]
    protected virtual void ResetSpeed()
    {
      currentSpeedFactor = 1;
    }

    public virtual float GetCurrentSpeed()
    {
      return GetMaxSpeed() * GetCurrentSpeedFactor();
    }

    public virtual float GetCurrentSpeedFactor()
    {
      return currentSpeedFactor;
    }

    public virtual float GetMaxSpeed()
    {
      return 5f;
    }
  }
}
