using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponTableSO weaponTable;
    public WeaponDataSO currentWeapon;

    public void TryUpgradeWeapon()
    {
        int nextLevel = currentWeapon._upgradeLevel + 1;

        if (nextLevel >= weaponTable.weapons.Length)
        {
            Debug.Log("최고 레벨 달성");
            return;
        }

        if (CoinManager.Instance.MinusCoin(currentWeapon._upgradePrice))
        {
            if (Random.Range(0f, 100f) <= currentWeapon._successRate)
            {
                currentWeapon = weaponTable.weapons[nextLevel];
                Debug.Log("강화 성공");
            }
            else
            {
                currentWeapon = weaponTable.weapons[0];
                Debug.Log("강화 실패");
            }
        }
        else
        {
            Debug.Log("그지");
        }
    }

    public void SellWeapon()
    {
        CoinManager.Instance.PlusCoin(currentWeapon._sellPrice);

        currentWeapon = weaponTable.weapons[0];

        Debug.Log("판매 성공");
    }
}