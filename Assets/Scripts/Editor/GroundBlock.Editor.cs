///
///
///
using Application.Entities;

using UnityEngine;
using UnityEditor;

namespace Application.Editor
{
  [CustomEditor(typeof(GroundBlock))]
  public class GroundBlockEditor : UnityEditor.Editor
  {
    protected GroundBlock block => target as GroundBlock;

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      if(IsEditable())
      {
        GUILayout.Space(20);

        if(GUILayout.Button("Add Wall"))
        {
          block.SpawnWall();
        }

        if(GUILayout.Button("Add BreakableWall"))
        {
          block.SpawnBreakableWall();
        }

        if(GUILayout.Button("Add CharacterSpawner"))
        {
          block.SpawnCharacterSpawner();
        }

        if(GUILayout.Button("Clear"))
        {
          block.ClearContent();
        }
      }
    }

    private bool IsEditable()
    {
      return block.GetComponentInParent<Level>() 
        || !PrefabUtility.IsPartOfPrefabInstance(target) && !PrefabUtility.IsPartOfPrefabAsset(target);
    }
  }
}
