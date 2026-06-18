using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "SO/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [Header("이름")]
    public string _weaponName;

    [Header("프리팹")]
    public GameObject weaponPrefab;

    [Header("강화 단계")]
    public int _upgradeLevel;

    [Header("판매/강화 가격")]
    public int _sellPrice;//판매 가격, 2.2배씩 증가

    public int _upgradePrice;//강화 가격, 1.8배씩 증가

    [Header("강화 성공 확률")]
    [Range(0f, 100f)]
    public float _successRate;

    [Header("강화 실패 확률")]
    [Range(0f, 100f)]
    public float _destroyRate;

    [SerializeField] private int baseUpgradePrice = 100;
    [SerializeField] private int baseSellPrice = 60;

    private void OnValidate()
    {
        _upgradePrice = Mathf.RoundToInt(baseUpgradePrice * Mathf.Pow(1.8f, _upgradeLevel));

        _sellPrice = Mathf.RoundToInt(baseSellPrice * Mathf.Pow(2.2f, _upgradeLevel));
    }
}
