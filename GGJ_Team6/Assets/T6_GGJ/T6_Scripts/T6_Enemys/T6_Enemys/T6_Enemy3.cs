﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_Enemy3 : T6_EnemyBehavior
{
    public AudioClip enemySound3;

    private EnemyState currState = EnemyState.Run;

    void Start()
    {
        StartHealth(40);
        GetManager();
        T6_AudioManager.am.Play(enemySound3);
    }

    void Update()
    {
        switch (currState)
        {
            case EnemyState.Run:
                EnemyMove(2f);
                break;
            case EnemyState.Die:
                Die();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            MakeDamage(10);
        }

        if (collision.tag == "Projectile")
        {
            TakeDamage(20);
        }

        if (collision.tag == "Expansion")
        {
            TakeDamage(50);
        }
    }
}
