///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Bot
  {
    public partial class BotBrainSmart : BotBrain
    {
      //TODO DRY

      public override void GameStarted()
      {
        base.GameStarted();

        FindWayPoint();
      }

      protected virtual void FindWayPoint()
      {
        //TODO finding a way
        var direction2Player = CharactersManager.GetPlayer().GetPosition() - bot.GetPosition();
        var nearestDir = bot.GetNearestDirection(direction2Player, bot.availableDirections);
        var direction = nearestDir * GenerationManager.GetGroundBlocksOffset();
        bot.SetWayPoint(bot.GetCurrentGroundBlock().GetPosition() + direction);
      }

      public override void Update()
      {
        if(bot.wayPoints.Count <= 0 && GameStatesManager.currentState == GameStates.Game)
        {
          FindWayPoint();
        }
      }
    }
  }
}
