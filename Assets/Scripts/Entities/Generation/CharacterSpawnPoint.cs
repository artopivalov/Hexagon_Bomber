///
///
///
using Application.Entities;

using System;

using UnityEngine;

namespace Application.Entities
{
  public class CharacterSpawnPoint : Entity
  {
    public enum CharacterType
    {
      Player,
      Bot,
    }

    public CharacterType characterType;
  }
}