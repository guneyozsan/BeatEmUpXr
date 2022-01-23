using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class HitAreaController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    
    public PostProcessVolume damageVolume;
    private int hp=5;

    public GameObject[] HPImage;
    public GameObject gameOverText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            StartCoroutine(DamageFX());
            audioSource.clip = hitSound;
            audioSource.Play();
            if (hp > 0)
            {
                hp--;
                HPImage[hp].SetActive(false);
            }
            if(hp == 0)
                gameOverText.SetActive(true);
                
        }
    }

    public IEnumerator DamageFX()
    {
        do
        {
            damageVolume.weight += Time.deltaTime * 8f;
            yield return null;
        } while (damageVolume.weight < 1);
        yield return null;
        do
        {
            damageVolume.weight -= Time.deltaTime * 2f;
            yield return null;
        } while (damageVolume.weight > 0);
        
    }
}
