using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Menu");
        }
    }

    public void Play(){
        SceneManager.LoadScene("Level1");
    }
    
    public void QuitGame(){
        Debug.Log("QUIT");
        Application.Quit();
    }
}
