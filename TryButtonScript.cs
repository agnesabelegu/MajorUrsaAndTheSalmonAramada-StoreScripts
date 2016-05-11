using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TryButtonScript : MonoBehaviour
{

    //public variables
    private StoreItemScript ItemToPreview;
    private StoreScript StoreManager;

    //private variables
    private PreviewItemScript PreviewSlot;
    private AudioSource HatSFX;

    void Start()
    {
        PreviewSlot = GameObject.FindGameObjectWithTag("PreviewItem").GetComponent<PreviewItemScript>();
        ItemToPreview = GetComponentInParent<StoreItemScript>();
        StoreManager = GameObject.FindGameObjectWithTag("StoreManager").GetComponent<StoreScript>();
        HatSFX = GetComponent<AudioSource>();
    }

    public void ReplaceSprite()
    {
        PreviewSlot.SelectedItemPrice = ItemToPreview.ItemPrice;
        PreviewSlot.SelectedItemName = ItemToPreview.ItemName;
        PreviewSlot.SelectedHighHealthItem = ItemToPreview.ItemHighHealthSprite;
        PreviewSlot.SelectedMedHealthItem = ItemToPreview.ItemMedHealthSprite;
        PreviewSlot.SelectedLowHealthItem = ItemToPreview.ItemLowHealthSprite;
        PreviewSlot.SelectedItemStatus = ItemToPreview.ItemBought;
        PreviewSlot.SelectedHat = ItemToPreview.ItemImage;

        HatSFX.Play();

        StoreManager.UpdateItemCost(PreviewSlot.SelectedItemPrice, PreviewSlot.SelectedItemStatus);
    }
}
