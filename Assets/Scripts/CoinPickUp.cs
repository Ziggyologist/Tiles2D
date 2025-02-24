using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] int scoreCoin = 100;
    [SerializeField] AudioClip coinPickUpSFX;
    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindFirstObjectByType<GameSession>().AddToScore(scoreCoin);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
