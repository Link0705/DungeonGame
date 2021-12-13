using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigProjectile : WeaponMod {
    public override void modProjectiles(List<GameObject> projectiles) {
        foreach (GameObject p in projectiles) {
            p.GetComponent<Collider>().transform.localScale *= 1.5f;
            p.transform.localScale *= 1.5f;
        }
    }
}
