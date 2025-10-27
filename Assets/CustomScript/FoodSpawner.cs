using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // --- Drag your assets into these slots in the Inspector ---
    public GameObject foodPrefab1;
    public GameObject foodPrefab2;
    public Transform spawnPoint;
    // ---------------------------------------------------------

    // This will keep track of the currently active food object
    private GameObject currentFoodObject;

    // A helper function to delete all food objects before spawning a new one
    private void DeleteCurrentFood()
    {
        // Find all game objects with the tag "Food"
        GameObject[] allFoodObjects = GameObject.FindGameObjectsWithTag("Food");

        // Loop through and destroy each one
        foreach (GameObject food in allFoodObjects)
        {
            Destroy(food);
        }
    }


    // This function will be called by your first button
    public void SpawnFood1()
    {
        DeleteCurrentFood();
        currentFoodObject = Instantiate(foodPrefab1, spawnPoint.position, spawnPoint.rotation);
    }

    // This function will be called by your second button
    public void SpawnFood2()
    {
        DeleteCurrentFood();
        currentFoodObject = Instantiate(foodPrefab2, spawnPoint.position, spawnPoint.rotation);
    }
}