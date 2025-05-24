using UnityEngine;

public class BaursakController : MonoBehaviour
{
    public float jumpAmount = 0.5f;   // Подъем за клик
    public float fallSpeed = 1.5f;    // Скорость падения
    public float minY = 0f;
    public float maxY = 10f;

    private Animator animator;
    private bool isFalling = false;    // Чтобы отслеживать состояние падения

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            // Прыжок вверх
            position.y += jumpAmount;
            animator.ResetTrigger("fall");
            animator.SetTrigger("climb");
            isFalling = false;
        }
        else
        {
            // Постепенное падение
            position.y -= fallSpeed * Time.deltaTime;

            if (!isFalling)
            {
                animator.ResetTrigger("climb");
                animator.SetTrigger("fall");
                isFalling = true;
            }
        }

        // Ограничение высоты
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;

        // Проверка проигрыша (упал слишком низко)
        if (position.y <= minY)
        {
            animator.SetTrigger("lose");
            enabled = false; // Останавливаем управление
        }

        // Проверка победы (достиг вершины)
        if (position.y >= maxY)
        {
            animator.SetTrigger("win");
            enabled = false; // Останавливаем управление
        }
    }
}
