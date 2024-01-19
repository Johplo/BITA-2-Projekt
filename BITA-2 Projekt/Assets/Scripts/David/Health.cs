using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region david
    public int maxHealth = 5;
    public float currentHealth;
    public GameObject DamageParticle;
    public GameObject HealParticel;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //Erstellt einen Effekt, wenn der Spieler Schaden bekommt
        GameObject particle = GameObject.Instantiate(DamageParticle);
        particle.transform.position = transform.position;
        particle.GetComponent<ParticleSystem>().Play();

        Destroy(particle, .6f);
        if (currentHealth <= 0) 
        {
            //Tod
            Destroy(this.gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (GameObject.Find("Infos").GetComponent<ItemInfo>().getHealamount() > 0)
        {
            currentHealth += amount;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    #endregion
}
