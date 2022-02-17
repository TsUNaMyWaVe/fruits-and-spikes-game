using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeConrtoller : MonoBehaviour
{
    private Transform[] allChildren;
    public GameObject player;
    private Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        playerCollider = player.GetComponent<Collider2D>();
        // foreach(Transform child in allChildren){
        //     Debug.Log("Child name: " + child.gameObject.name);
        // }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 1; i < allChildren.Length; i = i+3){
            // Debug.Log("Child " + i + " name in loop: " + allChildren[i].gameObject.name);
            if (i%2 == 1){
                continue;
            }
            else {
                if (allChildren[i].GetComponent<Collider2D>().IsTouching(playerCollider)){
                    StartCoroutine(SetUnactive(allChildren[i].gameObject));
                }
            }
        }
    }
    public IEnumerator SetUnactive(GameObject go){
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
    }
}
