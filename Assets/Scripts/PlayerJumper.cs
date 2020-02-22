using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    // config params
    [Header("Normal Jump")]
    [SerializeField] float jumpSpeed = 5f;
    [Tooltip("Layers where the player is able to jump from")]
    [SerializeField] List<string> jumpLayers;
    
    [Header("Wall Jump")]
    [SerializeField] Vector2 wallJumpForce = new Vector2(12f, 20f);
    [SerializeField] float disabledMoveControlTime = 0.5f;

    [Header("Audio Effects")]
    [SerializeField] AudioClip jumpAudioSFX = null;

    // cache
    CircleCollider2D _circleCollider2d;
    BoxCollider2D _feetBoxCollider2D;
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2d = GetComponent<CircleCollider2D>();
        _feetBoxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    public void WallJumpButtonHit()
    {
        // Findout if the collider is actually touching specific layer
        if (!_circleCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground")) || !_player.IsAlive())
        {
            return;
        }

        StartCoroutine(WallJump());
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

    public void JumpButtonHit()
    {
        // Findout if the collider is actually touching specific layer
        if (!_feetBoxCollider2D.IsTouchingLayers(LayerMask.GetMask(jumpLayers.ToArray())) || !_player.IsAlive())
        {
            return;
        }

        Jump(jumpSpeed);
    }

    private void Jump(float ySpeed)
    {
        PlayJumpSpecialFX();
        Vector2 jumpVelocityToAdd = new Vector2(0f, ySpeed);
        _rigidbody2D.velocity += jumpVelocityToAdd;
    }

    private void PlayJumpSpecialFX()
    {
        _animator.SetTrigger("Jump");

        PlayJumpSound();
    }

    private void PlayJumpSound()
    {
        if (!jumpAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(jumpAudioSFX, Camera.main.transform.position);
    }
}
