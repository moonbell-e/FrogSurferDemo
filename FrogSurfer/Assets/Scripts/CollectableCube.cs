using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    private bool IsCollected;

    private float _index;

    [SerializeField]
    private Collecter _collecter;

    void Update()
    {
       if (IsCollected == true)
        {
            if (transform.parent != null)
           {
                transform.localPosition = new Vector3(0, -_index, 0);
           }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyCube" || (other.GetComponent<Collecter>() != null && gameObject.tag == "EnemyCube"))
        {
            _collecter.HeightDecrease();
            transform.parent = null;
            if (other.GetComponent<Collecter>() != null)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public bool GetIsCollected()
    {
        return IsCollected;
    }
    public void MadeItCollected()
    {
        IsCollected = true;
    }

    public void SetTheIndex(float index)
    {
        this._index = index;
    }
}
