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
}
