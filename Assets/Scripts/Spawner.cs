using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject theEnemy;
    private int _xPos;
    private int _zPos;
    private float _enemyCount;
    private bool _enemySpawn = true;
    private int _minXRange = -30;
    private int _maxXRange = 24;
    private int _minZRange = 112;
    private int _maxZRange = 182;
    private float _yPos = 0.1f;
    private int _waitingValue = 10;

    void Start ()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (_enemySpawn)
        {
            _xPos = Random.Range(_minXRange, _maxXRange);
            _zPos = Random.Range(_minZRange, _maxZRange);
            
            Instantiate(theEnemy, new Vector3(_xPos, _yPos, _zPos), Quaternion.identity);
            yield return new WaitForSeconds(_waitingValue);
            _enemyCount++;
            if(_enemyCount >= 300)
            {
                _enemySpawn = false;
            }
            else
            {
                StartCoroutine(EnemyDrop());
            }
        }
    }
}
