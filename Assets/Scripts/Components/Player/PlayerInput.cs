using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerInput : BaseInput
{
    private Dictionary<Button, KeyCode> buttons;
    private List<string> skillList;
    void Start()
    {
        actionController = GetComponent<PlayerActionController>();
        movementController = GetComponent<PlayerMovementController>();
        buttons = Mappings.DefaultInputMap;
        skillList = new List<string>();
    }
    void Update()
    {
        if(Input.GetKeyDown(buttons[Button.JUMP]))
            movementController.Jump();
        
        if(Input.GetKeyDown(buttons[Button.DEFAULT_ATTACK]))
            actionController.Do("defaultAttack");
        
        
        movementController.Move(Input.GetAxis("Horizontal"));
    }
    public void AddSkill(string name, Action action) 
    {
        actionController.AddAction(name, action);
        skillList.Add(name);
    }
}
