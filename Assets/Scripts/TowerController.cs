using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class TowerController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject UpgradeTowerUI;
    [SerializeField] private bool isOpenUI = false;
    void Start()
    {
        Debug.Log("Script TowerController đã sẵn sàng trên: " + gameObject.name);
        Debug.Log("Tìm thấy UI: " +  UpgradeTowerUI.name);
    }
    void Update()
    {
        if(isOpenUI && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Bạn vừa click ra vùng trống hoặc vật thể 3D");
                UpgradeTowerUI.SetActive(false);
                isOpenUI = false;
            }
            else
            {
                Debug.Log("Bạn vừa click vào UI nâng cấp, tôi sẽ giữ nguyên UI");
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Đã click vào vật thể: " + gameObject.name);
        Debug.Log("Vị trí tháp - x:" + gameObject.transform.position.x + " y: " +gameObject.transform.position.y);
        // step1: bật ui nâng cấp lên
        // step2: setup vị trí cho nó là tháp của mình + độ lệch

        UpgradeTowerUI.SetActive(true);
        isOpenUI = true;

        // chuẩn bị vị trí
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position); // lấy vị trí UI + tọa độ màn
        Vector3 offset = new Vector3(100, -100, 0);
        UpgradeTowerUI.transform.position = screenPos + offset;
    }
}
