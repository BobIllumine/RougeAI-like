using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballProjectile : BaseProjectile
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animResolver = GetComponent<ProjectileAnimResolver>();
        animResolver.AnimateTrigger(ProjectileStatus.CAST);
    }
    void FixedUpdate() {
        body.velocity = velocity;    
    }
    void OnCollisionEnter2D(Collision2D other) {
        animResolver.AnimateTrigger(ProjectileStatus.HIT);
        if(other.gameObject.CompareTag("Enemy")) {
            SendMessageUpwards("OnHit", other);
        }
    }
    void DestroyOnHit() {
        Destroy(gameObject);
    }
    public override BaseProjectile Initialize(Vector2 direction, Vector2 velocity)
    {
        this.direction = direction;
        this.velocity = velocity;
        return this;
    }

}
