using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Task_Cauldron_2 : MonoBehaviour
{
    public Collider endZone;
    public float secondsSinceCompletion, timer;
    public PotionManager Potion;

    private Dictionary<string, int> ingredientCounts = new Dictionary<string, int>();
    private int addedIngredientsCount = 0; // Count of ingredients added to the recipe
    private int recipeNumeratorSum; // Sum of numerators in the current recipe

    public Image radialUI;
    private float fill;
    public AudioSource newPotion;
    public AudioSource correct;
    public AudioSource incorrect;

    void Start()
    {
        //Debug.Log("Cauldron is started");
        radialUI.fillAmount = 0;
        ingredientCounts.Clear();
    }

    private void OnTriggerEnter(Collider IngObj)
    {

        Debug.Log("This is the " + IngObj.gameObject.name);


        // Check if the ingredient name matches any texture names in the current recipe
        //Debug.Log("Checking for matching ingredients!");


        // Check if the added ingredients count matches the recipe requirement
        int recipeNumeratorSum = 0;
        foreach (var ingredient in Potion.currentRecipe.ingredients)
        {
            recipeNumeratorSum += ingredient.numerator;
        }

        switch (recipeNumeratorSum)
        {
            case 3:
                fill = 0.34f;
                break;
            case 4:
                fill = 0.25f;
                break;
            case 5:
                fill = 0.2f;
                break;
            case 6:
                fill = 0.17f;
                break;
            case 7:
                fill = 0.15f;
                break;
            case 8:
                fill = 0.125f;
                break;
        }

        string ingredientName = IngObj.gameObject.name;

        // Increment the count for the added ingredient
        if (ingredientCounts.ContainsKey(ingredientName))
        {
            ingredientCounts[ingredientName]++;
        }
        else
        {
            ingredientCounts.Add(ingredientName, 1);
        }


        foreach (var ingredient in Potion.currentRecipe.ingredients)
        {
            if (ingredientName == ingredient.ingredientImage.name)
            {
                if (ingredientCounts.TryGetValue(ingredientName, out int addedCount))
                {
                    if (addedCount <= ingredient.numerator)
                    {
                        addedIngredientsCount++; // Increment count for matched ingredient
                        radialUI.fillAmount += fill;
                        incorrect.Stop();
                        correct.Play();
                        Debug.Log("Addedcount is at" + addedCount);
                        break;
                    }
                    else
                    {
                        incorrect.Play();
                        Debug.Log("Incorrect ingredient added");
                    }
                }

            }
            else
            {
                incorrect.Play();
                Debug.Log("Incorrect ingredient added");
            }
        }



        // Debug log added ingredients count
        Debug.Log("Added Ingredients Count: " + addedIngredientsCount);
        // Debug log recipe numerator sum
        Debug.Log("Recipe Numerator Sum: " + recipeNumeratorSum);

        if (addedIngredientsCount >= recipeNumeratorSum)
        {
            // Call OnPotionCompleted method if requirements are met

            Potion.OnPotionCompleted();
            newPotion.Play();
            addedIngredientsCount = 0;
            radialUI.fillAmount = 0;
            ingredientCounts.Clear();


        }

    }
}

