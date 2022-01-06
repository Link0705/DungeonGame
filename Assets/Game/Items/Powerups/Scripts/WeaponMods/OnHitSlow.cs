using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitSlow : WeaponMod {
    public override void modProjectiles(List<GameObject> projectiles) {
        foreach (GameObject p in projectiles) {
            p.GetComponent<Projectile>().SetOnHitEffect(inventory.GetComponent<PlayerStats>().luck, 1, SlowEffect);
        }
    }

    public void SlowEffect(GameObject target) {
        IEnumerator coroutine = SlowEffectRoutine(target);
        StartCoroutine(coroutine);
    }

    public IEnumerator SlowEffectRoutine(GameObject target) {
        yield return new WaitForSeconds(0);
        // slow target
        yield return new WaitForSeconds(1);
        // remove slow
    }

    public override string GetDescription() {
        return "Adds Slow Effect to your Weapon that is triggered by your luck.\n"
                + "Slows Enemy by 25% for 1 Second";
    }
}
