internal sealed class Controllers : IInitialization
{
    #region Fields

    private readonly IExecute[] _executeControllers;

    #endregion


    #region Properties

    public int Length => _executeControllers.Length;
    public IExecute this[int index] => _executeControllers[index];

    #endregion


    #region LifeCircle

    public Controllers()
    {
        ServiceLocator.SetService(new InputController());
        ServiceLocator.SetService(new PhaseController());

        _executeControllers = new IExecute[3];
        _executeControllers[0] = ServiceLocator.Resolve<InputController>();
        _executeControllers[1] = ServiceLocator.Resolve<JawsController>();
        _executeControllers[2] = ServiceLocator.Resolve<PhaseController>();
    }

    #endregion


    #region IInitialization

    public void Initialization()
    {
        foreach (var controller in _executeControllers)
            if (controller is IInitialization initialization)
                initialization.Initialization();
    }

    #endregion
}



