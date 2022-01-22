using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<Transform> turrets;
    
    private void OnFire0()
    {
        Debug.Log("Fire 0");
        Fire(0);
    }

    private void OnFire1()
    {
        Debug.Log("Fire 1");
        Fire(1);
    }
    
    private void OnFire2()
    {
        Debug.Log("Fire 2");
        Fire(2);
    }
    
    private void OnFire3()
    {
        Debug.Log("Fire 3");
        Fire(3);
    }
    
    private void OnFire4()
    {
        Debug.Log("Fire 4");
        Fire(4);
    }
    
    private void OnFire5()
    {
        Debug.Log("Fire 5");
        Fire(5);
    }
    
    private void OnFire6()
    {
        Debug.Log("Fire 6");
        Fire(6);
    }
    
    private void OnFire7()
    {
        Debug.Log("Fire 7");
        Fire(7);
    }
    
    private void OnFire8()
    {
        Debug.Log("Fire 8");
        Fire(8);
    }
    
    private void OnFire9()
    {
        Debug.Log("Fire 9");
        Fire(9);
    }
    
    private void OnFire10()
    {
        Debug.Log("Fire 10");
        Fire(10);
    }
    
    private void OnFire11()
    {
        Debug.Log("Fire 11");
        Fire(11);
    }
    
    private void OnFire12()
    {
        Debug.Log("Fire 12");
        Fire(12);
    }
    
    private void OnFire13()
    {
        Debug.Log("Fire 13");
        Fire(13);
    }
    
    private void OnFire14()
    {
        Debug.Log("Fire 14");
        Fire(14);
    }
    
    private void OnFire15()
    {
        Debug.Log("Fire 15");
        Fire(15);
    }
    
    private void OnFire16()
    {
        Debug.Log("Fire 16");
        Fire(16);
    }
    
    private void OnFire17()
    {
        Debug.Log("Fire 17");
        Fire(17);
    }
    
    private void OnFire18()
    {
        Debug.Log("Fire 18");
        Fire(18);
    }
    
    private void OnFire19()
    {
        Debug.Log("Fire 19");
        Fire(19);
    }
    
    private void OnFire20()
    {
        Debug.Log("Fire 20");
        Fire(20);
    }
    
    private void OnFire21()
    {
        Debug.Log("Fire 21");
        Fire(21);
    }
    
    private void OnFire22()
    {
        Debug.Log("Fire 22");
        Fire(22);
    }
    
    private void OnFire23()
    {
        Debug.Log("Fire 23");
        Fire(23);
    }
    
    private void OnFire24()
    {
        Debug.Log("Fire 24");
        Fire(24);
    }
    
    private void Fire(int turretIndex)
    {
        Transform turret = turrets[turretIndex];
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = turret.position;
    }
}