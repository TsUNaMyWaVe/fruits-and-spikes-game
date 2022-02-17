using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour
{
    private bool isTouched = false;
    private Animator anim;
    private Collider2D col;
    public GameObject genControl;
    public GameObject endText;
    private GameObject[] collectables;
    public GameObject player;
    private PlayerController pc;
    private int overallCollect;
    // Start is called before the first frame update
    void Start()
    {
        endText.SetActive(false);
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        pc = player.GetComponent<PlayerController>();
        overallCollect = collectables.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        isTouched = true;
        anim.SetBool("Touched", isTouched);
        if (checkWin()){
            endText.SetActive(true);
            genControl.GetComponent<GeneralControls>().BackToMenu();
        }
        else {
            endText.GetComponent<TMPro.TextMeshProUGUI>().text = "You didn't collect all fruits yet!";
            endText.SetActive(true);
            StartCoroutine(SetUnactive(endText));
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        isTouched = false;
        anim.SetBool("Touched", isTouched);
    }
    private bool checkWin(){
        if (pc.getScore() == overallCollect){
            return true;
        }
        else {
            return false;
        }
    }
    public IEnumerator SetUnactive(GameObject go){
        yield return new WaitForSeconds(2);
        go.SetActive(false);
    }
}
