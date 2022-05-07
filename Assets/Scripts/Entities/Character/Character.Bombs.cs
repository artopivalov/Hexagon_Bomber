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
    public virtual void SpawnBomb()
    {
      var newBomb = PoolsManager.CreateElement(typeof(Bomb)) as Bomb;

      newBomb.Init();
      newBomb.SetPosition(currentGroundBlock.GetPosition());
      newBomb.SetPositionY(this.GetPositionY());
    }
  }
}
