using System;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess.Demo
{
    class Program
    {
        static void Main()
        {
            Database.InitDatabase("turnsol.arvixe.com","BluffinMuffin_Logger_Test","1ti3gre2","BluffinMuffin_Logs_Test");

            var server = new Server("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0));
            server.RegisterServer();

            var client1 = new Client("127.0.0.1");
            client1.RegisterClient();
            client1.SetAdditionalInformation("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0));

            Command.RegisterLobbyCommandFromClient("CheckCompatibilityCommand", server, client1, "{  \"CommandName\": \"CheckCompatibilityCommand\",  \"ImplementedProtocolVersion\": \"2.0.0\"}");
            Command.RegisterLobbyCommandFromServer("CheckCompatibilityResponse", server, client1, "{  \"CommandName\": \"CheckCompatibilityResponse\",  \"Success\": true,  \"MessageId\": \"None\",  \"Message\": \"\",  \"ImplementedProtocolVersion\": \"2.0.0\",  \"SupportedLobbyTypes\": [    \"QuickMode\",    \"RegisteredMode\"  ],  \"AvailableGames\": [    {      \"GameType\": \"CommunityCardsPoker\",      \"AvailableVariants\": [        \"TexasHoldem\",        \"OmahaHoldem\",        \"CrazyPineapple\"      ],      \"AvailableLimits\": [        \"NoLimit\",        \"FixedLimit\",        \"PotLimit\"      ],      \"AvailableBlinds\": [        \"Blinds\", \"Antes\", \"None\"      ],      \"MinPlayers\": 2,      \"MaxPlayers\": 10    }  ],  \"Command\": {    \"CommandName\": \"CheckCompatibilityCommand\",    \"ImplementedProtocolVersion\": \"2.0.0\"  }}");

            var client2 = new Client("127.0.0.1");
            client2.RegisterClient();
            client2.Identify("SpongeBob");

            Command.RegisterLobbyCommandFromClient("CheckCompatibilityCommand", server, client2, "{  \"CommandName\": \"CheckCompatibilityCommand\",  \"ImplementedProtocolVersion\": \"2.0.0\"}");
            Command.RegisterLobbyCommandFromServer("CheckCompatibilityResponse", server, client2, "{  \"CommandName\": \"CheckCompatibilityResponse\",  \"Success\": true,  \"MessageId\": \"None\",  \"Message\": \"\",  \"ImplementedProtocolVersion\": \"2.0.0\",  \"SupportedLobbyTypes\": [    \"QuickMode\",    \"RegisteredMode\"  ],  \"AvailableGames\": [    {      \"GameType\": \"CommunityCardsPoker\",      \"AvailableVariants\": [        \"TexasHoldem\",        \"OmahaHoldem\",        \"CrazyPineapple\"      ],      \"AvailableLimits\": [        \"NoLimit\",        \"FixedLimit\",        \"PotLimit\"      ],      \"AvailableBlinds\": [        \"Blinds\", \"Antes\", \"None\"      ],      \"MinPlayers\": 2,      \"MaxPlayers\": 10    }  ],  \"Command\": {    \"CommandName\": \"CheckCompatibilityCommand\",    \"ImplementedProtocolVersion\": \"2.0.0\"  }}");

            var table = new Table("Bikini Bottom", GameSubTypeEnum.TexasHoldem, 2,10,BlindTypeEnum.Blinds, LobbyTypeEnum.QuickMode, LimitTypeEnum.NoLimit, server);
            table.RegisterTable();

            var game = new Game(table);
            game.RegisterGame();

            Command.RegisterGameCommandFromServer("GameEndedCommand", game,client2, "{  \"CommandName\": \"GameEndedCommand\",  \"TableId\": 42}");
        }
    }
}
