using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gcScript;
    int scoreValue = 10;
    GameObject gameControllerObject;
    public void Start()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        
        if (gameControllerObject != null)
        {
            gcScript = gameControllerObject.GetComponent<GameController>();

        }
        if (gcScript == null)
        {
            Debug.Log("GameController Script no funciona");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionClone,2f);
        if (other.tag == "Player")
        {           
            GameObject playerExplosionClone = Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gcScript.GameOver();
            Destroy(playerExplosionClone,1f);                        
        }
        gcScript.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
