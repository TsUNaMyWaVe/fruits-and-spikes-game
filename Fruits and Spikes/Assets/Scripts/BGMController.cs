using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public static BGMController instace = null;
    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

    void Awake()
    {
        if (instace != null){
            Destroy(gameObject);
        }
        else {
            instace = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

}
