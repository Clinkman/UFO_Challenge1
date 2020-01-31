using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public GameObject thePlayer;
    public Text countText;
    public Text winText;
    public Text lives;

    private Rigidbody2D rb2d;
    private int count;
    private int count2;
    private int Lv;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        Lv = 3;
        count2 = 0;
        winText.text = "";
        SetCountText();
        SetLives();
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag ("Pickup2"))
        {
            other.gameObject.SetActive(false);
            count2 = count2 + 1;
            SetCountText2();
        }
        if (other.gameObject.CompareTag("RedPickup"))
        {
            other.gameObject.SetActive(false);
            Lv = Lv - 1;
            SetLives();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            thePlayer.transform.position = new Vector4(65, 0, 0);
            SetCountText2();
        }
    }

    void SetLives()
    {
        lives.text = "Lives: " + Lv.ToString();
        if(Lv <= 0)
        {
            winText.text = "You Lose!";
            count = 0;
            count2 = 0;
        }
    }

    void SetCountText2()
    {
        countText.text = "Count: " + count2.ToString();
        if(count2 >= 8)
        {
            winText.text = "You win! Game created by Curtis Marcoux!";
        }
    }
}
