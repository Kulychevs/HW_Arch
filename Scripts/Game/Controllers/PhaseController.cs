using System;
using UnityEngine;


internal sealed class PhaseController : BaseController, IInitialization, IExecute
{
    public event Action ChangePhase;


    #region Fields

    private GamePhases _gamePhase;
    private float _time = 0;
    private float _phaseTwoTime = 5;
    private float _phaseThreeTime = 10;

    #endregion


    #region IInitialization

    public void Initialization()
    {
        _gamePhase = GamePhases.PhaseOne;
    }

    #endregion


    #region IExecute

    public void Execute()
    {
        _time += Time.deltaTime;
        if (_gamePhase == GamePhases.PhaseOne && _time > _phaseTwoTime)
        {
            _gamePhase = GamePhases.PhaseTwo;
            ChangePhase();
        }
        else if(_gamePhase == GamePhases.PhaseTwo && _time > _phaseThreeTime)
        {
            _gamePhase = GamePhases.PhaseThree;
            ChangePhase();
        }
    }

    #endregion
}

