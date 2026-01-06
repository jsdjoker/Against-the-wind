using UnityEngine;

public class ObstacleDestory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);    
    }

}
