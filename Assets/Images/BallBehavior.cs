using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;

    public GameObject[] balls;
    public int ballType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time;
        balls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().balls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            GameObject otherObject = collision.gameObject;
            int otherObjectType = otherObject.GetComponent<BallBehavior>().ballType;
            Debug.Log("Collided with " + otherObjectType);

            if (ballType == otherObjectType && ballType != 10) {
                if (transform.position.x > otherObject.transform.position.x || (transform.position.y > otherObject.transform.position.y && transform.position.x == otherObject.transform.position.x)) {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().UpdateScore(ballType);
                    GameObject newBall =
                        Instantiate(balls[ballType+1], Vector3.Lerp(transform.position, otherObject.transform.position, 0.5f),Quaternion.identity);
                    newBall.GetComponent<Collider2D>().enabled = true;
                    newBall.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    Destroy(otherObject);
                    Destroy(gameObject);
                }
            }
        }
        

        
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
