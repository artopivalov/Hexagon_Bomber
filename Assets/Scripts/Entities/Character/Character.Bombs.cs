///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected float bombPower = 2;

    public virtual void SpawnBomb()
    {
      var newBomb = PoolsManager.CreateElement(typeof(Bomb)) as Bomb;

      newBomb.Init(this);
      newBomb.SetPosition(currentGroundBlock.GetPosition());
      newBomb.SetPositionY(this.GetPositionY());
    }

    public float GetBombPower()
    {
      return bombPower;
    }
  }
}
