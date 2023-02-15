using UnityEngine;
namespace mainGame
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        Animator _animator;
        private string _currentAnimation;

        private void OnEnable()
        {
            gameObject.GetComponent<PlayerController>().ChangeAnimation += ChangeAnimation;
        }

        private void OnDisable()
        {
            gameObject.GetComponent<PlayerController>().ChangeAnimation -= ChangeAnimation;
        }

        void Start()
        {
            _animator = GetComponent<Animator>();
            ChangeAnimation(PlayerAnimationConstants.PLAYER_RUN);
        }

        void ChangeAnimation(string AnimationType)
        {
            if (AnimationType == _currentAnimation)
            {
                return;
            }

            _currentAnimation = AnimationType;
            _animator.Play(_currentAnimation);
        }
    }
}
