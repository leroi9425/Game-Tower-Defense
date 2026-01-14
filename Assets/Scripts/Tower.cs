using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToweUpgrageState
{
    public Sprite sprite;
}
public class Tower : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject currentUI;
    public ToweUpgrageState[] upgrageStates;
    private int upgrareState;
    public GameObject towerUpgradeUIPrefab;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ToweUpgrageState currentUpgrageState = upgrageStates[upgrareState];
        //sr.sprite = currentUpgrageState.sprite;

    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (currentUI == null)
        {
            currentUI = Instantiate(towerUpgradeUIPrefab, FindFirstObjectByType<Canvas>().transform);

            // Thêm 2 dòng này để "cứu" Menu không bị xóa
            TowerUpgrageUI uiScript = currentUI.GetComponent<TowerUpgrageUI>();
            uiScript.tower = this;
            uiScript.Init(); // Báo cho Menu biết là vừa mới sinh ra
        }

        currentUI.transform.position = Input.mousePosition + new Vector3(80, -80, 0);
    }
}
