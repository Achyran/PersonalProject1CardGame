using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public CardDataCreature card;
    public bool isAttacking = false;

    //Activate creature
    private void OnMouseDown()
    {

        if (card.location == CardDataCreature.cardState.FIELD)
        {
            //Target Card that will be attacked
            if (TargetingSystem.targetTag == "Card")
            {
                if (TargetingSystem.selectedCard != card)
                {
                    AttackCreature(TargetingSystem.selectedCard);
                    Debug.Log(TargetingSystem.selectedCard.name + " attacks " + card.name);
                    TargetingSystem.resolveTarget();
                    

                }
                else
                {
                    TargetingSystem.resolveTarget();
                    Debug.Log(card.name + " cancelled its attack.");
                }
            }

            //Target Card that will attack
            else if (!card.summoningSickness)
            {
                TargetingSystem.setTagTarget("Card");
                TargetingSystem.selectedCard = card;

            }
        }
    }

    //Attack
    void AttackCreature(CardDataCreature Other)
    {
        Other.hp -= card.power;
        card.hp -= Other.power;
        Other.summoningSickness = true;
    }

}
