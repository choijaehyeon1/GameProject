using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerController player;
    

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyController>();
        if (!enemy)
            return;

        enemy.Monsterstat.Hp -= player.playerParams.stat.Attack - enemy.Monsterstat.Def;
    }
}
