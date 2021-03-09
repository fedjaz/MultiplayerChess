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
        public delegate void ReceiveMoveArgs(Connection sender, Move move);
        public delegate void ConnectionArgs(Connection sender, string gameID);
        public delegate void MessageArgs(Connection sender, string message);
        public event ReceiveMoveArgs ReceivedMove;
        public event MessageArgs ReceivedMessage;
        public event ConnectionArgs GameConnected;

        public Connection(Uri connectionURI)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(connectionURI).Build();
            hubConnection.On<string>("Connected", (gameID) => Connected(gameID));
            hubConnection.On<string>("ReceiveMove", (move) => ReceiveMove(move));
            hubConnection.On<string>("ReceiveMessage", (message) => ReceiveMessage(message));
            hubConnection.StartAsync();
        }

        void ReceiveMessage(string message)
        {
            ReceivedMessage?.Invoke(this, message);
        }

        public void SendMessage(string gameID, string message)
        {
            hubConnection.SendAsync("SendMessage", gameID, message);
        }

        public void Connect(string gameID)
        {
            hubConnection.SendAsync("Connect", gameID);
        }
        public void CreateGame()
        {
            hubConnection.SendAsync("CreateGame");
        }

        void Connected(string gameID)
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

        void ReceiveMove(string moveJson)
        {
            Move move = JsonConvert.DeserializeObject<Move>(moveJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ReceivedMove?.Invoke(this, move);
        }
    }
}
