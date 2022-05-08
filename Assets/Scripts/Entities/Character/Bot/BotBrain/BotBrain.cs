///
///
///
using UnityEngine;

namespace Application.Entities
{
  public partial class Bot
  {
    public abstract class BotBrain
    {
      protected Bot bot;

      public virtual BotBrain Init(Bot botReference)
      {
        this.bot = botReference;

        return this;
      }

      public virtual void Reset() { }

      public virtual void GameStarted() { }

      public abstract void Update();
    }
  }
}
