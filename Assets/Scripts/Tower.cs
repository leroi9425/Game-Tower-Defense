using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class TowerUpgradeStage
{
    public float range;
    public float fireRate;
    public Sprite sprite;
    public int price;
}
public class Tower : MonoBehaviour, IClickable2D
{
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public TowerUpgradeStage[] upgradeStages;
    public int indexUpgradeStage = 0;
    public SpriteRenderer sr;
    public GameObject towerUpgradeUIPrefab;
    public GameObject currentUI;

    public int towerPrice = 1;
    private float fireCooldown = 0f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Debug.Log(sr.name); // trả về tower_0
    }

    private void Update()
    {
        
    }
    private void Upgrade()
    {
        TowerUpgradeStage towerUpgradeStage = upgradeStages[indexUpgradeStage];  // trạng thái upgrade hiện tại của tháp
    }
    public void OnClick()
    {
        Debug.Log("Clicked vao thap roi");
    }
}