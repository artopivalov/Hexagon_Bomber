///
///
///
using UnityEngine;
using DG.Tweening;

namespace Application.Entities
{
  public class Bonus : Interactable, IExplodable
  {
    [Header("Settings")]
    public float lifeTime = 10;

    protected Sequence delay;

    protected override void OnEnable()
    {
      base.OnEnable();

      delay = DOTween.Sequence()
        .AppendInterval(lifeTime)
        .AppendCallback(Dispose);
    }

    public virtual void Explode()
    {
      Dispose();
    }

    protected override void OnDisable()
    {
      base.OnDisable();

      delay?.Kill();
    }
  }
}
