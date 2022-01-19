using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _countMoneyText;

    [SerializeField]
    private TMP_Text _countHealthText;

    [SerializeField]
    private TMP_Text _countPowerText;

    [SerializeField]
    private TMP_Text _countWantedText;

    [SerializeField]
    private TMP_Text _countPowerEnemyText;


    [SerializeField]
    private Button _addMoneyButton;

    [SerializeField]
    private Button _minusMoneyButton;


    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;


    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _addWantedButton;

    [SerializeField]
    private Button _minusWantedButton;

    [SerializeField]
    private Button _fightButton;

    [SerializeField]
    private Button _dontFightButton;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allCountWantedPlayer;

    private Money _money;
    private Health _heath;
    private Power _power;
    private Wanted _wanted;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = new Enemy("Enemy Asteroid");

        _money = new Money();
        _money.Attach(_enemy);

        _heath = new Health();
        _heath.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _wanted = new Wanted();
        _wanted.Attach(_enemy);

        _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _addWantedButton.onClick.AddListener(() => ChangeWanted(true));
        _minusWantedButton.onClick.AddListener(() => ChangeWanted(false));

        _fightButton.onClick.AddListener(Fight);
        _dontFightButton.onClick.AddListener(DontFight);

        _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
        ReactionWanted();
    }

    private void OnDestroy()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _power.Detach(_enemy);
        _wanted.Detach(_enemy);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeWanted(bool isAddCount)
    {
        if (isAddCount)
            _allCountWantedPlayer++;
        else
            _allCountWantedPlayer--;

        ChangeDataWindow(_allCountWantedPlayer, DataType.Wanted);
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power
           ? "<color=#07FF00>Win!!!</color>"
           : "<color=#FF0000>Lose!!!</color>");
    }

    private void DontFight()
    {
        Debug.Log("<color=#07FF00>Win!!!</color>");
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money {countChangeData}";
                _money.CountMoney = countChangeData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player Health {countChangeData}";
                _heath.CountHealth = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player Power {countChangeData}";
                _power.CountPower = countChangeData;
                break;

            case DataType.Wanted:
                _countWantedText.text = $"Player Wanted {countChangeData}";
                _wanted.CountWanted = countChangeData;
                ReactionWanted();
                break;
        }

        _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    }

    private void ReactionWanted()
    {
        int levelWantedZero = 0;
        int levelWantePositive = 2;

        int levelWantedNegative = 3;
        int levelWantedMostNegative = 5;

        if (_wanted.CountWanted <= levelWantedZero || _wanted.CountWanted <= levelWantePositive)
        {
            DontFightWithEnemy();
        }
        else if (_wanted.CountWanted >= levelWantedNegative || _wanted.CountWanted <= levelWantedMostNegative)
        {
            FightWithEnemy();
        }
        else
        {
            FightWithEnemy();
        }
    }

    private void DontFightWithEnemy()
    {
        _fightButton.gameObject.SetActive(false);
        _dontFightButton.gameObject.SetActive(true);
    }

    private void FightWithEnemy()
    {
        _fightButton.gameObject.SetActive(true);
        _dontFightButton.gameObject.SetActive(false);
    }
}
