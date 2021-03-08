using System;
using Newtonsoft;
using ChessController;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ServerConnector
{
    public class Connection
    {
        HubConnection hubConnection;
        public delegate void RecieveMoveArgs(Connection sender, Move move);
        public delegate void ConnectionArgs(Connection sender, string gameID);
        public event RecieveMoveArgs RecievedMove;
        public event ConnectionArgs GameConnected;

        public Connection(Uri connectionURI)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(connectionURI).Build();
            hubConnection.On<string>("Connected", (gameID) => Connected(gameID));
            hubConnection.On<string>("RecieveMove", (move) => RecieveMove(move));
            hubConnection.StartAsync();
        }

        public void Connect(string gameID)
        {
            hubConnection.SendAsync("Connect", gameID);
        }
        public void CreateGame()
        {
            hubConnection.SendAsync("CreateGame");
        }

        public void Connected(string gameID)
        {
            GameConnected?.Invoke(this, gameID);
        }

        public void Move(string gameID, Move move)
        {
            string moveJson = JsonConvert.SerializeObject(move, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            hubConnection.SendAsync("Move", gameID, moveJson);
        }

        public void RecieveMove(string moveJson)
        {
            Move move = JsonConvert.DeserializeObject<Move>(moveJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            RecievedMove?.Invoke(this, move);
        }
    }
}
