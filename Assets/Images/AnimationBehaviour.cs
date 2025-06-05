using UnityEngine;

public class AnimationBehaviour : MonoBehaviour

{
    private Animator anim;

    private float timer;
    private float timerThreshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        timerThreshold = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerThreshold) {
            timer = 0f;
            timerThreshold = Random.Range(1f, 3f);
            
            if (anim.GetBool("IsChewing") == true) {
                anim.SetBool("IsChewing", false);
            }
            else {
                anim.SetBool("IsChewing", true);
            }
        }
    }
}
