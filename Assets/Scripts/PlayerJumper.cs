using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    // config params
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float wallJumpSpeed = 5f;
    [Tooltip("Layers where the player is able to jump from")]
    [SerializeField] List<string> jumpLayers;

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

        _animator.SetTrigger("Jump");

        PlayJumpSFX();
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        _rigidbody2D.velocity += jumpVelocityToAdd;

    }

    public void JumpButtonHit()
    {
        // Findout if the collider is actually touching specific layer
        if (!_feetBoxCollider2D.IsTouchingLayers(LayerMask.GetMask(jumpLayers.ToArray())) || !_player.IsAlive())
        {
            return;
        }

        _animator.SetTrigger("Jump");

        PlayJumpSFX();
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        _rigidbody2D.velocity += jumpVelocityToAdd;

    }

    private void PlayJumpSFX()
    {
        if (!jumpAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(jumpAudioSFX, Camera.main.transform.position);
    }
}
