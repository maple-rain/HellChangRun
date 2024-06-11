﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] Animator animator;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] GameObject EndPanel;

    [Header("Movement Settings")]
    [SerializeField] float catchDistance = 1f;
    [SerializeField] float throwDistance = 5f;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float speed = 6f;

    private float throwTimer;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        transform.position = new Vector3(0.5f, 0.2f, -5f);
        throwTimer = Random.Range(6f, 9f);
    }

    private void Update()
    {
        if (player != null)
        {
            FollowPlayer();           
            throwTimer -= Time.deltaTime;
            if (throwTimer <= 0f)
            {
                ThrowWeapon();
                throwTimer = Random.Range(4f, 7f); 
            }
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), speed * Time.deltaTime);
        animator.SetFloat("Moving", speed);
    }
    private void ThrowWeapon()
    {
        animator.SetTrigger("ThrowAnimation"); 
        StartCoroutine(ThrowWeaponAfterAnimation());
    }

    private IEnumerator ThrowWeaponAfterAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 weaponPosition = new Vector3(transform.position.x, 4f, transform.position.z);
        GameObject weapon = Instantiate(weaponPrefab, weaponPosition, transform.rotation);
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            weaponRb.velocity = new Vector3(0f, 0f, 35f);
        }
        else
        {
            Debug.LogError("Rigidbody Error");
        }

        Destroy(weapon, 5f);

        animator.SetFloat("Moving", speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
        }
    }
}