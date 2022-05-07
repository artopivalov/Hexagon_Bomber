///
///
///
using Application.Managers;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Application.Entities
{
  public class Control : UnityEngine.UI.Button
  {
    public static Control instance;

    protected Joystick joystick;
    protected Vector2 previousPointerPosition;
    protected bool isPointerDown;

    protected override void Awake()
    {
      base.Awake();

      instance = this;

      joystick = GetComponentInChildren<Joystick>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
      base.OnPointerDown(eventData);

      isPointerDown = true;
      previousPointerPosition = GetPointerPosition();
      Events.PointerDown.TryInvoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
      base.OnPointerUp(eventData);

      isPointerDown = false;
      Events.PointerUp.TryInvoke();
    }

    protected virtual Vector2 GetPointerPosition()
    {
      return Input.mousePosition;
    }

    public Joystick GetJoystick()
    {
      return joystick;
    }

    protected virtual void Update()
    {
      if(isPointerDown)
      {
        var positionDifference = GetPointerPosition() - previousPointerPosition;
        if(positionDifference.magnitude > 0)
        {
          Events.PointerMove?.Invoke(positionDifference);
          previousPointerPosition = GetPointerPosition();
        }
      }

      Events.Update.TryInvoke(); //TODO move to more suitable place
    }
  }
}
