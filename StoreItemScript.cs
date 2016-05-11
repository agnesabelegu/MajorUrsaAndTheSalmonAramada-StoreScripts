using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreItemScript : MonoBehaviour
{

    public string ItemName;
    public Image ItemImage;
    public Sprite ItemHighHealthSprite;
    public Sprite ItemMedHealthSprite;
    public Sprite ItemLowHealthSprite;
    public int ItemPrice;
    [HideInInspector]
    public bool ItemBought = false;

    void Awake()
    {
        ItemImage = GetComponent<Image>();
    }
    public void UpdateItemStatus()
    {
        GetComponentInChildren<Text>().text = "BOUGHT!";
    }
}