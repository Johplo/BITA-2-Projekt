using Unity.Netcode;
using UnityEngine;

public class Nethealth : NetworkBehaviour 
{
    #region Johannes
    //eigene Werte Speichern
    public int maxhealth = 5;
    public int curhealth;

    public GameObject DamageParticle;
    public GameObject HealParticel;

    public override void OnNetworkSpawn() {
        //UI für andere erstellen und Host nach UI fragen.
    }

    private void Start() {
        curhealth = maxhealth;
    }

    public void Damaga(int dmg) {
        GameObject temp = Instantiate(DamageParticle);
        temp.transform.position = transform.position;
        temp.GetComponent<ParticleSystem>().Play(); 
        Destroy(temp, .6f);
        curhealth -= dmg;
        if (curhealth <= 0) {
            //Die
        }
    }

    public void Heal(int heal) {
        GameObject temp = Instantiate(HealParticel);
        temp.transform.position = transform.position;
        temp.GetComponent<ParticleSystem>().Play();
        Destroy(temp, .6f);
        curhealth += heal;
        if (curhealth > maxhealth) {
            curhealth = maxhealth;
        }
    }

    public void Biggermax(int add) {
        maxhealth += add;
    }
    #endregion
}
