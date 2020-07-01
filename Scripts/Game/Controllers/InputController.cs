using UnityEngine;


internal sealed class InputController : BaseController, IExecute, IInitialization
{
    #region Fields

    private JawsController _jawlController;

    #endregion


    #region IInitialization

    public void Initialization()
    {
        _jawlController = ServiceLocator.Resolve<JawsController>();
    }

    #endregion


    #region IExecute

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jawlController.OpenJawl();
        if (Input.GetKeyDown(KeyCode.Escape))
            _ = new ExitGameController();
    }

    #endregion
}


