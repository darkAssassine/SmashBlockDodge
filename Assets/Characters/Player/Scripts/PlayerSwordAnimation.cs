using UnityEngine;

public class PlayerSwordAnimation : MonoBehaviour
{
    [SerializeField] private Animator swordAnimatior;
    private void OnAttackAnimStarted()
    {
        swordAnimatior.Play("OnAttack");
    }

    private void OnAttackAnimEnded()
    {
        swordAnimatior.Play("OnAttackOver");
    }
}
