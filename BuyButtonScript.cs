using UnityEngine;
using System.Collections;

public class BuyButtonScript : MonoBehaviour
{
    //ADD PLAYER PREFAB TO REPLACE THE SPRITE OF

    //public variables
    public ScoreScript Score;
    public StoreScript Store;
    public AudioSource BoughtSFX;
    public AudioSource PrivateSFX;
    public AudioClip[] PrivateSFXS;

    //private variables
    private PreviewItemScript PreviewItem;
    private GameObject PlayerObject;

    void Awake()
    {
        PreviewItem = GameObject.FindGameObjectWithTag("PreviewItem").GetComponent<PreviewItemScript>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void Confirm()
    {
        //check if item is already bought
        if (!PreviewItem.SelectedItemStatus)
        {
            if (Score.GetScore() >= PreviewItem.SelectedItemPrice)
            {
                Store.DisplayConfirmation(PreviewItem.SelectedHat);
            }
            else
            {
                Store.DisplayInsufficientFunds();
            }
        }
        //if already bought, then simply replace the sprite.
        else
        {
            PlayerHealthScript playerHealth = PlayerObject.GetComponentInChildren<PlayerHealthScript>();

            playerHealth.highHealthSprite = PreviewItem.SelectedHighHealthItem;
            playerHealth.mediumHealthSprite = PreviewItem.SelectedMedHealthItem;
            playerHealth.lowHealthSprite = PreviewItem.SelectedLowHealthItem;

            playerHealth.ResetHealth();

            PlayerObject.transform.FindChild("Ship").GetComponent<SpriteRenderer>().sprite = playerHealth.highHealthSprite;
        }
    }

    public void Buy()
    {
        Score.SubstractScore(PreviewItem.SelectedItemPrice);

        PlayerHealthScript playerHealth = PlayerObject.GetComponentInChildren<PlayerHealthScript>();

        playerHealth.highHealthSprite = PreviewItem.SelectedHighHealthItem;
        playerHealth.mediumHealthSprite = PreviewItem.SelectedMedHealthItem;
        playerHealth.lowHealthSprite = PreviewItem.SelectedLowHealthItem;

        playerHealth.ResetHealth();

        PlayerObject.transform.FindChild("Ship").GetComponent<SpriteRenderer>().sprite = playerHealth.highHealthSprite;

        Store.UpdateTotalCash();
        Store.UpdateItemStatus(PreviewItem.SelectedItemName);

        BoughtSFX.Play();

        PrivateSFX.clip = PrivateSFXS[Random.Range(0, PrivateSFXS.Length)];
        PrivateSFX.Play();

        Store.CloseConfirmation();
    }
}
