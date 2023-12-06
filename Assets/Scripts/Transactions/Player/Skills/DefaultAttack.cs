using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DefaultAttack : Action, IEffect, ITarget, IStateDependent
{
    public BaseState state { get; protected set; }
    protected Dictionary<string, Func<object, object>> _statChangeMapping;
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
    // ITarget
    public BaseAnimResolver targetAnimResolver { get; protected set; }
    public ActionStatus targetStatus { get; protected set; }
    // Action
    public override void Fire(float cr)
    {
        this.cr = cr;
        animResolver.AnimateTrigger(status);
    }
    public override void UseOnState(BaseState state, float cr)
    {
        state.ApplyChanges(GetModifiedStats(state));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
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
        newStatus = Status.OK;
        status = ActionStatus.ATTACK;
        targetStatus = ActionStatus.HURT;
    }
    void Update() 
    {
        curHP_d = -state.AD;
    }
    public DefaultAttack Initialize(BaseAnimResolver animResolver, BaseState state) 
    {
        this.animResolver = animResolver;
        this.state = state;
        curHP_d = -state.AD;
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
