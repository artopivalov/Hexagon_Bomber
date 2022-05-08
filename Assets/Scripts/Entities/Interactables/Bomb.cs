///
///
///
using Application.Managers;

using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Application.Entities
{
  public class Bomb : Interactable, IExplodable
  {
    [Header("Settings")]
    public float explosionTime = 2f;

    protected bool isExploded;
    protected Character owner;
    protected Sequence explosion;

    public virtual void Init(Character owner)
    {
      this.owner = owner;
      isExploded = false;

      explosion = DOTween.Sequence()
        .AppendInterval(explosionTime)
        .AppendCallback(Explode);
    }

    protected override void OnDisable()
    {
      base.OnDisable();

      explosion?.Kill();
    }

    public virtual void Explode()
    {
      if(!isExploded)
      {
        owner.OnBombExploded(this);
        Dispose();

        foreach(var dir in HexagonManager.GetDirections())
        {
          var power = owner.GetBombPower();
          var blocksOffset = GenerationManager.GetGroundBlocksOffset();
          var distance = blocksOffset * power;
          var direction = dir * distance;

          RaycastHit[] hits = Physics.RaycastAll(
            origin: this.GetPosition() + Vector3.up * 0.5f - direction.normalized,
            direction: direction,
            maxDistance: distance + 1,
            layerMask: LayerMask.GetMask("Interactable", "Character")
          );

          float distanceFactor = -1;
          if(hits.Length > 0)
          {
            hits = hits.OrderBy((hit) => Vector3.Distance(hit.transform.position, this.GetPosition())).ToArray();
            foreach(var hit in hits)
            {
              var wall = hit.collider.TryFindInParent<Wall>();
              if(wall != null)
              {
                var distanceToCollider = Vector3.Distance(hit.transform.position, this.GetPosition());
                distanceFactor =
                  (distanceToCollider - blocksOffset) / blocksOffset / power;
                break;
              }

              var iExplodable = hit.collider.TryFindInParent<IExplodable>();
              if(iExplodable != null)
              {
                iExplodable.Explode();
              }
            }
          }

          CreateExplosionEffect(
            this.GetPosition()
            + (direction * (distanceFactor >= 0 ? distanceFactor : 1))
            + direction.normalized * 0.4f
          );
        }
      }

      isExploded = true;
    }

    protected virtual void CreateExplosionEffect(Vector3 targetPosition)
    {
      var offset = Vector3.up * 0.5f;
      var newEffect = PoolsManager.CreateElement<ExplosionLine>();
      newEffect.SetPosition(this.GetPosition() + offset);
      newEffect.SetTargetPosition(targetPosition + offset);
    }
  }
}
