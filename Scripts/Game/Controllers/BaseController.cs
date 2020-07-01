internal abstract class BaseController
{
    #region Properties

    public bool IsActive { get; private set; }

    #endregion


    #region Methods

    public virtual void On()
    {
        IsActive = true;
    }

    public virtual void Off()
    {
        IsActive = false;
    }

    public void Switch()
    {
        if (!IsActive)
            On();
        else
            Off();
    }

    #endregion
}

