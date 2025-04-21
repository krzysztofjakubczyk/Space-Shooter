using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private float TimeBeforeNextShoot;
    [SerializeField] float TimeAfterShoot;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private AudioSource _shootAudio;
    private void shoot()
    {   
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        _shootAudio.Play();
    }
    public void chooseAPrefab(Bullet prefab)
    {
        bulletPrefab = prefab;
    }
    private void Update()
    {
        TimeAfterShoot += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Q) && TimeAfterShoot >= TimeBeforeNextShoot)
        {
            shoot();
            TimeAfterShoot = 0;
        }
    }

}
