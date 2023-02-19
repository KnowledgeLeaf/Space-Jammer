using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Upgrade[] upgrades;
    [SerializeField] PlayerController playerConRef;
    [SerializeField] LifeState playerLife;
    public Transform shopContent;
    public GameObject itemPrefab;

    private void Awake()
    {
        //Singleton
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);
            upgrade.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Price") {
                    child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + upgrade.cost.ToString();
                } else if (child.gameObject.name == "Name") {
                    child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = upgrade.name;
                }   else if (child.gameObject.name == "Image") {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }
            }

            item.GetComponent<Button>().onClick.AddListener(() => BuyUpgrade(upgrade));
        }
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if (playerConRef.Money >= upgrade.cost)
        {
            playerConRef.Money -= upgrade.cost;

            ApplyUpgrade(upgrade);
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch(upgrade.name)
        {
            case "Speed":
                playerConRef.MaxSpeed += 1;
                playerConRef.AccelerationRate += 20f;
                break;
            case "Damage":
                playerConRef.Damage += 1;
                break;
            case "Health":
                playerLife.Health += 1;
                playerLife.PlayerHealthMod += 1;
                break;
            default:
                Debug.Log("Could Not Upgrade");
                break;
            
        }
    }
}

[System.Serializable] public class Upgrade
{
    public string name;
    public int cost;
    public Sprite image;
    [HideInInspector] public GameObject itemRef;
}
