using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreScript : MonoBehaviour
{
    //public variables
    public GameObject TotalCash;
    public GameObject ItemCost;
    public GameObject ScoreObject;
    public GameObject StoreScreen;
    public GameObject ConfirmScreen;
    public GameObject InsufficientScreen;
    public Image ConfirmItem;
    public GameObject BuyButton;
    public GameObject PreviewSlot;
    public GameObject PlayerObject;

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
