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
      Events.CharacterDied?.Invoke(this);
      Dispose();
    }
  }
}
