using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralControls : MonoBehaviour
{
    public GameObject player;
    public BGMController BGM;
    public int secsBeforeReset = 1;

    void Start(){

    }
    public void Reset(){
        StartCoroutine(ChangeToScene("Level1"));
    }
    public void StaticMaker(Rigidbody2D rb){
        StartCoroutine(ChangeToStatic(rb));
    }
    public void Collect(GameObject go){
        StartCoroutine(DestroyCollectable(go));
    }
    public void BackToMenu(){
        StartCoroutine(ChangeToMenu("Menu"));
    }
    public IEnumerator ChangeToScene(string sceneToChangeTo){
        yield return new WaitForSeconds(secsBeforeReset);
        SceneManager.LoadScene(sceneToChangeTo);
    }
    public IEnumerator ChangeToStatic(Rigidbody2D rb){
        yield return new WaitForSeconds(2);
        rb.bodyType = RigidbodyType2D.Static;
    }
    public IEnumerator DestroyCollectable(GameObject go){
        yield return new WaitForSeconds(0.2f);
        Destroy(go);
    }
    public IEnumerator ChangeToMenu(string sceneToChangeTo){
        yield return new WaitForSeconds(secsBeforeReset);
        Destroy(GameObject.Find("BGM"));
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
