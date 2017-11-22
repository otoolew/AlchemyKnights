using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionPage : MonoBehaviour {

    public Potion[] pages;

    public Potion currentPotion;
    public int currentPageNumber = 0;
    public Image pageImage;
    public Sprite imageSprite;
    public Text pageName;
    public Text pageUse;
    public Text pagePurpose;
    public Text pageActiveIngredient;
    public Text pageHalfLife;
    public Text pageWarning;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        //pageImage = GetComponentInChildren<Image>();
        currentPotion = pages[currentPageNumber];
    }

    // Update is called once per frame
    void Update()
    {
        currentPotion = pages[currentPageNumber];
        pageImage.sprite = imageSprite;
        ChangePage();
    }
    public void NextPage()
    {
        if (currentPageNumber < pages.Length - 1)
        {
            currentPageNumber++;

        }
    }
    public void PreviousPage()
    {
        if (currentPageNumber > 0)
        {
            currentPageNumber--;
        }
    }
    public void ChangePage()
    {
        imageSprite = currentPotion.itemSprite;
        pageName.text = currentPotion.itemName;
        pageUse.text = "Use: " + currentPotion.potionUse;
        pagePurpose.text = "Purpose: " + currentPotion.potionPurpose;
        pageActiveIngredient.text = "Active Ingredients: " + currentPotion.potionActiveIngredient;
        pageHalfLife.text = "Half Life (Seconds): " + currentPotion.potionHalfLife;
        pageWarning.text = "Warnings: " + currentPotion.potionWarning;
    }
}
