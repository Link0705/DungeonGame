using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    public enum EnemyType
    {
        SkeletonBasic,
        Wiking,
        BigSkeleton,
        Mage,
        Archer,
        Witch,
    }

    public enum EnemyDifficulty
    {
        Easy,
        Medium,
        Hard,
    }

    private EnemyType enemies;

    private int amountEnemy;

    [Header("Prefabs")]
    public GameObject skeleton_basic_prefab;
    public GameObject archer_prefab;
    public GameObject bigSkeleton_prefab;
    public GameObject witch_prefab;
    public GameObject wiking_prefab;
    public GameObject mage_prefab;


    public List<GameObject> GenerateEnemies(List<Transform> spawnPoints, Room activeRoom)
    {
        List<GameObject> returnList = new List<GameObject>();
        List<EnemyType> spawnType = new List<EnemyType>( (IEnumerable<EnemyType>) System.Enum.GetValues(typeof(EnemyType)));
        bool chooseMelee = false;

        do
        {
            int TypeRandomIndex;
            if (chooseMelee)
            {
                TypeRandomIndex = Random.Range(0, 2);
            }
            else
            {
                TypeRandomIndex = Random.Range(3, spawnType.Count);
            }

            chooseMelee = !chooseMelee;
            enemies = spawnType[TypeRandomIndex];

            amountEnemy = Random.Range(Mathf.Min(2, spawnPoints.Count), Mathf.Min(4, spawnPoints.Count));


            for (int f = 1; f <= amountEnemy; f++)
            {
                int PointRandomIndex = Random.Range(0, spawnPoints.Count - 1);
                Transform spawnpoint = spawnPoints[PointRandomIndex];
                spawnPoints.RemoveAt(PointRandomIndex);
                GameObject enemyObj = null;

                switch (enemies)
                {
                    case EnemyType.SkeletonBasic:
                        enemyObj = Instantiate(skeleton_basic_prefab);
                        break;
                    case EnemyType.Archer:
                        enemyObj = Instantiate(archer_prefab);
                        break;
                    case EnemyType.BigSkeleton:
                        enemyObj = Instantiate(bigSkeleton_prefab);
                        break;
                    case EnemyType.Mage:
                        if (mage_prefab != null)
                        {
                            enemyObj = Instantiate(mage_prefab);
                        }
                        break;
                    case EnemyType.Wiking:
                        enemyObj = Instantiate(wiking_prefab);
                        break;
                    case EnemyType.Witch:
                        enemyObj = Instantiate(witch_prefab);
                        break;
                }

                if (enemyObj != null)
                {
                    enemyObj.GetComponent<EnemyController>().Init(enemies, activeRoom);
                    enemyObj.GetComponent<NavMeshAgent>().Warp(spawnpoint.position);
                    returnList.Add(enemyObj);
                }
                else Destroy(enemyObj);

            }

        } while (spawnPoints.Count > 0);
        return returnList;
    }

}
