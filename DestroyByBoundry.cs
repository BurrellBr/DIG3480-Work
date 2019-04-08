using System.Collections;
using UnityEngine;

public class DestroyByBoundry : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
