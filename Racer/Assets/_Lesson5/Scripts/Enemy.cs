using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IEnemy
{
    private const int KCoins = 2;
    private const float KPower = 0.09f;
    private const int MaxHealthPlayer = 20;

    private string _name;

    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    private int _wantedPlayer;

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                var dataMoney = (Money)dataPlayer;
                _moneyPlayer = dataMoney.CountMoney;
                break;

            case DataType.Health:
                var dataHealth = (Health)dataPlayer;
                _healthPlayer = dataHealth.CountHealth;
                break;

            case DataType.Power:
                var dataPower = (Power)dataPlayer;
                _powerPlayer = dataPower.CountPower;
                break;

            case DataType.Wanted:
                var dataWanted = (Wanted)dataPlayer;
                _wantedPlayer = dataWanted.CountWanted;
                break;
        }

        Debug.Log($"Notified {_name} change to {dataType}");
    }

    public int Power
    {
        get
        {
            var kHealth = _healthPlayer > MaxHealthPlayer ? 50 : 10;
            var power = (int)(_healthPlayer + (_moneyPlayer * KCoins) + kHealth + _powerPlayer * KPower / KCoins);

            return power;
        }
    }

}
