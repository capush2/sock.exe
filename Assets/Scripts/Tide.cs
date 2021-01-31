using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : WeaponTool
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float throwForce = 20f;
    private float expRadius = 10f;

    private Collider col;
    [SerializeField] private float expDelay = 3;

    public void Start()
    {
        col = GetComponent<Collider>();
    }
    public override bool Use(RaycastHit hit)
    {
        Ray ray = transform.parent.GetComponentInParent<Camera>().ScreenPointToRay(Input.mousePosition);

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.AddForce(ray.direction * throwForce, ForceMode.VelocityChange);
        transform.parent = null;
        Used = true;
        StartCoroutine("Explode");

        return true;
    }

    public override void Equip()
    {
        base.Equip();
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(expDelay);
        ParticleSystem exp = Instantiate(explosion, transform.position, Quaternion.identity);

        exp.Play();
        for(int i = 0; i < 10; i++)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, expRadius, 1 << 10);
            foreach (Collider col in cols)
            {
                col.GetComponent<LivingThing>().OnTideHit();
            }
            yield return new WaitForSeconds(0.2f);
        }
        
        Destroy(this.gameObject);
        Destroy(exp, 10);
        yield return null;
    }
}
