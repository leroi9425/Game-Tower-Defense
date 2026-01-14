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
        justOpened = true;
    }
    private void Awake()
    {
        btnUpgrage.onClick.AddListener(handleUpgrage);
    }

    private void handleUpgrage()
    {

    }
    void Start()
    {
        
    }
    public void SetJustOpened()
    {
        justOpened = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (justOpened)
        {
            justOpened = false;
            return;
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Destroy(gameObject);
        }
    }
}
