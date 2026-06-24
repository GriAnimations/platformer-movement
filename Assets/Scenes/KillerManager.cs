using System.Collections;
using UnityEngine;

public class KillerManager : MonoBehaviour
{

    private BoxCollider2D _collider;
    [SerializeField] private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;

    private Transform _respawnTarget;
    private ParticleSystem _deathParticles;
    private TimerScript _timer;
    
    [SerializeField] private AudioManager audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _respawnTarget = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        _deathParticles = GameObject.Find("DeathParticles").GetComponent<ParticleSystem>();
        _timer = GameObject.Find("Start + Timer").GetComponent<TimerScript>();
        
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _timer.timerActive)
        {
            KillPlayer();
            RespawnTrigger(0.5f);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
			KillPlayer();
            RespawnTrigger(1);
        }
    }

    public void KillPlayer()
    {
        _deathParticles.Play();
        _collider.enabled = false;
        _renderer.enabled = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
            
        _timer.StopTimer();
        
        audioManager.PlaySound(0);
    }

    public void RespawnTrigger(float delay)
    {
        StartCoroutine(Respawn(delay));
    }

    private IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.transform.position = _respawnTarget.position;
        _collider.enabled = true;
        _renderer.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        
        _timer.ResetTimer();
    }
    
}
