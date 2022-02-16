using UnityEngine;

public class Collecter : MonoBehaviour
{
    private GameObject _mainCube;
    private float _height;
    void Start()
    {
        _mainCube = GameObject.Find("Player");
    }

    void Update()
    {
        _mainCube.transform.position = new Vector3(transform.position.x, _height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -_height, 0);
    }


    public void HeightDecrease()
    {
        if (_height <= 0)
        {
            FindObjectOfType<GameManager>().GameEnd();
        }
        else
        {
            _height--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CubeCollect" && other.gameObject.GetComponent<CollectableCube>().GetIsCollected()==false)
        {
            _height += 1f;
            other.gameObject.GetComponent<CollectableCube>().MadeItCollected();
            other.gameObject.GetComponent<CollectableCube>().SetTheIndex(_height);
            other.gameObject.transform.parent = _mainCube.transform;
        }
    }
}
