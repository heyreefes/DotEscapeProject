using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotateSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);//rotate obstacle
    }
}
