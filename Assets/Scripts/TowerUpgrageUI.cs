using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TowerUpgrageUI : MonoBehaviour
{
    public Tower tower;
    public Button upgradeButton;
    public TextMeshProUGUI priceTxt;

    public bool justOpened = true;
    private void Awake()
    {
        upgradeButton.onClick.AddListener(TryUpgrade);
    }
    public void TryUpgrade()
    {
        Debug.Log("Bạn vừa ấn nút nâng cấp");
    }
    private void Update()
    {
    }
}