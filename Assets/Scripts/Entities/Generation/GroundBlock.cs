///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class GroundBlock : Interactable
  {
    [Header("References")]
    public Wall wallReference;
    public BreakableWall breakableReference;
    public CharacterSpawnPoint characterSpawnPoint;

    public virtual void SpawnWall()
    {
      ClearContent();
      SpawnEntity(wallReference);
    }

    public virtual void SpawnBreakableWall()
    {
      ClearContent();
      SpawnEntity(breakableReference);
    }

    public virtual void SpawnCharacterSpawner()
    {
      ClearContent();
      SpawnEntity(characterSpawnPoint);
    }

    protected virtual void SpawnEntity(Entity reference)
    {
      var instance = UnityEditor.PrefabUtility.InstantiatePrefab(reference) as Entity;
      instance.transform.SetParent(this.transform);
      instance.transform.localPosition = Vector3.zero;

      UnityEditor.EditorUtility.SetDirty(this);
    }

    public virtual void ClearContent()
    {
      if(transform.childCount > 1)
      {
        var instance = transform.GetChild(1).GetComponent<Entity>();
        if(instance != null)
        {
          GameObject.DestroyImmediate(instance.gameObject);
          UnityEditor.EditorUtility.SetDirty(this);
        }
      }
    }
  }
}
