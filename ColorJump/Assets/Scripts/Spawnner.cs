using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public Transform powerSpawnPoint;
    public GameObject[] blockobjects;
    public GameObject powerObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spawnner")
        {
            Destroy(other.gameObject);
            Instantiate(blockobjects[Random.Range(0, blockobjects.Length)], spawnPoint.position, Quaternion.identity);//spawn new obstacles on entering spawnner
            Instantiate(powerObject, powerSpawnPoint.position, Quaternion.identity);//spawn new color change object on entering spawnner object
        }

    }
}
