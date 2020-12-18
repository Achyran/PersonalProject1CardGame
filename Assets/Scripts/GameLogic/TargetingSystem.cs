using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    //Get layer that needs to be targeted
    public static string targetTag;
    public static CardDataCreature selectedCard;

    //Make sure something needs to be targeted
    public static bool findTarget = false;

    //=================================================================================
    //                              >  Set Tag of Target  <
    //=================================================================================
    //Set the tag of which needs to be found
    public static void setTagTarget(string tagName)
    {
        if (!findTarget)
        {
            targetTag = tagName;
            findTarget = true;
            Debug.Log("You need to target a " + tagName);
        }
        else
        {
            Debug.Log("Previous Interaction hasn't been resolved yet");
        }
    }


    //=================================================================================
    //                              >  Resolve Target  <
    //=================================================================================
    //Resolve after everything is done
    public static void resolveTarget()
    {
        targetTag = "";
        findTarget = false;
        selectedCard = null;
        Debug.Log("Target Resolved");
    }

}
