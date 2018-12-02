using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Interactable {

    public GameObject woodPiecesParticlesPrefab;

    public override void Die()
    {
        StaticFenceSound.fenceAudio.PlayWoodExplosion(transform.position);
        GameObject _woodPiecesParticlesRef = Instantiate(woodPiecesParticlesPrefab, transform.position+Vector3.up*1.7f, Quaternion.identity);
        Destroy(_woodPiecesParticlesRef, 1);
        base.Die();
    }
}
