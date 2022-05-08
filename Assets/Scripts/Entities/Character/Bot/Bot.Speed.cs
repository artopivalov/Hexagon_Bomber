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
    public override float GetMaxSpeed()
    {
      return base.GetMaxSpeed() * 0.5f;
    }
  }
}
