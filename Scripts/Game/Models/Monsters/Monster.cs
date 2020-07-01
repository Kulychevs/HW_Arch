using UnityEngine;


internal abstract class Monster
{
    #region Fields

    private const string PATH = "Monsters";
    private readonly Sprite[] _monsterBody;
    protected float _strength;

    #endregion


    #region Properties

    public Sprite[] MonsterBody => _monsterBody;
    public float Strength => _strength;

    #endregion


    #region LifeCircle

    public Monster()
    {
        string name = ToString();

        _monsterBody = new Sprite[3];        
        _monsterBody[(int)MonsterParts.UpperJaw] = Resources.Load<Sprite>($"{PATH}\\{name}\\UpperJaw");
        _monsterBody[(int)MonsterParts.LowerJaw] = Resources.Load<Sprite>($"{PATH}\\{name}\\LowerJaw");
        _monsterBody[(int)MonsterParts.Body] = Resources.Load<Sprite>($"{PATH}\\{name}\\Body");
    }

    #endregion
}
