using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizez;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizez);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
