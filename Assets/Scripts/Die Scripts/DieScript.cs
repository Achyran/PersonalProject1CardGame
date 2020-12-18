using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    //Amount of faces a die has
    int faceCount = 4;

    //The faces of a die (0/1/1/2 is standard)
    int[] faces = {0, 1, 1, 2};

    //Value a dice will roll
    int rollValue;

    //=================================================================================
    //                                   >  Roll Script  <
    //=================================================================================
    //Rolls a random face of a die
    public int Roll()
    {
        int roll = Random.Range(0, faceCount);
        rollValue = faces[roll];

        return rollValue;
    }

    //=================================================================================
    //                                   >  Replace Die  <
    //=================================================================================
    //Replaces the faces of a die with new faces
    public void ReplaceDice(int[] newFaces)
    {
        for (int i = 0; i < newFaces.Length; i++)
        {
            faces[i] = newFaces[i];
        }
    }


    //Target Die (Replacement effect)
    private void OnMouseDown()
    {
        if (TargetingSystem.targetTag == "Die")
        {
            ReplaceDice(TargetingSystem.selectedCard.enterDie);
            TargetingSystem.resolveTarget();
        }
    }
}
