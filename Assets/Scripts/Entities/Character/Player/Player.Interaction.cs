///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Player
  {
    protected override void OnInteractionWithCharacter(Character character)
    {
      base.OnInteractionWithCharacter(character);

      Die();
    }
  }
}
