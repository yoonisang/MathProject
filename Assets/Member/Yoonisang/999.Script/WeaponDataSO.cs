using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "SO/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [Header("이름")]
    public string _weaponName;

    [Header("프리팹")]
    public GameObject weaponPrefab;

    [Header("강화 데이터")]
    public UpgradeDataSO upgradeData;
}
