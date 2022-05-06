///
///
///
using Application.Entities;

using UnityEngine;

namespace Application.Settings
{
  [CreateAssetMenu(menuName = menuMenuName, fileName = menuFileNameWithExtension, order = menuOrder)]
  public partial class LevelData : ScriptableObject
  {
    public const string menuMenuName = "Application/Settings/LevelData";
    public const string menuFileNameWithExtension = "level.data.000.asset";
    public const int menuOrder = 400;

    [Header("References")]
    public Level levelPrefab;
  }
}
