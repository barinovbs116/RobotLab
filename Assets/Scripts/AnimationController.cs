using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator íå íàéäåí â äî÷åðíèõ îáúåêòàõ.");
        }
    }

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true;
            animator.Play(0); 
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
