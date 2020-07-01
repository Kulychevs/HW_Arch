using UnityEngine;


internal sealed class JawsController : BaseController, IInitialization, IExecute
{
    #region Fields

    private Jaws[] _jaws;
    private Transform _jawTransform;
    private Sprite[] _bodySprites;
    private float _closeSpeed;
    private float _openSpeed;
    private readonly float _maxAngle = 0.25f;
    private readonly float _multiplier = 1.5f;

    #endregion


    #region Methods

    public void SetJaws(Sprite[] bodySprites, float closeSpeed, float openSpeed)
    {
        _bodySprites = bodySprites;
        _closeSpeed = closeSpeed;
        _openSpeed = -openSpeed;
    }

    public void OpenJawl()
    {
        if (_jawTransform.rotation.z < _maxAngle)
            foreach (var jaw in _jaws)
                jaw.RotateJaw(_openSpeed);
    }

    private void MultSpeed()
    {
        _closeSpeed *= _multiplier;
    }

    private void SetSprites()
    {
        _jaws[(int)MonsterParts.UpperJaw].GetComponent<SpriteRenderer>().sprite = _bodySprites[(int)MonsterParts.UpperJaw];
        _jaws[(int)MonsterParts.LowerJaw].GetComponent<SpriteRenderer>().sprite = _bodySprites[(int)MonsterParts.LowerJaw];
    }

    #endregion


    #region IInitialization

    public void Initialization()
    {
        _jaws = new Jaws[2];
        _jaws[(int)MonsterParts.UpperJaw] = Object.FindObjectOfType<UpperJaw>();
        _jaws[(int)MonsterParts.LowerJaw] = Object.FindObjectOfType<LowerJaw>();

        _jawTransform = _jaws[0].transform;

        SetSprites();

        ServiceLocator.Resolve<PhaseController>().ChangePhase += MultSpeed;
    }

    #endregion


    #region IExecute
    public void Execute()
    {
        foreach (var jaw in _jaws)
            jaw.RotateJaw(_closeSpeed);
    }

    #endregion
}
