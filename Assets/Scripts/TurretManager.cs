using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> shootSounds;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Material whiteMaterial;
    [SerializeField] private Material blackMaterial;
    [SerializeField] private List<Transform> turrets;
    [SerializeField] private float cooldownSeconds;

    private List<float> cooldowns;
    private List<Transform> cooldownIndicators;
    
    private Vector3 defaultLocalScale;
    private Vector3 defaultLocalPosition;

    private float nextTick = 0;

    private void Awake()
    {
        cooldowns = new List<float>(new float[turrets.Count]);

        for (int i = 0; i < cooldowns.Count; i++)
        {
            cooldowns[i] = 0;
        }

        cooldownIndicators = new List<Transform>();

        foreach (Transform cooldownIndicator in turrets.Select(turret => turret.GetChild(0)))
        {
            defaultLocalScale = cooldownIndicator.localScale;
            defaultLocalPosition = cooldownIndicator.localPosition;
            cooldownIndicator.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, 0f);
            cooldownIndicator.localPosition = new Vector3(defaultLocalPosition.x, defaultLocalPosition.y, -0.5f);
            cooldownIndicators.Add(cooldownIndicator);
        }
    }

    private void Update()
    {
        for (int i = 0; i < cooldowns.Count; i++)
        {
            float cooldown = cooldowns[i];
            Transform cooldownIndicator = cooldownIndicators[i];
            float scaleZ = cooldownIndicator.localScale.z;
            float localPositionZ = cooldownIndicator.localPosition.z;
            
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
                scaleZ -= Time.deltaTime / cooldownSeconds;
                localPositionZ -= Time.deltaTime / (2 * cooldownSeconds);
            }
            else
            {
                cooldown = 0;
                scaleZ = 0;
                localPositionZ = -0.5f;
            }

            cooldowns[i] = cooldown;

            cooldownIndicator.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, scaleZ);
            cooldownIndicator.localPosition = new Vector3(defaultLocalPosition.x, defaultLocalPosition.y, localPositionZ);
        }

        EnemySpawnerUpdate();
    }
    
    void EnemySpawnerUpdate()
    {
        nextTick -= Time.deltaTime;
        if (nextTick < 0)
        {
            nextTick = UnityEngine.Random.Range(1f, 2f);

            int amount = UnityEngine.Random.Range(1, 3);
            for (int i = 0; i < amount ; ++i)
            {
                int nextEnemyIndex = UnityEngine.Random.Range(0, 14);
                Transform enemy = Instantiate(enemyPrefabs[nextEnemyIndex % 5]).transform;
                enemy.position = turrets[nextEnemyIndex].position + Vector3.forward * 6;
                enemy.parent = null;
            }
        }

    }
    
    private void OnFire0()
    {
        Fire(0, true);
    }

    private void OnFire2()
    {
        Fire(1, true);
    }
    
    private void OnFire4()
    {
        Fire(2, true);
    }
    
    private void OnFire5()
    {
        Fire(3, true);
    }
    
    private void OnFire7()
    {
        Fire(4, true);
    }
    
    private void OnFire9()
    {
        Fire(5, true);
    }
    
    private void OnFire11()
    {
        Fire(6, true);
    }
    
    private void OnFire12()
    {
        Fire(7, true);
    }
    
    private void OnFire14()
    {
        Fire(8, true);
    }
    
    private void OnFire16()
    {
        Fire(9, true);
    }
    
    private void OnFire17()
    {
        Fire(10, true);
    }
    
    private void OnFire19()
    {
        Fire(11, true);
    }
    
    private void OnFire21()
    {
        Fire(12, true);
    }
    
    private void OnFire23()
    {
        Fire(13, true);
    }
    
    private void OnFire24()
    {
        Fire(14, true);
    }

    private void Fire(int turretIndex, bool isWhiteKey)
    {
        float cooldown = cooldowns[turretIndex];

        if (cooldown > 0)
        {
            return;
        }
        
        // Reset countdown.
        cooldowns[turretIndex] = cooldownSeconds;

        // SFX
        audioSource.clip = shootSounds[turretIndex];
        audioSource.Play();
        
        // Display indicator.
        Transform cooldownIndicator = cooldownIndicators[turretIndex];
        cooldownIndicator.localScale = defaultLocalScale;
        cooldownIndicator.localPosition = defaultLocalPosition;
        
        // Instantiate bullet.
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<MeshRenderer>().material = isWhiteKey ? whiteMaterial : blackMaterial;
        bullet.transform.position = turrets[turretIndex].position;
    }
}