///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Bot
  {
    [SubscribeToMainMethod]
    protected virtual void SubscribePhysic()
    {
      Events.AllCharacterSpawned += AllCharactersSpawnd;
    }

    [SubscribeToMainMethod]
    protected virtual void UnsubscribePhysic()
    {
      Events.AllCharacterSpawned -= AllCharactersSpawnd;
    }

    protected virtual void AllCharactersSpawnd()
    {
      foreach(var bot in CharactersManager.GetBots())
      {
        Physics.IgnoreCollision(collider, bot.GetCollider(), true);
      }
    }
  }
}
