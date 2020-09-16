using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnIds;

    public int MonsterID;

    public GameData Data { get; private set; }

    public void Awake()
    {
        Data = GetComponent<GameData>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnMonsterAsync());

    }

    IEnumerator SpawnMonsterAsync()
    {

        while (true)
        {
            yield return new WaitForSeconds(3f);
            spawnIds = GameObject.FindGameObjectsWithTag("Enemy");
            if (spawnIds.Length <= 20)
            {
                var monsterStat = GameManager.Instance.Data.Monster.monsters[0];
                var monsterPrefab = Resources.Load<GameObject>(string.Format("Monster/{0}", monsterStat.PrefabName));

                if (!monsterPrefab)
                {
                    Debug.LogErrorFormat("Monster '{0}' is null", monsterStat.PrefabName);
                }

                var monster = GameObject.Instantiate(monsterPrefab, new Vector3(47, 0, 45), Quaternion.identity)
                    .GetComponent<EnemyController>();
                monster.Monsterstat = monsterStat;
            }
            
        }
    }
}