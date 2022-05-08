///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public partial class Bot
  {
    public partial class BotBrainStupid : BotBrain
    {
      public override void GameStarted()
      {
        base.GameStarted();

        FindWayPoint();
      }

      protected virtual void FindWayPoint()
      {
        var direction = bot.availableDirections.Random() * GenerationManager.GetGroundBlocksOffset();
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
