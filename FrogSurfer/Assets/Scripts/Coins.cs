using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private int _coins;

    public Text coinScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            _coins++;
            coinScore.text = _coins.ToString();
            Destroy(other.gameObject);
        }
    }
}
