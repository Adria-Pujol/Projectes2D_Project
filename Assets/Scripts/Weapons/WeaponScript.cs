using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour
    {
        public Transform firePoint;

        // Update is called once per frame
        public void Shoot()
        {
            BulletPooler.instance.SpawnFromPool("Bullet", firePoint.position, firePoint.rotation);
        }
    }
}