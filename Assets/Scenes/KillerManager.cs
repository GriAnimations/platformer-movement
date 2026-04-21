using System.Collections;
using UnityEngine;

public class KillerManager : MonoBehaviour
{

    private CapsuleCollider2D _collider;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;

    [SerializeField] private Transform respawnTarget;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private TimerScript timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
			KillPlayer();
        }
    }

    public void KillPlayer()
    {
        deathParticles.Play();
        _collider.enabled = false;
        _renderer.enabled = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Respawn());
            
        timer.StopTimer();
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = respawnTarget.position;
        _collider.enabled = true;
        _renderer.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        
        timer.ResetTimer();
    }
    
}
