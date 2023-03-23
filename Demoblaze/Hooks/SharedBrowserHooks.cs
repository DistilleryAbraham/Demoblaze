using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Demoblaze.Hooks
{
    [Binding]
    public sealed class SharedBrowserHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            testThreadContainer.BaseContainer.Resolve<InitialHooks>();
        }
    }
}
