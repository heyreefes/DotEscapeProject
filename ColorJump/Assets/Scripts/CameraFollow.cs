using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
