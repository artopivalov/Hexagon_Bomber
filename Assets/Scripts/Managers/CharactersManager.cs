///
///
///
using Application.Entities;
using Application;

using UnityEngine;
using System;
using System.Collections.Generic;

namespace Application.Managers
{
  public static partial class CharactersManager
  {
    private static Player player;
    private static List<Character> aliveBots = new List<Character>();

    static CharactersManager()
    {
      CharactersManager.Subscribe();
    }

    private static void Subscribe()
    {
      Events.PreReset += OnPreReset;
      Events.PostReset += OnPostReset;
      Events.CharacterDied += OnCharacterDied;
    }

    private static void OnPreReset()
    {
      aliveBots.Clear();
    }

    private static void OnPostReset()
    {
      var allSpawners = GenerationManager.GetLevel().GetComponentsInChildren<CharacterSpawnPoint>();
      foreach(var spawner in allSpawners)
      {
        CreateCharacter(spawner);
      }
    }

    private static void OnCharacterDied(Character character)
    {
      switch(character)
      {
        case Player player:
          LevelsManager.PerformLevelFinish(false);
          break;
        case Bot bot:
          aliveBots.Remove(bot);
          if(aliveBots.Count <= 0)
          {
            LevelsManager.PerformLevelFinish(true);
          }
          break;
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
      else
      {
        aliveBots.Add(character);
      }
      Events.CharacterSpawned.TryInvoke();

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