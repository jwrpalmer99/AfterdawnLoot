using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterdawnLoot
{
    public class CounterListenerComponent : ComponentBase, IHandle<CounterIncreasedMessage>
    {

        public int currentCount = 0;

        public Task HandleAsync(CounterIncreasedMessage message)
        {
            currentCount += 1;
            return Task.CompletedTask;
        }
    }

}
