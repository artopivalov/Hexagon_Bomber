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

    private void OnCollisionStay(Collision collision) // refactor
    {
      var entity = collision.collider.GetComponent<Entity>();

      switch(entity)
      {
        case GroundBlock groundBlock:
          OnInteractionWithGroundBlock(groundBlock);
          break;
      }
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
        case Character character:
          OnInteractionWithCharacter(character);
          break;
      }
    }

    protected virtual void InteractionWithInteractable(Interactable interactable, Collider collision)
    {
      if(previousCollision != null && previousCollision == collision)
      {
        return;
      }

      switch(interactable)
      {
        case GroundBlock groundBlock:
          OnInteractionWithGroundBlock(groundBlock);
          break;
        case Bonus bonus:
          OnInteractionWithBonus(bonus);
          break;
      }

      previousCollision = collision;
    }

    protected virtual void OnInteractionWithCharacter(Character character)
    {

    }

    protected virtual void OnInteractionWithGroundBlock(GroundBlock groundBlock)
    {
      SetCurrentGroundBlock(groundBlock);
    }

    protected virtual void OnInteractionWithBonus(Bonus bonus)
    {
      bonus.Dispose();
      switch(bonus)
      {
        case BonusPower bonusPower:
          OnInteractionWithBonusPower(bonusPower);
          break;
        case BonusCount bonusCount:
          OnInteractionWithBonusCount(bonusCount);
          break;
      }
    }

    protected virtual void OnInteractionWithBonusPower(BonusPower bonusPower)
    {
      UpgradePower();
    }

    protected virtual void OnInteractionWithBonusCount(BonusCount bonusCount)
    {
      UpgradeCount();
    }
  }
}
