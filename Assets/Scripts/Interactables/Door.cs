﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public float doorSpeed = 10f;
    public int doorHealth = 200;

    bool isOpened = true;
    int playersInRange = 0;

    void Awake()
    {
    }

    void Update()
    {
        if (playersInRange > 0 && (Input.GetButtonDown("Action_1") || Input.GetButtonDown("Action_2")))
        {
            isOpened = !isOpened;
        }
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") playersInRange++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") playersInRange--;
    }

    public void TakeDamage(int amount)
    {
        doorHealth -= amount;
        if (doorHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        if (isOpened)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * doorSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 90f, 0f), Time.deltaTime * doorSpeed);
        }
    }
}
