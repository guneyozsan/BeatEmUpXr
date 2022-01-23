using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DieVFXPrefab, HitVFXPrefab;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private AudioClip soundDie;
    [SerializeField] private AudioClip soundHit;
    [SerializeField] private AudioSource audioSource;
    
    private int hp=2;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Damage();
        }
    }
    
    private void Damage()
    {
        audioSource.clip = soundHit;
        audioSource.Play();
        hp--;
        if(hp > 0) Instantiate(HitVFXPrefab, transform).transform.localPosition = Vector3.zero;
        else Die();
    }
    private void Die()
    {
        audioSource.clip = soundDie;
        audioSource.Play();
        Instantiate(DieVFXPrefab, transform).transform.localPosition = Vector3.zero;
        _renderer.enabled = false;
        _trail.enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject,1f);
    }
}
