using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    private float _range = 1000f;

    private AudioSource _audioSourceFX;

    void Awake()
    {
        _audioSourceFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        RaycastHit hit;
        _audioSourceFX.PlayOneShot(_audioSourceFX.clip);
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
            EnemyAI enemyHit = hit.transform.GetComponent<EnemyAI>();
            if(enemyHit!=null)
            {
                enemyHit.TakeDamage(_damage);
            }
        }
            
    }
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * _range;
        Gizmos.DrawRay(transform.position, direction);
    }


}
