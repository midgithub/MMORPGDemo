using System;
using System.Collections.Generic;
using XFramework.Event;
using XFramework.Fsm;
using XFramework.Network;
using XFramework.Procedure;

namespace UnityGameFramework.Runtime
{
    internal static class AvoidJIT
    {
        private static void NeverCalledMethod()
        {
            new Dictionary<int, EventHandler<GameEventArgs>>();
            new Dictionary<int, EventHandler<Packet>>();
            new Dictionary<int, FsmEventHandler<IProcedureManager>>();
        }
    }
}
