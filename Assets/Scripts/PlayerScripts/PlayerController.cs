using UnityEngine;
using UnityEngine.Events;

namespace mainGame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PolygonCollider2D))]
    public class PlayerController : MonoBehaviour, IControlable
    {
        public UnityAction<string> ChangeAnimation;
        public UnityAction GameOverUI;
        public UnityAction<int> ShowScore;

        public UnityAction DieSound;
        public UnityAction JumpSound;
        public UnityAction LandSound;
        
        
        private Rigidbody2D _rb2d;
        
        [SerializeField] private float _jumpVelocity;
        private bool _isGrounded;
        private int _currentScore;
        private bool _isAlive;

        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            ShowScore?.Invoke(_currentScore);
            _isAlive = true;
        }


        private void OnCollisionEnter2D(Collision2D col)
        {
             if (col.gameObject.TryGetComponent(out Ground _ground))
             { 
                 ChangeAnimation?.Invoke(PlayerAnimationConstants.PLAYER_RUN);
                 LandSound?.Invoke();
             }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out EndGame _endGame))
            { 
               EndGame(); 
            }
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out AddScore _addScore))
            {
                _currentScore++;
                ShowScore?.Invoke(_currentScore);
            }
        }

        public void Jump()
        {
            if (_isAlive == false)
            {
                return;
            }
            _rb2d.velocity = Vector2.up * _jumpVelocity;
            ChangeAnimation?.Invoke(PlayerAnimationConstants.PLAYER_JUMP);
            JumpSound?.Invoke();
        }

        private void EndGame()
        {
            Time.timeScale = 0;
            ChangeAnimation?.Invoke(PlayerAnimationConstants.PLAYER_DIE);
            GameOverUI?.Invoke();
            DieSound?.Invoke();
            _isAlive = false;
        }
    }
}
