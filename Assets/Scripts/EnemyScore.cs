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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        scoreController.updateScore(scoreValue);

    }


}
