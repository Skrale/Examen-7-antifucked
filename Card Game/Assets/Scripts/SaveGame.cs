using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public int ID;
    public string name;
    public int cardAmount;

    public CardData(Card card)
    {
        name = card.name;
        ID = card.cardId;
        cardAmount = 1;
    }
}

[System.Serializable]
public class SaveGame
{
    public List<CardData> data;
    public int gold;

    public SaveGame(List<CardData> somethingData, int goldBanaan)
    {
        data = somethingData;
        gold = goldBanaan;
    }
}