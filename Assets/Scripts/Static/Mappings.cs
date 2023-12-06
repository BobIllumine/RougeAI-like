using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mappings
{
    public static Dictionary<ActionStatus, string> PlayerTriggers = new Dictionary<ActionStatus, string>() {
        [ActionStatus.ATTACK] = "playerAttack1",
        [ActionStatus.DIE] = "playerDeath",
        [ActionStatus.HURT] = "playerTakeHit"
    };
    public static Dictionary<ActionStatus, string> PlayerBools = new Dictionary<ActionStatus, string>() {
        [ActionStatus.RUN] = "playerRun",
        [ActionStatus.FALL] = "playerFall",
        [ActionStatus.JUMP] = "playerJump",
    };
    public static Dictionary<ActionStatus, string> EnemyBools = new Dictionary<ActionStatus, string>() {
        [ActionStatus.RUN] = "draculaRun",
        [ActionStatus.JUMP] = "draculaJump",
        [ActionStatus.FALL] = "draculaFall"
    };
    public static Dictionary<ActionStatus, string> EnemyTriggers = new Dictionary<ActionStatus, string>() {
        [ActionStatus.ATTACK] = "draculaAttack",
        [ActionStatus.HURT] = "draculaHurt",
        [ActionStatus.DIE] = "draculaDeath"
    };

    public static Dictionary<ProjectileStatus, string> ProjectileTriggers = new Dictionary<ProjectileStatus, string>() {
        [ProjectileStatus.CAST] = "cast",
        [ProjectileStatus.HIT] = "hit"
    };
    public static Dictionary<Button, KeyCode> DefaultInputMapP1 = new Dictionary<Button, KeyCode>() {
        [Button.DEFAULT_ATTACK] = KeyCode.K,
        [Button.SKILL_1] = KeyCode.I,
        [Button.SKILL_2] = KeyCode.J,
        [Button.SKILL_3] = KeyCode.L,
        [Button.SKILL_4] = KeyCode.O,
        [Button.JUMP] = KeyCode.Space
    };
    public static Dictionary<Button, KeyCode> DefaultInputMapP2 = new Dictionary<Button, KeyCode>() {
        [Button.DEFAULT_ATTACK] = KeyCode.Keypad5,
        [Button.SKILL_1] = KeyCode.Keypad4,
        [Button.SKILL_2] = KeyCode.Keypad8,
        [Button.SKILL_3] = KeyCode.Keypad6,
        [Button.SKILL_4] = KeyCode.Keypad2,
        [Button.JUMP] = KeyCode.Keypad0
    };
}
