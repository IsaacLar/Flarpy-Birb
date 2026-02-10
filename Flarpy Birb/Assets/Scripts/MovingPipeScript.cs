using UnityEngine;

public class MovingPipeScript : MonoBehaviour
{
    public GameObject pipe;

    public GameObject topPipe;
    public GameObject bottomPipe;

    private int direction = 1;

    private int speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        pipe.transform.position += new Vector3(0, speed, 0) * Time.deltaTime * direction;
        
    }
}
