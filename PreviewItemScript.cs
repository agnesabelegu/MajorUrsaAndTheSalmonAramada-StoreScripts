using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreviewItemScript : MonoBehaviour
{
    [HideInInspector] public Sprite SelectedHighHealthItem;
    [HideInInspector] public Sprite SelectedMedHealthItem;
    [HideInInspector] public Sprite SelectedLowHealthItem;
    [HideInInspector] public Image SelectedHat;
    [HideInInspector] public int SelectedItemPrice;
    [HideInInspector] public string SelectedItemName;
    [HideInInspector] public bool SelectedItemStatus;

    private PlayerHealthScript currentItem;

    void Start()
    {
        currentItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHealthScript>();
    }

    void Update()
    {
        GetComponent<Image>().sprite = currentItem.highHealthSprite;

        if (SelectedHighHealthItem != null && currentItem.highHealthSprite != SelectedHighHealthItem)
        {
            GetComponent<Image>().sprite = SelectedHighHealthItem;
        }        
    }

    public void UpdatePreviewItem()
    {
        currentItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHealthScript>();
        GetComponent<Image>().sprite = currentItem.highHealthSprite;
    }

    public void Reset()
    {
        currentItem = null;
        SelectedHighHealthItem = null;
        SelectedMedHealthItem = null;
        SelectedLowHealthItem = null;
        SelectedItemPrice = 0;
        SelectedItemStatus = false;
        SelectedItemName = string.Empty;
    }
}
