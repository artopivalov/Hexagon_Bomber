///
///
///
using UnityEngine;

using DG.Tweening;

namespace Application.Entities
{
  public class ExplosionLine : Entity
  {
    protected Sequence delay;
    protected LineRenderer lineRenderer;

    protected override void Awake()
    {
      base.Awake();

      lineRenderer = GetComponent<LineRenderer>();
    }

    protected override void OnEnable()
    {
      base.OnEnable();

      delay?.Kill();
      delay = DOTween.Sequence().AppendInterval(0.5f).AppendCallback(Dispose);
    }

    public virtual void SetTargetPosition(Vector3 position)
    {
      lineRenderer.SetPosition(0, this.GetPosition());
      lineRenderer.SetPosition(1, position);
    }
  }
}
