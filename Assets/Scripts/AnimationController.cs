using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // ��������������, ��� � ������ ���� Animator � �������� ��������
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator �� ������ � �������� ��������.");
        }
    }

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true;
            animator.Play(0); // ��������� ������ ����; ����� �������� �� ��� �����, ���� ���������
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
