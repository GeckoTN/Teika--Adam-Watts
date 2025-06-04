using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        string tag = collision.gameObject.tag;
        Debug.Log("Ball entered trigger " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("top")) {
            Debug.Log("Game Over Timer started at " + timeStart);
            timeStart = Time.time;
        }
            
    }

    public void OnTriggerStay2D(Collider2D collision) {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Top")) {
            timeThusFar = Time.time - timeStart;
            Debug.Log("Game Over Timer at " + timeThusFar);
            if (timeThusFar >= timeout) {
                Debug.Log("Game Over!");
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().GameOver();
        }
        
        }
    }
}
