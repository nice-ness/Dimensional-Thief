using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDungeonExit : MonoBehaviour
{
    GameObject e;
    // Start is called before the first frame update
    void Start()
    {
        e = transform.GetChild(0).gameObject;
    }

    public void ToggleExit()
    {
        e.SetActive(true);
        Debug.Log("Exit Toggled");
    }

}
