using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public partial class GameOver : MonoBehaviour {


    // Use this for initialization
    public static bool dieinlevle2;
	void  OnGUI(){

        //MoveCharFeto d = new MoveCharFeto();
        
		//if retry button is pressed load scene 0 the game
		GUI.contentColor = Color.red;
        if (MoveCharFeto.CurrentLevel == 1)
        {
            dieinlevle2 = true;
        }
        else { dieinlevle2 = false; }
        if (SceneManager.GetActiveScene()==SceneManager.GetSceneByBuildIndex(2))
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex.ToString());
            Debug.Log(dieinlevle2.ToString());
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 70, 100, 40), "Retry?"))
            {
                if (dieinlevle2 == true)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
            //and quit button
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 120, 100, 40), "Quit"))
            {
                Application.Quit();
            }
        }
	}
	
}