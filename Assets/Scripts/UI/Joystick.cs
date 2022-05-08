///
/// my legacy joystick
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  //TODO multitouch
  public class Joystick : Entity
  {
    private UnityEngine.Camera targetCamera => CameraManager.ui.GetCamera();

    private RectTransform baseRect;
    private Vector2 direction;
    private Vector2 touchPosition;

    protected Vector2 touchClampedPosition;
    protected bool isJoystickActivated;

    [Header("Settings")]
    public float handleRange = 1;
    public float deadZone = 0.1f;
    public float magnetDistance = 0;

    [Header("References")]
    public RectTransform container;
    public RectTransform handle;
    public RectTransform unrestrictedPoint;
    public RectTransform joystickBackground;

    protected override void Start()
    {
      base.Start();

      baseRect = GetComponent<RectTransform>();

      DeactivateJoystick();
    }

    public override void Subscribe()
    {
      base.Subscribe();

      Events.PointerDown += OnPointerDown;
      Events.PointerUp += OnPointerUp;
      Events.PointerMove += OnPointerMove;
    }

    private void OnPointerDown()
    {
      ActivateJoystick();
    }

    private void OnPointerUp()
    {
      DeactivateJoystick();
    }

    private void OnPointerMove(Vector2 delta)
    {
      if(container.gameObject.activeSelf && isJoystickActivated)
      {
        UpdateTouchPosition();

        OnDrag();
      }
    }

    private void OnDrag()
    {
      direction = DefineDirection();
      SetDirection(direction.magnitude, direction.normalized);

      UpdateHandlePosition();
      UpdateJoystickPosition();
    }

    public Vector2 GetDirection()
    {
      return direction;
    }

    protected virtual void SetDirection(float magnitude, Vector2 normalized)
    {
      if(magnitude > deadZone)
      {
        if(magnitude > 1)
        {
          direction = normalized;
        }
      }
      else
      {
        direction = Vector3.zero;
      }
    }

    protected Vector2 GetTouchPositionInScreen()
    {
      return ScreenPointToAnchoredPosition(touchPosition);
    }

    protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
      if(RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, targetCamera, out Vector2 point))
      {
        return point;
      }

      return Vector2.zero;
    }

    public virtual void DeactivateJoystick()
    {
      container.gameObject.SetActive(false);
      direction = Vector2.zero;
      handle.anchoredPosition = Vector2.zero;
      isJoystickActivated = false;
    }

    public virtual void ActivateJoystick()
    {
      UpdateTouchPosition();

      container.gameObject.SetActive(true);
      container.anchoredPosition = GetTargetPositionOnScreen();
      unrestrictedPoint.anchoredPosition = GetTouchPositionInScreen();
      isJoystickActivated = true;
    }

    public virtual void ActivateJoystickAtStartPosition()
    {
      container.gameObject.SetActive(true);
      container.anchoredPosition = GetDefaultPosition();
      handle.anchoredPosition = Vector2.zero;
      direction = Vector2.zero;
    }

    protected virtual Vector2 GetDefaultPosition()
    {
      // returns center of the third of the screen
      var height = UnityEngine.Screen.height / 3;
      var width = UnityEngine.Screen.width / 2;
      return ScreenPointToAnchoredPosition(new Vector2(width, (height - height / 2)));
    }

    protected Vector2 GetTargetPositionOnScreen()
    {
      return ScreenPointToAnchoredPosition(touchPosition);
    }

    private Vector2 DefineDirection()
    {
      Vector2 position = targetCamera.WorldToScreenPoint(unrestrictedPoint.position);
      return (touchPosition - position) / GetHandleRadius() * UIHelper.GetCanvasScaleFactor();
    }

    private Vector2 GetHandleRadius()
    {
      return container.sizeDelta / 2 * handleRange;
    }

    private float GetMagnetDistance()
    {
      if(magnetDistance < 0)
      {
        return 0;
      }

      return GetHandleRadius().magnitude
        * UIHelper.GetCanvasScaleFactor()
        + magnetDistance;
    }

    protected virtual void UpdateTouchPosition()
    {
      touchPosition = Input.mousePosition;

      touchClampedPosition = touchPosition;
    }

    protected virtual void UpdateJoystickPosition()
    {
      float magnetDistance = GetMagnetDistance();
      if(magnetDistance > 0)
      {
        UpdatePosition(unrestrictedPoint, GetTouchPositionInScreen(), magnetDistance);
        UpdatePosition(container, GetTouchPositionInScreen(), magnetDistance);
      }
    }

    private void UpdatePosition(RectTransform transform, Vector2 target, float magnetDistance)
    {
      if(Vector2.Distance(target, transform.anchoredPosition) > magnetDistance)
      {
        Vector2 difference = target - transform.anchoredPosition;
        var targetPosition = difference * (1 - magnetDistance / difference.magnitude);
        transform.anchoredPosition += targetPosition;
      }
    }

    private void UpdateHandlePosition()
    {
      var radius = GetHandleRadius();
      var position = DefineDirection() * radius;
      handle.anchoredPosition = Vector2.ClampMagnitude(position, radius.magnitude * UIHelper.GetCanvasScaleFactor());
    }
  }
}
