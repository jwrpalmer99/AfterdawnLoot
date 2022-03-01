using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterdawnLoot
{
    public class SearchLootComponent : ComponentBase, IHandle<RefreshScores>
    {
        [Inject]
        private IEventAggregator _eventAggregator { get; set; }
        public bool recalc = false;

        public async Task RefreshScoresAsync()
        {
            try
            {
                await _eventAggregator.PublishAsync(new RefreshScores());
            }
            catch { }
        }

        public Task HandleAsync(RefreshScores message)
        {
            recalc = true;
            InvokeAsync(() => StateHasChanged());
            return Task.CompletedTask;
        }
    }

}
