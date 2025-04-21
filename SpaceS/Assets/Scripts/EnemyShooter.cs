using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] AiScriptable script;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private AudioSource _shootAudio;
    Transform delay;
    float counter;
    private void Start()
    {
        delay = GameObject.FindGameObjectWithTag("Player").transform;
        counter = script.shootTime;
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        _shootAudio.Play();
    }
    private void Update()
    {
        if (delay)
        {
            if (Mathf.Abs(delay.position.x - transform.position.x) < 15 && Mathf.Abs(delay.position.y - transform.position.y) < 1)
            {
                counter -= Time.deltaTime;
                if (counter <= 0)
                {
                    shoot();
                    counter = script.shootTime;
                }

            }
        }
    }

}