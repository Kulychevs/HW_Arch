using UnityEngine;


public sealed class GameInit
{
    #region Fields

    private Monster _monster;

    #endregion


    #region LifeCircle

    public GameInit(Monsters monster)
    {
        Activation("Player", true);
        Activation("Background", true);
        SetMonster(monster);

        ServiceLocator.SetService(new JawsController());
        var jawsController = ServiceLocator.Resolve<JawsController>();
        jawsController.SetJaws(_monster.MonsterBody, _monster.Strength, 3f);
        

        GameObject go = new GameObject("GameController");
        go.AddComponent<GameController>();
    }

    #endregion


    #region Methods  

    public static void Activation(string tag, bool isEnabled)
    {
        var pl = GameObject.FindGameObjectWithTag(tag);
        var renderers = pl.GetComponentsInChildren<SpriteRenderer>();
        foreach (var r in renderers)
            r.enabled = isEnabled;
    }

    private void SetMonster(Monsters monster)
    {
        switch (monster)
        {
            case Monsters.None:
                break;
            case Monsters.Lion:
                _monster = new Lion();
                break;
            case Monsters.Shark:
                _monster = new Shark();
                break;
            default:
                break;
        }
    }

    #endregion
}

