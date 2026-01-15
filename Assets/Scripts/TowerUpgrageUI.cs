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
        Tower.indexUpgradeStage += 1;
    }
    private void Update()
    {
        //// Xử lý để không đóng UI ngay lập tức khi vừa mở
        //if (justOpened)
        //{
        //    justOpened = false;
        //    return;
        //}

        //// Đóng UI nếu người chơi click ra ngoài bảng
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //        return;

        //    Destroy(gameObject);
        //}

        //// Tự động đóng nếu tháp đã đạt cấp tối đa
        //if (Tower.indexUpgradeStage >= tower.upgradeStages.Length)
        //{
        //    Destroy(gameObject);
        //}
    }
}