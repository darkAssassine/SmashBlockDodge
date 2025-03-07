using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator attackAnimator;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] Player player;

    private void OnEnable()
    {
        playerAttack.Attacked += PlayAttack;
        player.ChangedDirection += OnDirectionChanged;
    }

    private void PlayAttack()
    {
        attackAnimator.Play("big_slash_v");
    }
    private void OnDirectionChanged(FacingDirection direction)
    {
        int iDirection = 1;
        switch(direction)
        {
            case FacingDirection.Left:
                iDirection = -1;
                break;
            case FacingDirection.Right:
                iDirection = 0;
                break;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, iDirection * 180, transform.eulerAngles.z);
    }

}
