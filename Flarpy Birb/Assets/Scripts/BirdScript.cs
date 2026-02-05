using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;

    public int upwardsVelocity;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input using the new Input System Package
        var keyboard = Keyboard.current;

        if (keyboard.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * upwardsVelocity;
        }
    }

    private void killBird()
    {
        birdIsAlive = false;
        logic.gameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            killBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        killBird();
    }
}
