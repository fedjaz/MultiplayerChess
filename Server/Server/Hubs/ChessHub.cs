using Microsoft.AspNetCore.SignalR;
using ChessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Hubs
{
    public class ChessHub : Hub
    {
        Services.ChessService ChessService;

        public ChessHub(Services.ChessService chessService)
        {
            ChessService = chessService;
        }

        public async Task CreateGame()
        {
            string gameID = ChessService.CreateGame(Context.ConnectionId);
            await Clients.Caller.SendAsync("Connected", gameID);
        }

        public async Task SendMessage(string gameID, string message)
        {
            string connectionID = ChessService.FindOpponent(gameID, Context.ConnectionId);
            await Clients.Client(connectionID).SendAsync("ReceiveMessage", $"Rival: {message}\n");
        }

        public async Task Connect(string gameID)
        {
            ChessService.AddGuest(gameID, Context.ConnectionId);
            await Clients.Caller.SendAsync("Connected", gameID);
        }

        public async Task Move(string gameID, string moveJson)
        {
            Move move = JsonConvert.DeserializeObject<Move>(moveJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            if(ChessService.CheckMove(gameID, Context.ConnectionId, move))
            {
                string recieverID = ChessService.Move(gameID, move);
                moveJson = JsonConvert.SerializeObject(move, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                await Clients.Clients(recieverID).SendAsync("ReceiveMove", moveJson);
            }
        }

    }
}
