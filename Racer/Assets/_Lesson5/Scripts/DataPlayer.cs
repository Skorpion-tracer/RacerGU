using System.Collections.Generic;

public class DataPlayer
{
    private List<IEnemy> _enemies = new List<IEnemy>();

    public void Attach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    protected void Notify(DataType dataType)
    {
        foreach (var enemy in _enemies)
            enemy.Update(this, dataType);
    }
}

public class Money : DataPlayer
{
    private int _countMoney;
    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notify(DataType.Money);
            }
        }
    }
}

public class Health : DataPlayer
{
    private int _countHealth;
    public int CountHealth
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notify(DataType.Health);
            }
        }
    }
}

public class Power : DataPlayer
{
    private int _countPower;
    public int CountPower
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notify(DataType.Power);
            }
        }
    }
}

public class Wanted : DataPlayer
{
    private int _countWanted;
    public int CountWanted
    {
        get => _countWanted;
        set
        {
            if (_countWanted != value)
            {
                _countWanted = value;
                Notify(DataType.Wanted);
            }
        }
    }
}

