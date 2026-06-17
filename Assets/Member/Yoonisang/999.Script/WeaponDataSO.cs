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
    public int _sellPrice;//판매 가격

    public int _upgradePrice;//강화 가격

    [Header("강화 성공 확률")]
    [Range(0f, 100f)]
    public float _successRate;

    [Header("강화 실패 확률")]
    [Range(0f, 100f)]
    public float _destroyRate;

    [Header("강화 가격 보정값")]
    public float _upgradeCorrectionValue;

    [Header("판매 가격 보정값")]
    public float _sellCorrectionValue;

    private void OnValidate()
    {
        _upgradePrice = Mathf.RoundToInt((_upgradeLevel + 1) * _upgradeCorrectionValue);
        _sellPrice = Mathf.RoundToInt((_upgradeLevel + 1) * _sellCorrectionValue);
    }
}
