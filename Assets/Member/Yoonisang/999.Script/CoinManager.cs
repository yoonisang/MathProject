using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private int _currentCoin = 0;

    [SerializeField] private int _startingCoin = 100000;

    private void Awake()
    {
        _currentCoin = _startingCoin;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    // 코인 증가
    public void PlusCoin(int amount)
    {
        if (amount <= 0) return;

        _currentCoin += amount;
        UpdateCoinUI();
    }

    // 코인 감소
    public bool MinusCoin(int amount)
    {
        if (amount <= 0) return false;
        if (_currentCoin < amount)
        {
            Debug.LogWarning("코인이 부족합니다.");
            return false;
        }
        _currentCoin -= amount;
        UpdateCoinUI();

        return true;
    }

    // 현재 코인 확인
    public int GetCoin()
    {
        return _currentCoin;
    }

    // UI 갱신
    private void UpdateCoinUI()
    {
        coinText.text = "보유 금액: " + _currentCoin.ToString("N0");
    }
}