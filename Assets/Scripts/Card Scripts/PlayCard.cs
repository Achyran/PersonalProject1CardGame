using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    public SelectCard selectCard;
    public CardDataCreature cardData;
    private void OnMouseDown()
    {
        int tempMana = 8;

        if (tempMana >= cardData.manaCost && cardData.location == CardDataCreature.cardState.HAND && !TargetingSystem.findTarget)
        {
            tempMana -= cardData.manaCost;
            cardData.location = CardDataCreature.cardState.FIELD;
            if (cardData.hasEnterDice) ReplacementDie(); 


            Debug.Log(cardData.name + " Card Played!");
        }

        else if (cardData.location == CardDataCreature.cardState.HAND && TargetingSystem.findTarget)
        {
            Debug.Log("You can't play a card yet, card interaction is on stack");
        }
    }


    public void ReplacementDie() 
    {
        TargetingSystem.setTagTarget("Die");
        TargetingSystem.selectedCard = cardData;
    }
}
