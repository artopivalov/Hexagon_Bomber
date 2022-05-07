///
///
///
using Application.Managers;

using UnityEngine;
using DG.Tweening;

namespace Application.Entities
{
  public class Bomb : Interactable, IExplodable
  {
    protected bool isExploded;
    public float explosionTime = 2f;

    public virtual void Init()
    {
      isExploded = false;

      DOTween.Sequence()
        .AppendInterval(explosionTime)
        .AppendCallback(Explode);
    }

    public virtual void Explode()
    {
      if(!isExploded)
      {
        Dispose();

        for(int i = 0; i < 6; i++)
        {
          var distance = GenerationManager.GetGroundBlocksOffset();
          var direction = Quaternion.Euler(0, 60 * i, 0) * Vector3.left * distance;

          var hited = Physics.Raycast(
            origin: this.GetPosition() + Vector3.up * 0.5f,
            direction: direction,
            maxDistance: distance,
            layerMask: LayerMask.GetMask("Interactable", "Character"),
            hitInfo: out RaycastHit hit
          );

          if(hited)
          {
            var iExplodable = hit.collider.GetComponent<IExplodable>();
            if(iExplodable == null)
            {
              iExplodable = hit.collider.GetComponentInParent<IExplodable>();
            }

            if(iExplodable != null)
            {
              iExplodable.Explode();
            }
          }
        }
      }

      isExploded = true;
    }
  }
}
