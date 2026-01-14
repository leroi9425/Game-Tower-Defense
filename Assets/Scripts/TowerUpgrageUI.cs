using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TowerUpgrageUI : MonoBehaviour
{
    public Tower tower;
    public Button btnUpgrage;
    private bool justOpened;

    public void Init()
    {
        justOpened = true; // Đánh dấu là vừa được mở/cập nhật
    }

    private void Awake()
    {
        if (btnUpgrage != null)
            btnUpgrage.onClick.AddListener(HandleUpgrade);
    }

    private void HandleUpgrade()
    {
        // Thêm code nâng cấp của bạn ở đây
        Debug.Log("Đang nâng cấp tháp!");
        Destroy(gameObject); // Nâng cấp xong thì đóng menu
    }

    void Update()
    {
        // Nếu vừa mở trong Frame này, bỏ qua không kiểm tra click để tránh tự xóa
        if (justOpened)
        {
            justOpened = false;
            return;
        }

        // Kiểm tra click chuột trái
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Nếu click VÀO chính cái Menu này thì không xóa
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // Nếu click ra ngoài vùng UI thì mới xóa Menu
            Destroy(gameObject);
        }
    }
}