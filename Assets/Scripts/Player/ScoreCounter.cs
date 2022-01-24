using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float timeToCalculate;
    [SerializeField] float scorePerUnit;
    Vector2 lastPosition;
    
    public float score;

    bool inGame = true;
    void Start()
    {
        StartCoroutine(Score());
    }
    IEnumerator Score()
    {
        while (inGame)
        {
            lastPosition = transform.position;
            yield return new WaitForSeconds(timeToCalculate);
            score += Vector2.Distance(transform.position, lastPosition) * scorePerUnit;
        }
    }
}
