using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BolterMove2 : M_State
{
    M_Bolter bolter;
    public M_BolterMove2(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Bolter bolter) : base(@base, stateMachine, aniboolname)
    {
        this.bolter = bolter;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
