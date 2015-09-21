using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.InitDatabase("turnsol.arvixe.com","BluffinMuffin_Logger_Test","1ti3gre2","BluffinMuffin_Logs_Test");

            var server = new Server("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0));
            server.RegisterServer();

            var client1 = new Client("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0), "127.0.0.1");
            client1.RegisterClient();

            var c1 = new Command("CheckCompatibilityCommand", server,client1, "{  \"CommandName\": \"CheckCompatibilityCommand\",  \"ImplementedProtocolVersion\": \"2.0.0\"}");
            c1.RegisterLobbyCommandFromClient();

            var c1R = new Command("CheckCompatibilityResponse", server,client1, "{  \"CommandName\": \"CheckCompatibilityResponse\",  \"Success\": true,  \"MessageId\": \"None\",  \"Message\": \"\",  \"ImplementedProtocolVersion\": \"2.0.0\",  \"SupportedLobbyTypes\": [    \"QuickMode\",    \"RegisteredMode\"  ],  \"AvailableGames\": [    {      \"GameType\": \"CommunityCardsPoker\",      \"AvailableVariants\": [        \"TexasHoldem\",        \"OmahaHoldem\",        \"CrazyPineapple\"      ],      \"AvailableLimits\": [        \"NoLimit\",        \"FixedLimit\",        \"PotLimit\"      ],      \"AvailableBlinds\": [        \"Blinds\", \"Antes\", \"None\"      ],      \"MinPlayers\": 2,      \"MaxPlayers\": 10    }  ],  \"Command\": {    \"CommandName\": \"CheckCompatibilityCommand\",    \"ImplementedProtocolVersion\": \"2.0.0\"  }}");
            c1R.RegisterLobbyCommandFromServer();

            var client2 = new Client("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0), "127.0.0.1");
            client2.RegisterClient();
            client2.Identify("SpongeBob");

            var c2 = new Command("CheckCompatibilityCommand", server, client2, "{  \"CommandName\": \"CheckCompatibilityCommand\",  \"ImplementedProtocolVersion\": \"2.0.0\"}");
            c2.RegisterLobbyCommandFromClient();

            var c2R = new Command("CheckCompatibilityResponse", server, client2, "{  \"CommandName\": \"CheckCompatibilityResponse\",  \"Success\": true,  \"MessageId\": \"None\",  \"Message\": \"\",  \"ImplementedProtocolVersion\": \"2.0.0\",  \"SupportedLobbyTypes\": [    \"QuickMode\",    \"RegisteredMode\"  ],  \"AvailableGames\": [    {      \"GameType\": \"CommunityCardsPoker\",      \"AvailableVariants\": [        \"TexasHoldem\",        \"OmahaHoldem\",        \"CrazyPineapple\"      ],      \"AvailableLimits\": [        \"NoLimit\",        \"FixedLimit\",        \"PotLimit\"      ],      \"AvailableBlinds\": [        \"Blinds\", \"Antes\", \"None\"      ],      \"MinPlayers\": 2,      \"MaxPlayers\": 10    }  ],  \"Command\": {    \"CommandName\": \"CheckCompatibilityCommand\",    \"ImplementedProtocolVersion\": \"2.0.0\"  }}");
            c2R.RegisterLobbyCommandFromServer();

            var table = new Table("Bikini Bottom", GameSubTypeEnum.TexasHoldem, 2,10,BlindTypeEnum.Blinds, LobbyTypeEnum.QuickMode, LimitTypeEnum.NoLimit, server);
            table.RegisterTable();

        }
    }
}
