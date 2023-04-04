using UnityEngine;

public class BulletOP : MonoBehaviour
{
    // The speed at which the bullet moves
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;

    // Move the bullet forward
    public void Fire()
    {
        // Set the bullet to active
        gameObject.SetActive(true);

        // Move the bullet forward
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}