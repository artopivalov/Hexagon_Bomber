///
///
///
using UnityEngine;

namespace Application.Entities
{
  public static partial class EntityExtensions
  {
    public static T TryFindInParent<T>(this Collider collider)
    {
      T target = collider.GetComponent<T>();

      if(target == null)
      {
        target = collider.GetComponentInParent<T>();
      }

      return target;
    }
  }
}
