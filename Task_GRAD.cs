using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Task_GRAD : MonoBehaviour
{
    public Collider beginZone, endZone;
    public float secondsInEndZoneToComplete, timer;
    private Vector3 startPos;
    public GameObject Ingredient;
    //public PotionManager Potion;

    //private int addedIngredientsCount = 0; // Count of ingredients added to the recipe
    //private int recipeNumeratorSum; // Sum of numerators in the current recipe

    private void Start()
    {
        startPos = Ingredient.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cauldron")
        {
            if (other != endZone) return;

            timer += Time.deltaTime;



            if (timer >= secondsInEndZoneToComplete)
            {
                Ingredient.transform.position = startPos;
                timer = 0;
            }
        }


    }
}



