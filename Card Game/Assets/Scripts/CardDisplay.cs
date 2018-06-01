using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Collection collection;

    public Card card;

    public Button button;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;
    public Image rarityImage;

    public Text manaText;
    public Text attackText;
    public Text healthText;
    

    public void SellCard()
    {
        collection.manager.money += Random.Range(10, 40);
        collection.manager.cardLibrary.Remove(card);

        Destroy(gameObject);
    }

    public void CardSell()
    {
        collection.manager.saver.SellCard(card);
    }

    public void Initialize (Card tempCard) {

        card = tempCard;

        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;
        rarityImage.sprite = card.rarity;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
		
	}
}
