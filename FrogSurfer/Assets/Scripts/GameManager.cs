using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private float _restartDelay = 1.8f;

    [SerializeField] private GameObject _restartMenu;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            _restartMenu.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<AudioManager>().Play("Finish");
        }
    }
    public void GameEnd()
    { 
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("Restart", _restartDelay);
        FindObjectOfType<AudioManager>().Play("Fail");
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
