using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public GameObject collected;
    public int Score;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();    
    }

 
    // verifica quando a maçã é tocada
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cc.enabled = false;
            collected.SetActive(true);

            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.2f);
        }
    }
}
