///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected float bombPower;
    protected int maxBombsCount;

    [SubscribeToMainMethod]
    protected virtual void ResetBonus()
    {
      bombPower = 1f;
      maxBombsCount = 1;
    }

    protected virtual void UpgradePower()
    {
      bombPower++;
    }

    protected virtual void UpgradeCount()
    {
      maxBombsCount++;
    }

    public float GetBombPower()
    {
      return bombPower;
    }
  }
}
