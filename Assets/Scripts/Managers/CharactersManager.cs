///
///
///
using Application.Entities;
using Application;

using UnityEngine;
using System;

namespace Application.Managers
{
  public static partial class CharactersManager
  {
    private static Player player;

    static CharactersManager()
    {
      CharactersManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.PreReset += OnPreReset;
      Events.PostReset += OnPostReset;
    }

    private static void OnPreReset()
    {
      
    }

    private static void OnPostReset()
    {
      var allSpawners = GenerationManager.GetLevel().GetComponentsInChildren<CharacterSpawnPoint>();
      foreach(var spawner in allSpawners)
      {
        CreateCharacter(spawner);
      }
    }

    public static Character CreateCharacter(CharacterSpawnPoint characterSpawnPoint)
    {
      Character character = PoolsManager.CreateElement(GetCharacterType(characterSpawnPoint.characterType)) as Character;
      character.transform.position = characterSpawnPoint.transform.position;
      character.transform.eulerAngles = characterSpawnPoint.transform.eulerAngles;

      if(characterSpawnPoint.characterType == CharacterSpawnPoint.CharacterType.Player)
      {
        player = character as Player;
        Events.PlayerSpawned.TryInvoke();
      }

      return character;
    }

    private static Type GetCharacterType(CharacterSpawnPoint.CharacterType enumType)
    {
      switch(enumType)
      {
        case CharacterSpawnPoint.CharacterType.Player:
          return typeof(Player);
        case CharacterSpawnPoint.CharacterType.Bot:
          return typeof(Bot);
      }
      return typeof(MonoBehaviour);
    }

    public static Player GetPlayer()
    {
      return player;
    }
  }
}