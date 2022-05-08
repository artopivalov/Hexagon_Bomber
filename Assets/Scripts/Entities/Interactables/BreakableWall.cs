///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class BreakableWall : Interactable, IExplodable
  {
    [Header("Settings")]
    public float bonusChance = 0.5f;

    public void Explode()
    {
      if(Random.value < bonusChance)
      {
        Bonus newBonus;
        if(Random.value < 0.5f)
        {
          newBonus = PoolsManager.CreateElement<BonusPower>();
        }
        else
        {
          newBonus = PoolsManager.CreateElement<BonusCount>();
        }
        newBonus.SetPosition(this.GetPosition());
      }

      Dispose();
    }
  }
}
