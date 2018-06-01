using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    public Card[] commonLibrary;
    public Card[] epicLibrary;
    public Card[] legendaryLibrary;

    public GameManager gameManager;
    public LerpManager lerpManager;
    public DropCards dropArea;
    public GameObject cardPrefab;

    public List<Card> tempCompleteList = new List<Card>();
    public List<GameObject> tempObjList = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void InstantiateCards()
    {
        tempObjList.Clear();
        for (int i = 0; i < tempCompleteList.Count; i++)
        {
            GameObject tempObject = InstantiateCard(tempCompleteList[i]);
            StartCoroutine(lerpManager.MoveObject(tempObject, lerpManager.startMarker.position, lerpManager.endMarkers[i].position, 1));
            tempObjList.Add(tempObject);
        }
    }

    public void HasDroppedCorrectly(PackHandler pack)
    {
        if (dropArea.onPointer)
        {
            pack.cardPack.AddCards();
        }
    }

    public List<Card> GetCommon(int value)
    {
        List<Card> tempList = new List<Card>();

        for (int i = 0; i < value; i++)
        {
            tempList.Add(commonLibrary[Random.Range(0, commonLibrary.Length)]);
        }
        return tempList;
    }

    public List<Card> GetEpic(int value)
    {
        List<Card> tempList = new List<Card>();

        for(int i = 0; i < value; i++)
        {
            tempList.Add(epicLibrary[Random.Range(0, epicLibrary.Length)]);
        }
        return tempList;
    }

    public List<Card> GetLegendary(int value)
    {
        List<Card> tempList = new List<Card>();

        for (int i = 0; i < value; i++)
        {
            tempList.Add(legendaryLibrary[Random.Range(0, legendaryLibrary.Length)]);
        }
        return tempList;
    }


    GameObject InstantiateCard(Card card)
    {
        GameObject tempObject = Instantiate(cardPrefab);
        tempObject.transform.SetParent(transform);
        tempObject.transform.localScale = new Vector3(90, 90);
        tempObject.GetComponent<CardDisplay>().Initialize(card);

        return tempObject;
    }
}
