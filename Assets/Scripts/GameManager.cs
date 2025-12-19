using System.Collections;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject[] targets;
    public float spawnInterval = 1.0f;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }
    
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
