using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaursakController : MonoBehaviour
{
    public float jumpAmount = 0.5f;   // Сколько поднимается за клик
    public float fallSpeed = 1.5f;    // Скорость падения
    public float minY = 0f;
    public float maxY = 10f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 position = transform.position;

        // Реакция на одиночный клик мыши или тап на экран
        if (Input.GetMouseButtonDown(0))
        {
            position.y += jumpAmount;
            if (animator) animator.SetBool("isClimbing", true);
        }
        else
        {
            // Постепенное падение
            position.y -= fallSpeed * Time.deltaTime;
            if (animator) animator.SetBool("isClimbing", false);
        }

        // Ограничим высоту
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
