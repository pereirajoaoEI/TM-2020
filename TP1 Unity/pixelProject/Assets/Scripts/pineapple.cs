using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineapple : MonoBehaviour
{

    private SpriteRenderer sprite;
    private CircleCollider2D circle;

    public GameObject collected;

    public int pontos;

    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sprite.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            controlo.contr.totpontos += pontos;

            controlo.contr.UpdateScoreText();

            Destroy(gameObject, 0.5f);
        }
    }
}
