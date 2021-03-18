using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogic : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = true;
        }
            
    }

    public void HideWinHUD()
    {
        canvas.enabled = false;
    }
}
