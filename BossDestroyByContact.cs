using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int health;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        health -= 1;
        Destroy(other.gameObject);

        if (health == 0)
        {
            gameController.AddScore(scoreValue);            
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }
}
