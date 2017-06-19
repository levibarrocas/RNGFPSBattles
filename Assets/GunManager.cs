using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    [SerializeField]
    Transform ShootingOrigin;

    [SerializeField]
    int Damage;

    [SerializeField]
    GameObject[] Projectile;
    [SerializeField]
    float RPM;
    float Cooldown;
    
    public int Ammo;
    [SerializeField]
    int MaxAmmo;
    int ReserveAmmo;

    [SerializeField]
    float BulletSpeed;

    [SerializeField]
    float ReloadTime;
    float ReloadCooldown;

    [SerializeField]
    int ReloadState;

    [SerializeField]
    AudioClip ReloadIn;
    [SerializeField]
    AudioClip ReloadOut;
    [SerializeField]
    AudioClip ShootingSound;

    [SerializeField]
    bool Scope;

    bool Scoped;

    Camera PlayerCam;

    [SerializeField]
    GameObject ScopeImage;

    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        PlayerCam = GetComponentInChildren<Camera>();
        Ammo = MaxAmmo;
    }

    void Shoot(int ProjectileID,float Speed)
    {
            GameObject GO = Instantiate(Projectile[ProjectileID], ShootingOrigin.position, ShootingOrigin.rotation);
            GO.GetComponent<Rigidbody>().velocity = GO.transform.forward * Speed;
            GO.GetComponent<Bullet>().Damage = Damage;
            AS.PlayOneShot(ShootingSound, Random.Range(0.9f, 1.1f));
            Ammo--;
   }

    private void Update()
    {
        Cooldown += Time.deltaTime;
        Scoping();
        ReloadCycle();
        if (ReloadState == 0)
        {
            if (RPM < Cooldown)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (Ammo > 0)
                    {
                        Shoot(0, BulletSpeed);
                        Cooldown = 0;
                    }
                }
            }
        }


    }

    void Scoping()
    {
        if (Scope)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("Fire2 pressed with Scope true");
                if (!Scoped)
                {
                    PlayerCam.fieldOfView = 20;
                    ScopeImage.SetActive(true);
                    Scoped = true;
                }
                else
                {
                    PlayerCam.fieldOfView = 60;
                    ScopeImage.SetActive(false);
                    Scoped = false;
                }
            }
        } else
        {
            PlayerCam.fieldOfView = 60;
            ScopeImage.SetActive(false);
        }
    }

    void ReloadCycle()
    {
        if (ReloadState == 0)
        {
            if (Input.GetKeyDown("r"))
            {
                AS.PlayOneShot(ReloadOut);
                ReloadState = 1;
            }
        }
        if (ReloadState == 1)
        {
            ReloadCooldown += Time.deltaTime;
            if (ReloadCooldown > ReloadTime)
            {
                Reload();
                AS.PlayOneShot(ReloadIn);
                ReloadState = 0;
                ReloadCooldown = 0;
            }
        }
    }

    void Reload()
    {
        Ammo = MaxAmmo;
    }


}
