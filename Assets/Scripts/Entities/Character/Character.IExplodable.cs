///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character : IExplodable
  {
    public void Explode()
    {
      Die();
    }

    protected virtual void Die()
    {
      Events.CharacterDied?.Invoke(this);
      Dispose();
    }
  }
}
