using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAIGenerator : MonoBehaviour
{
    public bool generateButton = false;
    public float mode;

    public List<GameObject> ai_bots = new List<GameObject>();

    public void Update()
    {
        if (generateButton)
        {
            generateButton = false;
            
            if (ai_bots != null)
            {
                ai_bots.ForEach(bot => bot.GetComponent<EnemyHealth>().ReceiveDamage(100f));
                
            }
            Invoke(nameof(testGenerate), 2f);
        }
    }

    public void testGenerate()
    {
        var spawnPoints = generateRandomSpawnPoints();
        ai_bots = GetComponent<EnemyGenerator>().GenerateEnemies(mode, spawnPoints, null);
    }

    private List<Transform> generateRandomSpawnPoints()
    {
        List<Transform> SpawnList = new List<Transform>();

        for(int i = 0; i <= 10; i++)
        {
            GameObject spawnPoint = new GameObject();
            spawnPoint.transform.position = new Vector3(Random.Range(0.0f, 3.0f), 0, Random.Range(0.0f, 3.0f));
            SpawnList.Add(spawnPoint.transform);
        }

        return SpawnList;
    }
}