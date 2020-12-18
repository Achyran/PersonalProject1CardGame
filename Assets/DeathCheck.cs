using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    
    public CardDataCreature data;
    
    //Make sure the creature dies
    void Update()
    {
        if (data.hp <= 0) { data.location = CardDataCreature.cardState.GRAVEYARD; }
    }
}
