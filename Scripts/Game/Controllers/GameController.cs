using UnityEngine;


internal sealed class GameController : MonoBehaviour
{
    #region Fields

    private Controllers _controllers;

    #endregion


    #region UnityMethods

    void Start()
    {
        _controllers = new Controllers();
        _controllers.Initialization();
    }

    void Update()
    {
        for (var i = 0; i < _controllers.Length; i++)
            _controllers[i].Execute();
    }

    #endregion
}
