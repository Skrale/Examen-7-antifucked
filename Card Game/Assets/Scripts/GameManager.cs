using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public AudioSource sellCardSound;
    public AudioSource easterEggSound;
    public AudioSource buttonPressSound;
    public AudioSource music;

    public List<Card> cardLibrary = new List<Card>();
    public List<Card> deckLibrary = new List<Card>();
    public List<Card> allCards = new List<Card>();

    public int money;
    public Text moneyText;
    public Collection collection;
    public Savior saver;

    void Start()
    {
        saver.LoadGame();
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void ButtonSound()
    {
        buttonPressSound.Play();
    }

    public void EasterEgg()
    {
        music.Stop();
        easterEggSound.Play();
    }

    public void SellCardSound()
    {
        sellCardSound.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
