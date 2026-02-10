using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    public GameObject topPipe;
    public GameObject bottomPipe;
    
    //Minimum gap between pipes is 44
    private int topPipeMin = 10;
    private int topPipeMax = 34;

    private int bottomPipeMin = -34;
    private int bottomPipeMax;

    //The minimum and maximum gaps that are possible between the two pipes
    private int minGap = 44;
    private float maxGap;

    public float vertMove = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int topPipePos = Random.Range(topPipeMin, topPipeMax);
        topPipe.transform.position = new Vector3(40, topPipePos, 0);
        bottomPipeMax = topPipePos - minGap;
        int bottomPipePos = Random.Range(bottomPipeMin, bottomPipeMax);
        bottomPipe.transform.position = new Vector3(40, bottomPipePos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, vertMove, 0) * moveSpeed * Time.deltaTime;

        if (topPipe.transform.position.y > 34 || bottomPipe.transform.position.y < -34)
        {
            vertMove = -vertMove;
        }

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
