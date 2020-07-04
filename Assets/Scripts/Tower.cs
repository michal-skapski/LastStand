using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _maxHp = 500f;
    [SerializeField] private float _hp;
    [SerializeField] private int _damage = 100;
    [SerializeField] private Image _healthImage = null;
    [SerializeField] private float _delayDamage = 1f;
    [SerializeField] private Text _deathImage;

    private void Awake()
    {
        _hp = _maxHp;
    }
    private void Update()
    {
         _healthImage.fillAmount = Mathf.Lerp(_healthImage.fillAmount, _hp / _maxHp, 0.9f * Time.deltaTime);
        _delayDamage -= Time.deltaTime;
    }
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<EnemyAI>())
        {
            if (_delayDamage <= 0)
            {
                _hp -= _damage;
                _delayDamage = 1f;
                Death();
            }
        }
    }
    private void Death()
    {
        if (_hp <= 0f)
        {
            _deathImage.gameObject.SetActive(true);
        }
    }
}
