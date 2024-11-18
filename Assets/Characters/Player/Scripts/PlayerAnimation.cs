using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator attackAnimator;
    [SerializeField] PlayerAttack playerAttack;

    private void OnEnable()
    {
        playerAttack.Attacked += PlayAttack;
    }

    private void PlayAttack()
    {
        attackAnimator.Play("big_slash_v");
    }
}
