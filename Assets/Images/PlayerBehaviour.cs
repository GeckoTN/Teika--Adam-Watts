using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject[] balls;
    public GameObject currentBall;
    public GameObject gameOver;
    
    public int[] points;
    public int score;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    public void UpdateScore(int ballType) {
        score = score + points[ballType];
        scoreText.text = "Score: " + score;
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
        }

        if (currentBall != null) {
            Vector3 ballOffset = new Vector3(0f, -1f, 0f);
            currentBall.transform.position = transform.position + ballOffset;
            currentBall.GetComponent<Collider2D>().enabled = false;
            currentBall.GetComponent<Rigidbody2D>().gravityScale = 0f;
        } else {
            int index = Random.Range(0,4);
            currentBall = Instantiate(balls[index], transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            currentBall.GetComponent<Collider2D>().enabled = true;
            currentBall.GetComponent<Rigidbody2D>().gravityScale = 1f;
            currentBall = null;
        }
        
    }

    public void GameOver() {
        gameOver.SetActive(true);
    }
}
