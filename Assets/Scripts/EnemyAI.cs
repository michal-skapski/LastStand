using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //I need my tower position
    [SerializeField] private Transform _towerTransform;
    //I need my enemy position
    [SerializeField] private Transform _enemyTransform;

    private float _movementSpeed = 5f;
    private float _enemyFieldOfView = 1000f;
    //I also need to set the distance which the enemy will need to hold because i don't want my enemy to be so close he can kiss him.
    [SerializeField]private float _enemyGapFromPlayer=7f;
    //i need a private variable from distance
    private float _distanceFromThePlayer;
    [SerializeField] private float _health = 50f;

    //Now i will create a method, which will make this object (enemy) move to our Protagonist



    private void EnemyMovement()
    {
        //distance is returning the distance beetwen a and b points
        _distanceFromThePlayer = Vector3.Distance(_towerTransform.position, _enemyTransform.position);
       // _cc = GetComponent<CharacterController>();


        if (_distanceFromThePlayer < _enemyFieldOfView && _distanceFromThePlayer > _enemyGapFromPlayer)
        {
            //quaternion are used to represent rotation
            //Quaternion.LookRotation gives us quaternion based on Vector of the direction/position
            _enemyTransform.rotation = Quaternion.Slerp(_enemyTransform.rotation, Quaternion.LookRotation(_towerTransform.position - _enemyTransform.position),  _movementSpeed * Time.deltaTime); //time.deltatime - used to make an action good on every PC 
            
            //enemy movement
            _enemyTransform.position += _enemyTransform.forward * _movementSpeed * Time.deltaTime;

        }
    }
    private void Update()
    {
        EnemyMovement();
    }
    public void TakeDamage(float p_amount)
    {
        _health -= p_amount;
        if(_health <=0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }   
}