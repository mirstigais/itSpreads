using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right;
    private Animator anim;

    int maxHealth = 100;
    int currentHealth;
    
    [SerializeField]
    HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (direction.magnitude > 0.1f)
        {

            //should be in it's own class
            anim.SetBool("isWalking", true);

            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = heading;
            transform.position += heading * moveSpeed * Time.deltaTime;
        }
        else anim.SetBool("isWalking", false);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
