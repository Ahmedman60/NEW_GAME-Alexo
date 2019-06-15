using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //thing will hit you
    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(1);

    }
}
