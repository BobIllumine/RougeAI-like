using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Fireball : Action, IEffect, IProjectile, ITarget, IStateDependent, ITransient
{
    protected Dictionary<string, Func<object, object>> _statChangeMapping;
    // ITransient
    public float duration { get; protected set; }
    // IStateDependent
    public BaseState state { get; protected set; }
    // IEffect
    public int maxHP_d { get; protected set; }
    public float maxHP_mult { get; protected set; }
    public int curHP_d { get; protected set; }
    public float curHP_mult { get; protected set; }
    public int AD_d { get; protected set; }
    public float AD_mult { get; protected set; }
    public float MS_d { get; protected set; }
    public float MS_mult { get; protected set; }
    public float AS_d { get; protected set; }
    public float AS_mult { get; protected set; }
    public float CR_d { get; protected set; }
    public float CR_mult { get; protected set; }
    public Status newStatus { get; protected set; }
    public Dictionary<PropertyInfo, object> GetModifiedStats(BaseState state)
    {
        string[] statsArr = {"HP"};
        List<string> statChange = new List<string>(statsArr);
        Dictionary<PropertyInfo, object> stats = new Dictionary<PropertyInfo, object>();
        foreach(string stat in statChange)
        {
            PropertyInfo prop = state.GetType().GetProperty(stat);
            stats.Add(prop, _statChangeMapping[stat](prop.GetValue(state)));   
        }
        return stats;
    }
    // IProjectile
    public GameObject projectile { get; protected set; }
    // ITarget
    public BaseAnimResolver targetAnimResolver { get; protected set; }
    public ActionStatus targetStatus { get; protected set; }
    // Action
    public override void Fire(float cr)
    {
        if(!isAvailable)
            return;
        this.cr = cr;
        GameObject fireball = Instantiate(projectile, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.Euler(0, 0, -90));
        fireball.transform.SetParent(transform);
        FireballProjectile fball_proj = fireball.GetComponent<FireballProjectile>();
        fball_proj.Initialize(Vector2.right * animResolver.faceTowards, Vector2.right * animResolver.faceTowards * 1000 * Time.fixedDeltaTime);
        StartCoroutine(StartCooldown(cr));
    }
    public override void UseOnState(BaseState state, float cr)
    {
        state.ApplyTimedChanges(GetModifiedStats(state), duration);
    }
    public void OnHit(Collider2D other)
    {
        print("hello");
        if(other.gameObject.GetComponent<BaseState>() != null)
        {
            targetAnimResolver = other.gameObject.GetComponent<BaseAnimResolver>();
            targetAnimResolver.AnimateTrigger(targetStatus);
            UseOnState(other.gameObject.GetComponent<BaseState>(), cr);
        }
    }
    void Start() 
    {
        curHP_d = 0;
        curHP_mult = 1f;
        maxHP_d = 0;
        maxHP_mult = 1f;
        AD_d = 0;
        AD_mult = 1f;
        MS_d = 0f;
        MS_mult = 1f;
        AS_d = 0f;
        AS_mult = 1f;
        CR_d = 0f;
        CR_mult = 1f;
        newStatus = Status.STUNNED;
        status = ActionStatus.ATTACK;
        targetStatus = ActionStatus.HURT;
        cooldown = 3;
        isAvailable = true;
        projectile = Resources.Load<GameObject>("Prefabs/Projectiles/Fireball");
    }
    void Update() {
        curHP_d = -(int)(state.AD * 0.2f) - 10;
    }
    public Fireball Initialize(BaseAnimResolver animResolver, BaseState state) 
    {
        this.animResolver = animResolver;
        this.state = state;
        curHP_d = -(int)(state.AD * 0.2f) - 10;
        print(curHP_d);
        _statChangeMapping = new Dictionary<string, Func<object, object>>() {
            ["MaxHP"] = max_hp => (int)(maxHP_mult * (int)max_hp + maxHP_d),
            ["HP"] = hp => (int)(curHP_mult * (int)hp + curHP_d),
            ["AD"] = ad => (int)(AD_mult * (int)ad + AD_d),
            ["MS"] = ms => (float)(MS_mult * (float)ms + MS_d),
            ["AS"] = @as => (float)(AS_mult * (float)@as + AS_d),
            ["CR"] = cr => (float)(CR_mult * (float)cr + CR_d)
        };
        return this;
    }
}
