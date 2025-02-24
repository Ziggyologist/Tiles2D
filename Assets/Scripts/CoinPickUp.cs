using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] int score = 100;
    [SerializeField] AudioClip coinPickUpSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //FindObjectOfType<GameSession>().AddToScore(score);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
