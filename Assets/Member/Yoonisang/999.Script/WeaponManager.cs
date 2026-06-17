using TMPro;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponTableSO weaponTable;
    public WeaponDataSO currentWeapon;

    [Header("무기가 생성될 위치")]
    public Transform weaponParent;

    private GameObject _currentWeaponInstance;

    [Header("UI")]
    public TextMeshProUGUI _nameText;
    public TextMeshProUGUI _upgradePriceText;
    public TextMeshProUGUI _successRateText;
    public TextMeshProUGUI _sellPriceText;

    private void Start()
    {
        EquipWeapon(weaponTable.weapons[0]);
    }

    public void UpdateWeaponUI()
    {
        if (currentWeapon == null) return;

        _nameText.text = $"{currentWeapon._weaponName}";
        _upgradePriceText.text = $"강화 비용: {currentWeapon._upgradePrice.ToString()} G";
        _successRateText.text = $"성공 확률: {currentWeapon._successRate}%";
        _sellPriceText.text = $"판매 가격: {currentWeapon._sellPrice.ToString()} G";
    }

    public void EquipWeapon(WeaponDataSO newWeaponData)
    {
        currentWeapon = newWeaponData;

        if (_currentWeaponInstance != null)
        {
            Destroy(_currentWeaponInstance);
        }

        if (currentWeapon.weaponPrefab != null)
        {
            _currentWeaponInstance = Instantiate(currentWeapon.weaponPrefab, weaponParent);
            _currentWeaponInstance.transform.localPosition = Vector3.zero;
            _currentWeaponInstance.transform.localRotation = Quaternion.identity;
        }

        UpdateWeaponUI();
    }

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
                EquipWeapon(weaponTable.weapons[nextLevel]);
                Debug.Log("강화 성공");
            }
            else
            {
                EquipWeapon(weaponTable.weapons[0]);
                Debug.Log("강화 실패");
            }
        }
        else
        {
            Debug.Log("거지");
        }
    }

    public void SellWeapon()
    {
        CoinManager.Instance.PlusCoin(currentWeapon._sellPrice);

        EquipWeapon(weaponTable.weapons[0]);

        Debug.Log("판매");
    }
}