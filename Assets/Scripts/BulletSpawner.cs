using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;    
    [SerializeField] private float _speed;    
    [SerializeField] float _shootWaitingTime;

    private Coroutine _shootJob;
    private bool _isGameWorking;

    private void Start()
    {        
        _isGameWorking = true;
        _shootJob = StartCoroutine(Shoot());                    
    }

    private void OnDestroy() => 
        StopCoroutine(_shootJob);

    private IEnumerator Shoot()
    {        
        WaitForSeconds waitSeconds = new WaitForSeconds(_shootWaitingTime);

        while (_isGameWorking)
        {            
            Vector3 direction = (_target.position - transform.position).normalized;
            Vector3 bulletPosition = transform.position + direction;

            Bullet newBullet = Instantiate(_bullet, bulletPosition, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;            

            yield return waitSeconds;
         }
    }      
}