using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

public class Savior : MonoBehaviour
{
    public GameManager manager;

    private string saveFile = "/skrale.aap";

    public void SaveGame()
    {
        try
        {
            SaveGame save = CreateGameSave();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = File.Create(Application.persistentDataPath + saveFile))
            {
                formatter.Serialize(file, JsonUtility.ToJson(new SaveGame(ConvertData(manager.cardLibrary), manager.money)));
            }
        }

        catch(Exception e)
        {
            Debug.LogError("braadvlees" + e.Message);
        }
    }

    public void SellCard(Card card)
    {
        if (manager.cardLibrary.FindAll(x => x.cardId == card.cardId).Count == 0) return;

        manager.cardLibrary.Remove(manager.cardLibrary.Find(x => x.cardId == card.cardId));
        SaveGame();
    }

    public void LoadGame()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFile, FileMode.Open);
            SaveGame save = JsonUtility.FromJson<SaveGame>((string)formatter.Deserialize(file));
            file.Close();
            manager.cardLibrary = FromCardData(save.data);
            manager.money = save.gold;
        }

        catch(Exception e)
        {
            Debug.LogError("blubber" + e.Message);
        }
    }

    private SaveGame CreateGameSave()
    {
        return new SaveGame(ConvertData(manager.cardLibrary), manager.money);
    }

    private List<CardData> ConvertData(List<Card> kaartjes)
    {
        List<CardData> newCards = new List<CardData>();

        foreach (Card card in kaartjes)
        {
            if (newCards.Exists(x => x.ID == card.cardId))
            {
                newCards.Find(x => x.ID == card.cardId).cardAmount++;
            }
            else
                newCards.Add(new CardData(card));
        }

        return newCards;
    }

    private List<Card> FromCardData(List<CardData> cardDatas)
    {
        List<Card> datas = new List<Card>();
        foreach (var card in cardDatas)
        {
            for(int index = 0; index < card.cardAmount; index++)
            {
                datas.Add(manager.allCards.Find(x => x.cardId == card.ID) ?? manager.allCards.Find(x => x.name == card.name));
            }
        }
        return datas;
    }
}
