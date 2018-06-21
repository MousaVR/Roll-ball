using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public float speed;
    public  Text scoreText;
    public Text wintext;
    Rigidbody rb;
    int score;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody >();
        score = 0;
        ShowScore();
        wintext.text  = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(direction * speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            ShowScore();
            if (score >= 12) wintext.text ="You Win";
        }
    }
    void ShowScore()
    {
        scoreText.text = "Score : " + score;
    }
}
