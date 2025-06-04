using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0){
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - (speed/60);
            transform.position = newPosition;
        }
        else {
        if (Input.GetAxis("Horizontal") > 0){
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + (speed/60);
            transform.position = newPosition;
        }

        if (ball != null) {
            Vector3 ballOffset = new Vector3(0f, -1f, 0f);
            ball.transform.position = transform.position + ballOffset;
            ball.GetComponent<PolygonCollider2D>().enabled = false;
            ball.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ball.GetComponent<PolygonCollider2D>().enabled = true;
            ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            ball = null;
        }
        }
    }
}
