using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed;
    
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
        }
    }
}
