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

    [Header("Settings")]
    public CharacterType characterType;

    [Space(10)]
    public GameObject debugView;

    protected override void OnEnable()
    {
      base.OnEnable();

      debugView.SetActive(false);
    }
  }
}
