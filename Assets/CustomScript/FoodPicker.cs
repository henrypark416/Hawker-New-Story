using UnityEngine;

public class FoodPicker : MonoBehaviour
{
    [Tooltip("Where the food particle should appear on the utensil (e.g., spoon tip).")]
    public Transform particleAttachPoint;

    private GameObject currentParticle = null;

    private void OnTriggerEnter(Collider other)
    {
        // Prevent double-spawning
        if (currentParticle != null) return;
        // Only react to food
        if (!other.CompareTag("Food")) return;

        // Find a FoodIdentity on the collided object or its parent
        FoodIdentity food = other.GetComponentInParent<FoodIdentity>();
        if (food == null || food.particlePrefab == null) return;

        // Spawn and attach the correct particle
        currentParticle = Instantiate(food.particlePrefab,
                                      particleAttachPoint.position,
                                      particleAttachPoint.rotation);
        currentParticle.transform.SetParent(particleAttachPoint, worldPositionStays: true);
    }

    public void DestroyCurrentParticle()
    {
        if (currentParticle != null)
        {
            Destroy(currentParticle);
            currentParticle = null;
        }
    }
}
