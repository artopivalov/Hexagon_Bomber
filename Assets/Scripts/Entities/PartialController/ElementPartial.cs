///
/// legacy
///
namespace Application.Entities
{
  using static PartialController;

  public abstract class ElementPartial : Entity
  {
    protected PartialController controller;

    protected override void Awake()
    {
      this.controller = new PartialController(this);
      this.controller.InvokeMethods(SubscribeSettings.Init);

      base.Awake();
    }

    protected override void Start()
    {
      base.Start();

      this.controller.InvokeMethods(SubscribeSettings.Start);
    }

    public override void Subscribe()
    {
      base.Subscribe();

      this.controller.InvokeMethods(SubscribeSettings.Subscribe);
    }

    public override void Unsubscribe()
    {
      base.Unsubscribe();

      this.controller.InvokeMethods(SubscribeSettings.Unsubscribe);
    }

    protected override void OnEnable()
    {
      base.OnEnable();

      this.controller.InvokeMethods(SubscribeSettings.OnEnable);
      this.OnReset();
    }

    protected override void OnDisable()
    {
      base.OnDisable();

      this.controller.InvokeMethods(SubscribeSettings.OnDisable);
    }

    protected virtual void OnReset()
    {
      this.controller.InvokeMethods(SubscribeSettings.Reset);
    }

    protected virtual void Update()
    {
      this.controller.InvokeMethods(SubscribeSettings.Update);
    }

    protected virtual void LateUpdate()
    {
      this.controller.InvokeMethods(SubscribeSettings.LateUpdate);
    }

    protected virtual void FixedUpdate()
    {
      this.controller.InvokeMethods(SubscribeSettings.FixedUpdate);
    }
  }
}
