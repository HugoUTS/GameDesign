using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false; // Track if the player has collected the key

    public void CollectKey()
    {
        hasKey = true; // Set to true when the player collects the key
    }
}