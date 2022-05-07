///
///
///
using UnityEngine;
using DG.Tweening;

namespace Application.Entities
{
  public class Bomb : Interactable
  {
    public float explosionTime = 2f;

    public virtual void Init()
    {
      DOTween.Sequence().AppendInterval(explosionTime).AppendCallback(Explode);
    }

    protected virtual void Explode()
    {
      Dispose();
    }
  }
}
