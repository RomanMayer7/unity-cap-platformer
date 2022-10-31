using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    [Tooltip("The particles that appear after the player collects a coin.")]
    public GameObject coinParticles;

    PlayerMovement playerMovementScript;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovementScript = other.GetComponent<PlayerMovement>();
            playerMovementScript.soundManager.PlayCoinSound();
            ScoreManager.score += 10;

            ScoreManager.coinsCollected += 1;
            print("Collected " + ScoreManager.coinsCollected + " coins");
            //After you to collect 10 coins - 1 health is added back to the player
            if (ScoreManager.coinsCollected % 10==0)
            {

                playerMovementScript.ChangeHealth(1);
            }

            GameObject particles = Instantiate(coinParticles, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}