using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogic : MonoBehaviour
{
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Awake()
    {
        canvas = Instantiate(canvas);
        canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Testing");
            canvas.SetActive(true);
        }
            
    }

    public void HideWinHUD()
    {
        canvas.SetActive(true);
    }
}
