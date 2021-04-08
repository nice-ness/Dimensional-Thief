using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSpript : MonoBehaviour
{
    HealthController healthController;
    // Start is called before the first frame update
    void Awake()
    {
        healthController = GetComponentInParent<HealthController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(healthController.Health, transform.localScale.y, transform.localScale.z);
    }
}
