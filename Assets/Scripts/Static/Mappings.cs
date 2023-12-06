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
    };
    public static Dictionary<ActionStatus, string> EnemyTriggers = new Dictionary<ActionStatus, string>() {
        [ActionStatus.ATTACK] = "draculaAttack",
        [ActionStatus.HURT] = "draculaHurt"
    };

    public static Dictionary<ProjectileStatus, string> ProjectileTriggers = new Dictionary<ProjectileStatus, string>() {
        [ProjectileStatus.CAST] = "cast",
        [ProjectileStatus.HIT] = "hit"
    };
    public static Dictionary<Button, KeyCode> DefaultInputMap = new Dictionary<Button, KeyCode>() {
        [Button.DEFAULT_ATTACK] = KeyCode.J,
        [Button.SKILL_1] = KeyCode.L,
        [Button.SKILL_2] = KeyCode.Alpha2,
        [Button.SKILL_3] = KeyCode.Alpha3,
        [Button.SKILL_4] = KeyCode.Alpha4,
        [Button.JUMP] = KeyCode.Space
    };
}
