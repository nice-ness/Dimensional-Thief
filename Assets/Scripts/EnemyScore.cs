using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] int scoreValue;
    private ScoreController scoreController;
    // Start is called before the first frame update
    void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
        Debug.Log(scoreController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        if(scoreController == null)
        {
            scoreController = FindObjectOfType<ScoreController>();
            Debug.Log(FindObjectOfType<ScoreController>());
        }
        scoreController.updateScore(scoreValue);

    }


}
