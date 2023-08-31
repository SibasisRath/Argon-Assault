using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject _particleSystemForExplosion;
    [SerializeField] GameObject _particleSystemForGettingHit;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 2;
    [SerializeField] int scorePerHit = 5;
    private bool isDead;

    [SerializeField] GameObject scoreBoard;

    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("SpawnAtRunTime").transform;
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard");
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) ProcessKill();
        
    }

    private void ProcessHit()
    {
        hitPoints--;
        Invoke("GettingHit", 0f);
        scoreBoard.GetComponent<ScoreBoardScript>().Scoreing(scorePerHit);
    }

    private void GettingHit()
    {
        GameObject vfx = Instantiate(_particleSystemForGettingHit, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }

    private void ProcessKill()
    {
        Debug.Log("hit");
        GameObject vfx = Instantiate(_particleSystemForExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
