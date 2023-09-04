using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyAttack yazdım MonoBehaviour yerine, şimdi EnemyAttack'in childı oldu
public class PatrollingAttack : EnemyAttack
{
    PlayerMoveControls playerMove;
    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        // bizim virtual fonksiyonun içi boş, ama dolu olsaydı yani içinde kod olsaydı base.SpecialAttack() kodu sayesinde oradaki bütün kodları çağırabilcektim
        base.SpecialAttack();

        playerMove = playerStats.GetComponentInParent<PlayerMoveControls>();
        StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform.parent));
    }
}
