// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.14.0

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantBot.Bots
{
    public class RestaurantBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var replyText = string.Empty;

            switch (turnContext.Activity.Text)
            {
                case "Menu":
                    replyText = "Chicken Pizza" + System.Environment.NewLine + "Peproni Pizza";
                    break;
                case "Address":
                    replyText = "1000, Bellevue, WA; 425-000-000";
                    break;
                case "Order":
                    replyText = "Coming soon!";
                    break;
                default:
                    replyText = "Please select one of the above option!";
                    break;
            }
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome to the Garu's resurant. " + System.Environment.NewLine +
                              "Please type Menu to see the food we serve. " + System.Environment.NewLine +
                              "Type Address to get our location and contact number." + System.Environment.NewLine +
                              "Type Order to place a order";

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
