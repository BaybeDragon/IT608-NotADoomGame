using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public int ammo = 10;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.7f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    private Animator anim;
    EnemyHealth health;
    



    // Use this for initialization
    void Start()
    {
	void Start () {
        anim = GetComponent<Animator>();
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && ammo > 0)
        {
            ammo--;
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                if (hit.collider.tag == "Enemy")
                {
                    health = hit.collider.GetComponent<EnemyHealth>();
                    if (health != null)
                    {
                        anim.SetTrigger("knifeStab");
                        health.Damage(gunDamage);
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        //laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

    private void GunRecoil()
    private void gunRecoil()
    {

        
    }

}
