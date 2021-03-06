using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : Weapon {
    private float missileSpeed = 10f;

    public override void Attack() {
        List<GameObject> fireballObjs = new List<GameObject>();
        Vector3 pos = playerStats.transform.position;
        pos.y += 1;
        fireballObjs.Add(Instantiate(projectile, pos, playerStats.transform.rotation));
        if (inventory.WeaponMod != null)
            inventory.WeaponMod.modProjectiles(fireballObjs);
        foreach (GameObject fireballObj in fireballObjs) {
            FireballController fireballController = fireballObj.GetComponent<FireballController>();
            fireballController.playerStats = playerStats;
            fireballController.Speed = missileSpeed * playerStats.projectileSpeedMultiplier;
            fireballController.Lifetime = playerStats.range / fireballController.Speed;
        }
    }

    public override string GetDescription() {
        return "A medium ranged projectile Weapon";
    }
}
