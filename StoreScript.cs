using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreScript : MonoBehaviour
{
    //public variables
    public GameObject TotalCash;
    public GameObject ItemCost;
    public GameObject ScoreObject; //keeps track of player's score
    public GameObject StoreScreen; //holds a reference to the Store gameobject.
    public GameObject ConfirmScreen; //holds a reference to the Confirm panel
    public GameObject InsufficientScreen; //holds a reference to the Insufficient Funds panel
    public Image ConfirmItem;
    public GameObject BuyButton;
    public GameObject PreviewSlot; //Position where the player gets to see the item before buying
    public GameObject PlayerObject; //reference to the player object

    //Game audio
    public AudioSource PrivateSFX;
    public AudioClip[] GreetingSFXS;
    public AudioClip[] GoodbyeSFXS;
    public AudioClip[] InsufficientSFXS;

    //Array of store items
    public StoreItemScript[] StoreItems;

    public void UpdateTotalCash()
    {
        TotalCash.GetComponent<Text>().text = "Total Cash: \nBearBuck$" + ScoreObject.GetComponent<ScoreScript>().GetScore();
    }
    
    //If item is already bought, don't allow player to buy it twice. 
    //If not bought, display item cost.
    public void UpdateItemCost(int price, bool status)
    {
        UpdateTotalCash();
        if (!status)
        {
            ItemCost.GetComponent<Text>().text = "Item Cost: \nBearBuck$" + price;
            BuyButton.GetComponentInChildren<Text>().text = "BUY!";
        }
        else
        {
            ItemCost.GetComponent<Text>().text = "Item already bought!";
            BuyButton.GetComponentInChildren<Text>().text = "EQUIP!";
        }
    }
    
    //Check to see if any of the items in the store have already been bought.
    public void UpdateItemStatus(string Name)
    {
        foreach (StoreItemScript item in StoreItems)
        {
            if (item.ItemName == Name)
            {
                item.ItemBought = true;
                item.UpdateItemStatus();
            }
        }
    }

    //Displaying and closing Store
    public void DisplayStore()
    {
        //Enable Store Screen and Pause the game
        Time.timeScale = 0;
        StoreScreen.SetActive(true);
        ScoreObject.SetActive(false);
        PreviewSlot.GetComponent<PreviewItemScript>().UpdatePreviewItem();
        PlayerObject.GetComponent<PlayerShootScript>().isInStore = true;
        UpdateTotalCash();

        PrivateSFX.clip = GreetingSFXS[Random.Range(0, GreetingSFXS.Length)];
        PrivateSFX.Play();
    }

    public void CloseStore()
    {
        Time.timeScale = 1;
        StoreScreen.SetActive(false);
        ScoreObject.SetActive(true);
        PlayerObject.GetComponent<PlayerShootScript>().isInStore = false;
        PreviewSlot.GetComponent<PreviewItemScript>().Reset();

        PrivateSFX.clip = GoodbyeSFXS[Random.Range(0, GoodbyeSFXS.Length)];
        PrivateSFX.Play();
    }

    //Displaying and closing confirmation box
    public void DisplayConfirmation(Image itemConfirm)
    {
        if (itemConfirm == null)
            return;

        ConfirmItem.sprite = itemConfirm.sprite;
        ConfirmScreen.SetActive(true);
    }

    public void CloseConfirmation()
    {
        ConfirmScreen.SetActive(false);
    }

    //Displaying and closing Insufficient fund box
    public void DisplayInsufficientFunds()
    {
        InsufficientScreen.SetActive(true);
        PrivateSFX.clip = InsufficientSFXS[Random.Range(0, InsufficientSFXS.Length)];
        PrivateSFX.Play();
    }

    public void CloseInsufficientFunds()
    {
        InsufficientScreen.SetActive(false);
    }
}
