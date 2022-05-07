///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected Collider previousCollision;

    [SubscribeToMainMethod]
    protected virtual void ResetInteraction()
    {
      previousCollision = null;
    }

    public virtual void OnInteraction(Collider other)
    {
      var element = other.GetComponent<Entity>();
      if(element == null)
      {
        element = other.GetComponentInParent<Entity>();
      }
      if(element != null)
      {
        InteractionWithElement(element, other);
      }
    }

    protected virtual void InteractionWithElement(Entity element, Collider collision)
    {
      switch(element)
      {
        case Interactable interactable:
          InteractionWithInteractable(interactable, collision);
          break;
      }
    }

    protected virtual void InteractionWithInteractable(Interactable interactable, Collider collision)
    {
      if(previousCollision != null && previousCollision == collision)
      {
        return;
      }

      previousCollision = collision;
    }
  }
}
