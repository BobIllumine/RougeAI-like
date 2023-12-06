using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.UI;

public class EnemyState : BaseState
{
    [SerializeField] private int defaultMaxHP = 100;
    [SerializeField] private int defaultHP = 100;
    [SerializeField] private int defaultAD = 10;
    [SerializeField] private float defaultMS = 400.0f;
    [SerializeField] private float defaultAS = 1.0f;
    [SerializeField] private float defaultCR = 0.0f;
    [SerializeField] private Status defaultStatus = Status.OK;

    [SerializeField] public GameObject deathScreen;

    public override void ApplyChange((PropertyInfo, object) stat)
    {
        PropertyInfo prop = stat.Item1;
        object value = stat.Item2;
        prop.SetValue(this, value);
    }

    public override void ApplyChanges(Dictionary<PropertyInfo, object> other)
    {
        foreach (KeyValuePair<PropertyInfo, object> pair in other)
        {
            PropertyInfo prop = pair.Key;
            object value = pair.Value;
            prop.SetValue(this, value);
            print($"other: {value}");
        }
    }

    public override void ApplyTimedChanges(Dictionary<PropertyInfo, object> other, float duration)
    {
        Dictionary<PropertyInfo, object> copy = new Dictionary<PropertyInfo, object>();
        foreach (PropertyInfo prop in GetBaseProperties())
            copy.Add(prop, prop.GetValue(this));
        ApplyChanges(other);
        StartCoroutine(TimedRevert(copy, duration));
    }

    protected override void Update()
    {
        base.Update();
        animResolver.ChangeFloat(AS, "attackSpeed");
    }

    public override void DestroyOnDeath()
    {
        deathScreen.SetActive(true);
        deathScreen.transform.Find("PlayerAWin").gameObject.SetActive(true);
        base.DestroyOnDeath();
    }


    void Awake()
    {
        movementController = GetComponent<EnemyMovementController>();
        actionController = GetComponent<EnemyActionController>();
        animResolver = GetComponent<EnemyAnimResolver>();
        MaxHP = defaultMaxHP;
        HP = defaultHP;
        AD = defaultAD;
        MS = defaultMS;
        AS = defaultAS;
        CR = defaultCR;
        status = defaultStatus;
    }
}
