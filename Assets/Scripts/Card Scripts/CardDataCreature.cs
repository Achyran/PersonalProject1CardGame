using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDataCreature : MonoBehaviour
{
    public int cardID;
    public string cardName;
    public int manaCost;
    public int power;
    public int hp;

    //determines whether a character has an enter die or not
    public bool hasEnterDice;

    //The enter die the minion has
    public int[] enterDie;

    public enum cardRarities
    {
        BORING = 0,
        MEH = 1,
        COOL = 2,
        SICK = 3

    }

    public cardRarities rarity = cardRarities.BORING;

    //public Image image;
    


    public bool summoningSickness = true;

    public enum cardState
    {
        DECK = 0,
        HAND = 1,
        FIELD = 2,
        GRAVEYARD = 3
    }

    public cardState location = cardState.HAND;

    [HideInInspector]
    public cardState lingering = cardState.HAND;

    //Remove Summoning Sickness
    public void removeSummoningSickness()
    {
        if (summoningSickness) summoningSickness = false;
    }

    //Die
    void Die()
    {
        if (hp <= 0) location = cardState.GRAVEYARD;
    }



    private void Update()
    {
        lingering = location;
    }
}
