using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoveCharFeto : MonoBehaviour
{
    // Start is called before the first frame update
    public static int CurrentLevel = 1;
    private Rigidbody2D rb;
    private Animator anim;
    public float movespeed;
    private float Dirx;
    private bool facingright = true;  //help to make the char faceing to where it go right or left
    private Vector3 localscale;

    //Modification add by me in 10/5/2019 to make allow jump in wall
    bool jumpallowed, walljumpallowed;

    public static int point = 0;
    public Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localscale = transform.localScale; //the current scale of the player
        movespeed = 7f;
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //محطوطين كده عشان عندى 2 ليفل لو عندى اكتر احطهم بى الindex of the level
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            CurrentLevel = 0;
        }
        else
        {
            CurrentLevel = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
         mytext.text = "The Heights Score Is  " + point;
        }
        
        Debug.Log(SceneManager.GetActiveScene().name.ToString() + SceneManager.GetActiveScene().buildIndex.ToString());
        //1-for walking
        //get the left or right buttom click and  mutliple by speed and set it to the xdirextion
        Dirx = Input.GetAxis("Horizontal") * movespeed;
        //Modification add by me in 10/5/2019 to make allow jump in wall
        //fraction matrial help to slowly down the char when it collusion with the wall
        //2-for jumping
        if(rb.velocity.y == 0 || walljumpallowed)
            jumpallowed = true;
        else
            jumpallowed = false;
        if (Input.GetButtonDown("Jump") && jumpallowed)
        {
            rb.AddForce(Vector2.up * 700f);
        }

        if (Mathf.Abs(Dirx) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        ////////
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (rb.velocity.y > 0)
        {
            anim.SetBool("IsJumping", true);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("IsFalling", true);
            anim.SetBool("IsJumping", false);
        }

    }
    //so char can move to left or right
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Dirx, rb.velocity.y);
    }
    private void LateUpdate()
    {
        if (Dirx > 0)
        {
            facingright = true;
        }
        else if (Dirx < 0)
        {
            facingright = false;
        }
        if ((facingright) && (localscale.x < 0) || (!facingright) && (localscale.x > 0))
        {
            localscale.x *= -1;
        }
        transform.localScale = localscale;

    }
    public AudioClip myaucdio;

    void OnCollisionEnter2D(Collision2D col)
    {
        //level one fixing problem  elvitor
        if (col.gameObject.tag == "platform")
        {
            this.transform.parent = col.transform;
        }

        //level 2 fixing problems wall
        if (col.gameObject.tag == "wall")
        {
            walljumpallowed = true;
        }

        if (col.gameObject.tag == "coin")
        {
            point++;
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(myaucdio, col.transform.position);

            mytext.text = "Score " + point;
            // Debug.Log("score" + point);

        }
    }
    void OnCollisionExist2D(Collider2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            this.transform.parent = null;
        }
        //if the char doesn't touch the wall anymore

        //then wallclimaing and jumping will not be allowed
        if (col.gameObject.tag == "wall")
        {
            walljumpallowed = false;
        }
    }

}
