///
///
///
using Application.Attributes;

using UnityEngine;

namespace Application.Entities
{
  public partial class Character
  {
    protected GroundBlock currentGroundBlock;

    public virtual void SetCurrentGroundBlock(GroundBlock groundBlock)
    {
      currentGroundBlock?.SetScale(1);
      currentGroundBlock = groundBlock;
      currentGroundBlock.SetScale(1.1f);
    }

    public virtual GroundBlock GetCurrentGroundBlock()
    {
      return currentGroundBlock;
    }
  }
}
