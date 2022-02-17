using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedPlatform2 : MonoBehaviour
{
    public Rigidbody2D platrb;
    public GameObject genControl;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            genControl.GetComponent<GeneralControls>().StaticMaker(platrb);
            gameObject.SetActive(false);
        }
    }
}
