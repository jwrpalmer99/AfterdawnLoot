using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterdawnLoot
{
    public class ManageLootComponent : ComponentBase
    {
        [Inject]
        private IEventAggregator _eventAggregator { get; set; }

        public async Task RefreshScoresAsync()
        {
            await _eventAggregator.PublishAsync(new RefreshScores());
        }
    }

}
