
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impactEffect;

    public int contTarget = 0;
    public Text countText;

    //public ParticleSystem muzzleFlash; 
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           easyTarget easTarget = hit.transform.GetComponent<easyTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);
                if (target.health == 0)
                {
                    this.contTarget++;
                    countText.text = "Targets Destroyed: " + contTarget.ToString();
                }
            }

            if (easTarget != null)
            {
                easTarget.TakeDamage(damage);
                this.contTarget++;
                countText.text = "Targets Destroyed: " + contTarget.ToString();
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Targets Destroyed: " + contTarget.ToString();
    }
}
