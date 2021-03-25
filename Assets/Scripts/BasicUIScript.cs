using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUIScript : MonoBehaviour
{
    [SerializeField] private Vector3 positionUIElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ViewportToWorldPoint(positionUIElement);
    }
}
