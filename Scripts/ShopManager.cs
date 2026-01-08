using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Key for saving: 0=Default, 1=Red, 2=Blue

    [Header("UI References")]
    public TextMeshProUGUI moneyText; // Drag your Money Text here (if you have one)

    private int currentMoney;

    void Start()
    {
        // Load Money from Save System
        currentMoney = PlayerPrefs.GetInt("TotalMoney", 0);
        currentMoney = 1000;
        UpdateUI();
    }

    public void BuyOrEquipSkin(int skinID)
    {
        // skinID 0 = Default (Always Free)
        // skinID 1 = Red (Cost 100)
        // skinID 2 = Blue (Cost 500)

        int cost = 0;
        if (skinID == 1) cost = 100;
        if (skinID == 2) cost = 500;

        // Check if we already bought it? (Using a trick: 1=Bought, 0=Not)
        // Default skin (0) is always "bought"
        bool isOwned = (skinID == 0) || (PlayerPrefs.GetInt("SkinOwned_" + skinID, 0) == 1);

        if (isOwned)
        {
            // Just Equip it
            SelectSkin(skinID);
        }
        else
        {
            // Try to Buy
            if (currentMoney >= cost)
            {
                // Deduct Money
                currentMoney -= cost;
                PlayerPrefs.SetInt("TotalMoney", currentMoney);

                // Mark as Owned
                PlayerPrefs.SetInt("SkinOwned_" + skinID, 1);
                PlayerPrefs.Save();

                // Equip
                SelectSkin(skinID);
                Debug.Log("Skin Purchased!");
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }
        UpdateUI();
    }

    void SelectSkin(int id)
    {
        // Save the choice for the Game Scene to read later
        PlayerPrefs.SetInt("SelectedSkin", id);
        PlayerPrefs.Save();
        Debug.Log("Skin Equipped: " + id);
    }

    void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "Money: " + currentMoney.ToString();
    }
}