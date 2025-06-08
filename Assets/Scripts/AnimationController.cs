using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Предполагается, что у робота есть Animator в дочерних объектах
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator не найден в дочерних объектах.");
        }
    }

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true;
            animator.Play(0); // запускаем первый клип; можно заменить на имя клипа, если требуется
        }
    }

    public void StopAnimation()
    {
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
}
