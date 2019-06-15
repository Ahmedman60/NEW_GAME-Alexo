using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    private Rigidbody2D reg;

    public float speed = 10f;

    public int point = 0;
    public Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        reg = GetComponent<Rigidbody2D>();
        float x = 0f;
        float y = 0f;
        if (Input.GetKey("right"))
        {
            x = speed;
        }
        if (Input.GetKey("left"))
        {
            x = -speed;
        }
        if (Input.GetKey("up"))
        {
            y = speed+5;
        }
        if (Input.GetKey("down"))
        {
            y = -speed;
        }

        reg.AddForce(new Vector2(x, y));
    }
    public AudioClip myaucdio;

    //the thing you will hit
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag=="coin")
        {
          
            point++;
            Destroy(col.gameObject);
       
            AudioSource.PlayClipAtPoint(myaucdio, col.transform.position);
            mytext.text = "Score " + point;
           Debug.Log("score" + point);

        }
    }
}
