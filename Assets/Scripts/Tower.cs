using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject currentUI;
    public GameObject towerUpgradeUIPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        // 1. Chặn click xuyên qua UI
        if (EventSystem.current.IsPointerOverGameObject()) return;

        // 2. Kiểm tra nếu UI đã bị xóa (Missing) thì gán lại null để tạo mới
        if (currentUI == null)
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            if (canvas != null)
            {
                currentUI = Instantiate(towerUpgradeUIPrefab, canvas.transform);

                // Gọi Init để kích hoạt flag justOpened

                TowerUpgrageUI uiScript = currentUI.GetComponent<TowerUpgrageUI>();
                if (uiScript != null)
                {
                    uiScript.tower = this;
                    uiScript.Init();
                    Debug.Log("Đã lấy được Script UI thành công!");
                }
                else
                {
                    // Nếu dòng này hiện lên ở bảng Console, nghĩa là bạn gán nhầm Prefab
                    Debug.LogError("LỖI: Prefab này không có gắn script TowerUpgrageUI!");
                }
                uiScript.tower = this;
                uiScript.Init();
            }
        }
        else
        {
            // Nếu đang hiện rồi thì reset flag để không bị tự xóa
            currentUI.GetComponent<TowerUpgrageUI>().Init();
        }

        // 3. Đưa UI về đúng vị trí chuột
        // LƯU Ý: Prefab Panel phải để Anchor là Center, Pos 0,0,0
        currentUI.transform.position = Input.mousePosition + new Vector3(80, -80, 0);
    }
}