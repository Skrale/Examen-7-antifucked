using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PackTypes
{
    Standard,
    Special,
    Premium
}

public class CardPack : MonoBehaviour
{
    public int cardAmount;
    public int cardPrice;
    public PackManager packManager;
    public PackHandler packHandler;
    public Savior saver;
    //public Collection collection;
    public Text amountText;
    public Button buyButton;
    public Button backButton;
    public PackTypes currentPackType;
    public bool hasDropped = false;


    void Start()
    {

    }

    void Update()
    {
        amountText.text = cardAmount.ToString();
        buyButton.interactable = (packManager.gameManager.money >= cardPrice) ? true : false;
        CheckCardAvailability();

        if (hasDropped)
        {
            //DoLerp();
        }
    }

    public void AddCards()
    {
        switch (currentPackType)
        {
            case PackTypes.Premium:
                {
                    List<Card> tempEpicList = new List<Card>();
                    tempEpicList = packManager.GetEpic(2);
                    foreach (Card card in tempEpicList) { packManager.tempCompleteList.Add(card); }
                    packManager.tempCompleteList.Add(packManager.GetLegendary(1)[0]);
                }
                break;
            case PackTypes.Special:
                {
                    List<Card> tempEpicList = new List<Card>();
                    tempEpicList = packManager.GetEpic(2);
                    foreach (Card card in tempEpicList) { packManager.tempCompleteList.Add(card); }
                    packManager.tempCompleteList.Add(packManager.GetCommon(1)[0]);
                }
                break;
            case PackTypes.Standard:
                {
                    List<Card> tempCommonList = new List<Card>();
                    tempCommonList = packManager.GetCommon(2);
                    foreach (Card card in tempCommonList) { packManager.tempCompleteList.Add(card); }
                    packManager.tempCompleteList.Add(packManager.GetEpic(1)[0]);
                }
                break;
            default:
                break;
        }
        packManager.InstantiateCards();
        backButton.interactable = false;
        hasDropped = true;
        cardAmount--;
    }

    public void AddToCollection()
    {
        foreach (Card card in packManager.tempCompleteList)
        {
            packManager.gameManager.cardLibrary.Add(card);
        }
        packHandler.canDrag = true;
        backButton.interactable = true;
        packManager.tempCompleteList.Clear();
        packManager.StopAllCoroutines();
        
        foreach (GameObject tempObjectos in packManager.tempObjList)
        {
            Destroy(tempObjectos);
        }
        saver.SaveGame();
    }

    public void Buy()
    {
        cardAmount++;
        packManager.gameManager.money -= cardPrice;
    }

    public void CheckCardAvailability()
    {
        packHandler.GetComponent<PackHandler>().enabled = (cardAmount > 0) ? true : false;
    }
}
