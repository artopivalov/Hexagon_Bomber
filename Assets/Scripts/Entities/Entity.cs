///
///
///
using UnityEngine;

namespace Application.Entities
{
  public class Entity : MonoBehaviour
  {
    protected virtual void Awake()
    {
      Subscribe();
    }

    protected virtual void Start()
    {
    }

    public virtual void Subscribe()
    {

    }

    public virtual void Unsubscribe()
    {

    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }

    protected virtual void OnDestroy()
    {
      Unsubscribe();
    }

    public virtual void Dispose()
    {
      //TODO return to pool
      gameObject.SetActive(false);
      GameObject.Destroy(gameObject);
    }
  }
}
