using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    int currentSceneIndex;
    public Text txtCoins;
    private int score = 0;
    public float speed;
    Rigidbody PlayerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.velocity = (movement * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
         if(collision.gameObject.tag == "coins")
        {
            print("a");
            score += 1;
            txtCoins.text = "Coins Collected = " + score;
            Destroy(collision.gameObject);
        }
       
        if (score == 4)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }

        if (collision.gameObject.tag == "hazard")
        {
            SceneManager.LoadScene("GameLose");
        }

      
    }
}
