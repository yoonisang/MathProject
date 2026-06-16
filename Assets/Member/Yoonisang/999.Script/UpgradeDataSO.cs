using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "SO/UpgradeData")]
public class UpgradeDataSO : ScriptableObject
{
    [Header("강화 단계")]
    public int _upgradeLevel;

    [Header("판매 가격")]
    public int _sellPrice;

    [Header("강화 성공 확률")]
    [Range(0f, 100f)]
    public float _successRate;

    [Header("강화 실패 확률")]
    [Range(0f, 100f)]
    public float _destroyRate;
}
