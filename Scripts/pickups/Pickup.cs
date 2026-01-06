using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    const string playerstring = "Player";

     void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
         
        if(other.gameObject.tag == playerstring)
        {
            Onpickup();
            Destroy(gameObject);
        }
    }

    protected abstract void Onpickup();

}
