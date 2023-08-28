using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_DiverBackDead2 : M_State
{
    M_Diver diver;
    public M_DiverBackDead2(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Diver diver) : base(@base, stateMachine, aniboolname)
    {
        this.diver = diver;
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
        diver.SetVelocity(diver.zero);
    }
}
