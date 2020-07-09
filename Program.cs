using System;


public sealed class ApprovalMoney
{
    public float USD;
}

public abstract class Boss
{
    protected float _maxMoney;
    protected Boss _nextBoss;

    public void SetNextBoss(Boss nextBoss) => _nextBoss = nextBoss;

    public ApprovalMoney ApproveMoney(float askedMoney)
    {
        if (askedMoney <= _maxMoney)
        {
            ApprovalMoney money = new ApprovalMoney();
            money.USD = askedMoney;
            return money;
        }
        if (_nextBoss != null)
            return _nextBoss.ApproveMoney(askedMoney);
        return null;
    }
}

public sealed class Supervisor : Boss
{
    public Supervisor(float maxMoney) => _maxMoney = maxMoney;
}

public sealed class Director : Boss
{
    public Director(float maxMoney) => _maxMoney = maxMoney;
}

public sealed class Employer
{
    public ApprovalMoney ApprovalMoney;
}

class Program
{
    private static Boss GetChainOfBosses()
    {
        var supervisor = new Supervisor(1000);
        var director = new Director(10000);

        supervisor.SetNextBoss(director);

        return supervisor;
    }
    static void Main()
    {
        var employer = new Employer();
        var boss = GetChainOfBosses();

        employer.ApprovalMoney = boss.ApproveMoney(1500);

        Console.WriteLine(employer.ApprovalMoney.USD);
    }
}
