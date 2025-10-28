using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // --- Assign scene objects in the Inspector ---
    public GameObject food1;          // The actual scene instance of Food 1
    public GameObject food2;          // The actual scene instance of Food 2
    public Transform spawnPoint;      // Where the chosen food should appear
    public Transform hiddenPoint;     // Off-screen/hidden parking spot for both foods
    // --------------------------------------------

    private void Start()
    {
        // On play, park both foods at the hidden point
        ParkBoth();
    }

    // Button: bring Food 1
    public void SpawnFood1()
    {
        ParkBoth();                 // first, reset/park both
        Teleport(food1, spawnPoint);// then move the chosen one to spawn
    }

    // Button: bring Food 2
    public void SpawnFood2()
    {
        ParkBoth();                 // first, reset/park both
        Teleport(food2, spawnPoint);// then move the chosen one to spawn
    }

    // ---- Helpers ----

    // Move both foods to the hidden point and zero out their physics
    private void ParkBoth()
    {
        Teleport(food1, hiddenPoint);
        Teleport(food2, hiddenPoint);
    }

    // Teleport an object: set pos/rot and clear velocities on any rigidbodies
    private void Teleport(GameObject go, Transform target)
    {
        if (go == null || target == null) return;

        // set transform
        go.transform.SetPositionAndRotation(target.position, target.rotation);

        // reset physics on the object & its children (plates/ingredients, etc.)
        var bodies = go.GetComponentsInChildren<Rigidbody>(includeInactive: true);
        foreach (var rb in bodies)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // Optional: briefly sleep to avoid immediate jiggle on contact
            rb.Sleep();
        }
    }
}
