using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionManager : MonoBehaviour
{
    // Define a class to represent a recipe
    [Serializable]
    public class Recipe
    {
        public string potionName; // Name of the potion
        public Fraction[] ingredients; // Array of ingredients (fractions)
    }

    // Define a class to represent a fraction
    [Serializable]
    public class Fraction
    {
        public int numerator; // Numerator
        public int denominator; // Denominator
        public Texture2D ingredientImage; // Image for the ingredient (optional)
        public RawImage IngredientBoard;
    }

    // Array of predefined recipes (you can add more)
    public Recipe[] recipes;

    // Reference to the TextMeshProUGUI component for displaying the recipe
    public TextMeshProUGUI recipeTextMeshProUGUI;

    public Recipe currentRecipe; // Currently active recipe
    private int lastSelectedRecipeIndex = -1; // Index of the last selected recipe

    private void Start()
    {
        // Example usage: Start with a random recipe
        SetRandomRecipe();
    }

    // Set a random recipe as the current one, ensuring it's different from the last one
    private void SetRandomRecipe()
    {
        int randomIndex;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, recipes.Length);
        } while (randomIndex == lastSelectedRecipeIndex); // Repeat until a different recipe is selected

        lastSelectedRecipeIndex = randomIndex;
        currentRecipe = recipes[randomIndex];

        // Debug log the selected recipe's texture names
        Debug.Log("Selected Recipe:");
        foreach (var ingredient in currentRecipe.ingredients)
        {
            Debug.Log(ingredient.ingredientImage.name);
        }

        UpdateRecipeText();
    }

    // Update the recipe text on the TextMeshPro
    private void UpdateRecipeText()
    {
        string recipeText = $"{currentRecipe.potionName}\nIngredienser:\n";
        foreach (var ingredient in currentRecipe.ingredients)
        {
            recipeText += $"{ingredient.numerator}/{ingredient.denominator}           ";
            if (ingredient.ingredientImage != null)
            {
                ingredient.IngredientBoard.texture = ingredient.ingredientImage;
            }
        }

        // Set the recipe text on the TextMeshProUGUI
        recipeTextMeshProUGUI.text = recipeText;
    }

    public void OnPotionCompleted()
    {
        SetRandomRecipe(); // Get a new random recipe
    }

}

