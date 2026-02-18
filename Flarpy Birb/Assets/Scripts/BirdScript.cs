using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    [HideInInspector]
    public LogicScript logic;
    public Globalscript Global;


    public AudioSource birdFlap;
    public AudioSource birdDie;

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

        if (keyboard.spaceKey.wasPressedThisFrame && birdIsAlive && !Global.isPaused)
        {
            myRigidbody.linearVelocity = Vector2.up * upwardsVelocity;
            birdFlap.Play();
        }
    }

    private void killBird()
    {
        birdIsAlive = false;
        birdDie.Play();
        logic.gameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && birdIsAlive)
        {
            killBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            killBird();
        }
    }
}
