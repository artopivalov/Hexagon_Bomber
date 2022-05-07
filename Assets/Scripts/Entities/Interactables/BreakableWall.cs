///
///
///
using UnityEngine;

namespace Application.Entities
{
  public class BreakableWall : Interactable, IExplodable
  {
    public void Explode()
    {
      Dispose();
    }
  }
}
