///
///
///
using Application.Entities;

using UnityEngine.Events;

namespace Application
{
  public partial class Events
  {
    public static UnityAction CharacterSpawned;
    public static UnityAction<Character> CharacterDied;

    public static UnityAction PlayerSpawned;
  }
}
