///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entities
{
  public partial class Character
  {
    protected List<Bomb> spawnedBombs = new List<Bomb>();

    [SubscribeToMainMethod]
    protected virtual void ResetBombs()
    {
      spawnedBombs.Clear();
    }

    public virtual void SpawnBomb()
    {
      if(IsBombSpawnAvaiable())
      {
        var newBomb = PoolsManager.CreateElement(typeof(Bomb)) as Bomb;

        newBomb.Init(this);
        newBomb.SetPosition(currentGroundBlock.GetPosition());
        newBomb.SetPositionY(this.GetPositionY());
        spawnedBombs.Add(newBomb);
      }
    }

    protected virtual bool IsBombSpawnAvaiable()
    {
      bool isCountAllow = spawnedBombs.Count < maxBombsCount;
      bool isSlotEmpty = spawnedBombs.All((bomb) => 
      Vector3.Distance(this.GetPosition(), bomb.GetPosition()) > GenerationManager.GetGroundBlocksOffset() * 0.6f);
      return isCountAllow && isSlotEmpty;
    }

    public virtual void OnBombExploded(Bomb bomb)
    {
      spawnedBombs.Remove(bomb);
    }
  }
}
