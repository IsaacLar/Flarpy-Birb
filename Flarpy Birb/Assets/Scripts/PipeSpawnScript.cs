using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    //Reference to the pipe game object prefab
    public GameObject pipe;

    public LogicScript logic;

    //Seconds between each pipe being spawned
    public float spawnRate = 3.5f;
    private float timer = 0;

    

    public int heightOffset = 4;
    private float lowestPoint;
    private float highestPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        spawnPipe();

    }

    // Update is called once per frame
    void Update()
    {
        //If timer hasn't passed the respective time between pipes
        if ( timer < spawnRate)
        {   
            //Increment timer
            timer += Time.deltaTime;
        } else
        {   
            //Spawn a pipe
            spawnPipe();
            //Pick a random time to spawn next pipe
            spawnRate = Random.Range(3, 5);
            //Reset timer
            timer = 0;
        }           
    }

    void spawnPipe()
    {
        //Calculate lowest and highest points
        lowestPoint = transform.position.y - heightOffset;
        highestPoint = transform.position.y + heightOffset;

        //Spawn new pipe
        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        
        //Get the pipe move script object
        PipeMoveScript pipeMoveScript = newPipe.GetComponent<PipeMoveScript>();
           
        //If the player is above 25 or on an even score between 10 and 25
        if (logic.playerScore > 25 || (logic.playerScore >= 10 && logic.playerScore % 2 == 0))
        {
            //Make the pipe move up and down
            if (Random.Range(0, 2) *2 -1 > 0)
            {
                pipeMoveScript.vertMove = Random.Range(0.9f, 1.2f);
            } else
            {
                pipeMoveScript.vertMove = Random.Range(-0.9f, -1.2f);
            }
        } 
    }
}
