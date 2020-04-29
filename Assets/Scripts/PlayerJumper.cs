using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GroundedRaycastDetector))]
public class PlayerJumper : MonoBehaviour
{
    // config params
    [Header("Normal Jump")]
    [SerializeField] float jumpSpeed = 5f;
    
    [Header("Wall Jump")]
    [SerializeField] Vector2 wallJumpForce = new Vector2(12f, 20f);
    [SerializeField] float disabledMoveControlTime = 0.5f;

    [Header("Audio Effects")]
    [SerializeField] AudioClip jumpAudioSFX = null;

    // cache
    CircleCollider2D _circleCollider2d;
    CapsuleCollider2D _bodyCapsuleCollider2D;
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    Player _player;
    GroundedRaycastDetector _groundedRaycastDetector;
    GameSound _gameSound;

    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2d = GetComponent<CircleCollider2D>();
        _bodyCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _groundedRaycastDetector = GetComponent<GroundedRaycastDetector>();
        _gameSound = FindObjectOfType<GameSound>();
    }

    public void JumpButtonHit()
    {
        if(!_player.IsAlive() || _bodyCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders"))) { return; }

        if (_groundedRaycastDetector.IsGroundedOnLayers())
        {
            Jump(jumpSpeed);
        }
        else if (_circleCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            StartCoroutine(WallJump());
        }
    }

    private void Jump(float ySpeed)
    {
        PlayJumpSpecialFX();
        Vector2 jumpVelocityToAdd = new Vector2(0f, ySpeed);
        _rigidbody2D.velocity += jumpVelocityToAdd;
    }

    IEnumerator WallJump()
    {
        _player.SetIsMoveEnabled(false);

        PlayJumpSpecialFX();

        Vector2 wallJumpForceToAdd = new Vector2(wallJumpForce.x * transform.localScale.x * -1, wallJumpForce.y);
        _rigidbody2D.AddForce(wallJumpForceToAdd, ForceMode2D.Impulse);

        yield return new WaitForSeconds(disabledMoveControlTime);

        _player.SetIsMoveEnabled(true);
    }

    private void PlayJumpSpecialFX()
    {
        _animator.SetTrigger("Jump");

        PlayJumpSound();
    }

    private void PlayJumpSound()
    {
        if (!jumpAudioSFX || _gameSound.IsSoundMute) { return; }

        AudioSource.PlayClipAtPoint(jumpAudioSFX, Camera.main.transform.position);
    }
}
