using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public int upwardsVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            myRigidbody.linearVelocity = Vector2.up * upwardsVelocity;
        }
    }
}
