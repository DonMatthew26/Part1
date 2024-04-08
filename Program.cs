using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe App!");

            Recipe recipe = new Recipe();

            while (true)
            {
                Console.Write("\nEnter 'new' to enter a new recipe, 'reset' to clear current recipe, or 'exit' to quit: ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    break;
                }
                else if (input == "new")
                {
                    recipe.ResetRecipe();
                    Console.WriteLine("\nEnter recipe details:");
                    recipe.EnterRecipeDetails();
                }
                else if (input == "reset")
                {
                    recipe.ResetRecipe();
                    Console.WriteLine("\nRecipe data cleared.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }

    class Recipe
    {
        private List<Ingredient> ingredients;
        private List<Ingredient> originalIngredients;
        private List<string> steps;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            originalIngredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Quantity for {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                AddIngredient(name, quantity, unit);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string description = Console.ReadLine();
                AddStep(description);
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalIngredients[i].Quantity;
            }
        }

        public void ResetRecipe()
        {
            ingredients.Clear();
            originalIngredients.Clear();
            steps.Clear();
        }

        private void AddIngredient(string name, double quantity, string unit)
        {
            Ingredient ingredient = new Ingredient(name, quantity, unit);
            ingredients.Add(ingredient);
            originalIngredients.Add(new Ingredient(name, quantity, unit)); // Store original quantity
        }

        private void AddStep(string description)
        {
            steps.Add(description);
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
